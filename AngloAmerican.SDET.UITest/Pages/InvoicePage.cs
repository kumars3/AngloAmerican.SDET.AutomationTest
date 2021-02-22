using AngloAmerican.SDET.UITest.Common.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AngloAmerican.SDET.UITest.Pages
{
    public class InvoicePage : BasePage
    {
        #region
        private IWebElement ContinueButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='maincontainer']/div/div[1]/div/div/div[1]/table/tbody/tr/td[1]")]
        private IWebElement OrderDetails { get; set; }
        [FindsBy(How = How.XPath, Using = "//td[text()='Total:']/following-sibling::td")]
        private IWebElement TotalAmount { get; set; }
        #endregion

        #region Actions
        public string GetTotalAmount()
        {
            string totalAmount = TotalAmount.Text;
            return totalAmount;
        }
        public string GetOrderNumber()
        {
            string[] orderDetailList = OrderDetails.Text.Split(null);
            string orderNumber = orderDetailList[3].Substring(1, 3);
            return orderNumber;
        }
        #endregion
    }
}