using System.Collections.Generic;
using System.Linq;
using ComputerGeneratedStories.Validation.Interfaces;

namespace ComputerGeneratedStories.Validation
{
    public class ValidationManager : IValidationManager
    {
        private readonly List<ISimpleValidation> _simpleValidations;

        public ValidationManager(
            List<ISimpleValidation> simpleValidations
        )
        {
            _simpleValidations = simpleValidations;
        }

        public bool ValidateAll(string path)
        {
            return _simpleValidations.Aggregate(true,
                (current, simpleValidation) => current & simpleValidation.IsValid(path));
        }
    }
}