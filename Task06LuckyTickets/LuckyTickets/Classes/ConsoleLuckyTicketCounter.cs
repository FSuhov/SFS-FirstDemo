// <copyright file="ConsoleLuckyTicketCounter.cs" company="Oleksandr Brylov">
// Copyright (c) Oleksandr Brylov. Task 06, LuckyTickets.
// </copyright>

namespace LuckyTickets
{
    using System;
    using System.IO;

    /// <summary> Represents a class for interaction with user via console. </summary>
    internal class ConsoleLuckyTicketCounter
    {
        private LuckyTicketCounter ticketCounter;

        private LuckyTicketsConfig.Status status;

        /// <summary>
        /// Implements interaction with user via console input-output:
        /// Prints user manual at launch;
        /// Promts user to enter required data;
        /// Prints the result or error messages/advises;
        /// Asks user to continue or not.
        /// </summary>
        public void Run()
        {
            Console.WriteLine(LuckyTicketsConfig.USER_MANUAL);
            do
            {
                this.GetUserInput();
                this.ShowResult();
            }
            while (this.IsWantToContinue());
            Console.WriteLine(LuckyTicketsConfig.GOODBUY_MESSAGE);
        }

        private void GetUserInput()
        {
            Console.WriteLine(LuckyTicketsConfig.USER_INPUT_PROMPT);
            string userInput = Console.ReadLine();
            string[] args = userInput.Split(' ');
            this.SetStatus(args);
        }

        private void SetStatus(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    this.status = LuckyTicketsConfig.Status.NoArgs;
                    break;
                case 1:
                    this.status = this.InitLuckyTicket(args[0]);
                    break;
                case 2:
                    this.status = this.InitLuckyTicket(args[0], args[1]);
                    break;
                default:
                    this.status = LuckyTicketsConfig.Status.InvalidArgs;
                    break;
            }
        }

        private void ShowResult()
        {
            Console.Clear();
            if (this.status == LuckyTicketsConfig.Status.Success)
            {
                int result = 0;
                try
                {
                    result = this.ticketCounter.CountNumberOfLuckyTickets();
                    Console.WriteLine(LuckyTicketsConfig.DELIMITER);
                    Console.WriteLine("There are {0} lucky tickets possible using {1} ", result, this.ticketCounter.ToString());
                    Console.WriteLine(LuckyTicketsConfig.DELIMITER);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("There was an error accessing one of tickets.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                switch (this.status)
                {
                    case LuckyTicketsConfig.Status.NoArgs:
                        Console.ResetColor();
                        Console.WriteLine(LuckyTicketsConfig.USER_MANUAL);
                        break;
                    case LuckyTicketsConfig.Status.InvalidPath:
                        Console.Error.WriteLine("Unable to locate file");
                        Console.ResetColor();
                        Console.WriteLine(LuckyTicketsConfig.ERROR_ADVISE_INVALID_PATH);
                        break;
                    case LuckyTicketsConfig.Status.InvalidFileContent:
                        Console.Error.WriteLine("Unable to idetnify the algorythm (wrong data in the file)");
                        Console.ResetColor();
                        Console.WriteLine(LuckyTicketsConfig.ERROR_ADVISE_INVALID_CONTENT);
                        break;
                    case LuckyTicketsConfig.Status.InvalidArgs:
                        Console.Error.WriteLine("Wrong second command line argument");
                        Console.ResetColor();
                        Console.WriteLine(LuckyTicketsConfig.ERROR_ADVISE_INVALID_ARGS);
                        break;
                    default:
                        break;
                }
            }
        }

        private string ReadFile(string path)
        {
            string result;
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    result = reader.ReadLine();
                }
            }
            catch (FileNotFoundException)
            {
                result = "File not found";
            }

            return result;
        }

        private LuckyTicketsConfig.Status InitLuckyTicket(string path)
        {
            string mode = this.ReadFile(path);

            LuckyTicketsConfig.Status status;

            switch (mode)
            {
                case "Moscow":
                    this.ticketCounter = new LuckyTicketCounter(new LuckyTicketMoscow());
                    status = LuckyTicketsConfig.Status.Success;
                    break;
                case "Piter":
                    this.ticketCounter = new LuckyTicketCounter(new LuckyTicketPeter());
                    status = LuckyTicketsConfig.Status.Success;
                    break;
                case "File not found":
                    status = LuckyTicketsConfig.Status.InvalidPath;
                    break;
                default:
                    status = LuckyTicketsConfig.Status.InvalidFileContent;
                    break;
            }

            return status;
        }

        private LuckyTicketsConfig.Status InitLuckyTicket(string path, string digits)
        {
            string mode = this.ReadFile(path);
            LuckyTicketsConfig.Status status;
            int parsedDigits = 0;

            if (mode.Equals("File not found"))
            {
                status = LuckyTicketsConfig.Status.InvalidPath;
            }
            else if (int.TryParse(digits, out parsedDigits) && this.IsValidNumberOfDigits(parsedDigits))
            {
                switch (mode)
                {
                    case "Moscow":
                        this.ticketCounter = new LuckyTicketCounter(new LuckyTicketMoscow(), parsedDigits);
                        status = LuckyTicketsConfig.Status.Success;
                        break;
                    case "Piter":
                        this.ticketCounter = new LuckyTicketCounter(new LuckyTicketPeter(), parsedDigits);
                        status = LuckyTicketsConfig.Status.Success;
                        break;
                    default:
                        status = LuckyTicketsConfig.Status.InvalidFileContent;
                        break;
                }
            }
            else
            {
                status = LuckyTicketsConfig.Status.InvalidArgs;
            }

            return status;
        }

        private bool IsWantToContinue()
        {
            Console.WriteLine(LuckyTicketsConfig.ASK_TO_CONTINUE_MESSAGE);
            string userInput = Console.ReadLine().ToLower();
            return userInput.Equals("yes") || userInput.Equals("y");
        }

        private bool IsValidNumberOfDigits(int number)
        {
            return number % 2 == 0 && number > 0 && number < 19;
        }
    }
}
