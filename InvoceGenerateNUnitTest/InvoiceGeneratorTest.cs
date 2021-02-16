using CabInvoiceGenerator;
using NUnit.Framework;

namespace InvoceGenerateNUnitTest
{
    public class InvoiceGeneratorTest
    {
        InvoiceGenerate invoiceGenerator;
        [SetUp]
        public void Setup()
        {
            invoiceGenerator = new InvoiceGenerate();
        }
        /// <summary>
        /// Givens the distance and time should calculate total fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldCalculateTotalFare()
        {
            double distance = 2.0;
            int time = 5;
            double expectedFare = 25;
            double exactFare = invoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(expectedFare, exactFare);
        }
    }
}