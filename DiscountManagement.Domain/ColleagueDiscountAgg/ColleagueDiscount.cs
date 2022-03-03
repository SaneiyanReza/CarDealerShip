using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public class ColleagueDiscount : BaseEntity<int>
    {
        public int VehicleID { get; private set; }
        public double DiscountRate { get; private set; }
        public bool IsRemoved { get; private set; }

        public ColleagueDiscount(int vehicleID, double discountRate)
        {
            VehicleID = vehicleID;
            DiscountRate = discountRate;
            IsRemoved = false;
        }

        public void Edit(int vehicleID, double discountRate)
        {
            VehicleID = vehicleID;
            DiscountRate = discountRate;
        }
        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
