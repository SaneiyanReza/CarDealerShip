using _0_Framework.App;
using ShopManegement.App.Vehicle;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.App.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        [Range(1, 100000, ErrorMessage = Validations.IsRequired)]
        public int VehicleID { get; set; }

        [Range(1, 99.99, ErrorMessage = Validations.CorrectValues)]
        [Required(ErrorMessage = Validations.IsRequired)]
        public double DiscountRate { get; set; } = 1;

        [Required(ErrorMessage = Validations.IsRequired)]
        public string StartDate { get; set; }
        
        [Required(ErrorMessage = Validations.IsRequired)]
        public string EndDate { get; set; }
        public string Reason { get; set; }
        public List<VehicleViewModel> Vehicles { get; set; }
    }
}
