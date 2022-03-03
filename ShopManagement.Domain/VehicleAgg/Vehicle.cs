using _0_Framework.Domain;
using ShopManagement.Domain.VehicleCategoryAgg;
using ShopManagement.Domain.VehiclePictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.VehicleAgg
{
    public class Vehicle : BaseEntity<int>
    {

        public string Name { get; private set; }
        public string Model { get; private set; }
        public double CarFunction { get; private set; }
        public double UnitPrice { get; private set; }
        public bool IsAvailable { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keyword { get; private set; }
        public string MetaDescription { get; private set; }
        public int CategoryID { get; private set; }
        public string Specifications
        {
            get
            {
                return Name + "  " + Model + "  " + CarFunction;
            }
        }
        public VehicleCategory VehicleCategory { get; private set; }
        public List<VehiclePicture> VehiclePictures { get; private set; }

        public Vehicle(string name, string model , double carFunction ,double unitPrice, string shortDescription,
            string description, string picture, string pictureAlt, string pictureTitle, string slug,
            string keyword, string metaDescription, int categoryID)
        {
            Name = name;
            Model = model;
            CarFunction = carFunction;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keyword = keyword;
            MetaDescription = metaDescription;
            CategoryID = categoryID;
            IsAvailable = true;
        }

        public void Edit(string name, string model, double carFunction, double unitPrice, string shortDescription,
            string description, string picture, string pictureAlt, string pictureTitle, string slug,
            string keyword, string metaDescription,int categoryID)
        {
            Name = name;
            Model = model;
            CarFunction = carFunction;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keyword = keyword;
            MetaDescription = metaDescription;
            CategoryID = categoryID;
        }

        public void Available()
        {
            this.IsAvailable = true;
        }

        public void NotAvailable()
        {
            this.IsAvailable = false;
        }
    }
}
