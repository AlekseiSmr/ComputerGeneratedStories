using ComputerGeneratedStories.Models;

namespace ComputerGeneratedStories.DataSubstitution.Interface
{
    public interface ISubstitutionService
    {
        string Substitute(string pattern, TsvModel data);
    }
}