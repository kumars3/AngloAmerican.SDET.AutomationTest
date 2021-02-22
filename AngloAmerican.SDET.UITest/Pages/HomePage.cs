using AngloAmerican.SDET.UITest.Common.Extensions;
using AngloAmerican.SDET.UITest.Common.Pages;
using AngloAmerican.SDET.UITest.Common.Selenium;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AngloAmerican.SDET.UITest.Pages
{
    public class HomePage : BasePage
    {
        #region Web Elements
        [FindsBy(How = How.XPath, Using = "//a[text()='Login or register']")]
        private IWebElement LoginLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//a/span[text()='Account']")]
        private IWebElement MyAccountLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//ul[@id='main_menu_top']/li/a[@class='top menu_specials']")]
        private IWebElement SpecialsMenuLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//ul[@id='main_menu_top']/li[2]/ul/li[1]/a")]
        private IWebElement CheckYourOrderLinkLogedInUser { get; set; }
        [FindsBy(How = How.XPath, Using = "//ul[@id='main_menu_top']/li[2]/ul/li[2]/a")]
        private IWebElement SearchInputBox { get; set; }
        [FindsBy(How = How.Id, Using = "filter_keyword")]
        private IWebElement SearchButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@title='Go")]
        private IWebElement CheckYourOrderLinkLogedOutUser { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@class='block_6']")]
        public IWebElement GbpCurrencyOption { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@class='block_7']/ul/li/a")]
        public IWebElement BasketItemsDropDown { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[text()='Home']")]
        private IWebElement HomeMenuLink { get; set; }
       private IWebElement ProductBrandLink(string productBrand) => Drivers.WebDriver().FindElement(By.XPath($"//a/img[@alt='{productBrand}']"));
        private static IWebElement ProductCategoryMenu(string productCode) => Drivers.WebDriver().FindElement(By.XPath($"//section[@id='categorymenu']/nav/ul/li[{productCode}]/a"));
        #endregion

        #region Actions
        public AccountLoginPage NavigateToAccountLoginPage()
        {
            WebElementExtensions.Click(LoginLink);
            return InstanceOf<AccountLoginPage>();
        }

        public MyAccountPage NavigateToMyAccountPage()
        {
            WebElementExtensions.Click(MyAccountLink);
            return InstanceOf<MyAccountPage>();
        }

        public ProductListPage NavigateToSaleProuductList()
        {
            WebElementExtensions.Click(SpecialsMenuLink);
            return InstanceOf<ProductListPage>();                
        }

        public OrderHistoryPage NavigateToOrderHistoryPage()
        {
            WebElementExtensions.Click(CheckYourOrderLinkLogedInUser);
            return InstanceOf<OrderHistoryPage>();        
        }

        public OrderDetailsPage NavigateToOrderDetailsPage()
        {
            WebElementExtensions.Click(CheckYourOrderLinkLogedOutUser);
            return InstanceOf<OrderDetailsPage>();
        }

        public ProductListPage NavigateToBrandProductListPage(string productBrand)
        {
            JavaScriptExtensions.ScrollToBottom();
            WebElementExtensions.Click(ProductBrandLink(productBrand));
            return InstanceOf<ProductListPage>();
        }

        public ProductListPage SearchAProudct(string keyWord)
        {

            WebElementExtensions.SendKeys(SearchInputBox, keyWord,true,2);
            WebElementExtensions.Click(SearchButton);
            return InstanceOf<ProductListPage>();        
        }

        public ProductListPage NavigateToProductCategoryProductListPage(string productCategory)
        {
            string productCategoryIndexAtMenuBar = productCategory.Split('-')[1];
            WebElementExtensions.Click(ProductCategoryMenu(productCategoryIndexAtMenuBar));
            return InstanceOf<ProductListPage>();
        }

        public MyBasketPage ViewMyBasket()
        {
            JavaScriptExtensions.ScrollToTop();
            WebElementExtensions.Click(BasketItemsDropDown);
            return InstanceOf<MyBasketPage>();
        }
        #endregion
    }
}
