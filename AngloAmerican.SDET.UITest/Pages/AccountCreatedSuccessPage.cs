using AngloAmerican.SDET.UITest.Common.Extensions;
using AngloAmerican.SDET.UITest.Common.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AngloAmerican.SDET.UITest.Pages
{
    public class AccountCreatedSuccessPage:BasePage
    {
        public static readonly string expectedAccountCreatedConfirmationMessage = "YOUR ACCOUNT HAS BEEN CREATED!";
        #region Web Elements
        [FindsBy(How = How.XPath, Using = "//h1[@class='heading1']/span[1]")]
        private IWebElement AccountCreatedSuccessMessage { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@class='top menu_account']/div[1]")]
        private IWebElement UserWelcomeMessageAtTopMenu { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@title='Continue']")]
        private IWebElement ContinueButton { get; set; }
        #endregion

        #region Actions
        public string GetAccountCreatedSuccessMessage => AccountCreatedSuccessMessage.Text;
        public string GetUserWelcomeMessage => UserWelcomeMessageAtTopMenu.Text;

        public MyAccountPage NavigateToBasketPage()
        {
            WebElementExtensions.Click(ContinueButton);
            return InstanceOf<MyAccountPage>();
        }
        #endregion
    }
}