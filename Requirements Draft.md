# Requirements Draft

* Self Registration for Users
* User Login
* Admin User
* Admin Sales Report
* Users must take a UNIQUE username and 6 CHARACTER MINIMUM PASSWORD
* Admins should be able to PROMOTE other users to admin
* PREFERRED a button on the UI that allows admins to promote users
* Users need access to available inventory
* Need to be able to sort highest to lowest price
* Need a dashboard for users and admins
* Program should hide sold products
* Each item will store a 
  * Short name
  * Picture
  * Price
  * Description
* Unsold items should contain an "Add to cart function" on the dashboard
* Cart should be able to hold multiple items until point of sale
* PREFERRED multiple photos of an item
* All items sold in USD
* Store price in Base 10, not Float
* CANNOT checkout without a cart
* Checkout and cart should include an itemized list of purchases AND cost
* Checkout should be able to remove items from the cart
* If everything is removed, the user should be automatically returned to the dashboard.
* Add a Pay Now button to the shopping cart
* Add a return to shopping button
* After 'Pay Now,' require a shipping address, credit card number, phone number, expiration month, CVV security code,and shipping speed. All fields are required
* Shipping speeds will be
  * Overnight: $29
  * 3-Day: $19
  * Ground: $0
* After inputs, user must click 'Confirm Order'
* Confirm order should display a new page, with a list of purchases, subtotal, tax at a default of 6%, shipping speed cost, and grand total.
* Purchases list should contain item name and price
* On the Confirm Order page, there should be a Complete Order button.
* Before clicking Complete Order, there should also be a button to return to shopping, saving the cart for later. 
* Complete Order should take the items out of inventory, set the items to sold, return the user's receipt, and empty the user's cart
* The receipt should include the last 4 digits of the user's credit card, their shipping address, the itemized list of purchase, and the price breakdown. 
* Confirm Order page should contain
* The user should receive a receipt on site
* The user should receive an automatic email containing the receipt. (SendGrid)
* The receipt page should include a close page button.
* The sold items should automatically be added to the sales report.
* Admin should be able to pull up a sales report with a sales report function. Could be a command or a UI button
* PREFERRED an Admin can select hidden SOLD inventory to see the receipt of purchase that item is included on. 
* With a pulled up sales report, an Admin should be able to export a CSV (sheets) file
* Admins need an Add Inventory Function. PREFERRED an add item button, creating a saved page and object, with the ability to upload pictures and customize attributes of the entities. 
* Needs a mockup PRIOR to implementation. 





