using System;
using System.Collections.Generic;
using HeadstonePurchasing.Models;
using HeadstonePurchasing.PL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeadstonePurchasing.Test.Models
{
    [TestClass]
    public class Basket
    {
        private PL.Product _Test1 = new PL.Product
        {
            ID = 10,
            Discount = 0.5,
            Name = "Test1",
            PricePerUnit = 1
        };

        private PL.Product _Test2 = new PL.Product
        {
            ID = 11,
            Discount = 0,
            Name = "Test2",
            PricePerUnit = 1
        };

        private PL.Product _Test3 = new PL.Product
        {
            ID = 12,
            Discount = 0.1,
            Name = "Test3",
            PricePerUnit = 1
        };

        private PL.Product _Headstone = new PL.Product
        {
            ID = 1,
            Discount = 0.1,
            Name = "Headstone",
            PricePerUnit = 10
        };

        private PL.Product _Dowel = new PL.Product
        {
            ID = 1,
            Discount = 0,
            Name = "Dowel",
            PricePerUnit = 1
        };

        private PL.Product _Base = new PL.Product
        {
            ID = 1,
            Discount = 0.1,
            Name = "Base",
            PricePerUnit = 5
        };

        [TestMethod]
        public void CalculateTotalsNoSpecials()
        {
            HeadstonePurchasing.Models.Basket newBasket = new HeadstonePurchasing.Models.Basket();
            Console.WriteLine("=============================================");
            newBasket.AddProductToBasket(_Test1);
            Helper.PrintObject(newBasket);
            Assert.IsTrue(newBasket.Total == 1);
            Assert.IsTrue(newBasket.Discounts == 0.5);
            Assert.IsTrue(newBasket.TotalAfterDiscounts == 0.5);
            Console.WriteLine("=============================================");
            newBasket.RemoveProductFromBasket(_Test1);
            Helper.PrintObject(newBasket);
            Assert.IsTrue(newBasket.Total == 0);
            Assert.IsTrue(newBasket.Discounts == 0);
            Assert.IsTrue(newBasket.TotalAfterDiscounts == 0);
            Console.WriteLine("=============================================");
            newBasket.AddProductToBasket(_Test1);
            Helper.PrintObject(newBasket);
            Assert.IsTrue(newBasket.Total == 1);
            Assert.IsTrue(newBasket.Discounts == 0.5);
            Assert.IsTrue(newBasket.TotalAfterDiscounts == 0.5);
            Console.WriteLine("=============================================");
            newBasket.AddProductToBasket(_Test1);
            Helper.PrintObject(newBasket);
            Assert.IsTrue(newBasket.Total == 2);
            Assert.IsTrue(newBasket.Discounts == 1);
            Assert.IsTrue(newBasket.TotalAfterDiscounts == 1);
            Console.WriteLine("=============================================");
            newBasket.RemoveProductFromBasket(_Test1);
            Helper.PrintObject(newBasket);
            Assert.IsTrue(newBasket.Total == 1);
            Assert.IsTrue(newBasket.Discounts == 0.5);
            Assert.IsTrue(newBasket.TotalAfterDiscounts == 0.5);
            Console.WriteLine("=============================================");
            newBasket.AddProductToBasket(_Test2);
            Helper.PrintObject(newBasket);
            Assert.IsTrue(newBasket.Total == 2);
            Assert.IsTrue(newBasket.Discounts == 0.5);
            Assert.IsTrue(newBasket.TotalAfterDiscounts == 1.5);
            Console.WriteLine("=============================================");
            newBasket.AddProductToBasket(_Test2);
            Helper.PrintObject(newBasket);
            Assert.IsTrue(newBasket.Total == 3);
            Assert.IsTrue(newBasket.Discounts == 0.5);
            Assert.IsTrue(newBasket.TotalAfterDiscounts == 2.5);
            Console.WriteLine("=============================================");
            newBasket.RemoveProductFromBasket(_Test2);
            Helper.PrintObject(newBasket);
            Assert.IsTrue(newBasket.Total == 2);
            Assert.IsTrue(newBasket.Discounts == 0.5);
            Assert.IsTrue(newBasket.TotalAfterDiscounts == 1.5);
            Console.WriteLine("=============================================");
            newBasket.AddProductToBasket(_Test3);
            Helper.PrintObject(newBasket);
            Assert.IsTrue(newBasket.Total == 3);
            Assert.IsTrue(newBasket.Discounts == 0.6);
            Assert.IsTrue(newBasket.TotalAfterDiscounts == 2.4);
            Console.WriteLine("=============================================");
            newBasket.AddProductToBasket(_Test3);
            Helper.PrintObject(newBasket);
            Assert.IsTrue(newBasket.Total == 4);
            Assert.IsTrue(newBasket.Discounts == 0.7);
            Assert.IsTrue(newBasket.TotalAfterDiscounts == 3.3);
            Console.WriteLine("=============================================");
            newBasket.RemoveProductFromBasket(_Test3);
            Helper.PrintObject(newBasket);
            Assert.IsTrue(newBasket.Total == 3);
            Assert.IsTrue(newBasket.Discounts == 0.6);
            Assert.IsTrue(newBasket.TotalAfterDiscounts == 2.4);
        }

        [TestMethod]
        public void CalculateTotalsWithSpecialOffers()
        {
            HeadstonePurchasing.Models.Basket newBasket = new HeadstonePurchasing.Models.Basket();
            Console.WriteLine("=============================================");
            newBasket.AddProductToBasket(_Headstone);
            Helper.PrintObject(newBasket);
            Assert.IsTrue(newBasket.Total == _Headstone.PricePerUnit);
            Assert.IsTrue(newBasket.Discounts == _Headstone.PricePerUnit * _Headstone.Discount);
            Assert.IsTrue(newBasket.TotalAfterDiscounts == newBasket.Total - newBasket.Discounts);

            Console.WriteLine("=============================================");
            newBasket.AddProductToBasket(_Base);
            Helper.PrintObject(newBasket);
            Assert.IsTrue(newBasket.Total == _Base.PricePerUnit + _Headstone.PricePerUnit);
            Assert.IsTrue(newBasket.Discounts 
                          == (_Base.PricePerUnit * _Base.Discount)
                          + (_Headstone.PricePerUnit * _Headstone.Discount));
            Assert.IsTrue(newBasket.TotalAfterDiscounts == newBasket.Total - newBasket.Discounts);

            Console.WriteLine("=============================================");
            newBasket.AddProductToBasket(_Dowel);
            Helper.PrintObject(newBasket);
            Assert.IsTrue(newBasket.Total == _Base.PricePerUnit
            + _Headstone.PricePerUnit + _Dowel.PricePerUnit);
            Assert.IsTrue(newBasket.Discounts == 2);
            Assert.IsTrue(newBasket.TotalAfterDiscounts == newBasket.Total - newBasket.Discounts);
        }
    }
}
