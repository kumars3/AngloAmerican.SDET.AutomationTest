using AngloAmerican.SDET.UITest.Common.Extensions;
using AngloAmerican.SDET.UITest.Common.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AngloAmerican.SDET.UITest.Pages
{
    public class CheckoutConfirmationPage: BasePage
    {
        public static readonly string expectedCheckoutMessage = "CHECKOUT CONFIRMATION";
        #region Web Elements
        [FindsBy(How = How.Id, Using = "checkout_btn")]
        private IWebElement ConfirmOrderButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//h1[@class='heading1']/span[@class='maintext']")]
        private IWebElement CheckOutMessage { get; set; }

        [FindsBy(How = How.Id, Using = "back")]
        private IWebElement BackButton { get; set; }

        #endregion

        #region Actions

        public string GetCheckOutMessage => CheckOutMessage.Text;
        public OrderConfirmationPage ConfirmOrder()
        {
            WebElementExtensions.Click(ConfirmOrderButton);
            return InstanceOf<OrderConfirmationPage>();
        }
        #endregion
    }
}