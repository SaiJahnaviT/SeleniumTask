Feature: Recruitment Feature

A short summary of the feature

@login
Scenario Outline: Verify the Functionality Add Candidate
Given I am in HomePage.
When I Click on 'Recruitment' slot in Catalog.
Then I Navigated to Recruitment Page.
When I Click on Add button
Then I Navigated to Add Candidate Page.
When I Enter Details Firstname '<firstname>',Lastname '<lastname>',EmailID '<emailID>'
And Click on Save button.
Then Application is Saved and viewed.
Examples: 
			| firstname | lastname | emailID           |
			| Monica    | Geller   | monicag@gmail.com |

@login
Scenario Outline: Verify the Functionality Add Candidate without lastname
Given I am in HomePage.
When I Click on 'Recruitment' slot in Catalog.
Then I Navigated to Recruitment Page.
When I Click on Add button
Then I Navigated to Add Candidate Page.
When I Enter Details Firstname '<firstname>',Lastname '<lastname>',EmailID '<emailID>'
And Click on Save button.
Then error Displayed.
Examples: 
			| firstname | lastname | emailID           |
			| Monica    |          | monicag@gmail.com |
