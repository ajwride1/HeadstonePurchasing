using System;
using Newtonsoft.Json;

namespace HeadstonePurchasing.Test
{
    public static class Helper
    {
        public static void PrintObject(object objectToPrint)
        {
            Console.WriteLine(JsonConvert.SerializeObject(objectToPrint, Formatting.Indented));
        }
    }
}
