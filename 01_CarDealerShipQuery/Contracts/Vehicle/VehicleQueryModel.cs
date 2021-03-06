using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CarDealerShipQuery.Contracts.Vehicle
{
    public class VehicleQueryModel
    {
        public int ID { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Specifications { get; set; }
        public string VehicleName { get; set; }
        public string VehicleModel { get; set; }
        public string Price { get; set; }
        public string PriceWithDiscount { get; set; }
        public double DiscountRate { get; set; }
        public bool HasDiscount { get; set; }
        public string DiscountExpire { get; set; }
        public string Category { get; set; }
        public string CategorySlug { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Slug { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreationDate { get; set; }
        public List<VehiclePictureQueryModel> Pictures { get; set; }
    }
    public class VehiclePictureQueryModel
    {
        public int VehicleID { get; set; }
        public string Picture { get; set; }
        public string PictureTitle { get; set; }
        public string PictureAlt { get; set; }
        public bool IsRemoved { get; set; }
    }
}
