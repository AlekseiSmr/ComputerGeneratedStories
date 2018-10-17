using System;
using System.Collections.Generic;
using System.IO;
using ComputerGeneratedStories.DataSubstitution;
using ComputerGeneratedStories.Models;
using ComputerGeneratedStories.Parser;
using ComputerGeneratedStories.Persistense;
using ComputerGeneratedStories.Validation;
using ComputerGeneratedStories.Validation.Interfaces;
using ComputerGeneratedStories.Validation.Validators;
using Microsoft.Extensions.Configuration;

namespace ComputerGeneratedStories
{
    internal class Program
    {
        private static AppSettings _appConfig;


        private static void Main(string[] args)
        {
            // Configuring
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            _appConfig = builder.GetSection("application").Get<AppSettings>();

            Console.WriteLine("Started");
            Console.WriteLine();

            // Do work
            var businessService = new BusinessService(
                new FakeRepository(),
                new SubstitutionService(),
                new ValidationManager(new List<ISimpleValidation> {new PathValidator(), new FileExistingValidator()}),
                new TsvParser<TsvModel>(),
                new RandomGenerator.RandomGenerator(),
                _appConfig
            );

            var result = businessService.Process(_appConfig.Path);

            // Output results
            if (result.OperationSuccessful)
            {
                result.Sentences.ForEach(i =>
                {
                    Console.WriteLine("{0}", i);
                    Console.WriteLine();
                });
            }
            else
            {
                Console.WriteLine("Process failed");
            }

            Console.WriteLine("Ended");
            Console.ReadLine();
        }
    }
}