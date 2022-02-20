using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.VehicleCategoryAgg
{
    public class VehicleCategory : BaseEntity
    {
        public string Name { get; private set; }
        public string Model { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Keyword { get; private set; }
        public string MetaDiscription { get; private set; }
        public string Slug { get; private set; }

        public VehicleCategory(string name, string model , string description, string picture,
            string pictureAlt, string pictureTitle, string keyword, string metaDiscription, string slug)
        {
            Name = name;
            Model = model;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keyword = keyword;
            MetaDiscription = metaDiscription;
            Slug = slug;
        }
        public void Edit(string name, string model , string description, string picture,
            string pictureAlt, string pictureTitle, string keyword, string metaDiscription, string slug)
        {
            Name = name;
            Model = model;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keyword = keyword;
            MetaDiscription = metaDiscription;
            Slug = slug;
        }
    }
}
