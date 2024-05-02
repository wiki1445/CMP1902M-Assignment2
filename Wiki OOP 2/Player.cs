using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    // This is the name of the player.
    public string Name { get; }
    // This indicates if the player is an AI.
    public bool IsComputer { get; }

    public Player(string name, bool isComputer = false)
    {

        Name = name;
        IsComputer = isComputer;

    }
}