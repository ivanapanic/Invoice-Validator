using Invoice_Validator_Test.Pages;
using Invoice_Validator_Test.Pages.Admin;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Invoice_Validator_Test.Steps
{
    [Binding]
    public class InvalidLoginSteps : BaseSteps
    {
        //VARIABLES
        string username = "Username" + GenerateRandomData.GenerateRandomString(5);
        string password = GenerateRandomData.GenerateRandomString(10);
        


        //TEST LOGIN WITH INVALID DATA
        [Given(@"User navigates to Invoice validator web site")]
        public void GivenUserNavigatesToInvoiceValidatorWebSite()
        {
            Driver.Navigate().GoToUrl("https://intnstest:60081/Account/Login/?ReturnUrl=%2F");
        }

        [When(@"user enters invalid data")]
        public void WhenUserEntersInvalidData()
        {
            LoginPage loginPage = new LoginPage(Driver);
            loginPage.UsernameInputField().SendKeys(username);
            loginPage.PasswordInputField().SendKeys(password);
        }

        [When(@"clicks on sign in button")]
        public void WhenClicksOnSignInButton()
        {
            LoginPage loginPage = new LoginPage(Driver);
            loginPage.SignInButton().Click();
        }

        [Then(@"error message is displayed")]
        public void ThenErrorMessageIsDisplayed()
        {
            LoginPage loginPage = new LoginPage(Driver);
            Assert.AreEqual("Invalid username or password.", loginPage.InvalidDataErrorMessage().Text);           
        }


        //TEST LOGIN WITH EMPTY FIELDS
        [Given(@"User navigates to Invoice validator site")]
        public void GivenUserNavigatesToInvoiceValidatorSite()
        {
            Driver.Navigate().GoToUrl("https://intnstest:60081/Account/Login/?ReturnUrl=%2F");
        }

        [When(@"user leaves fields empty")]
        public void WhenUserLeavesFieldsEmpty()
        {
            LoginPage loginPage = new LoginPage(Driver);
            loginPage.UsernameInputField().Clear();
            loginPage.PasswordInputField().Clear();
        }

        [When(@"clicks on button sign in")]
        public void AndClicksOnButtonSignIn()
        {
            LoginPage loginPage = new LoginPage(Driver);
            loginPage.SignInButton().Click();
        }

        [Then(@"error message is displayed on login page")]
        public void ThenErrorMessageIsDisplayedOnLoginPage()
        {
            LoginPage loginPage = new LoginPage(Driver);
            //Assert.AreEqual("You are not present in the system. Please contact administrator.", loginPage.EmptyFieldsErrorMessage().Text);
            Assert.AreEqual("Internal server error", loginPage.EmptyFieldsErrorMessage().Text);
        }
    }
}
