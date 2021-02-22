Feature: CustomerE2ECheckoutJourney
	In order buy a product at Automation Test Store
	As a customer I want to complete my checkout journey
	So that my order is fullfilled and it is listed in my order details

Background:
Given I am on home page

@Chrome
Scenario Outline: Complete the chekcout journey as a new customer
    When I navigate to account login page
	And I continue to register a new customer	
	And I create a customer <CustomerType> account with details <FirstName>,<LastName>,<TelephoneNo>,<AddressLine1>,<City>,<Region>,<ZipCode>,<Country>,<SubscribeNewsLetterFlag>
	Then the new customer account is created successfully
	When I navigate to home page
	And I add <ProductBrand> product into the basket
	And I search a product <ProductCategory> from proudct category menu
	And I sort product list based on <SortingIndex>
	And I add a product into basket from the search list
	And I checkout from my basket
	And I confirm my order
	Then My order is created successfully
	When I navigate to my order history page
	Then My order is listed in order history page
	When I navigate to my order details page
	Then The order is displayed in my order detail page	

	Examples:
	| FirstName | LastName | TelephoneNo | AddressLine1  | City    | Region    | ZipCode | Country        | SubscribeNewsLetterFlag | ProductBrand | ProductCategory | SortingIndex | CustomerType |
	| Santosh   | Kumar    | 01234567891 | 1 Vachel Road | Reading | Berkshire | RG1 1NS | United Kingdon | False                   | Dove         | Fragrance-5     | 3            | NewCustomer  |

@Chrome
Scenario Outline: Complete the chekcout journey as a existing customer
    When I navigate to account login page
	And I log into my account having <EmailId>
	And I add sale product into basket
	And I navigate to home page
	And I add <ProductBrand> product into the basket
	When I search a product <ProductCategory> from proudct category menu
	And I add a product into basket from the search list
	And I checkout from my basket
	And I confirm my order
	Then My order is created successfully
	When I navigate to my order history page
	Then My order is listed in order history page
	When I navigate to my order details page
	Then The order is displayed in my order detail page
	
	Examples:
	| EmailId                | ProductBrand | ProductCategory |
	| santosh_uk96@yahoo.com | Dove         | Fragrance-5     |

@Chrome
Scenario Outline: Complete the chekcout journey as a guest customer
    When I add <ProductBrand> product into the basket
	And I search a product <ProductCategory> from proudct category menu
	And I sort product list based on <SortingIndex>
	And I add a product into basket from the search list
	And I checkout from my basket
	And I continue to create a guest account
	And I create a customer <CustomerType> account with details <FirstName>,<LastName>,<TelephoneNo>,<AddressLine1>,<City>,<Region>,<ZipCode>,<Country>,<SubscribeNewsLetterFlag>
	Then the new customer account is created successfully
	When I confirm my order
	Then My order is created successfully		
	
	Examples:
	| EmailId                | QuanityOfProduct | ProductBrand | ProductCategory | SortingIndex | CustomerType  | FirstName | LastName | TelephoneNo | AddressLine1  | City    | Region    | ZipCode | Country        |
	| santosh_uk96@yahoo.com | 2                | Dove         | MakeUp-3        | 4            | GuestCustomer | Santosh   | Kumar    | 01234567891 | 1 Vachel Road | Reading | Berkshire | RG1 1NS | United Kingdon |

@Chrome
Scenario Outline: Check Order History
    When I navigate to account login page
	And I log into my account having <EmailId>
	And I navigate to my order history page
	Then <OrderNumber> is displayed in my order history
	When I navigate to my order details page
	Then My <OrderNumber> is displayed in my order detail page
	
	Examples:
	| EmailId                | OrderNumber |
	| santosh_uk96@yahoo.com | 404         |