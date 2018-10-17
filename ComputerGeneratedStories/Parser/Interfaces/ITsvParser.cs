using System.Collections.Generic;

namespace ComputerGeneratedStories.Parser.Interfaces
{
    public interface ITsvParser<out T>
    {
        IEnumerable<T> Parse(string path);
    }
}