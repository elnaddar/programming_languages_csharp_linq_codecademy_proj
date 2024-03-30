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

            foreach (Language l in languages)
                Console.WriteLine(l.Prettify());

            foreach (var s in languages.Select(l => $"{l.Year}, {l.Name}, {l.ChiefDeveloper}"))
                Console.WriteLine(s);
        }
    }
}
