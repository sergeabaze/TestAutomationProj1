Feature: OnLigneShoppingUserRegistration
	In order to do online transaction
	As an unregistered user of the web site
	I want to register to website

@mytag
Scenario: Register new user
	Given user it at home page
	And navigate to register page
	When user enter valide valide email password and confirm password
	And click on signin button
	Then user navigate to user account
	When user logout from user account
	Then myaccount link should not be displayed
