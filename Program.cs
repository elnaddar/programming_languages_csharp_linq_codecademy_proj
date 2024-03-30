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


            /*
                3. When was C# first released?
                   Find the language(s) with the name "C#". Use the Prettify() method to print the results to the console.

                   Note: As you write more of these LINQ queries and print the results, your console output might get too long to read. We suggest you comment out the print statements of the previous query before writing the next one.
            */
            var csLang = from l in languages
                         where l.Name == "C#"
                         select l.Prettify();

            foreach (var lang in csLang)
                Console.WriteLine(lang);


            /*
                4. Microsoft invented a bunch of languages, not just C#!
                   Find all of the languages which have "Microsoft" included in their ChiefDeveloper property.
            */
            var msLangs = languages
                          .Where(l => l.ChiefDeveloper.Contains("Microsoft"))
                          .Select(l => l.Name);

            Console.WriteLine($"Microsoft invented {msLangs.Count()} languages.");
            foreach (var lang in msLangs)
                Console.WriteLine(lang);


            /*
                5. A few early languages laid the foundation for many of the advanced
                   languages we use now. One of those languages is Lisp, which looks like
                   this:  
                   ``` styles_pre__Vzth4
                   ;;; Here's a comment
                   (print "Hello world")
                   (+ 3 4)
                   (let x 29)
                   ```
                   Find all of the languages that descend from Lisp.

            */
            var lispLangs = from l in languages
                            where l.Predecessors.Contains("Lisp")
                            select l.Name;

            Console.WriteLine($"\nThere are {msLangs.Count()} languages that descend from Lisp.");
            foreach (var lang in lispLangs)
                Console.Write(lang + ", ");
            Console.WriteLine();


            /*
                6. Programmers really like to call their languages “scripts”.
                   Find all of the language names that contain the word "Script" (capital S).
                   Make sure the query only selects the name of each language.
            */
            var scriptLangs = from l in languages
                              where l.Name.Contains("Script")
                              select l.Name;

            Console.WriteLine($"\nThere are {scriptLangs.Count()} languages that have Script in their name.");
            foreach (var lang in scriptLangs)
                Console.Write(lang + ", ");
            Console.WriteLine();


            /*
                7. How many languages are included in the languages list?
            */
            Console.WriteLine($"\nThere are {languages.Count} in `languages` list.");
        }
    }
}
