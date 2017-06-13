using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Madlibs
{
    public class Madlib
    {
        private string format;
        private Dictionary<string, string[]> options;

        public Madlib(string format, object options)
        {
            this.format = format;
            this.options = options.GetType()
                .GetProperties()
                .ToDictionary(
                    x => x.Name,
                    x => (string[])x.GetValue(options, null)
                );
        }

        public MadlibResult Execute()
        {
            var seed = new StringBuilder();
            var result = format;
            Random random = new Random();

            foreach (var kv in options)
            {
                var choices = kv.Value;
                var index = random.Next(0, choices.Length);

                seed.Append(index);
                result = InjectSingleValue(result, kv.Key, choices[index]);
            }

            return new MadlibResult(seed.ToString(), result);
        }

        public MadlibResult Execute(string seed)
        {
            var result = format;
            var indexes = seed.Select(x => (int)char.GetNumericValue(x)).ToList();
            var count = 0;

            foreach (var kv in options)
            {
                var choices = kv.Value;
                var index = indexes[count];

                if (index > choices.Length - 1 || index < 0)
                    throw new ArgumentOutOfRangeException(nameof(seed), $"seed cannot generate valid result for {kv.Key}");

                result = InjectSingleValue(result, kv.Key, choices[index]);
                count++;
            }

            return new MadlibResult(seed, result);
        }

        /// <summary>
        /// Oskar Austegard implementation.
        /// http://mo.notono.us/2008/07/c-stringinject-format-strings-by-key.html
        /// </summary>
        private static string InjectSingleValue(string format, string key, object replacementValue)
        {
            string result = format;
            //regex replacement of key with value, where the generic key format is:
            //Regex foo = new Regex("{(foo)(?:}|(?::(.[^}]*)}))");
            Regex attributeRegex = new Regex("{(" + key + ")(?:}|(?::(.[^}]*)}))");  //for key = foo, matches {foo} and {foo:SomeFormat}

            //loop through matches, since each key may be used more than once (and with a different format string)
            foreach (Match m in attributeRegex.Matches(format))
            {
                string replacement = m.ToString();
                if (m.Groups[2].Length > 0) //matched {foo:SomeFormat}
                {
                    //do a double string.Format - first to build the proper format string, and then to format the replacement value
                    string attributeFormatString = string.Format(CultureInfo.InvariantCulture, "{{0:{0}}}", m.Groups[2]);
                    replacement = string.Format(CultureInfo.CurrentCulture, attributeFormatString, replacementValue);
                }
                else //matched {foo}
                {
                    replacement = (replacementValue ?? string.Empty).ToString();
                }
                //perform replacements, one match at a time
                result = result.Replace(m.ToString(), replacement);  //attributeRegex.Replace(result, replacement, 1);
            }
            return result;
        }

        
    }

    public class MadlibResult
    {
        public MadlibResult(string seed, string text)
        {
            this.Seed = seed;
            this.Text = text;
        }

        public string Seed { get; protected set; }
        public string Text { get; protected set; }

        public override string ToString() 
        {
            return $"Seed : {this.Seed}\nText : {this.Text}";
        }
    }
}