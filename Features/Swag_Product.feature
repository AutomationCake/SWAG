Feature: To verify the product page


@product-01
Scenario: To verify all the element is present or not in the product page
	Given Navigate to product page
	Then user able to see the open menu
	Then user able to see the product label "Products"
	Then user able to see the sort dropdown
	Then user able to see the inventory items
	Then use able to see the shopping cart

@product
Scenario Outline: To verify user able to add the product
	Given Navigate to product page
	When user select the product "<ProductName>" and click Add to cart
	Then user able to see remove button "<ProductName>"
	Then user able to see the cart count "1"
	When user select the product "<ProductName>" and click remove
	Then user not able to see remove button "<ProductName>"
	Then user not able to see the cart count

Examples:
	| ProductName         |
	| Sauce Labs Backpack |


@product
Scenario: To verify user able to add and remove the product in cart page
	Given Navigate to product page
	When user select the product "Sauce Labs Backpack" and click Add to cart
	Then user able to see remove button "Sauce Labs Backpack"
	Then user able to see the cart count "1"
	When user click the cart icon
	Then user able to see the added product "Sauce Labs Backpack" in the cart
	Then user verify the product name "Sauce Labs Backpack" and quantity "1"
	Then user able to see remove button "Sauce Labs Backpack"
	Then user able to see the continue shopping button
	Then user able to see the checkout button
	When user select the product "Sauce Labs Backpack" and click remove
	Then user not able to see the name "Sauce Labs Backpack" and quantity "1"

@product
Scenario: To verify user able to continue shopping in cart page
	Given Navigate to product page
	When user select the product "Sauce Labs Backpack" and click Add to cart
	Then user able to see remove button "Sauce Labs Backpack"
	Then user able to see the cart count "1"
	When user click the cart icon
	Then user able to see the added product "Sauce Labs Backpack" in the cart
	Then user verify the product name "Sauce Labs Backpack" and quantity "1"
	Then user able to see remove button "Sauce Labs Backpack"
	Then user able to see the continue shopping button
	Then user able to see the checkout button
	When user select the product "Sauce Labs Backpack" and click continue shopping
	Then user able to see the product page
	Then user able to see the open menu
	Then user able to see the product label "Products"
	Then user able to see the sort dropdown
	Then user able to see the inventory items
	Then use able to see the shopping cart
	When user select the other product "Sauce Labs Bike Light" and click Add to cart
	Then user able to see the cart count "2"
	When user click the cart icon
	Then user able to see the continue shopping button
	Then user able to see the checkout button
	When user select the product "Sauce Labs Bike Light" and click remove
	When user select the product "Sauce Labs Backpack" and click remove
	Then user not able to see the name "Sauce Labs Bike Light" and quantity "1"
	Then user not able to see the name "Sauce Labs Backpack" and quantity "1"








	
