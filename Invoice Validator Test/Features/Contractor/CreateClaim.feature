Feature: Create Claim
	In order to test if Create claim works
    As contractor
    I want to be able to Create new claim

Background: Login as Contractor
Given Log in as contractor


Scenario: Create claim with valid data
Given Invoice Validator is displayed
     When contractor enters valid data in create claim form
	 And clicks Create button
	 When page is redirected to Claims list page
	 Then created claim is displayed on top of the list


Scenario: Create claim with invalid data
Given Page Invoice is displayed
     When contractor enters invalid data in create claim form
	 And clicks button Create
	 Then Messages about errors are displayed
