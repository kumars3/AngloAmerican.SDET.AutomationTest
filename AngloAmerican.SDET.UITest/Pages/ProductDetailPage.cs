using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using AngloAmerican.SDET.UITest.Common.Pages;
using AngloAmerican.SDET.UITest.Common.Extensions;

namespace AngloAmerican.SDET.UITest.Pages
{
    public class ProductDetailPage: BasePage
    {
        #region Web Elements
        [FindsBy(How = How.XPath, Using = "//a[@class='cart']")]
        private IWebElement ProductCartButton { get; set; }
        #endregion

        #region Actions
        public void AddProductIntoBasket()
        {
          WebElementExtensions.Click(ProductCartButton);          
        }
        #endregion
    }
}