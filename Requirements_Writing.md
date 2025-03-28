# Requirements Writing

- #### Version 1

  - Database T7E-1

    - Establish Database Architecture T7S-1
      - Needs to Have
      - Effort (shorter)
      - Functional
      - Establish and implement a standard system for storing data on the database, and price should specifically be stored in base 10
    - Create Query System For Inventory T7S-2
      - Needs to Have
      - Effort (Short, SQL has most of it built in)
      - Functional
      - Create a system/function in the database to search the inventory files
    - Establish Error Handling T7S-3
      - Needs to Have
      - Effort (This will take the whole of implementation, so put the whole week of the process)
      - Functional
      - Create a system to handle error codes from missing or corrupted data from a variety of sources, in order to maintain a smooth user experience
    - Store Sales History T7S-4
      - Needs to Have
      - Effort (medium, maybe give this one half a day to a day)
      - Functional
      - Create and store checkout sales, with the items sold, who bought them, and how much
    - Create Query For Sales T7S-5
      - Needs to Have
      - Effort (short)
      - Functional
      - Create a system to call and search completed checkout sales

  - Registration Page T7E-2

    - Create Username Text Box T7S-6
      - Needs to Have
      - Effort
      - Functional
      - Create a username input text box, which will only accept unused usernames. Needs to check the new username with the database.
    - Create Password Text Box T7S-7
      - Needs to Have
      - Effort()
      - Functional
      - Create a password input text box, which will check for a minimum character length of 6 characters

    * Commit Users to The Database T7S-8
      * Needs to Have
      * Effort(Medium)
      * Functional
      * Establish a system where the database creates a new file for a user, storing their username, password, and eventually their purchases

  - Login Page T7E-3

    - Create Username Text Box T7S-9
      - Needs to Have
      - Effort(Medium)
      - Functional
      - Create an input text box for usernames on login that will check the input to the database, in order to recognize the password. If there is no matching username, inform the user that the username does not exist.
    - Create Password Text Box T7S-10
      - Needs to Have
      - Effort(Low)
      - Functional
      - Create an input text box for passwords on login that will check the input with the database user file matching the username. If it matches, user should be logged in. 

  - Inventory Page T7E-4

    - Display Database Inventory T7S-11
      - Needs to Have
      - Effort(Medium)
      - Functional
      - Pull the inventory list from the database, and display a small photo, the full car name, and price.
    - Implement 'Sort By Price' Function T7S-12
      - Needs to have
      - Effort(High)
      - Functional
      - Create a sorting function for displayed info on the inventory page, which can be done either on the front end or backend
    - Create Text Box For Item Query T7S-13
      - Needs to have
      - Effort(Medium)
      - Functional
      - Create an input text box on the inventory page that will take the input and use it to search the full car names, and possibly descriptions in the database

  - Admin Dashboard T7E-5

    - Display Sold Inventory T7S-14
      - Needs to Have
      - Effort
      - Functional
      - Change admin display to include sold items on inventory list
    - Create Button For Sales Report T7S-15
      - Needs to Have
      - Effort
      - Functional
      - Create a button on admin UI to generate a sales report, including all prior sales to the button input
    - Create Button To Export Sales Report T7S-16
      - Needs to Have
      - Effort
      - Functional
      - Grant the admin a method for exporting the sales report as a .csv file
    - Grant Admin to Users T7S-17
      - Needs to Have
      - Effort
      - Functional
      - Create a way for admin users to promote other users to admin
    - Create Page Of Users T7S-18
      - Wants to Have
      - Effort
      - Functional
      - Create a display or page to show a list of current users to an admin so they can grant them admin permissions
    - Create Button To Add Inventory T7S-19
      - Needs to Have
      - Effort
      - Functional
      - Create a button and display for admins to insert new items into the inventory/database, and new items must include name, picture, price in USD, and description
    - Add Function To Select Sold Items T7S-20
      - Wants to Have
      - Effort
      - Functional
      - Create a display for when an admin selects a sold item that shows the sale receipt of the item

  - Inventory Object Page T7E-6

    - Display Object Name, Picture, Price, and Description T7S-21
      - Needs to Have
      - Effort
      - Functional
      - Create a display with an inventory item's name, picture, price in USD, and brief description
    - Display Multiple Photos T7S-22
      - Wants to Have
      - Effort
      - Functional
      - Add multiple photos for each item that the user can cycle through in some way
    - Create Add To Cart Button T7S-23
      - Needs to have
      - Effort
      - Functional
      - Create an add to cart button that calls the function to either create a new cart or add to an existing cart for the user

  - Shopping Cart Page T7E-7

    - Display Selected Inventory T7S-24
      - Needs to have
      - Effort
      - Functional
      - Display the stored cart for the user, only if the user has something in the shopping cart already, and keep the stored items until point of sale or removal by the user, and the user should not be able to display an empty cart page
    - Display Total Price T7S-25
      - Needs to Have
      - Effort
      - Functional
      - Calculate total price in USD using subtotal of all inventory items, and calculated sales tax at 6%
    - Create Button For Checkout/Pay Now T7S-26
      - Needs to Have
      - Effort
      - Functional
      - Create a button called Checkout/Pay Now that calls a function that calls the checkout pop up window, and locks in the total price
    - Create Button For Return To Inventory T7S-27
      - Needs to Have
      - Effort
      - Functional
      - Create a button that returns the user to the inventory page
    - Create Button To Remove Items From Cart T7S-28
      - Needs to Have
      - Effort
      - Functional
      - Create a button that removes the inventory item from the shopping cart
    - Create an Auto Close Function T7S-29
      - Needs to Have
      - Effort
      - Functional
      - The shopping cart page should automatically close if the shopping cart is emptied

  - Checkout Pop-Up Window T7E-8 T7S-30

    - Display Pop-Up Window
      - Needs to Have
      - Effort
      - Functional
      - Displays a pop-up window on checkout to input user credit card information
    - Create Text Box For Shipping Address, Credit Card Number, Phone Number, Expiration Month, and CVV Security Code T7S-31
      - Needs to Have
      - Effort
      - Functional
      - Create input text boxes for credit card information, including the aforementioned, each checking for their specific lengths (card number is 16, phone number is 10 or 11, etc.)
    - Create Select Option For Shipping Speed T7S-32
      - Needs to Have
      - Effort
      - Functional
      - Create a checkmark to select shipping speed, which should automatically update the price of the purchase
    - Create Confirm Order Button T7S-33
      - Needs to Have
      - Effort
      - Functional
      - Create a button that calls a function to draft a sale object, but not commit it, and navigate the user to the Confirm Order Page.

  - Confirm Order Page T7E-9

    - Display Item List T7S-34
      - Needs to Have
      - Effort
      - Functional
      - Display itemized list for purchase with each item's full name and price
    - Display Subtotal, Tax, Shipping Cost, and Grand Total T7S-35
      - Needs to have
      - Effort
      - Functional
      - Display the subtotal of all items for purchase, the calculated tax, the shipping cost, and the grand total (sum) of the purchase
    - Create Complete Order Button T7S-36
      - Needs to Have
      - Effort
      - Functional
      - Create a button on the Confirm Order page that will submit the price to the user's bank, set the sold inventory items to sold, draft a sale receipt, and send the user to a page with their receipt.

  - Receipt Page T7E-10

    - Display Card Digits, User Address, and Itemized List of Purchases T7S-37
      - Need to Have
      - Effort
      - Functional
      - Display the last 4 digits of users credit card, the user's address, and the itemized list of purchases with prices
    - Send Emailed Receipt T7S-38
      - Need to Have
      - Effort
      - Functional
      - Automatically send an email through SendGrid to user's email address
    - Create Close Page Button T7S-39
      - Need to Have
      - Effort
      - Functional
      - Create a button that navigates user back to the inventory page

  - Optimization T7E-11

    - Minimize Storage T7S-40
      - Needs to Have
      - Effort
      - Non-Functional
      - Optimize stored values for minimal storage requirements
    - Ensure Fast Load Times T7S-41
      - Needs to Have
      - Effort
      - Non-Functional
      - Optimize input functions to minimize load times
    - Maintain Ease Of Use T7S-42
      - Needs to Have
      - Effort
      - Non-Functional
      - Take time to ensure every input and layout on the app is easy to navigate and use.

