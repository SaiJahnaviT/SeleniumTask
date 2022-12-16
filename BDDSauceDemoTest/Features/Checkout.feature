Feature: Checkout Feature

A short summary of the feature

@tag1
Scenario: Verify Functionality of Checkout Items
Given I Started SauceDemo Application
Then Login Page Displayed
When I Enter Username 'standard_user' and Password 'secret_sauce'
And Click Login Button
Then I Logged in succesfully and Navigated to inventory page.
When I Add items to the Cart.
| items                 |
| Sauce Labs Backpack   |
| Sauce Labs Bike Light |
Then Item are Added.
When I Click on Cart Button
Then I am Navigated to Cart Page
When I Check the Cart Items
Then I am Able to see the Added Items in the Cart.
When I Click on Checkout Button.
Then I am Naviagted to Details Page.
When I Fill the Details
| firstname | lastname | postalcode |
| jahnavi   | tulasi   | 505325     |
Then I Click on Continue Button.
And I am Navigated to Final Checkout Page.
When I Check Checkout Items and price.
And I Check the SubTotal Amount of items.
Then I Click on Finish Button.
And  Completed the Checkout Process.
