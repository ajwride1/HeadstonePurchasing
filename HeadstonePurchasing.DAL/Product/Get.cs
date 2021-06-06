using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HeadstonePurchasing.DAL.Product.DTO;
using Newtonsoft.Json;

namespace HeadstonePurchasing.DAL.Product
{
    public static class Get
    {
        private const string _ConfigFilePath = @"Product\config.json";
        private const string _DiscountsConfigFilePath = @"Product\discounts.json";

        public static DTO.Detail Detail(int id)
        {
            Enums.ID productEnum = (Enums.ID) id;
            return Detail(productEnum);
        }

        public static DTO.Detail Detail(string name)
        {
            Enums.ID productEnum = (Enums.ID)Enum.Parse(typeof(Enums.ID), name);
            return Detail(productEnum);
        }

        public static List<DTO.Detail> All()
        {
            DTO.Config config = _ReadConfigFile<DTO.Config>(_ConfigFilePath);

            ConcurrentBag<DTO.Detail> allDetails = new ConcurrentBag<Detail>(config.Products);

            Parallel.ForEach(allDetails, new ParallelOptions {MaxDegreeOfParallelism = 10}, detail =>
            {
                Enums.ID productEnum = (Enums.ID)Enum.Parse(typeof(Enums.ID), detail.Name);
                detail.ID = (int) productEnum;
            });

            return allDetails.ToList();
        }

        public static DTO.Detail Detail(Enums.ID productEnum)
        {
            DTO.Config config = _ReadConfigFile<DTO.Config>(_ConfigFilePath);

            if (!config.Products
                .Any(p => p.Name.Trim().ToUpper()
                          == productEnum.ToString().Trim().ToUpper()))
                throw new KeyNotFoundException($"There is no product information in the config file for {productEnum}");

            DTO.Detail product = config.Products.First(p => p.Name.Trim().ToUpper()
                                                            == productEnum.ToString().Trim().ToUpper());

            product.ID = (int) productEnum;

            return product;
        }

        public static DTO.Discounts Discounts()
        {
            return _ReadConfigFile<DTO.Discounts>(_DiscountsConfigFilePath);
        }

        private static T _ReadConfigFile<T>(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"The config file {filePath} is missing");

            string rawConfig = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<T>(rawConfig);
        }
    }
}
