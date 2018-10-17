using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ComputerGeneratedStories.Parser.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;

namespace ComputerGeneratedStories.Parser
{
    public class TsvParser<T> : ITsvParser<T>
    {
        public IEnumerable<T> Parse(string path)
        {
            using (var fileReader = File.OpenText(path))
            {
                var csvReader = new CsvReader(fileReader, new Configuration
                {
                    HasHeaderRecord = true,
                    Encoding = Encoding.UTF8,
                    Delimiter = "\t",
                    IgnoreBlankLines = true, // Seems to be unhelpful
                    TrimOptions = TrimOptions.Trim
                });

                return csvReader.GetRecords<T>().ToList();
            }
        }
    }
}