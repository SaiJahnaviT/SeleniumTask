Feature: Leave Feature

A short summary of the feature

@login
Scenario: Verify the Search Functionality in Leave Page.
Given I am in HomePage.
When I Click on 'Leave' slot in Catalog.
Then I Navigated to Leave Page.
When I Take a Dates from Record Table.
And I Enter that Dates in Searchbox.
When I Click on Search Button.
Then The Similar records displayed.
