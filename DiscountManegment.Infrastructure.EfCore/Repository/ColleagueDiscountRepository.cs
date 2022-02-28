using _0_Framework.App;
using _0_Framework.Infrastucture;
using DiscountManagement.App.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using Microsoft.EntityFrameworkCore;
using ShopManegment.Infrastructure.EfCore;
using System.Collections.Generic;
using System.Linq;

namespace DiscountManegment.Infrastructure.EfCore.Repository
{
    public class ColleagueDiscountRepository : RepositoryBase<int, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly CarDealerShipContext _shipContext;
        public ColleagueDiscountRepository(DiscountContext context , CarDealerShipContext shipContext) : base(context)
        {
            _context = context;
            _shipContext = shipContext;
        }

        public EditColleagueDiscount GetDetails(int id)
        {
            return _context.ColleagueDiscounts.Select(x => new EditColleagueDiscount
            {
                ID = x.ID,
                DiscountRate = x.DiscountRate,
                VehicleID = x.VehicleID
            }).FirstOrDefault(x => x.ID == id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel discountSearchModel)
        {
            var vehicles = _shipContext.Vehicles.Select(x => new { x.ID , x.Specifications }).ToList();
            var query = _context.ColleagueDiscounts.Select(x => new ColleagueDiscountViewModel
            {
                ID = x.ID,
                CreationDate = x.CreationDate.ToFarsi(),
                DiscountRate = x.DiscountRate,
                VehicleID= x.VehicleID,
                IsRemoved = x.IsRemoved
            });

            if (discountSearchModel.VehicleID > 0)
            {
                query = query.Where(x => x.VehicleID == discountSearchModel.VehicleID);
            }

            var discounts = query.OrderByDescending(x => x.ID).ToList();
            discounts.ForEach(discounts => discounts.Vehicle = vehicles.FirstOrDefault(x => x.ID == discounts.VehicleID)?.Specifications);

            return discounts;
        }
    }
}
