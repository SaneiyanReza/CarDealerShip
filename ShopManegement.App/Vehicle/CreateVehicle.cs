using _0_Framework.App;
using ShopManegement.App.VehicleCategories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegement.App.Vehicle
{
    public class CreateVehicle
    {
        [Required(ErrorMessage = Validations.IsRequired)]
        public string Name { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string Model { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        [Range(0,999999 ,ErrorMessage = Validations.CorrectValues)]
        public double CarFunction { get; set; } = 0;

        [Required(ErrorMessage = Validations.IsRequired)]
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string Slug { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string Keyword { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string MetaDescription { get; set; }

        [Range(1, 100000, ErrorMessage = Validations.IsRequired)]
        public int CategoryID { get; set; }
        public List<VehicleCategoryViewModel> Categories { get; set; }
    }
}
