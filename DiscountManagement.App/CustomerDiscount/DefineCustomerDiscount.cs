using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.App.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        public int VehicleID { get; set; }
        public double DiscountRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Reason { get; set; }
    }
}
