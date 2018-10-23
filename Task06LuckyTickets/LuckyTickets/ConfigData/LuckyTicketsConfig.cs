// <copyright file="LuckyTicketsConfig.cs" company="Oleksandr Brylov">
// Copyright (c) Oleksandr Brylov. Task 06, LuckyTickets.
// </copyright>

namespace LuckyTickets
{
    using System;

    /// <summary> Contains a static members to be used during interaction with user. </summary>
    public class LuckyTicketsConfig
    {
        /// <summary> A decarated frame to be printed via console around results output </summary>
        public const string DELIMITER = "+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++";

        /// <summary> Default number of digits in ticket serial number </summary>
        public const int DEFAULT_DIGITS = 6;

        /// <summary> Max single digit that can be used in the ticket serial number </summary>
        public const char MAX_VALUE = '9';

        /// <summary> Minimal available number, i.e. we start to count from ticket 000 001 </summary>
        public const int MIN_SERIAL_NUMBER = 1;

        /// <summary> A user manual to be shown on the console </summary>
        public static readonly string USER_MANUAL = string.Format(
                                                    "=========================================================================================================={0}"
                                                  + "This application counts lucky tickets{0}"
                                                  + "There are two algorythms:{0}"
                                                  + "Moscow - ticket is lucky if sum of left half of digits equals to right half{0}"
                                                  + "Piter - if sum of even digits is equal to odd digits.{0}"
                                                  + "==========================================================================================================",
                                                    Environment.NewLine);

        public static readonly string USER_INPUT_PROMPT = string.Format(
                                                    "Please enter the path to the file containing alrgorythm name{0}"
                                                  + "and (optionally) - quantity of digits in ticket number.",
                                                    Environment.NewLine);

        /// <summary> An advise to be shown when no arguments been provided. </summary>
        public static readonly string ERROR_ADVISE_NO_ARGS = "You shell enter the path to file containing algorythm name, for example \"input.txt\"";

        /// <summary> An advise to be shown when invalid arguments been provided. </summary>
        public static readonly string ERROR_ADVISE_INVALID_ARGS = string.Format(
                                                                  "Please check the arguments you entered. There is one required (path to file with algorythm){0}"
                                                                + "and one optional (number of digits).{0}"
                                                                + "Number of digits must be even, positive and less than 19.",
                                                                  Environment.NewLine);

        /// <summary> An advise to be shown when file has not been found. </summary>
        public static readonly string ERROR_ADVISE_INVALID_PATH = "Please check the path to file";

        /// <summary> An advise to be shown when file does not contain valid alrgorythm name. </summary>
        public static readonly string ERROR_ADVISE_INVALID_CONTENT = "Please check the algorythm in the file. It should be either Moscow or Piter (case sensitive)";

        /// <summary> The message prompting user to continue or stop the application </summary>
        public static readonly string ASK_TO_CONTINUE_MESSAGE = "Would you like to continue? => yes or y";

        /// <summary> The message to be printed on stop of application </summary>
        public static readonly string GOODBUY_MESSAGE = "Thank you for using our application...";

        /// <summary> The result of validation of user input. </summary>
        public enum Status
        {
            /// <summary> When user did not provided any arguments. </summary>
            NoArgs,

            /// <summary> When invalid arguments have been submitted. </summary>
            InvalidArgs,

            /// <summary> User submitted path to not existing file. </summary>
            InvalidPath,

            /// <summary> When file does not contain valid alrgorythm name. </summary>
            InvalidFileContent,

            /// <summary> Correct arguments provided. </summary>
            Success
        }
    }
}
