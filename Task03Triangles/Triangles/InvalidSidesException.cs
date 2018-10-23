// <copyright file="InvalidSidesException.cs" company="Alex Brylov">
// Copyright (c) Alex Brylov. TASK 3 - TRIANGLES
// </copyright>

namespace Triangles
{
    using System;

    /// <summary>
    /// Represents a class of custom exception occuring
    /// when triangle with given sides can not exist.
    /// </summary>
    public class InvalidSidesException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSidesException"/> class.
        /// </summary>
        public InvalidSidesException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSidesException"/> class.
        /// </summary>
        /// <param name="sideA"> Length of shape side A provided by user </param>
        /// <param name="sideB"> Length of shape side B provided by user </param>
        /// <param name="sideC"> Length of shape side C provided by user </param>
        public InvalidSidesException(double sideA, double sideB, double sideC)
            : base(string.Format("Triangle with given sides {0}, {1}, {2} can not exist", sideA, sideB, sideC))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSidesException"/> class.
        /// </summary>
        /// <param name="sideA"> Length of shape side A provided by user </param>
        /// <param name="sideB"> Length of shape side B provided by user </param>
        /// <param name="sideC"> Length of shape side C provided by user </param>
        /// <param name="inner"> Inner exception.</param>
        public InvalidSidesException(double sideA, double sideB, double sideC, Exception inner)
            : base(string.Format("Triangle with given sides {0}, {1}, {2} can not exist", sideA, sideB, sideC), inner)
        {
        }
    }
}
