# OOPDiscountSystem
A discount shop system created during my free time. This allowed me to practice Object Oreinted Programming during the summer holidays 2019.

## About Discount System
The discount system was part of a challenge to create a system that uses Object-Oriented Programming. This opportunity allowed me to gain a better understanding of object-oriented programming, while also trying creative solutions to meet the requirements.

The task set was to create a shop that would calculate the items price after discount has been applied and the delivery cost. The shop will have a total of 5 items, with each item having a discount type. These discount types are:
- None
- 2 for £20
- 3 for £10
- Buy 1 get 1 free
- 3 for the price of 2

The delivery charge is £7, however, if all the items cost after discount is £50 or over, the delivery is free.

## Key Features
The key features of my solution are the following:

- Display all shop items and its discount type and normal price
- Allow the user to select what item they want to add to the basket
- Display all the items that are currently in the basket and its quantity (Example: "A: 2", "C: 4")
- Input validation (Example: User is allowed to enter "A", but not "&")
- Display delivery cost and total cost after discount has been applied

## My approach to the problem
My solution to the problem was to first note down all the requirements based on the task. After this, I start to think about how I will store what items are in the basket, and what classes and methods I might need.

## The Classes
The 3 classes that I decided to add are:

• Item: This class is used to create item objects, which contains information such as item name, price and discount type.

• Discount: This class is used to create new discount types. Each type of discount has a class which inherits from the main "Discount" class. Each discount class has an applyDiscount method, which returns the cost of items after discount has been applied.

• Basket: This class is used to store what items are in the basket. This includes the AddToBasket, GetBasket and CalculateTotalPrice method.


## Performance and Reusability
After I've decided what classes and methods I will likely need to use, I start to think about creative solutions to problems that allow the program to run more faster, or create more reusable code. The 2 main improvements that I made are the following:

- Basket Improvements: When "AddToBasket" method is called, the item is stored in a dictionary, where the key is the item and the value is the quantity. For example, if I added the item "A" to the basket, the dictionary would only need to increment the quantity in the key "A" (Example: A = 2 means 2 A items). This solution is efficient, as the program is storing the quantity of the item, instead of storing items seperately (Like A, A). This allows processing items to run more quickly.

- Discount Improvements: In the discount class, instead of making a unique method for each discount type, I decided to use the same method for similar discount types. For example, "2 for £20" offer is very similar to the "3 for £10" offer. This means that if both of these offers are very similar, I can use the same method for both these discounts, but use 2 different parameters for the offer quantity and offer price. In my discount system, I used 2 different discount classes, which are "QuantityForSetPrice" and "BuyQuantityForPriceOfQuanity". "QuantityForSetPrice" deals with offers such as "2 for £20" and "3 for £10", while "BuyQuanityForPriceOfQuantity" deals with "Buy 1 get 1 free" and "3 for the price of 2". This solution has allowed my code to become very reusable, are a store with thousands of items can use the same discount classes, but with different parameters.
