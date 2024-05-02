using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {

        // Create instances of the Die, SevensOutGame, and Statistics classes.
        Die die = new Die();
        SevensOutGame sevensOutGame = new SevensOutGame(die, new List<Player>());
        Statistics statistics = new Statistics();

        while (true)
        {

            // This will show the user the options to choose from.
            Console.WriteLine("Please select one of these options (1/2/3/4): ");
            Console.WriteLine("1. Sevens Out game");
            Console.WriteLine("2. Three Or More game");
            Console.WriteLine("3. View Statistics");
            Console.WriteLine("4. Exit");

            // Read user input to see what they have selected.
            string? input = Console.ReadLine();

            // This will see which option the user selected and act on it.
            if (input != null)
            {

                switch (input)
                {

                    // This is the first option that the user could have selected.
                    case "1":
                        Console.WriteLine("Starting Sevens Out game...");
                        // This will create the players.
                        Player player1 = new Player("Player 1");
                        Player player2 = new Player("Player 2");
                        List<Player> players = new List<Player> { player1, player2 };
                        // This will send the user to the sevens out game.
                        sevensOutGame = new SevensOutGame(die, players);
                        PlayGame(sevensOutGame);
                        break;

                    // This is the second option that the use could have selected.
                    case "2":
                        Console.WriteLine("Starting Three Or More game...");
                        // This will create the players.
                        player1 = new Player("Player 1");
                        player2 = new Player("Player 2");
                        // This will send the user to the three or more game.
                        ThreeOrMoreGame threeOrMoreGame = new ThreeOrMoreGame(die, new List<Player> { player1, player2 });
                        PlayGame(threeOrMoreGame);
                        break;

                    // This is the third option that the user could have selected.
                    case "3":
                        Console.WriteLine("Loading Statistics...");
                        // This will show the statistics.
                        statistics.DisplayStatistics();
                        break;

                    // This is the fourth option that the user could have selected.
                    case "4":
                        Console.WriteLine("Exiting.");
                        return;
                    default:
                        // Error handling for if the user inputs something other than the options available.
                        Console.WriteLine("Invalid inputm please choose 1/2/3/4.");
                        break;

                }
            }
            else
            {

                // This will show an error for if the input is blank.
                Console.WriteLine("Error, input is blank.");

            }
        }
    }

    // This will allow the player to choose who they want to play against.
    static void PlayGame(Game game)
    {
        Console.WriteLine("Please select an opponent: ");
        Console.WriteLine("1. Play against partner");
        Console.WriteLine("2. Play against the computer");

        string? input = Console.ReadLine();

        switch (input)
        {
            // This is the first option that the user could have selected.
            case "1":
                Console.WriteLine("Playing with partner.");
                break;

            // This is the second option that the user could have selected.
            case "2":
                Console.WriteLine("Playing against the computer.");
                break;

            default:
                // This is for if the user writes in anything other than 1 or 2.
                Console.WriteLine("Invalid input, please enter 1 or 2.");
                return; 
        }

        // Starts the game.
        Console.WriteLine("Starting the game...");
        game.Play();
    }
}