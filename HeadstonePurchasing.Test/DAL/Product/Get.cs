using System;
using System.Collections.Generic;
using System.Linq;
using HeadstonePurchasing.DAL.Product.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeadstonePurchasing.Test.DAL.Product
{
    [TestClass]
    public class Get
    {
        [TestMethod]
        public void ProductByID()
        {
            foreach (HeadstonePurchasing.DAL.Product.Enums.ID productId 
                in Enum.GetValues(typeof(HeadstonePurchasing.DAL.Product.Enums.ID)))
            {
                HeadstonePurchasing.DAL.Product.DTO.Detail product 
                    = HeadstonePurchasing.DAL.Product.Get.Detail((int) productId);

                Helper.PrintObject(product);

                _CheckProduct(product, productId);
            }
        }

        [TestMethod]
        public void ProductByName()
        {
            foreach (HeadstonePurchasing.DAL.Product.Enums.ID productId
                in Enum.GetValues(typeof(HeadstonePurchasing.DAL.Product.Enums.ID)))
            {
                HeadstonePurchasing.DAL.Product.DTO.Detail product
                    = HeadstonePurchasing.DAL.Product.Get.Detail(productId.ToString());

                Helper.PrintObject(product);

                _CheckProduct(product, productId);
            }
        }

        [TestMethod]
        public void All()
        {
            List<Detail> allProducts = HeadstonePurchasing.DAL.Product.Get.All();

            Helper.PrintObject(allProducts);

            foreach (HeadstonePurchasing.DAL.Product.Enums.ID productId
                in Enum.GetValues(typeof(HeadstonePurchasing.DAL.Product.Enums.ID)))
            {
                Detail product
                    = allProducts.First(p => p.ID == (int) productId);

                _CheckProduct(product, productId);
            }
        }

        [TestMethod]
        public void Discounts()
        {
            HeadstonePurchasing.DAL.Product.DTO.Discounts discounts
                = HeadstonePurchasing.DAL.Product.Get.Discounts();

            Helper.PrintObject(discounts);
        }

        private void _CheckProduct(HeadstonePurchasing.DAL.Product.DTO.Detail product,
            HeadstonePurchasing.DAL.Product.Enums.ID productId)
        {
            Assert.IsTrue(product.ID == (int)productId);
            Assert.IsTrue(product.Name == productId.ToString());
            Assert.IsTrue(product.PricePerUnit != null);
            Assert.IsTrue(product.DiscountPercentage != null);
        }
    }
}
