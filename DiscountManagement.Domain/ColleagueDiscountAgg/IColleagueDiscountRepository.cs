using _0_Framework.Domain;
using DiscountManagement.App.ColleagueDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public interface IColleagueDiscountRepository : IRepository<int , ColleagueDiscount>
    {
        EditColleagueDiscount GetDetails(int id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel discountSearchModel);
    }
}
