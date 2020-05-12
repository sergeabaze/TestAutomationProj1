Feature: invalideLogin
	Restreindre laccess au site a nimporte quel
	Utilisateur
	Ne donne que acces aux utilisateurs avec credentials

@mytag
Scenario: Invalide Loggin
	Given User is at the home page
    And Navigate to login page
    When User enter incorrect user name and password
    And Click on the signin button
    Then Validation message should display and browser should close
