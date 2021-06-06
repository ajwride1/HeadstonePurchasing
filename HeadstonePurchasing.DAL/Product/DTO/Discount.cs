using System.Collections.Generic;

namespace HeadstonePurchasing.DAL.Product.DTO
{
    public class Discount
    {
        public List<string> Products { get; set; }
        public double Percentage { get; set; }
    }
}
