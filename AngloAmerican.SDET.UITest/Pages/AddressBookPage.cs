using AngloAmerican.SDET.UITest.Common.Extensions;
using AngloAmerican.SDET.UITest.Common.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AngloAmerican.SDET.UITest.Pages
{
    public class AddressBookPage : BasePage
    {
        public static readonly string expectedNewAddressUpdateMessage = "Your address has been successfully inserted";
        #region Web Elements
        [FindsBy(How = How.XPath, Using = "//button[@title = 'Edit']")]
        private IWebElement EditButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@title = 'New Address']")]
        private IWebElement NewAddressButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-success']")]
        private IWebElement NewAddressUpdateSuccessMessage { get; set; }
        #endregion

        #region Actions
        public CreateAccountPage NavigateToMyAddressBook()
        {
            WebElementExtensions.Click(NewAddressButton);
            return InstanceOf<CreateAccountPage>();
        }

        public string GetNewAddressUpdateSuccessMessage()
        {   string[] splitedSuccessMessage = NewAddressUpdateSuccessMessage.Text.Split('×');
            string formatedActualSuccessMessage = splitedSuccessMessage[1].Trim();
            return formatedActualSuccessMessage;
        }
        #endregion
    }
}