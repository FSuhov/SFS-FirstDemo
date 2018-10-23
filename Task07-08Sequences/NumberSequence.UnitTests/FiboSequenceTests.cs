using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberSequence.BusineessLogicClasses;

namespace NumberSequence.UnitTests
{
    [TestClass]
    public class FiboSequenceTests
    {
        [TestMethod]
        [DataRow(45, 150, new int[] { 55,89,144 })]
        [DataRow(45, 1, new int[] {})]
        [DataRow(1000000000, 2147483647, new int[] { 1134903170, 1836311903 })]
        public void GetSequence_WhenCalledReturns_IEnumerableSequence(int start, int limit, int[] expected)
        {
            // Arrange
            FiboSequence fiboSequence = new FiboSequence(start,limit);

            // Act
            int[] actual = fiboSequence.GetSequence().ToArray();
            bool areEqual = actual.SequenceEqual(expected);

            // Assert
            Assert.IsTrue(areEqual);
        }
    }
}
