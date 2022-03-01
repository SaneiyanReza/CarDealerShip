using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CarDealerShipQuery.Contracts.Vehicle
{
    public interface IVehicleQuery
    {
        List<VehicleQueryModel> GetVehicles();
    }
}
