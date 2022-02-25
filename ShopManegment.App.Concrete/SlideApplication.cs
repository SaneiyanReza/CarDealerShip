using _0_Framework.App;
using ShopManagement.Domain.SlideAgg;
using ShopManegement.App.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegment.App.Concrete
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public OperationResult Create(CreateSlide createSlide)
        {
            var operetion = new OperationResult();
            var slid = new Slide(createSlide.Picture, createSlide.PictureTitle, createSlide.PictureAlt, createSlide.Heading
                , createSlide.Title, createSlide.Text, createSlide.BtnText);

            _slideRepository.Create(slid);
            _slideRepository.SaveChanges();

            return operetion.Succedded();
        }

        public OperationResult Edit(EditSlide editSlide)
        {
            var operetion = new OperationResult();
            var slide = _slideRepository.Get(editSlide.ID);
            if (slide == null)
            {
                return operetion.Faild(ErrorMessage.RecordNotFound);
            }

            slide.Edit(editSlide.Picture , editSlide.PictureTitle , editSlide.PictureAlt , editSlide.Heading , editSlide.Title,
                editSlide.Text , editSlide.BtnText );
            _slideRepository.SaveChanges();

            return operetion.Succedded();
        }

        public EditSlide GetDetails(int Id)
        {
            return _slideRepository.GetDetails(Id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetList();
        }

        public OperationResult Remove(int Id)
        {
            var operetion = new OperationResult();
            var slide = _slideRepository.Get(Id);
            if (slide == null)
            {
                return operetion.Faild(ErrorMessage.RecordNotFound);
            }

            slide.Remove();
            _slideRepository.SaveChanges();

            return operetion.Succedded();
        }

        public OperationResult Restore(int Id)
        {
            var operetion = new OperationResult();
            var slide = _slideRepository.Get(Id);
            if (slide == null)
            {
                return operetion.Faild(ErrorMessage.RecordNotFound);
            }

            slide.Restore();
            _slideRepository.SaveChanges();

            return operetion.Succedded();
        }
    }
}
