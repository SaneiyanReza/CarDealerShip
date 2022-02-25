using _0_Framework.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegement.App.Slide
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlide createSlide);
        OperationResult Edit(EditSlide editSlide);
        OperationResult Remove(int Id);
        OperationResult Restore(int Id);
        EditSlide GetDetails(int Id);
        List<SlideViewModel> GetList();
    }
}
