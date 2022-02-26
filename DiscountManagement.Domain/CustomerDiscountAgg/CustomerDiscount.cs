using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public class CustomerDiscount : BaseEntity
    {
        public int VehicleID { get; private set; }
        public double DiscountRate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Reason { get; private set; }
        public CustomerDiscount(int vehicleID, double discountRate, DateTime startDate, DateTime endDate, string reason)
        {
            VehicleID = vehicleID;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }

        public void Edit(int vehicleID, double discountRate, DateTime startDate, DateTime endDate, string reason)
        {
            VehicleID = vehicleID;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }
    }
}
