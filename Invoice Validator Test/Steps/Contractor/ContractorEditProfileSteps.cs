using Invoice_Validator_Test.Pages;
using Invoice_Validator_Test.Pages.Admin;
using Invoice_Validator_Test.Pages.Contractor;
using Invoice_Validator_Test.Steps;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using static Invoice_Validator_Test.Pages.Contractor.ContractorProfilePage;

namespace Invoice_Validator_Test
{
    [Binding]
    public class ContractorEditProfileSteps : BaseSteps
    {
        private ContractorProfilePage contractorProfilePage = new ContractorProfilePage(Driver);
        private HomePage homePage = new HomePage(Driver);

        public void EditContractorPageTests()
        {
            LoginPage loginPage = new LoginPage(Driver);
            CreateClaimPage contractorHomePage = new CreateClaimPage(Driver);
            HomePage homePage = new HomePage(Driver);

            loginPage.LoginAsContractor();
            homePage.SetRandomLocalLanguage();
            homePage.NavigateToContractorProfilePage();

        }

        //VARIABLES 

        private Dictionary<ProfileFields, string> dictReadDataDuringEdition;
        private Dictionary<ProfileFields, string> dictReadEditedData;

        //valid data
        string address = "AddressTest" + GenerateRandomData.GenerateRandomNumber(3);
        string bankName = "BankNameTest" + GenerateRandomData.GenerateRandomNumber(3);
        string accountNumber = GenerateRandomData.GenerateRandomNumber(3) + "-" +
            GenerateRandomData.GenerateRandomNumber(13) + "-" +
            GenerateRandomData.GenerateRandomNumber(2);
        string agencyName = "AgencyName" + GenerateRandomData.GenerateRandomNumber(3);
        string registryNumber = GenerateRandomData.GenerateRandomNumber(5);
        string taxNumber = GenerateRandomData.GenerateRandomNumber(5);
        string telNumber = GenerateRandomData.GenerateRandomNumber(6);

        //invalid data
        string invalidAddress = GenerateRandomData.GenerateRandomSpecialCharacters(3);
        string invalidBankName = GenerateRandomData.GenerateRandomSpecialCharacters(3);
        string invalidAccNumber = GenerateRandomData.GenerateRandomNumber(5) +
            GenerateRandomData.GenerateRandomSpecialCharacters(3);
        string invalidAgencyName = GenerateRandomData.GenerateRandomSpecialCharacters(3);
        string invalidRegistryNumber = GenerateRandomData.GenerateRandomNumber(5) + GenerateRandomData.GenerateRandomSpecialCharacters(3);
        string invalidTaxNumber = GenerateRandomData.GenerateRandomNumber(5) + GenerateRandomData.GenerateRandomSpecialCharacters(3);
        string invalidTelNumber = GenerateRandomData.GenerateRandomNumber(5) + GenerateRandomData.GenerateRandomSpecialCharacters(3);



        //LOGIN
        [Given(@"Contractor is logged in")]
        public void GivenContractorIsLoggedIn()
        {
            EditContractorPageTests();
        }


        //TEST EDIT CONTRACTOR'S PROFILE WITH VALID DATA 
        [Given(@"Profile page is displayed")]
        public void ThenProfilePageIsDisplayed()
        {
            Assert.That(contractorProfilePage.IsContractorProfilePageDisplayed(), Is.True, "Contractor Profile page is not displayed.");

        }

        [When(@"contractor enters valid data")]
        public void WhenContractorEntersValidData()
        {
            contractorProfilePage.ClearAllProfileFields();

            contractorProfilePage.FillAllProfileFields(address, bankName, accountNumber, agencyName,
                registryNumber, taxNumber, telNumber);

            dictReadDataDuringEdition = contractorProfilePage.StoreProfileDataToDictionary();
        }

        [When(@"clicks Save button")]
        public void WhenClicksSaveButton()
        {
            contractorProfilePage.ClickSave();
        }

        [When(@"page is redirected to Home page")]
        public void WhenPageIsRedirectedToHomePage()
        {
            Assert.That(homePage.IsHomePageDisplayed(), Is.True, "Contractor Home page is not displayed.");
        }

        [When(@"clicks on Profile from header menu")]
        public void WhenClicksOnProfileFromHeaderMenu()
        {
            homePage.NavigateToContractorProfilePage();
        }

        [Then(@"changed data is displayed")]
        public void ThenChangedDataIsDisplayed()
        { 
            dictReadEditedData = contractorProfilePage.StoreProfileDataToDictionary();
            Assert.AreEqual(dictReadDataDuringEdition, dictReadEditedData);

        }



        //TEST EDIT CONTRACTOR'S PROFILE WITH INVALID DATA
        [Given(@"Contractor Profile page is displayed")]
        public void ThenContractorProfilePageIsDisplayed()
        {
            Assert.That(contractorProfilePage.IsContractorProfilePageDisplayed(), Is.True, "Contractor Profile page is not displayed.");
        }

        [When(@"contractor enters invalid data")]
        public void WhenContractorEntersInvalidData()
        {
            contractorProfilePage.ClearAllProfileFields();

            contractorProfilePage.FillAllProfileFields(invalidAddress, invalidBankName, invalidAccNumber, 
                invalidAgencyName, invalidRegistryNumber, invalidTaxNumber, invalidTelNumber);

        }
        
        [When(@"clicks button Save")]
        public void WhenClicksButtonSave()
        {
            contractorProfilePage.SaveButton().Click();
        }

        [Then(@"Error messages are displayed on page")]
        public void ThenErrorMessagesAreDisplayedOnPage()
        {
            //loop for error messages depending on local language
            if (homePage.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual("Address must be alphanumeric.", contractorProfilePage.AddressErrorMessage().Text);
                Assert.AreEqual("Bank name must be alphanumeric.", contractorProfilePage.BankNameErrorMessage().Text);
                Assert.AreEqual("Invalid format. Please enter a valid format: xxx-xxxxxxxxxxxxx-xx.", contractorProfilePage.AccountNumerErrorMessage().Text);
                Assert.AreEqual("Agency name be alphanumeric.", contractorProfilePage.AgencyNameErrorMessage().Text);
                Assert.AreEqual("Registry number for country number format is invalid.", contractorProfilePage.RegistryNumberErrorMessage().Text);
                Assert.AreEqual("Tax identification number format is invalid.", contractorProfilePage.TaxNumberErrorMessage().Text);
                Assert.AreEqual("Telephone number format is invalid.", contractorProfilePage.TelephoneErrorMessage().Text);
            }
            else
            {
                Assert.AreEqual("Naziv adrese mora biti alfanumerički.", contractorProfilePage.AddressErrorMessage().Text);
                Assert.AreEqual("Naziv banke mora biti alfanumerički.", contractorProfilePage.BankNameErrorMessage().Text);
                Assert.AreEqual("Neispravan format. Unesite broj u formatu: xxx-xxxxxxxxxxxxx-xx.", contractorProfilePage.AccountNumerErrorMessage().Text);
                Assert.AreEqual("Naziv agencije mora biti alfanumerički.", contractorProfilePage.AgencyNameErrorMessage().Text);
                Assert.AreEqual("Format matičnog broja je nevažeći.", contractorProfilePage.RegistryNumberErrorMessage().Text);
                Assert.AreEqual("Format poreskog identifikacionog broja je nevažeći.", contractorProfilePage.TaxNumberErrorMessage().Text);
                Assert.AreEqual("Broj telefona je nevažeći.", contractorProfilePage.TelephoneErrorMessage().Text);
            }
        }
    }
}
