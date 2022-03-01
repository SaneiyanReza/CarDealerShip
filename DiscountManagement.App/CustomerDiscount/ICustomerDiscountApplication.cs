using _0_Framework.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.App.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        OperationResult Define(DefineCustomerDiscount customerDiscount);
        OperationResult Edit(EditCustomerDiscount customerDiscount);
        void DeleteByID(int id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel model);
        EditCustomerDiscount GetDetails(int id);
    }
}
