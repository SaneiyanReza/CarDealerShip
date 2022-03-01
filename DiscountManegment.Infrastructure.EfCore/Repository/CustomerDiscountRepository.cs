using _0_Framework.App;
using _0_Framework.Infrastucture;
using DiscountManagement.App.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using ShopManegment.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManegment.Infrastructure.EfCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<int, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly CarDealerShipContext _shipContext;
        public CustomerDiscountRepository(DiscountContext context, CarDealerShipContext shipContext) : base(context)
        {
            _context = context;
            _shipContext = shipContext;
        }

        public void DeleteByID(int id)
        {
            var discount = (from d in _context.CustomerDiscounts where (d.ID == id) select d).FirstOrDefault(x => x.ID == id);

            if (discount != null)
            {
                _context.Remove(discount);
            }
        }

        public EditCustomerDiscount GetDetails(int id)
        {
            return _context.CustomerDiscounts.Select(x => new EditCustomerDiscount
            {
                ID = x.ID,
                VehicleID = x.VehicleID,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToFarsi(),
                EndDate = x.EndDate.ToFarsi(),
                Reason = x.Reason
            }).FirstOrDefault(x => x.ID == id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel model)
        {
            var Vehicles = _shipContext.Vehicles.Select(x => new { x.ID, x.Specifications }).ToList();
            var query = _context.CustomerDiscounts.Select(x => new CustomerDiscountViewModel
            {
                ID = x.ID,
                VehicleID = x.VehicleID,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToFarsi(),
                StartDateEn = x.StartDate,
                EndDate = x.EndDate.ToFarsi(),
                EndDateEn = x.EndDate,
                Reason = x.Reason,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (model.VehicleID > 0)
            {
                query = query.Where(x => x.VehicleID == model.VehicleID);
            }

            if (!string.IsNullOrWhiteSpace(model.StartDate))
            {
                query = query.Where(x => x.StartDateEn > model.StartDate.ToGeorgianDateTime());
            }

            if (!string.IsNullOrWhiteSpace(model.StartDate))
            {
                query = query.Where(x => x.EndDateEn < model.EndDate.ToGeorgianDateTime());
            }

            var discounts = query.OrderByDescending(x => x.ID).ToList();

            discounts.ForEach(discount => discount.Vehicle = Vehicles.FirstOrDefault(x => x.ID == discount.VehicleID)?.Specifications);

            return discounts;
        }
    }
}
