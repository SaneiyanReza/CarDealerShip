using _01_CarDealerShipQuery.Contracts.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CarDealerShipQuery.Contracts.VehicleCategory
{
    public class VehicleCategoryQueryModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }
        public List<VehicleQueryModel> Vehicles { get; set; }
        public VehicleQueryModel VehicleQueryModel { get; set; }
    }
}
