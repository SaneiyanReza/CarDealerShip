using _0_Framework.App;
using ShopManegement.App.Vehicle;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.App.ColleagueDiscount
{
    public class DefineColleagueDiscount
    {
        [Range(1,100000 , ErrorMessage = Validations.IsRequired)]
        public int VehicleID { get; set; }

        [Range(1, 99.99, ErrorMessage = Validations.CorrectValues)]
        [Required(ErrorMessage = Validations.IsRequired)]
        public double DiscountRate { get; set; } = 1;
        public List<VehicleViewModel> Vehicles { get; set; }
    }
}
