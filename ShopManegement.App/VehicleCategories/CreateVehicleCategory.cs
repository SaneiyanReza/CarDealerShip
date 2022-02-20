using _0_Framework.App;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegement.App.VehicleCategories
{
    public class CreateVehicleCategory
    {
        [Required(ErrorMessage = Validations.IsRequired)]
        public string Name { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string Model { get; set; }

        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string Keyword { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string Slug { get; set; }
    }

}
