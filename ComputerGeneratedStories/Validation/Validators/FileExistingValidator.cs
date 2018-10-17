using System.IO;
using ComputerGeneratedStories.Validation.Interfaces;

namespace ComputerGeneratedStories.Validation.Validators
{
    public class FileExistingValidator : ISimpleValidation
    {
        public bool IsValid(string path)
        {
            return File.Exists(path);
        }
    }
}