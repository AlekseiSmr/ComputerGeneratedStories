using System.Collections.Generic;
using System.Linq;
using ComputerGeneratedStories.DataSubstitution.Interface;
using ComputerGeneratedStories.Models;
using ComputerGeneratedStories.Parser.Interfaces;
using ComputerGeneratedStories.Persistense.Interfaces;
using ComputerGeneratedStories.RandomGenerator.Interfaces;
using ComputerGeneratedStories.Validation.Interfaces;

namespace ComputerGeneratedStories
{
    public class BusinessService
    {
        private readonly AppSettings _appSettings;
        private readonly IRandomGenerator _randomGenerator;
        private readonly IRepository _repository;
        private readonly ISubstitutionService _substitutionService;
        private readonly ITsvParser<TsvModel> _tsvParser;
        private readonly IValidationManager _validationManager;

        public BusinessService(
            IRepository repository,
            ISubstitutionService substitutionService,
            IValidationManager validationManager,
            ITsvParser<TsvModel> tsvParser,
            IRandomGenerator randomGenerator,
            AppSettings appSettings
        )
        {
            _repository = repository;
            _substitutionService = substitutionService;
            _validationManager = validationManager;
            _tsvParser = tsvParser;
            _randomGenerator = randomGenerator;
            _appSettings = appSettings;
        }

        /// <summary>
        ///     Main business logic process.
        /// </summary>
        /// <param name="path"> Path to file </param>
        /// <returns> Proces result </returns>
        public Result Process(string path)
        {
            var result = new Result
            {
                OperationSuccessful = false,
                Sentences = new List<string>()
            };

            if (!_validationManager.ValidateAll(path))
                return result;

            var records = _tsvParser
                .Parse(path)
                .Where(x => !string.IsNullOrWhiteSpace(x.AnalystFirm)) // Workaround, see TsvParser comments 
                .ToList();

            var allSentences = _repository.GetSentences();
            var limit = _randomGenerator.GetNext(_appSettings.MinSentences, _appSettings.MaxSentences);

            // Generate stories
            for (var i = 0; i < limit; i++)
            {
                // Works without check for uniqueness of stories and data patches
                var nextSentence = allSentences.ElementAtOrDefault(_randomGenerator.GetNext(allSentences.Count));
                var nextData = records.ElementAtOrDefault(_randomGenerator.GetNext(records.Count));

                if (!string.IsNullOrWhiteSpace(nextSentence) && nextData != null)
                {
                    result.Sentences.Add(_substitutionService.Substitute(nextSentence, records.First()));
                }
            }

            result.OperationSuccessful = true;
            return result;
        }
    }
}