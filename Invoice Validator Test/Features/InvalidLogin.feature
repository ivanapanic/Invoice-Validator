Feature: Invalid login
	In order to test if error message is displayed
    As a user
    I want to be warned if my data is invalid

@mytag
Scenario: Enter invalid data
	Given User navigates to Invoice validator web site
	When user enters invalid data
	And clicks on sign in button
	Then error message is displayed

Scenario: Leave empty fields
Given User navigates to Invoice validator site
When user leaves fields empty
And clicks on button sign in 
Then error message is displayed on login page
