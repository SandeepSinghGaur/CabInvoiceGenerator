using CabInvoiceGenerator;
using NUnit.Framework;
using System.Collections.Generic;

namespace InvoceGenerateNUnitTest
{
    public class InvoiceGeneratorTest
    {
        InvoiceGenerate invoiceGenerator;
        List<MultipleRide> rideList;
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
        /// <summary>
        /// Givens the multiple rides should return total fare.
        /// </summary>
        [Test]
        public void GivenMultipleRides_ShouldReturnTotalFare()
        {
            MultipleRide[] rides = {new MultipleRide(5.0,5),
                                    new MultipleRide(0.2,1)};

            double expectedFare = 60;
            double actualFare = invoiceGenerator.CalculateTotalFare(rides);
            Assert.AreEqual(expectedFare, actualFare);
        }
        /// <summary>
        /// Given the Multiple Ride Should Return Total fare,Total Number of Rides,Avarage Fare
        /// </summary>
        [Test]
        public void GivenListOfRides_Should_Return_EnhancedInvoice()
        {
            rideList = new List<MultipleRide> { new MultipleRide(5, 20), new MultipleRide(3, 15), new MultipleRide(2, 10) };
            double expectedFare = 145;
            int expectedRides = 3;
            double expectedAverage = expectedFare / expectedRides;
            InvoiceData data = invoiceGenerator.GetInvoiceSummary(rideList);
            Assert.IsTrue(data.noOfRides == expectedRides && data.totalFare == expectedFare && data.averageFare == expectedAverage);
        }

    }
}