Feature: Edit Contractor
	In order to test if Edit contractor form works
	As admin
	I want to be able to edit contractor

Scenario:  Edit Contractor
Given Log in with admin credentials
And Edit contractor page is displayed
	When admin enters  data
	And active checkbox is checked
	And clicks on save button
	Then edit page is redirected to list page
	And edited contractor is visible in list
	When admin clicks on Edit in list of contractors
	Then Changed data is displayed in Edit form
	When active checkbox is not checked
	And admin clicks on save button
	Then page is redirected to contractor list page
	And edited contractor is not visible in list