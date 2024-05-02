using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ThreeOrMoreGame : Game
{
    private int total;
    private int score;
    private List<int> diceValues;
    private List<Player> players;
    private int currentPlayerIndex;

    public ThreeOrMoreGame(Die die, List<Player> players) : base(die)
    {

        // The total score.
        total = 0;
        // The current score.
        score = 0;
        diceValues = new List<int>();
        this.players = players;
        currentPlayerIndex = 0;

    }

    public override void Play()
    {
        // This will check if the user has chosen to play against a computer.
        bool player1IsComputer = players[0].IsComputer;

        // This will let the game continue until someone reaches 20 points.
        while (total < 20)
        {

            Console.WriteLine($"{players[currentPlayerIndex].Name}'s turn: ");
            // This will clear the numbers once the turn is over.
            diceValues.Clear();

            // This will roll 5 dice.
            for (int i = 0; i < 5; i++)
            {

                // This will add the numbers that are rolled to the list.
                diceValues.Add(die.Roll());

            }

            Console.WriteLine("Dice rolled: " + string.Join(", ", diceValues));

            // This will check for any combinations that may have been rolled.
            int[] counts = new int[7];
            foreach (int value in diceValues)
            {

                counts[value]++;

            }

            // This will check for any 2-of-a-kind that may have been rolled.
            bool hasTwoOfAKind = false;
            int valueOfTwoOfAKind = 0;

            for (int i = 1; i <= 6; i++)
            {

                if (counts[i] == 2)
                {

                    hasTwoOfAKind = true;
                    valueOfTwoOfAKind = i;
                    break;

                }

            }

            // If any 2-of-a-kind have been rolled this will take care of it.
            if (hasTwoOfAKind)
            {

                Console.WriteLine($"You rolled a 2-of-a-kind of {valueOfTwoOfAKind}.");

                // If player 1 is a computer it will reroll automatically.
                if (player1IsComputer && currentPlayerIndex == 0)
                {

                    Console.WriteLine("Rerolling all dice...");
                    continue;

                }
                // If the player isn't a computer then it will allow the player to choose one of these options.
                else
                {

                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Reroll all dice");
                    Console.WriteLine("2. Reroll remaining dice");

                    // This will read the player's choice.
                    string input = Console.ReadLine();

                    switch (input)
                    {

                        // If the player has chosen the first option it will reroll all the dice.
                        case "1":
                            Console.WriteLine("Rerolling all dice...");
                            diceValues.Clear();
                            for (int i = 0; i < 5; i++)
                            {
                                diceValues.Add(die.Roll());
                            }
                            break;

                        // If the player has chosen the second option it will reroll only the remaining dice that weren't part of a 2-of-a-kind.
                        case "2":
                            Console.WriteLine("Rerolling remaining dice...");
                            for (int i = 0; i < diceValues.Count; i++)
                            {
                                if (diceValues[i] != valueOfTwoOfAKind)
                                {
                                    diceValues[i] = die.Roll();
                                }
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid input, rerolling all dice.");
                            diceValues.Clear();
                            for (int i = 0; i < 5; i++)
                            {
                                diceValues.Add(die.Roll());
                            }
                            break;

                    }
                }
            }

            // This will calculate the scores depending on how many/if there were any combinations.
            score = CalculateScore(counts);

            // This will keep updating the total score.
            total += score;

            Console.WriteLine($"Score: {score}");
            Console.WriteLine($"Total Score: {total}");

            // This will keep checking if anyone has won yet by getting 20 or more.
            // If someone did get 20 or more, it will let them know that they have won.
            if (total >= 20)
            {

                Console.WriteLine($"{players[currentPlayerIndex].Name} has won.");
                return;

            }

            // This will switch to the next player.
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
        }
    }

    // This will calculate the score depending on the combinations that the players get.
    private int CalculateScore(int[] counts)
    {

        int score = 0;

        // This will check for 3-of-a-kind, 4-of-a-kind, or 5-of-a-kind. 
        for (int i = 1; i <= 6; i++)
        {

            if (counts[i] == 3)
            {

                score += 3;

            }
            else if (counts[i] == 4)
            {

                score += 6;

            }
            else if (counts[i] == 5)
            {

                score += 12;

            }
        }

        return score;

    }
}