using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShopManegement.App.Slide;

namespace _01_CarDealerShipQuery.Contracts.Slide
{
    public interface ISlideQuery
    {
        List<SlideQueryModel> GetSlides();
    }
}
