using AngloAmerican.SDET.UITest.Common.Extensions;
using AngloAmerican.SDET.UITest.Common.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AngloAmerican.SDET.UITest.Pages
{
    public class OrderConfirmationPage : BasePage
    {
        public static readonly string expectedOrderConfirmationMessage = "YOUR ORDER HAS BEEN PROCESSED!";
        #region Web Elements
        [FindsBy(How = How.XPath, Using = "//h1[@class='heading1']/span[@class='maintext']")]
        private IWebElement OrderCreatedSuccessMessage { get; set; }
        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Your order #')]")]
        private IWebElement InvoicePageLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[text()='invoice page']")]
        private IWebElement OrderNumberCreatedMessage { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@title='Continue']")]
        private IWebElement ContinueButton { get; set; }
        #endregion

        #region Actions
        public string GetOrderConfirmationMessage => OrderCreatedSuccessMessage.Text;
        public string GetOrderNumber => OrderNumberCreatedMessage.Text.Substring(12,3);
        public HomePage CompletCheckoutJourney()
        {
            WebElementExtensions.Click(ContinueButton);
            return InstanceOf<HomePage>();
        }

        public OrderDetailsPage ViewInvoice()
        {
            WebElementExtensions.Click(InvoicePageLink);
            return InstanceOf<OrderDetailsPage>();
        }
        #endregion
    }
}