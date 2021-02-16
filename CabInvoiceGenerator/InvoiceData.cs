using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceData
    {
        public int noOfRides;
        public double totalFare;
        public double averageFare;

        public InvoiceData(int noOfRides, double totalFare, double averageFare)
        {
            this.noOfRides = noOfRides;
            this.totalFare = totalFare;
            this.averageFare = averageFare;
        }
    }
}
