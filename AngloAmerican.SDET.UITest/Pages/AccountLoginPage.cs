using AngloAmerican.SDET.UITest.Common.Extensions;
using AngloAmerican.SDET.UITest.Common.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using AngloAmerican.SDET.UITest.Common.Config;

namespace AngloAmerican.SDET.UITest.Pages
{
    public class AccountLoginPage: BasePage
    {
        #region Web Elements
        [FindsBy(How = How.Id, Using = "accountFrm_accountregister")]
        private IWebElement RegisterAccountRadioButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@title='Continue']")]
        private IWebElement ContinueButton { get; set; }
        [FindsBy(How = How.Id, Using = "accountFrm_accountguest")]
        private IWebElement GuestCheckoutRadioButton { get; set; }
        [FindsBy(How = How.Id, Using = "loginFrm_loginname")]
        private IWebElement LoginNameInputBox { get; set; }
        [FindsBy(How = How.Id, Using = "loginFrm_password")]
        private IWebElement PasswordInputBox { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@title='Login']")]
        private IWebElement LoginButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Forgot your password?']")]
        private IWebElement ForgotPasswordLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[text()='Forgot your login?']")]
        private IWebElement ForgotLoginLink { get; set; }
        #endregion

        #region Actions
        public CreateAccountPage NavigateToCreateAccountPage()
        {
            if (RegisterAccountRadioButton.GetAttribute("checked").ToLower() != "checked")
           WebElementExtensions.Click(RegisterAccountRadioButton);
            WebElementExtensions.Click(ContinueButton);
            return InstanceOf<CreateAccountPage>();
        }
        public MyAccountPage LoginToMyAccount(string emialId)
        {
            string loginName = emialId.Split('@')[0];
            WebElementExtensions.SendKeys(LoginNameInputBox, loginName);
            WebElementExtensions.SendKeys(PasswordInputBox, ConfigSetUp.Config.UserPassword);
            WebElementExtensions.Click(LoginButton);
            return InstanceOf<MyAccountPage>();
        }

        public CreateAccountPage CreateAnAccountForGuestUser()
        {
            WebElementExtensions.Click(GuestCheckoutRadioButton);
            WebElementExtensions.Click(ContinueButton);
            return InstanceOf<CreateAccountPage>();
        }
        #endregion
    }
}