using AngloAmerican.SDET.UITest.Common.ContextInjection;
using AngloAmerican.SDET.UITest.Common.Pages;
using AngloAmerican.SDET.UITest.Pages;
using TechTalk.SpecFlow;

namespace AngloAmerican.SDET.UITest.Steps
{
    [Binding]
    public class CustomerE2ECheckoutJourneySteps:BasePage
    {
        public CommonContext _commonContext;

        public CustomerE2ECheckoutJourneySteps(CommonContext commonContext)
        {
            _commonContext = commonContext;
        }

        [When(@"I navigate to home page")]
        [Given(@"I am on home page")]
        public void GivenIAmOnHomePage()
        {
            InstanceOf<BasePage>().NavigateToHomePage();
        }

        [When(@"I navigate to account login page")]
        public void GivenINavigatToAccountLoginPage()
        {
            InstanceOf<HomePage>().NavigateToAccountLoginPage();            
        }
        
        [When(@"I continue to register a new customer")]
        public void WhenIContinueToRegisterANewCustomer()
        {
            InstanceOf<AccountLoginPage>().NavigateToCreateAccountPage();
        }

        [When(@"I continue to create a guest account")]
        public void WhenIContinueToCreateAGuestAccount()
        {
            InstanceOf<AccountLoginPage>().CreateAnAccountForGuestUser();
        }

        [When(@"I create a customer (.*) account with details (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenICreatANewCustomerAccount(string customerType, string firstName, string lastName,
            string telephoneNum, string addressLine1, string cityName, string regionName, string zipCode, string countryName,
            string subscribeNewsLetterFlag)
        {
            var emailId = InstanceOf<CreateAccountPage>().RandomEmailBuilder();
            var loginName = emailId.Split('@')[0];
            _commonContext.UserEmailId = emailId;
            _commonContext.UserLoginName = loginName;
            _commonContext.UserFirstName = firstName;
            _commonContext.CustomerType = customerType;
            InstanceOf<CreateAccountPage>().CreateCustomerAccount(customerType,firstName, lastName, emailId,
             telephoneNum, addressLine1, cityName, regionName, zipCode, countryName, loginName,
             subscribeNewsLetterFlag);
        }

        [When(@"I log into my account having (.*)")]
        public void WhenILogIntoMyAccount(string emailId)
        {
            InstanceOf<AccountLoginPage>().LoginToMyAccount(emailId);
        }

        [When(@"I add sale product into basket")]
        public void WhenIAddSaleProductIntoBasket()
        {
            InstanceOf<HomePage>().NavigateToSaleProuductList();
            InstanceOf<ProductListPage>().AddProductIntoBasketFromProductList();
        }

        [When(@"I add (.*) product into the basket")]
        public void WhenIAddProductIntoBasket(string productBrand)
        {
            InstanceOf<HomePage>().NavigateToBrandProductListPage(productBrand);
            InstanceOf<ProductListPage>().AddProductIntoBasket();
        }

        [When(@"I add a product into basket from the search list")]
        public void WhenIAddAProductIntoBasketFromTheSearchList()
        {
            InstanceOf<ProductListPage>().AddProductIntoBasket();
        }

        [When(@"I search a proudct (.*) from top search menu bar")]
        public void WhenISearchAProudctShirtFromTopSearchMenuBar(string keyWord)
        {
            InstanceOf<HomePage>().SearchAProudct(keyWord);
        }

        [When(@"I search a product (.*) from proudct category menu")]
        public void WhenISearchAProductFromProudctCategoryMenu(string productCategory)
        {
            InstanceOf<HomePage>().NavigateToProductCategoryProductListPage(productCategory);
        }

        [When(@"I checkout from my basket")]
        public void WhenICheckoutFromMyBasket()
        {
            InstanceOf<HomePage>().ViewMyBasket();
            InstanceOf<MyBasketPage>().CheckoutAndBuyProudct();
        }

        [When(@"I confirm my order")]
        public void WhenIConfirmMyOrder()
        {
            InstanceOf<CheckoutConfirmationPage>().ConfirmOrder();
        }

        [When(@"I navigate to my order history page")]
        public void WhenINavigateToMyOrderHistoryPage()
        {
            InstanceOf<HomePage>().NavigateToMyAccountPage();
            InstanceOf<MyAccountPage>().NavigateToOrderHistoryPage();
        }

        [When(@"I navigate to my order details page")]
        public void WhenINavigateToMyOrderDetailsPage()
        {
            if (_commonContext.CustomerType.ToLower() == "newcustomer" || _commonContext.CustomerType.ToLower() == null)
            {
                InstanceOf<OrderHistoryPage>().NavigateToOrderDetailsPage();
            }
            else
            {
                InstanceOf<OrderConfirmationPage>().ViewInvoice();                
            }
        }

        [When(@"I filter the page to display (.*) products per page")]
        public void WhenIFilterThePageToDisplayProductsPerPage(string numberOfProductsPerPage)
        {
            InstanceOf<ProductListPage>().FilterProductsPerPage(numberOfProductsPerPage);
            InstanceOf<ProductListPage>().GetTotalNumberOfProductInProductList();
            InstanceOf<ProductListPage>().GetNumberOfProductInPaginationSummary();
        }

        [When(@"I sort product list based on (.*)")]
        public void WhenISortProductListBasedOn(int sortingIndex)
        {
            InstanceOf<ProductListPage>().SortProductList(sortingIndex);
        }

        [When(@"I navigate to my address book")]
        public void WhenINavigateToMyAddressBook()
        {
            InstanceOf<MyAccountPage>().NavigateToAddressBookPage();            
        }

        [When(@"I click on new address button")]
        public void WhenIClickOnNewAddressButton()
        {
            InstanceOf<AddressBookPage>().NavigateToMyAddressBook();
        }

        [When(@"I change my new address with values (.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIChangeMyNewAddressWithValues(string firstName, string lastName, string addressLine1,
            string cityName, string regionName, string zipCode, string countryName)
        {
            InstanceOf<CreateAccountPage>().AddNewAddress(firstName, lastName, addressLine1,
            cityName, regionName, zipCode, countryName);
        }

        [When(@"I create a customer account with all empty data")]
        public void WhenICreateACustomerAccountWithEmptyData()
        {
            InstanceOf<CreateAccountPage>().CreateCustomerAccountWithEmptyData();
        }

    }
}