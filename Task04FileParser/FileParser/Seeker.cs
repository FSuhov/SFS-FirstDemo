// <copyright file="Seeker.cs" company="Oleksandr Brylov">
// Copyright (c) Oleksandr Brylov. Task 4 - File Parser
// </copyright>

namespace FileParser
{
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Implementing the logic of parsing:
    /// Contains method that find entries.
    /// Contains fields required for that method.
    /// </summary>
    public class Seeker : IFileParser
    {
        private string path;
        private string find;

        /// <summary>
        /// Initializes a new instance of the <see cref="Seeker"/> class.
        /// </summary>
        /// <param name="path"> Path to file to be parsed. </param>
        /// <param name="find"> String to be found. </param>
        public Seeker(string path, string find)
        {
            this.path = path;
            this.find = find;
        }

        /// <summary>
        /// Counts all entries of the specified string.
        /// Throws custom exceptions if failed to manage files.
        /// </summary>
        /// <returns> Total number of entries found. </returns>
        public int ParseFile()
        {
            int entryCount = 0;
            using (StreamReader reader = new StreamReader(this.path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    entryCount += this.CountEntriesInString(line, this.find);
                }
            }

            return entryCount;
        }

        private int CountEntriesInString(string text, string find)
        {
            MatchCollection matches = Regex.Matches(text, find);
            return matches.Count;
        }
    }
}
