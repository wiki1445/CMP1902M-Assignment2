using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Die
{
    // This is a random number generator.
    // It will generate a random number. 
    private Random random;
    public int FaceValue { get; private set; }

    public Die()
    {

        random = new Random();
        Roll();

    }

    public int Roll()
    {

        // This ensures the random generated number will be a number between 1 and 6. 
        FaceValue = random.Next(1, 7); 
        return FaceValue;

    }
}