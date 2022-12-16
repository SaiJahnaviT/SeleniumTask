Feature: Cart Feature

A short summary of the feature

@tag1
Scenario: Verify the Functionality of cart
Given I Started SauceDemo Application
Then Login Page Displayed
When I Enter Username 'standard_user' and Password 'secret_sauce'
And Click Login Button
Then I Logged in succesfully and Navigated to inventory page.
When I Add items to the Cart.
| items               |
| Sauce Labs Backpack |
Then Item are Added.
When I Click on Cart Button
Then I am Navigated to Cart Page
When I Check the Cart Items
Then I am Able to see the Added Items in the Cart.
