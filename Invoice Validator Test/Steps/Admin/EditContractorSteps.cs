using Invoice_Validator_Test.Pages;
using Invoice_Validator_Test.Pages.Admin;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TechTalk.SpecFlow;
using static Invoice_Validator_Test.Pages.Admin.EditContractorPage;

namespace Invoice_Validator_Test.Steps.Admin
{
    [Binding]
    public class EditContractorSteps : BaseSteps
    {

        //VARIABLES
        private Dictionary<EditContractorFields, string> dictReadDataDuringEdition;
        private Dictionary<EditContractorFields, string> dictReadEditedData;

        string pccId = GenerateRandomData.GenerateRandomNumber(5);
        string firstName = "FirstName" + GenerateRandomData.GenerateRandomString(5);
        string lastName = "LastName" + GenerateRandomData.GenerateRandomString(5);

        //LOGIN
        [Given(@"Log in with admin credentials")]
        public void GivenLogInWithAdminCredentials()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080/Account/Login/?ReturnUrl=%2F");

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.UsernameInputField().SendKeys("IQService.admin1");
            loginPage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");

            loginPage.SignInButton().Click();
        }

        //TEST EDIT CONTRACTOR WITH ACTIVE/INACTIVE CHECKBOX

        //active checkbox
        [Given(@"Admin Home page is displayed")]
        public void GivenAdminHomePageIsDisplayed()
        {
            AdminHomePage adminHomePage = new AdminHomePage(Driver);
            Assert.That(adminHomePage.IsAdminHomePageDisplayed(), Is.True, "Home page is not displayed.");
        }

        [When(@"admin clicks on List page in Contractor dropdown")]
        public void WhenAdminClicksOnListPageInContractorDropdown()
        {
            AdminHomePage adminHomePage = new AdminHomePage(Driver);
            adminHomePage.ContractorDropdown().Click();
            adminHomePage.ContractorDropdownList().Click();
        }

        [Then(@"contractors list page is displayed")]
        public void ThenContractorsListPageIsDisplayed()
        {
            ContractorListPage contractorListPage = new ContractorListPage(Driver);
            Assert.That(contractorListPage.IsConractorsListPageDisplayed, Is.True, "Contractors List page is not displayed.");
        }

        [When(@"admin clicks on Edit button in list of contractors")]
        public void WhenAdminClicksOnEditButtonInListOfContractors()
        {
            ContractorListPage contractorListPage = new ContractorListPage(Driver);

            //contractorListPage.Table().FindElement(By.XPath("//tr[contains(string(), '" + GenerateRandomData.GenerateRow(listPage.Table()) + "')]//td[7]//a[1]")).Click();
            contractorListPage.Table().FindElement(By.XPath("//tr[contains(string(), '" + "Username" + "')]//td[7]//a[1]")).Click();

        }


        [Then(@"Edit contractor page is displayed")]
        public void ThenEditContractorPageIsDisplayed()
        {
            EditContractorPage editContractorPage = new EditContractorPage(Driver);
            Assert.That(editContractorPage.IsContractorEditPageDisplayed(), Is.True, "Edit Contractor page is not displayed.");
        }

        [When(@"admin enters  data")]
        public void WhenAdminEntersData()
        {
            EditContractorPage editContractorPage = new EditContractorPage(Driver);
            //clear input fields
            editContractorPage.PCCIdField().Clear();
            editContractorPage.FirstNameField().Clear();
            editContractorPage.LastNameField().Clear();

            //enter data in input fields
            editContractorPage.PCCIdField().SendKeys(pccId);           
            editContractorPage.FirstNameField().SendKeys(firstName);            
            editContractorPage.LastNameField().SendKeys(lastName);

            dictReadDataDuringEdition = editContractorPage.StoreProfileDataToDictionary();

        }

        [When(@"active checkbox is checked")]
        public void WhenActiveCheckboxIsChecked()
        {
            //active checkbox is checked by default
        }

        [When(@"clicks on save button")]
        public void WhenClicksOnSaveButton()
        {
            EditContractorPage editContractorPage = new EditContractorPage(Driver);
            editContractorPage.SaveButton().Click();
        }



        [Then(@"edit page is redirected to list page")]
        public void ThenEditPageIsRedirectedToListPage()
        {
            ContractorListPage contractorListPage = new ContractorListPage(Driver);
            Assert.That(contractorListPage.IsConractorsListPageDisplayed, Is.True, "Contractor List page is not displayed.");
        }

        [Then(@"edited contractor is visible in list")]
        public void ThenEditedContractorIsVisibleInList()
        {
            ContractorListPage contractorListPage = new ContractorListPage(Driver);
            Assert.AreEqual(pccId, contractorListPage.Table().FindElement(By.XPath("//td[6][contains(string(), '" + pccId + "')]")).Text);
        }


        //inactive checkbox
        //check again the same contractor
        [When(@"admin clicks on Edit in list of contractors")]
        public void WhenAdminClicksOnEditInListOfContractors()
        {
            ContractorListPage contractorListPage = new ContractorListPage(Driver);
            contractorListPage.Table().FindElement(By.XPath("//tr[contains(string(), '" + pccId + "')]//td[7]//a[1]")).Click();
        }


        [Then(@"Changed data is displayed in Edit form")]
        public void ThenChangedDataIsDisplayedInEditForm()
        {
            EditContractorPage editContractorPage = new EditContractorPage(Driver);
            //Assert.AreEqual(pccId, editContractorPage.PCCIdField().GetAttribute("value"));
            //Assert.AreEqual(firstName, editContractorPage.FirstNameField().GetAttribute("value"));
            //Assert.AreEqual(lastName, editContractorPage.LastNameField().GetAttribute("value"));

            dictReadEditedData = editContractorPage.StoreProfileDataToDictionary();

            Assert.AreEqual(dictReadDataDuringEdition, dictReadEditedData);
        }



        [When(@"active checkbox is not checked")]
        public void WhenActiveCheckboxIsNotChecked()
        {

            EditContractorPage editContractorPage = new EditContractorPage(Driver);
            editContractorPage.ActiveCheckbox().Click();

        }

        [When(@"admin clicks on save button")]
        public void WhenClicksOnSave()
        {
            EditContractorPage editContractorPage = new EditContractorPage(Driver);
            editContractorPage.SaveButton().Click();
        }



        [Then(@"page is redirected to contractor list page")]
        public void ThenPageIsRedirectedToContractorListPage()
        {
            ContractorListPage contractorListPage = new ContractorListPage(Driver);
            Assert.That(contractorListPage.IsConractorsListPageDisplayed, Is.True, "Contractor List page is not displayed.");
        }

        [Then(@"edited contractor is not visible in list")]
        public void ThenEditedContractorIsNotVisibleInList()
        {
            ContractorListPage contractorListPage = new ContractorListPage(Driver);
            Assert.IsFalse(contractorListPage.Table().Text.Contains(pccId));
        }

    }
}
