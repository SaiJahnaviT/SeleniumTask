Feature: Api Methods

@mytag
Scenario Outline: Verify the Post Functionality
Given I Create new post using id '<id>' title '<title>' and author '<author>'.
Examples: 
		| id | title   | author   |
		| 44 | title44 | author44 |



Scenario Outline: verify the Delete Functionality
Given I delete post using id '<id>'.
Examples: 
| id |
| 2  |

Scenario Outline: verify the Get Functionality
Given I Get posts using id '<id>'.
Examples: 
| id |
| 4  |


Scenario Outline: Verify the Put Functionality
Given I Change the post using id '<id>' title '<title>' and author '<author>'.
Examples: 
		| id | title   | author   |
		| 21 | title021 | author21 |

Scenario Outline: Verify the Patch Functionality
Given I Change the post using id '<id>' title '<title>'.
Examples: 
		| id | title    |
		| 40 | title04040 |

