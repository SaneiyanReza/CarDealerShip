using _0_Framework.App;
using ShopManegement.App.Vehicle;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegement.App.VehiclePicture
{
    public class CreateVehiclePicture
    {
        [Range(1,100000 , ErrorMessage = Validations.IsRequired)]
        public int VehicleID { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string Picture { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string PictureAlt { get; set; }
        public List<VehicleViewModel> Vehicles { get; set; }
    }
}
