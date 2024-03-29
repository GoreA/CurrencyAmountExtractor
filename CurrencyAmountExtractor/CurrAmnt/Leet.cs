﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CurrencyAmountExtractor.CurrAmnt
{
    public class Leet
    {
        /// <summary>
        /// Scans the document from given path to extract Leet pairs.
        /// </summary>
        /// <param name="path">the path of document from which can be taken Leet. For more details please visit https://en.wikipedia.org/wiki/Leet </param>
        /// <returns>a dictionary that contains letters as key values and possible digits to replace</returns>
        public static Dictionary<string, string> GetLetterDigitDictionary(string path)
        {
            Dictionary<string, string> leetDictionary = new Dictionary<string, string>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Regex kRegex = new Regex(".=");
                    Match kMatch = kRegex.Match(line);
                    string key = kMatch.Value.TrimEnd('=');
                    Regex valueRegex = new Regex("=.");
                    Match valueMatch = valueRegex.Match(line);
                    string value = valueMatch.Value.TrimStart('=');
                    if (leetDictionary.ContainsKey(key))
                    {
                        leetDictionary[key] = value;
                    }
                    else
                    {
                        leetDictionary.Add(key, value);
                    }
                }
            }
            return leetDictionary;
        }
    }
}
