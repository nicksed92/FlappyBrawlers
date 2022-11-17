using System;

public class Utilites
{
    private static Random random = new Random();

    public static float GetRandomFloat(float min, float max)
    {
        return (float)(random.NextDouble() * (max - (double)min)) + min;
    }

    public static int GetRandomInt(int min, int max)
    {
        return random.Next(min, max + 1);
    }
}
