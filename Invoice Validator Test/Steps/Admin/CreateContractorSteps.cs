using Invoice_Validator_Test.Pages;
using Invoice_Validator_Test.Pages.Admin;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static Invoice_Validator_Test.Pages.Admin.CreateContractorPage;

namespace Invoice_Validator_Test.Steps.Admin
{
    class CreateContractorSteps : BaseSteps
    
    {
        //VARIABLES
        string existingUsername = "IQService.contractor1";
        string existingPccId = "81971";


        string username = "Username" + GenerateRandomData.GenerateRandomString(5);
        string pccId = GenerateRandomData.GenerateRandomNumber(5);
        string firstName = "FirstName" + GenerateRandomData.GenerateRandomString(5);
        string lastName = "LastName" + GenerateRandomData.GenerateRandomString(5);


        //LOGIN
        [Given(@"Admin is logged in")]
        public void GivenAdminNavigatesToInvoiceValidatorWebSite()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080/Account/Login/?ReturnUrl=%2F");

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.UsernameInputField().SendKeys("IQService.admin1");
            loginPage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");

            loginPage.SignInButton().Click();

        }


        //TEST CREATE CONTRACTOR WITH VALID DATA
        [Given(@"Admin clicks on Create in Contractor dropdown")]
        public void AdminClicksOnCreateInContractorDropdown()
        {
            AdminHomePage adminHomePage = new AdminHomePage(Driver);
            adminHomePage.ContractorDropdown().Click();
            adminHomePage.ContractorDropdownCreate().Click();
        }

        [Then(@"Create Contractor page is displayed")]
        public void CreateContractorPageIsDisplayed()
        {
            CreateContractorPage createContractorPage = new CreateContractorPage(Driver);
            Assert.That(createContractorPage.IsCreateContractorPageDisplayed, Is.True, "Create Contractor page is not displayed.");
        }

        [When(@"admin enters valid data for new contractor")]
        public void AdminEntersValidDataForNewContractor()
        {
            CreateContractorPage createContractorPage = new CreateContractorPage(Driver);
            createContractorPage.UsernameContractorInputField().SendKeys(username);
            createContractorPage.PCCIdInputField().SendKeys(pccId);
            createContractorPage.FirstNameInputField().SendKeys(firstName);
            createContractorPage.LastNameInputField().SendKeys(lastName);
        }

        [When(@"clicks on create button")]
        public void ClicksOnCreateButton()
        {
            CreateContractorPage createContractorPage = new CreateContractorPage(Driver);
;           createContractorPage.CreateButton().Click();
        }

        [Then(@"page is redirected to list page")]
        public void PageIsRedirectedToListPage()
        {
            ContractorListPage contractorListPage = new ContractorListPage(Driver);
            Assert.That(contractorListPage.IsConractorsListPageDisplayed, Is.True, "Contractors List page is not displayed.");
        }

        [Then(@"new contractor is displayed in list")]
        public void NewContractorIsDisplayedInList()
        {
            ContractorListPage contractorListPage = new ContractorListPage(Driver);
            Assert.AreEqual(username, contractorListPage.Table().FindElement(By.XPath("//td[2][contains(string(), '" + username + "')]")).Text);
        }



        //TEST CREATE CONTRACTOR WITH INVALID DATA
        [Given(@"Admin clicks on Create button in Contractor dropdown")]
        public void AdminClicksOnCreateButtonInContractorDropdown()
        {
            AdminHomePage adminHomePage = new AdminHomePage(Driver);
            adminHomePage.ContractorDropdown().Click();
            adminHomePage.ContractorDropdownCreate().Click();
        }

        [Then(@"Page Create Contractor is displayed")]
        public void PageCreateContractorIsDisplayed()
        {
            CreateContractorPage createContractorPage = new CreateContractorPage(Driver);
            Assert.That(createContractorPage.IsCreateContractorPageDisplayed, Is.True, "Create Contractor page is not displayed.");
        }

        [When(@"admin enters invalid data for new contractor")]
        public void AdminEntersInvalidDataForNewContractor()
        {
            ContractorListPage contractorListPage = new ContractorListPage(Driver);
            CreateContractorPage createContractorPage = new CreateContractorPage(Driver);
            createContractorPage.UsernameContractorInputField().SendKeys(existingUsername);
            createContractorPage.PCCIdInputField().SendKeys(existingPccId);
            createContractorPage.FirstNameInputField().SendKeys(firstName);
            createContractorPage.LastNameInputField().SendKeys(lastName);

        }

        [When(@"clicks on button create")]
        public void ClicksOnButtonCreate()
        {
            CreateContractorPage createContractorPage = new CreateContractorPage(Driver);
            createContractorPage.CreateButton().Click();
        }

        [Then(@"Error messages are displayed")]
        public void ErrorMessagesAreDisplayed()
        {
            CreateContractorPage createContractorPage = new CreateContractorPage(Driver);
            AdminHomePage adminHomePage = new AdminHomePage(Driver);

            //loop for error messages depending on local language
            if (adminHomePage.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual("Username already exsits.", createContractorPage.UsernameErrorMessage().Text);
                Assert.AreEqual("PCC id already exsits.", createContractorPage.PCCIdErrorMessage().Text);
            }
            else
            {
                Assert.AreEqual("Korisničko ime već postoji.", createContractorPage.UsernameErrorMessage().Text);
                Assert.AreEqual("PCC ID već postoji.", createContractorPage.PCCIdErrorMessage().Text);
            }
        }


        //TEST CREATE CONTRACTOR WITH EMPTY FIELDS
        [Given(@"Admin clicks on button Create in Contractor dropdown")]
        public void GivenAdminClicksOnButtonCreateInContractorDropdown()
        {
            AdminHomePage adminHomePage = new AdminHomePage(Driver);
            adminHomePage.ContractorDropdown().Click();
            adminHomePage.ContractorDropdownCreate().Click();
        }

        [Then(@"Create Contractor is displayed")]
        public void ThenCreateContractorIsDisplayed()
        {
            CreateContractorPage createContractorPage = new CreateContractorPage(Driver);
            Assert.That(createContractorPage.IsCreateContractorPageDisplayed, Is.True, "Create Contractor page is not displayed.");
        }

        [When(@"leave fields empty")]
        public void WhenLeaveFieldsEmpty()
        {
            CreateContractorPage createContractorPage = new CreateContractorPage(Driver);
            createContractorPage.UsernameContractorInputField().Clear();
            createContractorPage.PCCIdInputField().Clear();
            createContractorPage.FirstNameInputField().Clear();
            createContractorPage.LastNameInputField().Clear();
        }

        [When(@"admin clicks on create button on create contractor page")]
        public void WhenAdminClicksOnCreateButtonOnCreateContractorPage()
        {
            CreateContractorPage createContractorPage = new CreateContractorPage(Driver);
            createContractorPage.CreateButton().Click();
        }

        [Then(@"Error messages are displayed on the page")]
        public void ThenErrorMessagesAreDisplayedOnThePage()
        {
            CreateContractorPage createContractorPage = new CreateContractorPage(Driver);
            AdminHomePage adminHomePage = new AdminHomePage(Driver);

            //loop for error messages depending on local language
            if (adminHomePage.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual("Input for username is required.", createContractorPage.UsernameEmptyErrorMessage().Text);
                Assert.AreEqual("Input for pcc id is required.", createContractorPage.PCCIdEmptyErrorMessage().Text);
                Assert.AreEqual("Input for first name is required.", createContractorPage.FirstNameEmptyErrorMessage().Text);
                Assert.AreEqual("input for last name is required.", createContractorPage.LastNameEmptyErrorMessage().Text);
            }
            else
            {
                Assert.AreEqual("Unos korisničkog imena je obavezan.", createContractorPage.UsernameEmptyErrorMessage().Text);
                Assert.AreEqual("Unos pcc id-a je obavezan.", createContractorPage.PCCIdEmptyErrorMessage().Text);
                Assert.AreEqual("Unos imena je obavezan.", createContractorPage.FirstNameEmptyErrorMessage().Text);
                Assert.AreEqual("Unos prezimena je obavezan.", createContractorPage.LastNameEmptyErrorMessage().Text); 
            }
        }

    }
}

