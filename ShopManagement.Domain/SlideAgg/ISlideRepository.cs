using _0_Framework.Domain;
using ShopManegement.App.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.SlideAgg
{
    public interface ISlideRepository : IRepository<int , Slide>
    {
        EditSlide GetDetails(int id);
        List<SlideViewModel> GetList();
    }
}
