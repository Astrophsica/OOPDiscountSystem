using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountSystem
{
    static class ConsoleIOService
    {
        public static void OutputCustomMsg(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void OutputBlankLine()
        {
            Console.WriteLine();
        }

        public static string GetConsoleInput()
        {
            return Console.ReadLine();
        }

        public static void OutputWelcomeMsg()
        {
            Console.WriteLine("Welcome to Yar890's Online Shop");
            Console.WriteLine("Below you will find a list of items that are avaliable to purchase: ");
        }

        public static void OutputPricingRules (Dictionary<String, Item> pricingRules)
        {
            foreach (KeyValuePair<string, Item> item in pricingRules)
            {
                Console.WriteLine(string.Concat(item.Value.id, ": £", item.Value.price.ToString(), " (" + item.Value.discount.promotionalMessage + ")"));
            }
            Console.WriteLine();
        }

        

        public static void OutputBasket(Basket basket)
        {
            foreach (KeyValuePair<string, int> item in basket.GetBasket())
            {
                Console.WriteLine(string.Concat(item.Key, ": ", item.Value));
            }
            Console.WriteLine();
        }
    }
}
