namespace HeadstonePurchasing.Models
{
    public class Product : PL.Product
    {
        public Product() { }

        public Product(DAL.Product.DTO.Detail dto)
        {
            ID = dto.ID;
            Name = dto.Name.Trim();
            PricePerUnit = dto.PricePerUnit ?? 0;
            Discount = dto.DiscountPercentage ?? 0;
        }
    }
}