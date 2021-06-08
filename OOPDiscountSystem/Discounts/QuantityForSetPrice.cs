using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountSystem
{
    class QuantityForSetPrice : Discount
    {
        public int offerQuantity;
        public int discountPrice;

        /// <summary>
        /// Sets up QuantityForSetPrice discount
        /// </summary>
        /// <param name="discountName">The name of the discount deal</param>
        /// <param name="quantity">The offer quantity</param>
        /// <param name="price">The price for the offer quantity</param>
        public QuantityForSetPrice(string discountName, int quantity, int price) : base(discountName)
        {
            this.offerQuantity = quantity;
            this.discountPrice = price;
        }

        /// <summary>
        /// Applies the discount to the items based on item quantity
        /// </summary>
        /// <param name="itemQuantity">The quantity of a specific item that is in the basket</param>
        /// <param name="normalPrice">The normal price of the item</param>
        /// <returns>The overall price of the items after discount has been applied</returns>
        override public double ApplyDiscount(int itemQuantity, double normalPrice)
        {
            // Initialise variables
            double discountedTotal;
            int itemQuantityOnOffer;
            int itemQuantityNotOnOffer;

            // Gets items that are on offer and items that are not on offer
            // (EG: 3 items, Buy 2 for £10 deal, the third item is not on offer)
            itemQuantityOnOffer = GetItemQuantityOnOffer(itemQuantity, offerQuantity);
            itemQuantityNotOnOffer = itemQuantity - itemQuantityOnOffer;

            // Calculates the number of sets of items based on item quantity that is on offer
            // (EG: 4 items, Buy 2 for £10, there are 4 / 2 = 2 sets of items that are on offer)
            int setsOfItems = GetSetsOfItems(offerQuantity, itemQuantityOnOffer);

            // Calculates price of items on offer
            discountedTotal = GetPriceAtQuantity(discountPrice, setsOfItems);
            // Calculates price of items not on offer and adds it to discountedTotal
            discountedTotal = discountedTotal + GetPriceAtQuantity(normalPrice, itemQuantityNotOnOffer);

            return discountedTotal;
        }
    }
}

