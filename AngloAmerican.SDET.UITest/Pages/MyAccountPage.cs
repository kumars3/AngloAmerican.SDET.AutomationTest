using AngloAmerican.SDET.UITest.Common.Extensions;
using AngloAmerican.SDET.UITest.Common.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AngloAmerican.SDET.UITest.Pages
{
    public class MyAccountPage:BasePage
    {
        #region Web Elements
        [FindsBy(How = How.XPath, Using = "//a[@title = 'Order history']")]
        private IWebElement OrderHistoryButton {get; set; }
        [FindsBy(How = How.XPath, Using = "//ul[@class='nav-dash']/li[3]/a")]
        private IWebElement ManageAddressBookLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-original-title='Manage Address Book' and @class='btn']")]
        private IWebElement ManageAddressBookButton { get; set; }
        #endregion

        #region Actions
        public OrderHistoryPage NavigateToOrderHistoryPage()
        {
            WebElementExtensions.Click(OrderHistoryButton);
            return InstanceOf<OrderHistoryPage>();
        }
        public AddressBookPage NavigateToAddressBookPage()
        {
            WebElementExtensions.Click(ManageAddressBookButton);
            return InstanceOf<AddressBookPage>();
        }


        #endregion
    }
}