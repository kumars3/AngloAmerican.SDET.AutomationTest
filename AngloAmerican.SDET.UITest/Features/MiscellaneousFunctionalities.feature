Feature: MiscellaneousFunctionalities
	In order buy a product at Automation Test Store
	As an automation teser I want to ensure that miscellaneuos functionalites are working correctly
	So that the end customer have smooth chekcout journey

Background:
Given I am on home page
@Chrome
Scenario: Verify pagination summary
	When I search a product Fragrance-5 from proudct category menu
	And I filter the page to display 50 products per page
	Then the number of records are displayed correctly
@Chrome
Scenario Outline:  Add a new address
	When I navigate to account login page
	And I log into my account having <EmailId>
	And I navigate to my address book
	And I click on new address button
	And I change my new address with values <FirstName>,<LastName>,<AddressLine1>,<City>,<Region>,<ZipCode>,<Country>
	Then the new address is added successfully
	Examples:
	| EmailId                | FirstName | LastName | AddressLine1  | City    | Region    | ZipCode | Country        |
	| santosh_uk96@yahoo.com | Nick      | Chambers | 1 Vachel Road | Reading | Berkshire | RG1 1NS | United Kingdon |

@Chrome
@Negative
Scenario Outline: Create a new customer account with empty data
    When I navigate to account login page
	And I continue to register a new customer	
	And I create a customer account with all empty data
	Then the account is not created