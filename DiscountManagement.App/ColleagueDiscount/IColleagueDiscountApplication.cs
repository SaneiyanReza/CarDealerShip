using _0_Framework.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.App.ColleagueDiscount
{
    public interface IColleagueDiscountApplication
    {
        OperationResult Define(DefineColleagueDiscount defineColleague);
        OperationResult Edit(EditColleagueDiscount editColleague);
        OperationResult Romove(int id);
        OperationResult Restore(int id);
        EditColleagueDiscount GetDetails(int id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel discountSearchModel);
    }
}
