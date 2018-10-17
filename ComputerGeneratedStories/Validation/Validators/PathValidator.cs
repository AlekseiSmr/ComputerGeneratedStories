using ComputerGeneratedStories.Validation.Interfaces;

namespace ComputerGeneratedStories.Validation.Validators
{
    public class PathValidator : ISimpleValidation
    {
        public bool IsValid(string path)
        {
            return !string.IsNullOrWhiteSpace(path);
        }
    }
}