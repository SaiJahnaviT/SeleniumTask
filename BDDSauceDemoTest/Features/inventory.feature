@iventory
Feature: Inventory Feature

A short summary of the feature
Scenario: Verify the Functionality of Add to the cart
Given I Started SauceDemo Application
Then Login Page Displayed
When I Enter USername 'standard_user' and Password 'secret_sauce'
And Click Login Button
Then I Looged in succesfully and Navigated to inventory page.
When I Add items to the Cart.
| items               |
| Sauce Labs Backpack |
Then Item are Added.


