using _0_Framework.Domain;
using ShopManagement.Domain.VehicleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.VehiclePictureAgg
{
    public class VehiclePicture : BaseEntity
    {
        public int VehicleID { get; private set; }
        public string Picture { get; private set; }
        public string PictureTitle { get; private set; }
        public string PictureAlt { get; private set; }
        public bool IsDeleted { get; private set; }
        public Vehicle Vehicle { get; private set; }

        public VehiclePicture(int vehicleID, string picture, string pictureTitle, string pictureAlt)
        {
            VehicleID = vehicleID;
            Picture = picture;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            IsDeleted = false;
        }

        public void Edit(int vehicleID, string picture, string pictureTitle, string pictureAlt)
        {
            VehicleID = vehicleID;
            Picture = picture;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Restore()
        {
            IsDeleted=false;
        }
    }
}
