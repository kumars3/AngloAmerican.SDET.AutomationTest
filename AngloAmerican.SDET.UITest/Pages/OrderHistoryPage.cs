using AngloAmerican.SDET.UITest.Common.Extensions;
using AngloAmerican.SDET.UITest.Common.Helper;
using AngloAmerican.SDET.UITest.Common.Pages;
using log4net;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AngloAmerican.SDET.UITest.Pages
{
    public class OrderHistoryPage : BasePage
    {
        private static readonly ILog Logger = ExceptionLogger.GetLogger(typeof(OrderHistoryPage));
        #region Web Elements
        [FindsBy(How = How.XPath, Using = "//div[@class='contentpanel']/div[1]/div[1]")]
        private IWebElement OrderIdLabel { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@class='contentpanel']")]
        private IWebElement AllOrderHistoryData { get; set; }

        [FindsBy(How = How.Id, Using = "button_edit")]
        private IWebElement ViewButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@title='Continue']")]
        private IWebElement ContinueButton { get; set; }
        #endregion

        #region Actions
        public string GetOrderNumber()
        {
            string orderNumber = OrderIdLabel.Text.Substring(11, 3);
            return orderNumber;
        }

        public string GetAllOrderHistoryData()
        {           
           return AllOrderHistoryData.Text;
        }
        public OrderDetailsPage NavigateToOrderDetailsPage()
        {
            WebElementExtensions.Click(ViewButton);
            return InstanceOf<OrderDetailsPage>();        
        }
        #endregion
    }
}