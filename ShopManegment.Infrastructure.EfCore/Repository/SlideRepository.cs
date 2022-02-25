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
                Text = x.Text,
                Heading = x.Heading,
                BtnText = x.BtnText               
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
                IsDeleted = x.IsDeleted,
                CreationDate =x.CreationDate,
            }).OrderByDescending(x => x.ID).ToList();
        }
    }
}
