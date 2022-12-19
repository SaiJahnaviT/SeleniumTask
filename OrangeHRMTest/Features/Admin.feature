Feature: Admin Feature

A short summary of the feature

@login
Scenario Outline: Verify the Functionality of Adding User
Given I am in HomePage.
When I Click on 'Admin' slot in Catalog.
Then I Navigated to Admin's Page.
When I Click on Add Button.
Then I Navigated to Add User Page
When I User detail UserRole '<UserRole>',Employee Name '<EmployeeName>', Status '<Status>',Username '<Username>', Password '<Password>'
Then I Click Save Button.
Examples: 
		| UserRole | EmployeeName | Status  | Username | Password |
		| Admin    | a            | Enabled | Jahnavi000   | Adiii$123  |

@login
Scenario: Verify the Search Functionality 
Given I am in HomePage.
When I Click on 'Admin' slot in Catalog.
Then I Navigated to Admin's Page.
When I Take a Username from table
And I Enter that Username in Searchbox
When I Click on Search Button.
Then The records displayed.



