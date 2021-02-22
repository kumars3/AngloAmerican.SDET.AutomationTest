using AngloAmerican.SDET.UITest.Common.ContextInjection;
using AngloAmerican.SDET.UITest.Common.Helper;
using AngloAmerican.SDET.UITest.Common.Pages;
using AngloAmerican.SDET.UITest.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AngloAmerican.SDET.UITest.Steps
{
    [Binding]
    public class ValidationSteps:BasePage
    {
        public CommonContext _commonContext;

        public ValidationSteps(CommonContext commonContext)
        {
            _commonContext = commonContext;
        }

        [Then(@"the new customer account is created successfully")]
        public void ThenTheNewCustomerAccountIsCreatedSuccessfully()
        {
            if (_commonContext.CustomerType.ToLower() == "newcustomer")
            {
                var expectedUserWelcomeMessage = "Welcome back " + _commonContext.UserFirstName;
                InstanceOf<AccountCreatedSuccessPage>().GetAccountCreatedSuccessMessage.Trim().Should().Be(AccountCreatedSuccessPage.expectedAccountCreatedConfirmationMessage.Trim());
                InstanceOf<AccountCreatedSuccessPage>().GetUserWelcomeMessage.Trim().Should().Be(expectedUserWelcomeMessage.Trim());
            }
            else
            {
                InstanceOf<CheckoutConfirmationPage>().GetCheckOutMessage.Trim().Should().Be(CheckoutConfirmationPage.expectedCheckoutMessage.Trim());
            }
        }

        [Then(@"My order is created successfully")]
        public void ThenMyOrderIsCreatedSuccessfullyAndIsListedInMyOrderHistory()
        {
            InstanceOf<OrderConfirmationPage>().GetOrderConfirmationMessage.Trim().Should().Be(OrderConfirmationPage.expectedOrderConfirmationMessage.Trim());
            if (_commonContext.CustomerType.ToLower() == "newcustomer")
            {
                _commonContext.OrderNumber = InstanceOf<OrderConfirmationPage>().GetOrderNumber;
            }            
            CaptureTestEvidence.TakeScreenShot(_commonContext);
        }

        [Then(@"My order is listed in order history page")]
        public void ThenMyOrderIsListedInOrderHistoryPage()
        {
           InstanceOf<OrderHistoryPage>().GetOrderNumber().Should().Be(_commonContext.OrderNumber);
        }

        [Then(@"(.*) is displayed in my order history")]
        public void ThenIsDisplayedInMyOrderHistory(string orderNumber)
        {
            InstanceOf<OrderHistoryPage>().GetAllOrderHistoryData().Should().Contain("Order ID: #"+orderNumber);
            CaptureTestEvidence.TakeScreenShot(_commonContext);
        }

        [Then(@"The order is displayed in my order detail page")]
        public void ThenTheOrderIsplayedInMyOrderDetailPage()
        {
            InstanceOf<OrderDetailsPage>().GetOrderNumber().Should().Be(_commonContext.OrderNumber);
            CaptureTestEvidence.TakeScreenShot(_commonContext);
        }

        [Then(@"My (.*) is displayed in my order detail page")]
        public void ThenMyOrderIsplayedInMyOrderDetailPage(string orderNumber)
        {
            InstanceOf<OrderDetailsPage>().GetOrderNumber().Should().Be(orderNumber);
            CaptureTestEvidence.TakeScreenShot(_commonContext);
        }

        [Then(@"the number of records are displayed correctly")]
        public void ThenTheNumberOfRecordsAreDisplayedCorrectly()
        {
            int actualCount = InstanceOf<ProductListPage>().GetNumberOfProductInPaginationSummary();
            int expectedCount = InstanceOf<ProductListPage>().GetTotalNumberOfProductInProductList();
            actualCount.Should().Be(expectedCount);
            CaptureTestEvidence.TakeScreenShot(_commonContext);
        }

        [Then(@"the new address is added successfully")]
        public void ThenTheNewAddressIsAddedSuccessfully()
        {
            var actualSuccessMessage = InstanceOf<AddressBookPage>().GetNewAddressUpdateSuccessMessage();
            var expectedSuccessMessage = AddressBookPage.expectedNewAddressUpdateMessage.Trim();
            actualSuccessMessage.Should().Be(expectedSuccessMessage);
            CaptureTestEvidence.TakeScreenShot(_commonContext);
        }

        [Then(@"the account is not created")]
        public void ThenTheAccountIsNotCreated()
        {
            var actualErrorMessage = InstanceOf<CreateAccountPage>().GetConsolidatedErrorMessage();
            var expectedErrorMessage = InstanceOf<CreateAccountPage>().GetExepectedErrorMessage();

            for (int i = 0; i < expectedErrorMessage.Count; i++)
            {
                actualErrorMessage[i].Trim().Should().Be(expectedErrorMessage[i].Trim());
            }
        }

    }
}