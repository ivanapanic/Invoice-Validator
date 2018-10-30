Feature: Created Claim Present In The Claims List
	In order to test if Contractor's Created claim is present in 
	Admin's Contractor claims list



Scenario: Create claim and check Claims list using search form
Given User is logged in as contractor
And Contractor Home page is displayed
     When contractor enters data in create claim form
	 And clicks Create button on create claim page 
	 And contractor clicks on sign out button
	 Then page is redirected to login page
	 When user logs in as admin
	 And redirect page to Contractor claims page 
	 And admin enters data for filtering claim
	 Then contractors's created claim is displayed in list
	 When admin enters data for searching claim
	 Then created claim is displayed in list

