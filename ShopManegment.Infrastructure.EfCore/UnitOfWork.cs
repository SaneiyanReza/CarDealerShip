using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.SlideAgg;
using ShopManegement.App.Slide;
using ShopManegment.Infrastructure.EfCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ShopManegment.Infrastructure.EfCore
{
    public class UnitOfWork
    {
        private SlideRepository _slideRepository;
        private CarDealerShipContext context;

        //public CarDealerShipContext Context
        //{
        //    get
        //    {

        //        if (this.context == null)
        //        {
        //            this.context = new CarDealerShipContext(context);
        //        }
        //        return context;
        //    }
        //}
        public SlideRepository SlideRepository
        {
            get
            {

                if (this._slideRepository == null)
                {
                    this._slideRepository = new SlideRepository(context);
                }
                return _slideRepository;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        //public UnitOfWork(DbContextOptions<CarDealerShipContext> options) : base(options)
        //{
        //}

        public UnitOfWork()
        {
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

