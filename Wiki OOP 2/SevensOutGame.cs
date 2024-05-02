using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SevensOutGame : Game
{
    private int score;
    private List<Player> players;
    private int currentPlayerIndex;

    public SevensOutGame(Die die, List<Player> players) : base(die)
    {

        // Makes sure the score starts off at 0.
        score = 0;
        this.players = players;
        currentPlayerIndex = 0;

    }

    // Starts playing the game.
    public override void Play()
    {
        while (true)
        {

            // Checks in case there are no players in the game. 
            // If there are no players in the game it will exit automatically.
            if (players.Count == 0)
            {

                Console.WriteLine("Exiting, no players in the game.");
                return;

            }

            Player currentPlayer = players[currentPlayerIndex];
            // This show's which player's turn it is.
            Console.WriteLine($"{currentPlayer.Name}'s turn:");

            // This will roll the two dice and calculate the total.
            int roll1 = die.Roll();
            int roll2 = die.Roll();
            int sum = roll1 + roll2;

            // This shows which numbers have been rolled.
            Console.WriteLine($"Rolled: {roll1}, {roll2}, Total: {sum}");

            // This checks if the total is 7.
            // If it is a 7 it will notify the players that a total of 7 has been reached.
            if (sum == 7)
            {

                Console.WriteLine("Total reached 7");
                return;

            }

            else
            {

                // This checks if it is a double.
                // If it is, it adds double the total to the score.
                // It will then give a message saying that a double has been rolled.
                if (roll1 == roll2)
                {

                    score += sum * 2; 
                    Console.WriteLine($"Double rolled. Scored {sum * 2}");

                }

                else
                {

                    // Add the total to the score.
                    score += sum;
                    Console.WriteLine($"Current total: {score}");

                }
            }

            // Move to the next player.
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;

        }
    }

    // Method to simulate die rolls for testing.
    // It will print out the simulated rolls.
    public void SimulateDieRolls(int roll1, int roll2)
    {

        Console.WriteLine($"Simulated Die Rolls: {roll1}, {roll2}");

    }
}