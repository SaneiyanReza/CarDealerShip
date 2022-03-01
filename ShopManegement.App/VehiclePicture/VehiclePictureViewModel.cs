using ShopManegement.App.Vehicle;

namespace ShopManegement.App.VehiclePicture
{
    public class VehiclePictureViewModel
    {
        public int ID { get; set; }
        public string VehicleName { get; set; }
        public string VehicleModel { get; set; }
        public double VehicleFunction { get; set; }
        public string Picture { get; set; }
        public string CreationDate { get; set; }
        public int VehicleID { get; set; }
        public bool IsRemoved { get; set; }
    }
}
