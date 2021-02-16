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
            double totalFare = 0;
            foreach (MultipleRide ride in rides)
            {
                totalFare += this.CalculateFare(ride.distance, ride.time);
            }
            return totalFare;
        }
       
    }
}
