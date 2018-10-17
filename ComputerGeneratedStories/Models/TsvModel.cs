using CsvHelper.Configuration.Attributes;

namespace ComputerGeneratedStories.Models
{
    public class TsvModel
    {
        [Name("Analyst Name")] [Index(0)] public string AnalystName { get; set; }

        [Name("Analyst Firm")] [Index(1)] public string AnalystFirm { get; set; }

        [Name("Company")] [Index(2)] public string Company { get; set; }

        [Name("Previous Rating")] [Index(3)] public string PreviousRating { get; set; }

        [Name("Rating")] [Index(4)] public string Rating { get; set; }

        [Name("Target")] [Index(5)] public string Target { get; set; }

        [Name("Current price")] [Index(6)] public string CurrentPrice { get; set; }
    }
}