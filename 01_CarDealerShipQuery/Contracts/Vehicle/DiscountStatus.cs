using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CarDealerShipQuery.Contracts.Vehicle
{
    public class DiscountStatus
    {
        public bool IsDiscount { get; set; } = true;
        public string Specification { get; set; }
        public double DiscountRate { get; set; }
    }
}
