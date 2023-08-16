namespace DMCustoms.Models
{
    public class LeaseInputViewModel
    {
        public VehicleType VehicleType { get; set; }
        public decimal LeaseAmount { get; set; }
        public decimal ResidualValue { get; set; }
        public int LeaseDuration { get; set; }
    }
}
