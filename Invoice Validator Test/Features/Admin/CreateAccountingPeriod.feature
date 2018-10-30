Feature: Create Accounting Period
	In order to test if Create Accounting period form works
	As admin
	I want to be able to create accounting period

Background:  Login as Admin
Given Login with admin credentials

Scenario: Create Accounting period with active checkbox
Given Create Accounting page is displayed
	When admin enters valid data for new accounting period and leave checkbox checked
	And admin clicks on button create
	Then page is redirected to Accounting periods list page
	And new accounting period is displayed in list as active

Scenario: Create Accounting period with inactive checkbox
 Given Page Create Accounting period is displayed
	When admin enters valid data in create accounting period form
	And admin uncheck Active checkbox
	And admin clicks on create
	Then page is redirected to List of Accounting periods page
	Then new accounting period is displayed in list as inactive

Scenario: Create Accounting period with invalid year and date format
 Given Page Create Accounting period with Create form is displayed
	When admin enters invalid data in create accounting period form
	And admin clicks on create button
    Then expected messages are displayed


Scenario: Create Accounting period with empty fields
 Given Page Create with Create Accounting period form is displayed
	When admin leaves fields empty
    Then expected error messages are displayed