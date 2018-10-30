Feature: Create Contractor
	In order to test if Create contractor form works
	As admin
	I want to be able to create contractor

Background:  Login as Admin
Given Admin is logged in

Scenario: Create contractor with unique username and pcc id
Given Create Contractor page is displayed
	When admin enters valid data for new contractor
	And clicks on create button
	Then page is redirected to list page
	And new contractor is displayed in list

Scenario: Create contractor with non-unique username and pcc id
 Given Page Create Contractor is displayed
	When admin enters invalid data for new contractor
	And clicks on button create
	Then Error messages are displayed

Scenario: Create contractor with empty fields
 Given Create Contractor is displayed
	When leave fields empty
	And admin clicks on create button on create contractor page
	Then Error messages are displayed on the page