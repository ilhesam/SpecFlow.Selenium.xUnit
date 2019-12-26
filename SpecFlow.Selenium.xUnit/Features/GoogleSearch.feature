Feature: GoogleSearch
	In order to avoid mistake in search

Scenario: Search Text
		The text inside the search field does not change
	Given I going to the "https://google.com" home page
	When I enter a text "for example" to search
	And I click on the search button
	Then The text inside the search field should not be changed