Feature: Login Feature
A short summary of the feature

@tag1
Scenario: Verify the Login Functionality with Valid User
Given I am Started the OrangeHRM Application
Then Login Page Displayed.
When I Enter Username 'Admin' and Password 'admin123'.
And Click Login Button.
Then I Logged in Successfully to the Application.

