using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgrammingLanguages
{
    class Program
    {
        static void Main()
        {
            List<Language> languages = File.ReadAllLines("./languages.tsv")
              .Skip(1)
              .Select(line => Language.FromTsv(line))
              .ToList();

            /*
                1. Let’s start by printing all of the languages:
                   print each item in languages by calling its Prettify() method.
            */
            foreach (Language l in languages)
                Console.WriteLine(l.Prettify());

            /*
                2. Write a query that returns a string for each language. It should include the year, name, and chief developer of each language.
                   Print each one to the console.
            */
            foreach (var s in languages.Select(l => $"{l.Year}, {l.Name}, {l.ChiefDeveloper}"))
                Console.WriteLine(s);
        }
    }
}
