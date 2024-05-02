using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Testing
{
    public void RunTests()
    {
        // This will create a Die object.
        Die die = new Die(); 

        // This will test the Sevens Out game.
        Console.WriteLine("Testing Sevens Out game: ");
        TestSevensOutGame(die);

        Player player1 = new Player("Player 1");
        Player player2 = new Player("Player 2");

        Game threeOrMoreGame = new ThreeOrMoreGame(die, new List<Player> { player1, player2 });

        // This will test the Three Or More game. 
        Console.WriteLine("\nTesting Three Or More game:");
        threeOrMoreGame.Play();
    }

    //This is to test the Sevens Out game.
    private void TestSevensOutGame(Die die)
    {

        SevensOutGame sevensOutGame = new SevensOutGame(die, new List<Player>());

        // This will test when the sum is 7.
        Debug.Assert(RollAndCheck(sevensOutGame, 4, 3) == true, "Error, sum 7 detection error.");

        // This will test when the sum is not 7.
        Debug.Assert(RollAndCheck(sevensOutGame, 2, 4) == false, "Error, sum 7 incorrectly detected.");

    }

    // This will simulate dice rolls to test it out.
    // This will check if the game stops when the total is 7.
    private bool RollAndCheck(SevensOutGame game, int roll1, int roll2)
    {

        SimulateDie(game, roll1, roll2);

        game.Play();

        return true;

    }

    private void SimulateDie(SevensOutGame game, int roll1, int roll2)
    {

        game.SimulateDieRolls(roll1, roll2);

    }
}