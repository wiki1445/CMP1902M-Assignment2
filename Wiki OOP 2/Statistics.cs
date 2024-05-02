using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Statistics
{
    // Dictionary used to store how many win each player has.
    private Dictionary<string, int> winsByPlayer;

    public Statistics()
    {

        winsByPlayer = new Dictionary<string, int>();

    }

    // Method used to record a win for a player.
    public void RecordWin(string playerName)
    {
        {

            winsByPlayer[playerName] = winsByPlayer.ContainsKey(playerName) ? winsByPlayer[playerName] + 1 : 1;

        }
    }

    // Method used to retrieve the number of wins for a player.
    // If the player doesn't exist it will return 0 wins.
    public int GetWinsForPlayer(string playerName)
    {
        if (winsByPlayer.ContainsKey(playerName))
        {

            return winsByPlayer[playerName];

        }
        else
        {

            return 0;

        }
    }

    // Method used to display the statistics.
    public void DisplayStatistics()
    {
        Console.WriteLine("Statistics: ");
        foreach (var kvp in winsByPlayer)
        {

            Console.WriteLine($"{kvp.Key}: {kvp.Value} wins");

        }
    }
}