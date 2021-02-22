using AngloAmerican.SDET.UITest.Common.Extensions;
using AngloAmerican.SDET.UITest.Common.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using AngloAmerican.SDET.UITest.Common.Config;
using System;
using System.Collections.Generic;

namespace AngloAmerican.SDET.UITest.Pages
{
   public class CreateAccountPage:BasePage
    {
        #region Web Elements              
        [FindsBy(How = How.Name, Using = "firstname")]
        private IWebElement FirstNameInputBox { get; set; }
        [FindsBy(How = How.Name, Using = "lastname")]
        private IWebElement LastNameInputBox { get; set; }        
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement EmailInputBox { get; set; }

        [FindsBy(How = How.Name, Using = "telephone")]
        private IWebElement TelephoneNumInputBox { get; set; }
        [FindsBy(How = How.Name, Using = "address_1")]
        private IWebElement AddressLine1InputBox { get; set; }
        [FindsBy(How = How.Name, Using = "city")]
        private IWebElement CityInputBox { get; set; }
        [FindsBy(How = How.Name, Using = "zone_id")]
        private IWebElement RegionDropDownList { get; set; }
        [FindsBy(How = How.Name, Using = "postcode")]
        private IWebElement ZipCodeInputBox { get; set; }
        [FindsBy(How = How.Name, Using = "country_id")]
        private IWebElement CountryDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "AccountFrm_loginname")]
        private IWebElement LoginNameInputName { get; set; }
        [FindsBy(How = How.Id, Using = "AccountFrm_password")]
        private IWebElement PasswordInputBox { get; set; }
        [FindsBy(How = How.Id, Using = "AccountFrm_confirm")]
        private IWebElement ConfirmPasswordInputBox { get; set;}

        [FindsBy(How = How.Id, Using = "AccountFrm_newsletter1")]
        private IWebElement SubscribeNewsLetterYesRadioButton { get; set; }
        [FindsBy(How = How.Id, Using = "AccountFrm_newsletter0")]
        private IWebElement SubscribeNewsLetterNoButton { get; set; }
        [FindsBy(How = How.Id, Using = "AccountFrm_agree")]
        private IWebElement PrivacyPolicyCheckBox { get; set;}
        [FindsBy(How = How.XPath, Using = "//button[@title='Continue']")]
        private IWebElement ContinueButton { get; set; }        
        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-error alert-danger']")]
        private IWebElement ConsolidatedErrorMessage { get; set; }



        #endregion

        #region Actions
        public AccountCreatedSuccessPage CreateCustomerAccount(string customerType,string firstName, string lastName, string emailId,
            string telephoneNum, string addressLine1, string cityName, string regionName, string zipCode, string countryName,string loginName,
            string subscribeNewsLetterFlag)
        {
            WebElementExtensions.SendKeys(FirstNameInputBox, firstName);
            WebElementExtensions.SendKeys(LastNameInputBox, lastName);
            WebElementExtensions.SendKeys(EmailInputBox, emailId);
            WebElementExtensions.SendKeys(TelephoneNumInputBox, telephoneNum);
            WebElementExtensions.SendKeys(AddressLine1InputBox, addressLine1);
            WebElementExtensions.SendKeys(CityInputBox, cityName);
            WebElementExtensions.SelectDropDownOptionByText(RegionDropDownList, regionName);
            WebElementExtensions.SendKeys(ZipCodeInputBox, zipCode);
            WebElementExtensions.SelectDropDownOptionByText(CountryDropDownList, countryName);
            if (customerType.ToLower() == "newcustomer")
            {
                WebElementExtensions.SendKeys(LoginNameInputName, loginName);
                WebElementExtensions.SendKeys(PasswordInputBox, ConfigSetUp.Config.UserPassword);
                WebElementExtensions.SendKeys(ConfirmPasswordInputBox, ConfigSetUp.Config.UserPassword);
                if (bool.Parse(subscribeNewsLetterFlag)) WebElementExtensions.Click(SubscribeNewsLetterYesRadioButton);
                WebElementExtensions.Click(PrivacyPolicyCheckBox);
            }
            WebElementExtensions.Click(ContinueButton);

            return InstanceOf<AccountCreatedSuccessPage>();
        }

        public void CreateCustomerAccountWithEmptyData()
        {
            WebElementExtensions.Click(PrivacyPolicyCheckBox);
            JavaScriptExtensions.ScrollToBottom();
            WebElementExtensions.Click(ContinueButton);
        }

        public AddressBookPage AddNewAddress(string firstName, string lastName, string addressLine1,
            string cityName, string regionName, string zipCode, string countryName)
        {
            WebElementExtensions.SendKeys(FirstNameInputBox, firstName);
            WebElementExtensions.SendKeys(LastNameInputBox, lastName);
            WebElementExtensions.SendKeys(AddressLine1InputBox, addressLine1);
            WebElementExtensions.SendKeys(CityInputBox, cityName);
            WebElementExtensions.SelectDropDownOptionByText(RegionDropDownList, regionName);
            WebElementExtensions.SendKeys(ZipCodeInputBox, zipCode);
            WebElementExtensions.SelectDropDownOptionByText(CountryDropDownList, countryName);
            WebElementExtensions.Click(ContinueButton);
            return InstanceOf<AddressBookPage>();
        }

        //To make email unique and ensure tests are running smoothly in pipeline a random test user email is generated
        public string RandomEmailBuilder()
        {
            var random = new Random();
            int num = random.Next(1000);
            string emailId = "testuser" + num + "@testmail.com";
            string loginName = emailId.Split('@')[0];
            return emailId;
        }
        public string[] GetConsolidatedErrorMessage()
        {
            string[] splitedErrorMessage = ConsolidatedErrorMessage.Text.Split('×');
            var splitedErrorMessageList = splitedErrorMessage[1].Split("\n");  
            return splitedErrorMessageList;
        }

        public List<string> GetExepectedErrorMessage()
        {
            List<string> expectedErrorMessages = new List<string>
            {
            "\r",
            "Login name must be alphanumeric only and between 5 and 64 characters!",
            "First Name must be between 1 and 32 characters!",
            "Last Name must be between 1 and 32 characters!",
            "Email Address does not appear to be valid!",
            "Address 1 must be between 3 and 128 characters!",
            "City must be between 3 and 128 characters!",
            "Zip/postal code must be between 3 and 10 characters!",
            "Please select a region / state!",
            "Password must be between 4 and 20 characters!"
            };            
            return expectedErrorMessages;

        }
        #endregion
    }
}