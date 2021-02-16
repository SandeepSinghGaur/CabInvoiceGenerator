using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
   public class MultipleRide
    {
        public int time;
        public double distance;
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleRide"/> class.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        public MultipleRide(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
