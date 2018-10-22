// <copyright file="Program.cs" company="Alex Brylov">
// Copyright (c) Alex Brylov. TASK 2 - ENVELOPES.
// </copyright>

namespace Envelopes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class Program contains application entry point
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConsoleEnvelopeComparator consoleComparator = new ConsoleEnvelopeComparator();
            consoleComparator.Run(args);
            Console.ReadKey();
        }
    }
}
