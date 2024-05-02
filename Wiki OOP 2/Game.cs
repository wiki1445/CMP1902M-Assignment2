using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// A template for creating games.
public abstract class Game
{
    protected Die die;

    public Game(Die die)
    {

        this.die = die;

    }

    public abstract void Play();
}