using System;

namespace DiscountManagement.App.CustomerDiscount
{
    public class CustomerDiscountViewModel
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public string Vehicle { get; set; }
        public double DiscountRate { get; set; }
        public string StartDate { get; set; }
        public DateTime StartDateEn { get; set; }
        public string EndDate { get; set; }
        public DateTime EndDateEn { get; set; }
        public string Reason { get; set; }
        public string CreationDate { get; set; }
    }
}
