using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountSystem
{
    class Item
    {
        public string id;
        public double price;
        public Discount discount;

        /// <summary>
        /// Sets up the PricingRule of a specific item, based on parameters
        /// </summary>
        /// <param name="item">The item name</param>
        /// <param name="price">The normal price of the item</param>
        /// <param name="discount">The type of discount</param>
        public Item(string id, double price, Discount discount)
        {
            this.id = id;
            this.price = price;
            this.discount = discount;
        }

        /// <summary>
        /// Sets up the PricingRule of a specific item, based on parameters
        /// </summary>
        /// <param name="item">The item name</param>
        /// <param name="price">The normal price of the item</param>
        public Item(string id, double price)
        {
            this.id = id;
            this.price = price;
            this.discount = new Discount("No Discount");
        }
    }
}
