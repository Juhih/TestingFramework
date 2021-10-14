Feature: Orange HRM
	

@mytag
Scenario: Login
	Given User is at Orange HRM
	When User enters the username and password 
	And User clicks on Login button
	Then User is on dashboard page


Scenario Outline: Add an Admin Role
	Given User is at Orange HRM
	When User enters the username and password 
	And User clicks on Login button
	Then User is on dashboard page
	Then User Click on Admin tab
	And User click on Add button 
	Then User add the details '<User Role>' '<Employee Name>' '<Status>' '<Password>'
	And User click on save 
	Then User verifies the added admin '<User Role>' '<Employee Name>' '<Status>'
	And User Deletes the added record

	Examples: 
	| User Role | Employee Name | Status | Password     |
	|  Admin    |Joe Root       | Enabled| JoeRoot@123  |