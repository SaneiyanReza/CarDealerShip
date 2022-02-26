using _01_CarDealerShipQuery.Contracts.Slide;
using ShopManegement.App.Slide;
using ShopManegment.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShopManagement.Domain.SlideAgg;

namespace _01_CarDealerShipQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly CarDealerShipContext _Context;

        public SlideQuery(CarDealerShipContext carDealerShipContext)
        {
            _Context = carDealerShipContext;
        }

        public  List<SlideQueryModel> GetSlides()
        {
            return _Context.Slides.Where(x => x.IsDeleted == false).Select(x => new SlideQueryModel
            {
                BtnText = x.BtnText,
                Heading = x.Heading,
                Link = x.Link,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Text = x.Text,
                Title = x.Title
            }).ToList();
            //return new SlideQueryModel
            //{
            //    BtnText = slide.BtnText,
            //    Heading = slide.Heading,
            //    Link = slide.Link,
            //    Picture = slide.Picture,
            //    PictureAlt = slide.PictureAlt,
            //    PictureTitle = slide.PictureTitle,
            //    Text = slide.Text,
            //    Title = slide.Title
            //};
        }
    }
}
