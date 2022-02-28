namespace ShopManegement.App.Vehicle
{
    public class VehicleViewModel 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public double CarFunction { get; set; }
        public double UnitPrice { get; set; }
        public string CategoryName { get; set; }
        public string Picture { get; set; }
        public int CategoryID { get; set; }
        public string CreationDate { get; set; }
        public bool IsAvailable { get; set; }
        public string Specifications 
        {
            get
            {
                return Name + "  " + Model + "  " + CarFunction;
            }
        }
    }
}
