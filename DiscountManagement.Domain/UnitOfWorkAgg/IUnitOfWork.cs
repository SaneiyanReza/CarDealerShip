using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.UnitOfWorkAgg
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerDiscountRepository CustomerDiscounts { get; }
        IColleagueDiscountRepository ColleagueDiscounts { get; }
        void Complete();
    }
}
