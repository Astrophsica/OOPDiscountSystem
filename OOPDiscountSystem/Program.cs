using System;
using System.Collections.Generic;

namespace DiscountSystem
{
    class Program
    {
        private string userInput = null;
        private Dictionary<string, Item> pricingRules;
        private Basket mainBasket;

        /// <summary>
        /// This is the first method that is ran in the program
        /// </summary>
        /// <param name="args"></param>
        public void Main(string[] args)
        {
            // Initialise
            Dictionary<string, Discount> discounts = CreatePreSetDiscounts();
            Dictionary<string, Item> pricingRules = CreatePreSetPricingRules(discounts);
            Basket mainBasket = new Basket(pricingRules);

            // Outputs the list of avaliable items to purchase
            OutputWelcomeMessage();

            RunShopLoop();

            // Gets the total price of all items in basket, including delivery charge
            Dictionary<string, double> results = mainBasket.CalculateTotalPrice();

            OutputResults(results);

            IOService.GetConsoleInput();
        }


        public void RunShopLoop()
        {
            // A while loop that runs until user wants to get total price
            while (userInput != "/")
            {
                // Get user input and convert user input to upper caps
                IOService.OutputCustomMsg("Please enter the item you want to add to the basket, or type / to get total price: ");
                userInput = IOService.GetConsoleInput().ToUpper();

                // If user input is a valid item, then added item to basket
                if (pricingRules.ContainsKey(userInput) == true)
                {
                    mainBasket.AddToBasket(userInput);
                    IOService.OutputCustomMsg(string.Concat("Item " + userInput + " has been added to the basket."));
                    IOService.OutputBlankLine();

                    // Outputs current basket 
                    IOService.OutputCustomMsg("Current Basket: ");
                    IOService.OutputBasket(mainBasket);
                }
                // If user input is /, exit while loop
                else if (userInput == "/")
                {
                    break;
                }
                // Invalid input detected, let user know that they entered an invalid input
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            IOService.OutputBlankLine();
        }




        public Dictionary<string, Item> CreatePreSetPricingRules(Dictionary<string, Discount> Discounts)
        {
            // Add the pricing rule of each item to PricingRules dictionary
            Dictionary<string, Item> pricingRules = new Dictionary<string, Item>();
            
            pricingRules.Add("A", new Item("A", 8));
            pricingRules.Add("B", new Item("B", 12, Discounts["Buy2For20"]));
            pricingRules.Add("C", new Item("C", 4, Discounts["Buy3For10"]));
            pricingRules.Add("D", new Item("D", 7, Discounts["Get1Buy1Free"]));
            pricingRules.Add("E", new Item("E", 5, Discounts["Buy3ForPriceOf2"]));

            return pricingRules;
        }




        public Dictionary<string, Discount> CreatePreSetDiscounts()
        {
            // Creates discount type
            Dictionary<string, Discount> Discounts = new Dictionary<string, Discount>();

            Discounts.Add("Buy2For20", new QuantityForSetPrice("Buy 2 for £20", 2, 20));
            Discounts.Add("Buy3For10", new QuantityForSetPrice("Buy 3 for £10", 3, 10));
            Discounts.Add("Get1Buy1Free", new BuyQuantityForPriceOfQuantity("Buy 1 get 1 free", 2, 1));
            Discounts.Add("Buy3ForPriceOf2", new BuyQuantityForPriceOfQuantity("Get 3 for the price of 2", 3, 2));

            return Discounts;
        }


        public void OutputWelcomeMessage()
        {
            IOService.OutputCustomMsg("Welcome to Yar890's Online Shop");
            IOService.OutputCustomMsg("Below you will find a list of items that are avaliable to purchase: ");
            IOService.OutputPricingRules(pricingRules);
        }


        public void OutputResults(Dictionary<string, double> results)
        {
            // Outputs the total price and delivery charge
            IOService.OutputCustomMsg(string.Concat("Total Price: £", results["Total"]));
            IOService.OutputCustomMsg(string.Concat("Delivery Charge: £", results["DeliveryCharge"]));
            IOService.OutputCustomMsg(string.Concat("Overall Total: £", (results["Total"] + results["DeliveryCharge"])));
        }
    }



}

