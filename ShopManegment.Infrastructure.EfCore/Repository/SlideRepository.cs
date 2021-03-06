using _0_Framework.App;
using _0_Framework.Infrastucture;
using ShopManagement.Domain.SlideAgg;
using ShopManegement.App.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegment.Infrastructure.EfCore.Repository
{
    public class SlideRepository : RepositoryBase<int, Slide>, ISlideRepository
    {
        private readonly CarDealerShipContext _context;
        public SlideRepository(CarDealerShipContext context) : base(context)
        {
            _context = context;
        }
        public EditSlide GetDetails(int id)
        {
            return _context.Slides.Select(x => new EditSlide
            {
                ID = id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Title = x.Title,
                Text = x.Text,
                Heading = x.Heading,
                BtnText = x.BtnText,
                Link = x.Link
            }).FirstOrDefault(x => x.ID == id);
        }

        public List<SlideViewModel> GetList()
        {
            return _context.Slides.Select(x => new SlideViewModel
            {
                ID = x.ID,
                Picture = x.Picture,
                Heading = x.Heading,
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                CreationDate =x.CreationDate.ToFarsi(),
            }).OrderByDescending(x => x.ID).ToList();
        }
    }
}
