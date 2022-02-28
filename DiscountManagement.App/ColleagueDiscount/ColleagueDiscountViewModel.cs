namespace DiscountManagement.App.ColleagueDiscount
{
    public class ColleagueDiscountViewModel
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public double DiscountRate { get; set; }
        public string Vehicle { get; set; }
        public string CreationDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}
