using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegment.Configuration.Permissions
{
    public static class ShopPermissions
    {
        #region "Vehicle"
        public const byte ListVehicles = 10;
        public const byte SearchVehicle = 11;
        public const byte CraeteVehicle = 12;
        public const byte EditVehicle = 13;
        public const byte DeleteVehicle = 14;
        #endregion

        #region "VehicleCategory"
        public const byte ListVehicleCategories = 20;
        public const byte SearchVehicleCategorie = 21;
        public const byte CreateVehicleCategorie = 22;
        public const byte EditVehicleCategorie = 23;
        #endregion

        #region "VehiclePicture"
        public const byte ListVehiclePictures = 30;
        public const byte SearchVehiclePicture = 31;
        public const byte CreateVehiclePicture = 32;
        public const byte EditVehiclePicture = 33;
        #endregion

        #region "Slide"
        public const byte ListSlides = 40;
        public const byte SearchSlide = 41;
        public const byte CreateSlide = 42;
        public const byte EditSlide = 43;
        #endregion
    }
}
