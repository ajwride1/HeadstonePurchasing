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
            _CalculateDiscounts();
            _TotalAfterDiscounts = Total - Discounts;
        }

        private void _CalculateDiscounts()
        {
            _Discounts = Products.Sum(p => p.PricePerUnit * p.Discount);
            _CheckCurrentOffers();
        }

        private void _CheckCurrentOffers()
        {
            _GetLatestOffers();

            foreach (SpecialOffer currentOffer in _CurrentOffers)
            {
                bool allOfferProductsInBasket = true;

                foreach (string currentOfferProduct in currentOffer.Products)
                {
                    if (!Products.Any(p => p.Name == currentOfferProduct))
                        allOfferProductsInBasket = false;
                }

                if (allOfferProductsInBasket)
                {
                    foreach (string discountProduct in currentOffer.Discount.Products)
                    {
                        if (Products.Any(p => p.Name == discountProduct))
                        {
                            _Discounts += Products
                                              .First(p => p.Name == discountProduct)
                                              .PricePerUnit *
                                          currentOffer.Discount.Percentage;
                        }
                    }
                }
            }
        }

        private void _GetLatestOffers()
        {
            Discounts currentDiscounts = Get.Discounts();
            _CurrentOffers = currentDiscounts.SpecialOffers;
        }
    }
}