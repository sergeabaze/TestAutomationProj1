Feature: InvalideLogin
	In order to restrict the access to the userprofile
    as a non registered user of web site i should not be able to
    log into the website

@mytag
Scenario: Echec Login avec Parametres Invalides
	Given Utilisateur sur la Page Accueille
	And Navigation vers la page Login
	When Utilisateur entre le mot de passe et login incorrect
	And Click sur le bouton signin
	Then Message Erreur Afficher au Navigateur
