using _0_Framework.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegment.Configuration.Permissions
{
    public class ShopPermissonsExposer : IPermissonsExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Vehicle" , new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.ListVehicles , "ListVehicles"),
                        new PermissionDto(ShopPermissions.SearchVehicle , "SearchVehicles"),
                        new PermissionDto(ShopPermissions.CraeteVehicle , "CraeteVehicles"),
                        new PermissionDto(ShopPermissions.EditVehicle , "EditVehicles"),
                        new PermissionDto(ShopPermissions.DeleteVehicle , "DeleteVehicles"),
                    }
                },
                {
                    "VehicleCategory" , new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.ListVehicleCategories , "ListVehicleCategories"),
                        new PermissionDto(ShopPermissions.SearchVehicleCategorie , "SearchVehicleCategories"),
                        new PermissionDto(ShopPermissions.CreateVehicleCategorie , "CreateVehicleCategories"),
                        new PermissionDto(ShopPermissions.EditVehicleCategorie , "EditVehicleCategories"),
                    }
                },
                {
                    "VehiclePicture" , new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.ListVehiclePictures , "ListVehiclePictures"),
                        new PermissionDto(ShopPermissions.SearchVehiclePicture , "SearchVehiclePictures"),
                        new PermissionDto(ShopPermissions.CreateVehiclePicture , "CreateVehiclePictures"),
                        new PermissionDto(ShopPermissions.EditVehiclePicture , "EditVehiclePictures"),
                    }
                },
                {
                    "Slide" , new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.ListSlides , "ListSlides"),
                        new PermissionDto(ShopPermissions.SearchSlide , "SearchSlides"),
                        new PermissionDto(ShopPermissions.CreateSlide , "CreateSlides"),
                        new PermissionDto(ShopPermissions.EditSlide , "EditSlides"),
                    }
                },

            };
        }
    }
}
