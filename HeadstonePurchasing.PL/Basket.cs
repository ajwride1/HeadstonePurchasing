using System.Collections.Generic;

namespace HeadstonePurchasing.PL
{
    public class Basket
    {
        public int ID { get; set; }
        public List<Product> Products => _Products;
        public double Total => _Total;
        public double Discounts => _Discounts;
        public double TotalAfterDiscounts => _TotalAfterDiscounts;

        protected double _Discounts;
        protected double _TotalAfterDiscounts;
        protected double _Total;
        protected List<Product> _Products;
    }
}
