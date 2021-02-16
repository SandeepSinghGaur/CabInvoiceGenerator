using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerate
    {
        public const double COST_PERKILOMETER = 10.0;
        public const int COST_PER_MINUTE = 1;
        public const double MINIMUM_FARE = 5;
        double totalFare;
        InvoiceSummary invoiceSummary = new InvoiceSummary();

        /// <summary>
        /// Calculates the fare of one ride
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        public double CalculateFare(double distance, int time)
        {
            double totalFare = distance * COST_PERKILOMETER + time * COST_PER_MINUTE;
            return Math.Max(totalFare, MINIMUM_FARE);
        }

        /// <summary>
        /// Calculates the total fare for multiple rides.
        /// </summary>
        /// <param name="rides">The rides.</param>
        /// <returns></returns>
        public double CalculateTotalFare(MultipleRide[] rides)
        {
            
            foreach (MultipleRide ride in rides)
            {
                totalFare += this.CalculateFare(ride.distance, ride.time);
            }
            return totalFare;
        }
        /// <summary>
        /// Get Enhanced Invoice
        /// </summary>
        /// <param name="rideList"></param>
        /// <returns></returns>
        public InvoiceData GetInvoiceSummary(List<MultipleRide> rideList)
        {
            double fare = CalculateFareForMultipleRides(rideList);
            InvoiceData data = invoiceSummary.GetInvoice(rideList.Count, totalFare);
            return data;
        }
        /// <summary>
        /// Calculate Fare For Multiple Rides
        /// </summary>
        /// <param name="rideList"></param>
        /// <returns></returns>
        public double CalculateFareForMultipleRides(List<MultipleRide> rideList)
        {
            this.totalFare = 0;
            foreach (var ride in rideList)
            {
                this.totalFare = totalFare + CalculateFare(ride);
            }
            return this.totalFare;
        }
        /// <summary>
        /// Calculate Fare for a single ride
        /// </summary>
        /// <param name="ride"></param>
        /// <returns></returns>
        public double CalculateFare(MultipleRide ride)
        {
            if (ride == null)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "Ride is Invalid");
            }
            if (ride.distance <= 0)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_DISTANCE, "Distance is Invalid");
            }
            if (ride.time <= 0)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_TIME, "Time is Invalid");
            }

            double fare = (ride.distance * COST_PERKILOMETER) + (ride.time * COST_PER_MINUTE);
            return Math.Max(fare, MINIMUM_FARE);
        }
    }
}
