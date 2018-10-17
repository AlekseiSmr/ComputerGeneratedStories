namespace ComputerGeneratedStories.RandomGenerator.Interfaces
{
    public interface IRandomGenerator
    {
        int GetNext(int max);
        int GetNext(int minValue, int maxValue);
    }
}