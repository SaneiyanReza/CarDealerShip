using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Domain.UnitOfWorkAgg;
using DiscountManegment.Infrastructure.EfCore.Repository;
using ShopManegment.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManegment.Infrastructure.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DiscountContext _discountContext;
        private readonly CarDealerShipContext _dealerContext;
        CustomerDiscountRepository _customerDiscounts;
        ColleagueDiscountRepository _colleagueDiscounts;

        public UnitOfWork(DiscountContext discountContext, CarDealerShipContext dealerContext)
        {
            _discountContext = discountContext;
            _dealerContext = dealerContext;
        }

        //public CustomerDiscountRepository CustomerDiscounts
        //{
        //    get
        //    {

        //        if (_customerDiscounts == null)
        //        {
        //            _customerDiscounts = new CustomerDiscountRepository(_discountContext, _dealerContext);
        //        }
        //        return _customerDiscounts;
        //    }
        //}

        //public ColleagueDiscountRepository ColleagueDiscounts
        //{
        //    get
        //    {

        //        if (_customerDiscounts == null)
        //        {
        //            _colleagueDiscounts = new ColleagueDiscountRepository(_discountContext, _dealerContext);
        //        }
        //        return _colleagueDiscounts;
        //    }
        //}

        ICustomerDiscountRepository IUnitOfWork.CustomerDiscounts
        {
            get
            {

                if (_customerDiscounts == null)
                {
                    _customerDiscounts = new CustomerDiscountRepository(_discountContext, _dealerContext);
                }
                return _customerDiscounts;
            }
        }
        IColleagueDiscountRepository IUnitOfWork.ColleagueDiscounts
        {
            get
            {

                if (_customerDiscounts == null)
                {
                    _colleagueDiscounts = new ColleagueDiscountRepository(_discountContext, _dealerContext);
                }
                return _colleagueDiscounts;
            }
        }

        public void Complete()
        {
            _discountContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _discountContext.Dispose();
            }
        }
    }
}
