using AngloAmerican.SDET.UITest.Common.Extensions;
using AngloAmerican.SDET.UITest.Common.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AngloAmerican.SDET.UITest.Pages
{
    public class MyBasketPage: BasePage
    {
        #region Web Elements
        [FindsBy(How = How.Id, Using = "cart_checkout2")]
        private IWebElement CheckoutButtonTwo { get; set; }
        #endregion

        #region Actions
        public CheckoutConfirmationPage CheckoutAndBuyProudct()
        {
            JavaScriptExtensions.ScrollToBottom();
            WebElementExtensions.Click(CheckoutButtonTwo);
            return InstanceOf<CheckoutConfirmationPage>();
        }
        #endregion
    }
}