using _0_Framework.Domain;
using ShopManagement.Domain.VehicleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.VehiclePictureAgg
{
    public class VehiclePicture : BaseEntity<int>
    {
        public int VehicleID { get; private set; }
        public string Picture { get; private set; }
        public string PictureTitle { get; private set; }
        public string PictureAlt { get; private set; }
        public bool IsRemoved { get; private set; }
        public Vehicle Vehicle { get; private set; }

        public VehiclePicture(int vehicleID, string picture, string pictureTitle, string pictureAlt)
        {
            VehicleID = vehicleID;
            Picture = picture;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            IsRemoved = false;
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
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
