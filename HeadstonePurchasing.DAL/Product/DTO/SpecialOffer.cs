using System.Collections.Generic;

namespace HeadstonePurchasing.DAL.Product.DTO
{
    public class SpecialOffer
    {
        public List<string> Products { get; set; }
        public Discount Discount { get; set; }
    }
}
