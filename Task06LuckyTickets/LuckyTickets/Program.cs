// <copyright file="Program.cs" company="Oleksandr Brylov">
// Copyright (c) Oleksandr Brylov. Task 06, LuckyTickets.
// </copyright>

namespace LuckyTickets
{
    /// <summary> Contains an entry point of the application. </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConsoleLuckyTicketCounter ticketCounter = new ConsoleLuckyTicketCounter();
            ticketCounter.Run();
        }
    }
}
