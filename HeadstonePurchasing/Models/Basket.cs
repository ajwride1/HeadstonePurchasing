using System.Collections.Generic;
using System.Linq;
using HeadstonePurchasing.DAL.Product;
using HeadstonePurchasing.DAL.Product.DTO;

namespace HeadstonePurchasing.Models
{
    public class Basket : PL.Basket
    {
        private List<SpecialOffer> _CurrentOffers;

        public Basket()
        {
            ID = 1;
            _Products = new List<PL.Product>();

            Discounts currentDiscounts = Get.Discounts();
            _CurrentOffers = currentDiscounts.SpecialOffers;
        }

        public void AddProductToBasket(PL.Product product)
        {
            _Products.Add(product);
            _CalculateTotals();
        }

        public void RemoveProductFromBasket(PL.Product product)
        {
            _Products.Remove(product);
            _CalculateTotals();
        }

        private void _CalculateTotals()
        {
            _Total = Products.Sum(p => p.PricePerUnit);
            _Discounts = Products.Sum(p => p.PricePerUnit * p.Discount);
            _TotalAfterDiscounts = Total - Discounts;
        }
    }
}