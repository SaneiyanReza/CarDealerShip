using _0_Framework.App;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegement.App.Slide
{
    public class CreateSlide
    {
        public string Picture { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string Heading { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string Title { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string Text { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string BtnText { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string Link { get; set; }
    }
}
