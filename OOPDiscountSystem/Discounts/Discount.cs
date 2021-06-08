using System;
using System.Collections.Generic;
using System.Text;

namespace YarShop
{
    class Discount
    {
        public string promotionalMessage;

        /// <summary>
        /// Sets up discount to contain discount name
        /// </summary>
        /// <param name="discountName">The name of the discount deal</param>
        public Discount(string discountName)
        {
            this.promotionalMessage = discountName;
        }

        /// <summary>
        /// Applies the discount
        /// </summary>
        /// <param name="itemQuantity">The item quantity in basket</param>
        /// <param name="normalPrice">The normal price of the item</param>
        /// <returns>Discounted total price of items</returns>
        public virtual double ApplyDiscount(int itemQuantity, double normalPrice)
        {
            return itemQuantity * normalPrice;
        }

        /// <summary>
        /// Gets the set of items based on item quantity
        /// </summary>
        /// <param name="itemsPerSet">Number of items in each set</param>
        /// <param name="ItemQuantity">Number of overall items</param>
        /// <returns>Set of items</returns>
        internal int GetSetsOfItems(int itemsPerSet, int ItemQuantity)
        {
            return ItemQuantity / itemsPerSet;
        }

        /// <summary>
        /// Gets the quantity of items that are not on offer
        /// </summary>
        /// <param name="itemQuantity">Number of overall items</param>
        /// <param name="offerQuantity">Number of items that is on offer</param>
        /// <returns>Items that are on offer</returns>
        internal int GetItemQuantityOnOffer(int itemQuantity, int offerQuantity)
        {
            int itemsNotOnOffer = itemQuantity % offerQuantity;
            return itemQuantity - itemsNotOnOffer;
        }

        /// <summary>
        /// Calculates the price of items at a set price
        /// </summary>
        /// <param name="price">The cost of an item</param>
        /// <param name="itemQuantity">Number of overall items</param>
        /// <returns>Price of items based on quantity</returns>
        internal double GetPriceAtQuantity(double price, int itemQuantity)
        {
            return itemQuantity * price;
        }
    }
}

