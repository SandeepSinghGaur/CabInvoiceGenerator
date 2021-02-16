using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CabInvoiceGenerator
{
    public class RideRepositry
    {
        public Dictionary<int, List<MultipleRide>> rideRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        public RideRepositry()
        {
            rideRepository = new Dictionary<int, List<MultipleRide>>();
        }
        /// <summary>
        /// Add rides to dictionary
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rideList"></param>
        public void Add(int userId, List<MultipleRide> rideList)
        {
            if (rideList.Any(e => e == null) || rideList == null)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "Rides are null");
            }
            if (rideRepository.ContainsKey(userId))
            {
                rideRepository[userId] = rideList;
            }
            if (rideRepository.ContainsKey(userId) == false)
            {
                rideRepository.Add(userId, rideList);
            }

        }

        /// <summary>
        /// Get rides from dictionary
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<MultipleRide> GetRides(int userId)
        {
            try
            {
                return this.rideRepository[userId];
            }
            catch (Exception)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_USER_ID, "Invalid UserID");
            }
        }
    }
}
