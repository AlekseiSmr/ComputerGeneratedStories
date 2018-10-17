using System;
using ComputerGeneratedStories.RandomGenerator.Interfaces;

namespace ComputerGeneratedStories.RandomGenerator
{
    public class RandomGenerator : IRandomGenerator
    {
        private static readonly Random Rnd = new Random();

        public int GetNext(int max)
        {
            return Rnd.Next(max);
        }

        public int GetNext(int minValue, int maxValue)
        {
            return Rnd.Next(minValue, maxValue);
        }
    }
}