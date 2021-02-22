using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using AngloAmerican.SDET.UITest.Common.Selenium;
using AngloAmerican.SDET.UITest.Common.Pages;
using AngloAmerican.SDET.UITest.Common.Extensions;
using System;

namespace AngloAmerican.SDET.UITest.Pages
{
    public class ProductListPage: BasePage
    {
        #region Web Elements
        [FindsBy(How = How.Id, Using = "sort")]
        private IWebElement SortByDropDown { get; set; }
        [FindsBy(How = How.ClassName, Using = "pricenew")]
        private IWebElement NewPriceLabel { get; set; }
        [FindsBy(How = How.ClassName, Using = "priceold")]
        private IWebElement OldPriceLabel { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@class='block_7']/ul/li/a")]
        private IWebElement OutOfStockLabel { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[text()='Out of Stock']")]
        private IWebElement BasketItemsDropDown { get; set; }
        [FindsBy(How = How.ClassName, Using = "btn call_to_order")]
        private IWebElement CallToOrderButton { get; set; }
        [FindsBy(How = How.Id, Using = "limit")]
        private IWebElement PaginationDropDownList { get; set; }
        [FindsBy(How = How.XPath, Using = "//form[@class='form-inline pull-left']")]
        private IWebElement PaginationSummary { get; set; }
        private static IWebElement ProductName(int productIndex) => Drivers.WebDriver().FindElement(By.XPath($"//div[@class='thumbnails grid row list-inline']/div[{productIndex}]/div[1]/div[1]/a"));
        private IList<IWebElement> ProductNameList => Drivers.WebDriver().FindElements(By.XPath("//div[@class='thumbnails grid row list-inline']/div"));
        private static IWebElement ProductCartButton(int productIndex) => Drivers.WebDriver().FindElement(By.XPath($"//div[@class='thumbnails grid row list-inline']/div[{productIndex}]/div[2]/div[3]/a"));
        private IList<IWebElement> AvailableProductCartButton => Drivers.WebDriver().FindElements(By.XPath("//div[@class='pricetag jumbotron']/a[@title='Add to Cart']"));
        private IList<IWebElement> AvailablePriceTaggedProduct => Drivers.WebDriver().FindElements(By.XPath("//div[@class='pricetag jumbotron']"));
        private IList<IWebElement> NewPriceList = Drivers.WebDriver().FindElements(By.ClassName("pricenew"));
        private IList<IWebElement> OldPriceList = Drivers.WebDriver().FindElements(By.ClassName("priceold"));
        #endregion

        #region Actions
        public void AddProductIntoBasket()
        {
            for (int i = 1; i < ProductNameList.Count; i++)
            {
                string className = ProductName(i).GetAttribute("class");
                bool isProuductOutOfStock = className.Equals("btn call_to_order");
                
                if (!isProuductOutOfStock && ProductName(i).Enabled)
                {
                    WebElementExtensions.Click(ProductCartButton(i));
                    break;
                }
            }
         }

        public void AddProductIntoBasketFromProductList()
        {
            for (int i = 0; i < 2; i++)
            {
                WebElementExtensions.Click(AvailableProductCartButton[i]);
            }
        }
        
        public ProductDetailPage NavigateToProductDetailPage()
        {
            for (int i = 1; i < ProductNameList.Count; i++)
            {
               string className = ProductName(i).GetAttribute("class");
                bool isProuductOutOfStock = className.Equals("btn call_to_order");
                if (!isProuductOutOfStock)
                {
                    WebElementExtensions.Click(ProductName(i));
                    break;
                }
            }
            return InstanceOf<ProductDetailPage>();
        }

        public void FilterProductsPerPage(string numberOfProductsPerPage)
        {
            JavaScriptExtensions.ScrollToBottom();
            WebElementExtensions.SelectDropDownOptionByText(PaginationDropDownList, numberOfProductsPerPage);
            JavaScriptExtensions.ScrollToBottom();
        }

        public int GetTotalNumberOfProductInProductList()
        {
            return AvailablePriceTaggedProduct.Count;
        }

        public int GetNumberOfProductInPaginationSummary()
        {
            string[] paginationSummary = PaginationSummary.Text.Split(null);
            int totalNumberofProductDisplayed = Convert.ToInt32(paginationSummary[42]);
            return totalNumberofProductDisplayed;
        }

        public void SortProductList(int sortingIndex)
        {
            WebElementExtensions.SelectDropDownOptionByIndex(SortByDropDown, sortingIndex);
        }
        #endregion
    }
}