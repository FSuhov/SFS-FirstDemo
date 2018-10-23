// <copyright file="LuckyTicketCounter.cs" company="Oleksandr Brylov">
// Copyright (c) Oleksandr Brylov. Task 06, LuckyTickets.
// </copyright>

namespace LuckyTickets
{
    using System;
    using System.Text;

    /// <summary>
    /// Represents an object which can count the possible number of lucky tickets.
    /// </summary>
    public class LuckyTicketCounter
    {
        private ulong maxNumber;
        private int digits;

        private ILuckyTicketIdentifier ticketIdentifier;

        /// <summary>
        /// Initializes a new instance of the <see cref="LuckyTicketCounter"/> class.
        /// </summary>
        /// <param name="ticketIdentifier"> An instance of object that implements ILuckyTicketIdentifier interface. </param>
        /// <param name="digits"> A number of digits in the ticket. </param>
        public LuckyTicketCounter(ILuckyTicketIdentifier ticketIdentifier, int digits = LuckyTicketsConfig.DEFAULT_DIGITS)
        {
            this.ticketIdentifier = ticketIdentifier;
            this.maxNumber = this.GetMaxNumber(digits);
            this.digits = digits;
        }

        /// <summary>
        /// Checks and returns the possible number of lucky tickets.
        /// </summary>
        /// <returns> Possible number of lucky tickets. </returns>
        public int CountNumberOfLuckyTickets()
        {
            int counter = 0;
            for (ulong i = LuckyTicketsConfig.MIN_SERIAL_NUMBER; i <= this.maxNumber; i++)
            {
                if (this.ticketIdentifier.IsLuckyTicket(new Ticket(i, this.digits)))
                {
                    counter++;
                }
            }

            return counter;
        }

        /// <summary>
        /// Creates an informative string about the range of possible tickets serial numbers
        /// </summary>
        /// <returns> A string containing minimal and maximum possible serial number </returns>
        public override string ToString()
        {
            string min = LuckyTicketsConfig.MIN_SERIAL_NUMBER.ToString("D" + this.digits.ToString());
            return string.Format("{0} within the range of {1} and {2}", this.ticketIdentifier.ToString(), min,  this.maxNumber);
        }

        private ulong GetMaxNumber(int digits)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < digits; i++)
            {
                result.Append(LuckyTicketsConfig.MAX_VALUE);
            }

            return ulong.Parse(result.ToString());
        }
    }
}
