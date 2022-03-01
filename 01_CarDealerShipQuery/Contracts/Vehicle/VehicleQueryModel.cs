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
        public string Slug { get; set; }
        public string Specifications { get; set; }
        public string Price { get; set; }
        public string PriceWithDiscount { get; set; }
        public double DiscountRate { get; set; }
        public string Category { get; set; }
        public bool HasDiscount { get; set; }

    }
}
