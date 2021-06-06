namespace HeadstonePurchasing.DAL.Product.DTO
{
    public class Detail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double? PricePerUnit { get; set; }
        public double? DiscountPercentage { get; set; }
    }
}
