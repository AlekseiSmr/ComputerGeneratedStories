using System.Collections.Generic;
using ComputerGeneratedStories.DataSubstitution.Interface;
using ComputerGeneratedStories.Models;

namespace ComputerGeneratedStories.DataSubstitution
{
    public class SubstitutionService : ISubstitutionService
    {
        private static readonly Dictionary<string, string> PatternKeys = new Dictionary<string, string>
        {
            {"[Analyst Firm]", "AnalystFirm"},
            {"[Analyst Name]", "AnalystName"},
            {"[Company]", "Company"},
            {"[Previous Rating]", "PreviousRating"},
            {"[Rating]", "Rating"},
            {"[Target]", "Target"},
            {"[% from current price]%", "CurrentPrice"}
        };

        public string Substitute(string pattern, TsvModel data)
        {
            foreach (var patternKey in PatternKeys)
            {
                if (pattern.Contains(patternKey.Key))
                {
                    pattern = pattern.Replace(patternKey.Key,
                        data.GetType().GetProperty(patternKey.Value).GetValue(data).ToString());
                }
            }

            return pattern;
        }
    }
}