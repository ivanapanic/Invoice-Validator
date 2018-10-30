using Invoice_Validator_Test.Pages;
using Invoice_Validator_Test.Pages.Admin;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        private CreateContractorPage createContractorPage = new CreateContractorPage(Driver);
        private ContractorListPage contractorListPage = new ContractorListPage(Driver);
        private HomePage homePage = new HomePage(Driver);


        public void CreateContractorPageTests()
        {
            LoginPage loginPage = new LoginPage(Driver);
            HomePage homePage = new HomePage(Driver);

            loginPage.LoginAsAdmin();
            homePage.SetRandomLocalLanguage();
            homePage.NavigateToCreateContractorPage();
        }

        //VARIABLES
        string existingUsername = ConfigurationManager.AppSettings["usernameContractor"];
        string existingPccId = "81971";


        string username = "Username" + GenerateRandomData.GenerateRandomString(5);
        string pccId = GenerateRandomData.GenerateRandomNumber(5);
        string firstName = "FirstName" + GenerateRandomData.GenerateRandomString(5);
        string lastName = "LastName" + GenerateRandomData.GenerateRandomString(5);


        //LOGIN
        [Given(@"Admin is logged in")]
        public void GivenAdminNavigatesToInvoiceValidatorWebSite()
        {
            CreateContractorPageTests();
        }


        //TEST CREATE CONTRACTOR WITH VALID DATA
        [Given(@"Create Contractor page is displayed")]
        public void CreateContractorPageIsDisplayed()
        {
            Assert.That(createContractorPage.IsCreateContractorPageDisplayed, Is.True, "Create Contractor page is not displayed.");
        }

        [When(@"admin enters valid data for new contractor")]
        public void AdminEntersValidDataForNewContractor()
        {
            createContractorPage.FillCreateContractorFields(username, pccId, firstName, lastName);
        }

        [When(@"clicks on create button")]
        public void ClicksOnCreateButton()
        {
            createContractorPage.ClickCreate();
        }

        [Then(@"page is redirected to list page")]
        public void PageIsRedirectedToListPage()
        {
            Assert.That(contractorListPage.IsConractorsListPageDisplayed, Is.True, "Contractors List page is not displayed.");
        }

        [Then(@"new contractor is displayed in list")]
        public void NewContractorIsDisplayedInList()
        {
            Assert.AreEqual(username, contractorListPage.Table().FindElement(By.XPath("//td[2][contains(string(), '" + username + "')]")).Text);
        }



        //TEST CREATE CONTRACTOR WITH INVALID DATA
        [Given(@"Page Create Contractor is displayed")]
        public void PageCreateContractorIsDisplayed()
        {
            Assert.That(createContractorPage.IsCreateContractorPageDisplayed, Is.True, "Create Contractor page is not displayed.");
        }

        [When(@"admin enters invalid data for new contractor")]
        public void AdminEntersInvalidDataForNewContractor()
        {
            createContractorPage.FillCreateContractorFields(existingUsername, existingPccId, firstName, lastName);
        }

        [When(@"clicks on button create")]
        public void ClicksOnButtonCreate()
        {
            createContractorPage.ClickCreate();
        }

        [Then(@"Error messages are displayed")]
        public void ErrorMessagesAreDisplayed()
        {
            //loop for error messages depending on local language
            if (homePage.LanguageDropDown().Text.Contains("EN"))
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
        [Given(@"Create Contractor is displayed")]
        public void ThenCreateContractorIsDisplayed()
        {
            Assert.That(createContractorPage.IsCreateContractorPageDisplayed, Is.True, "Create Contractor page is not displayed.");
        }

        [When(@"leave fields empty")]
        public void WhenLeaveFieldsEmpty()
        {
            createContractorPage.ClearCreateContractorFields();
        }

        [When(@"admin clicks on create button on create contractor page")]
        public void WhenAdminClicksOnCreateButtonOnCreateContractorPage()
        {
            createContractorPage.ClickCreate();
        }

        [Then(@"Error messages are displayed on the page")]
        public void ThenErrorMessagesAreDisplayedOnThePage()
        {
            //loop for error messages depending on local language
            if (homePage.LanguageDropDown().Text.Contains("EN"))
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

