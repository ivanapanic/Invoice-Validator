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
        private ContractorListPage contractorListPage = new ContractorListPage(Driver);
        private EditContractorPage editContractorPage = new EditContractorPage(Driver);
        private HomePage homePage = new HomePage(Driver);


        public void CreateContractorPageTests()
        {
            LoginPage loginPage = new LoginPage(Driver);
            HomePage homePage = new HomePage(Driver);
            ContractorListPage contractorListPage = new ContractorListPage(Driver);

            loginPage.LoginAsAdmin();
            homePage.SetRandomLocalLanguage();
            homePage.NavigateToContratorsListPage();
            contractorListPage.NavigateToEditContractorPage();
            
        }

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
            CreateContractorPageTests();
        }

        //TEST EDIT CONTRACTOR WITH ACTIVE/INACTIVE CHECKBOX

        //active checkbox
        [Given(@"Edit contractor page is displayed")]
        public void ThenEditContractorPageIsDisplayed()
        {
            Assert.That(editContractorPage.IsContractorEditPageDisplayed(), Is.True, "Edit Contractor page is not displayed.");
        }

        [When(@"admin enters  data")]
        public void WhenAdminEntersData()
        {
            editContractorPage.ClearAllEditContractorFields();
            editContractorPage.FillAllEditContractorFields(pccId, firstName, lastName);
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
            editContractorPage.ClickSave();
        }

        [Then(@"edit page is redirected to list page")]
        public void ThenEditPageIsRedirectedToListPage()
        {
            Assert.That(contractorListPage.IsConractorsListPageDisplayed, Is.True, "Contractor List page is not displayed.");
        }

        [Then(@"edited contractor is visible in list")]
        public void ThenEditedContractorIsVisibleInList()
        {
            Assert.AreEqual(pccId, contractorListPage.Table().FindElement(By.XPath("//td[6][contains(string(), '" + pccId + "')]")).Text);
        }


        //inactive checkbox
        //check again the same contractor
        [When(@"admin clicks on Edit in list of contractors")]
        public void WhenAdminClicksOnEditInListOfContractors()
        {
            contractorListPage.Table().FindElement(By.XPath("//tr[contains(string(), '" + pccId + "')]//td[7]//a[1]")).Click();
        }

        [Then(@"Changed data is displayed in Edit form")]
        public void ThenChangedDataIsDisplayedInEditForm()
        {
            dictReadEditedData = editContractorPage.StoreProfileDataToDictionary();
            Assert.AreEqual(dictReadDataDuringEdition, dictReadEditedData);
        }

        [When(@"active checkbox is not checked")]
        public void WhenActiveCheckboxIsNotChecked()
        {
            editContractorPage.CheckCheckbox();
        }

        [When(@"admin clicks on save button")]
        public void WhenClicksOnSave()
        {
            editContractorPage.ClickSave();
        }

        [Then(@"page is redirected to contractor list page")]
        public void ThenPageIsRedirectedToContractorListPage()
        {
            Assert.That(contractorListPage.IsConractorsListPageDisplayed, Is.True, "Contractor List page is not displayed.");
        }

        [Then(@"edited contractor is not visible in list")]
        public void ThenEditedContractorIsNotVisibleInList()
        {
            Assert.IsFalse(contractorListPage.Table().Text.Contains(pccId));
        }

    }
}
