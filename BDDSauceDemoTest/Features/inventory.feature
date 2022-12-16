@iventory
Feature: Inventory Feature

A short summary of the feature
Scenario: Verify the Functionality of Add to the cart
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


