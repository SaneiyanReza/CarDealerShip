using _0_Framework.Domain;
using DiscountManagement.App.CustomerDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository : IRepository<int, CustomerDiscount>
    {
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel model);
        EditCustomerDiscount GetDetails(int id);
        void DeleteByID(int id);
    }
}
