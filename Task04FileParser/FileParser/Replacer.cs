// <copyright file="Replacer.cs" company="Oleksandr Brylov">
// Copyright (c) Oleksandr Brylov. Task 4 - File Parser
// </copyright>

namespace FileParser
{
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Implementing the logic of parsing:
    /// Contains method that find entries and replace it with another string.
    /// Contains fields required for that method.
    /// </summary>
    public class Replacer : IFileParser
    {
        private string path;
        private string find;
        private string replacement;

        /// <summary>
        /// Initializes a new instance of the <see cref="Replacer"/> class.
        /// </summary>
        /// <param name="path"> Path to the file to parse. </param>
        /// <param name="find"> String to find in the file. </param>
        /// <param name="replace"> String to be replaced on. </param>
        public Replacer(string path, string find, string replace)
        {
            this.path = path;
            this.find = find;
            this.replacement = replace;
        }

        /// <summary>
        /// Replaces all entries of the string in the source file.
        /// Creates temporary file in order to store the edited data.
        /// Replaces original file with the temporary file if entries found.
        /// Deletes temporary file after complition.
        /// Throws FailedToReplaceFileException if failed to replace original file.
        /// Throws FailedToDeleteTempFileException if failed to remove temporary file.
        /// </summary>
        /// <returns> Total number of entries replaced. </returns>
        public int ParseFile()
        {
            int entryCount = 0;
            string tempFileName = Path.GetDirectoryName(this.path) + "\\" + Path.GetRandomFileName() + ".txt";

            using (StreamWriter output = new StreamWriter(tempFileName))
            {
                using (StreamReader reader = new StreamReader(this.path))
                {
                    StringBuilder line;
                    while (!reader.EndOfStream)
                    {
                        line = new StringBuilder(reader.ReadLine());
                        entryCount += this.ReplaceEntriesInString(line);
                        output.WriteLine(line);
                    }
                }
            }

            if (entryCount > 0)
            {
                try
                {
                    File.Replace(tempFileName, this.path, null);
                }
                catch
                {
                    throw new FailedToReplaceFileException(this.path);
                }
            }
            else
            {
                try
                {
                    File.Delete(tempFileName);
                }
                catch
                {
                    throw new FailedToDeleteTempFileException(tempFileName);
                }
            }

            return entryCount;
        }

        private int ReplaceEntriesInString(StringBuilder text)
        {
            MatchCollection matches = Regex.Matches(text.ToString(), this.find);

            if (matches.Count > 0)
            {
                text.Replace(this.find, this.replacement);
            }

            return matches.Count;
        }
    }
}
