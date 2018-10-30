Feature: Contractor Edit profile
In order to test if Edit profile works
As contractor
I want to be able to edit my profile

Background: Login as Contractor
Given Contractor is logged in


Scenario: Edit profile with valid data
Given Profile page is displayed
     When contractor enters valid data
	 And clicks Save button
	 When page is redirected to Home page
	 And clicks on Profile from header menu
	 Then changed data is displayed


Scenario: Edit profile with invalid data
Given Contractor Profile page is displayed
     When contractor enters invalid data
	 And clicks button Save
	 Then Error messages are displayed on page