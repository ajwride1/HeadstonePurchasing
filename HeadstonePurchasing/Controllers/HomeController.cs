using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HeadstonePurchasing.Models;

namespace HeadstonePurchasing.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ConcurrentBag<Product> allProducts = new ConcurrentBag<Product>();

            List<DAL.Product.DTO.Detail> allProductDtos = DAL.Product.Get.All();

            Parallel.ForEach(allProductDtos, new ParallelOptions {MaxDegreeOfParallelism = 10},
                productDto => { allProducts.Add(new Product(productDto)); });

            return View(allProducts.ToList());
        }
    }
}