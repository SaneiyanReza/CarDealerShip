using _0_Framework.Domain;
using ShopManagement.Domain.VehicleCategoryAgg;
using ShopManegement.App.VehicleCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain
{
    public interface IVehicleCategoryRepository : IRepository<int , VehicleCategory>
    {
        List<VehicleCategoryViewModel> GetVehicleCategories();

        EditVehicleCategory GetDetails(int id);

        List<VehicleCategoryViewModel> Search(SearchVehicleCategory searchVehicleCategory);

    }
}
