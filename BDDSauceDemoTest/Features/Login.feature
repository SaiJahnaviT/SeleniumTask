Feature: Login Feature

A short summary of the feature


@tag1
Scenario Outline: Verify the Login Functionality of SauceDemo with valid users
Given I Started SauceDemo Application
Then Login Page Displayed
When I Enter Username '<Username>' and Password 'secret_sauce'
And Click Login Button
Then I Logged in succesfully and Navigated to inventory page.
Examples:
			| Username                |
			| standard_user           |
			| problem_user            |
			| performance_glitch_user |

Scenario: Verify the Login Functionality of SauceDemo with Invalid user
Given I Started SauceDemo Application
Then Login Page Displayed
When I Enter Username 'locked_out_user' and Password 'secret_sauce'
And Click Login Button
Then Error Displayed,I am unable to Login



