using System.Collections.Generic;

namespace ComputerGeneratedStories.Persistense.Interfaces
{
    public interface IRepository
    {
        List<string> GetSentences();
    }
}