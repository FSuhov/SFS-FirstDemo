using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Envelopes.UnitTests
{
    [TestClass]
    public class EnvelopeTests
    {
        [TestMethod]
        [DataRow(8, 6, 10, 6, 0, DisplayName = ConfigEnvelopes.NON_CAN_BE_PLACED)]
        [DataRow(8, 6, 7, 5, 1, DisplayName = ConfigEnvelopes.SECOND_CAN_BE_PLACED)]
        [DataRow(8, 6, 7, 10, -1, DisplayName = ConfigEnvelopes.FIRST_CAN_BE_PLACED)]
        [DataRow(8, 6, 8, 6, 0, DisplayName = ConfigEnvelopes.NON_CAN_BE_PLACED)]
        [DataRow(8.55f, 6.23f, 10.01f, 6.099f, 0, DisplayName = ConfigEnvelopes.NON_CAN_BE_PLACED)]
        [DataRow(8000354, 6000900, 7100555, 5123999, 1, DisplayName = ConfigEnvelopes.SECOND_CAN_BE_PLACED)]
        [DataRow(8999100, 6554900, 7154876, 10800399, - 1, DisplayName = ConfigEnvelopes.FIRST_CAN_BE_PLACED)]
        [DataRow(8000354.34f, 6000900.54f, 7100555.89f, 5123999f, 1, DisplayName = ConfigEnvelopes.SECOND_CAN_BE_PLACED)]
        [DataRow(8000354.34f, 6000900.54f, 9100555.89f, 5123999f, 0, DisplayName = ConfigEnvelopes.NON_CAN_BE_PLACED)]
        public void CompareTo_WhenCalled_ReturnCompareResult(float widthThis, float heightThis, float widthOther, float heightOther, int expectedResult)
        {
            // Arrange
            Envelope envelopeThis = new Envelope(widthThis, heightThis);
            Envelope envelopeOther = new Envelope(widthOther, heightOther);
            
            // Act
            var result = envelopeThis.CompareTo(envelopeOther);

            // Assert
            Assert.AreEqual(result, expectedResult);
        }
    }
}
