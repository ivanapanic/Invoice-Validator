using Invoice_Validator_Test.Pages;
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
            Driver.Navigate().GoToUrl("http://intnstest:50080/Account/Login/?ReturnUrl=%2F");

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.UsernameInputField().SendKeys("IQService.contractor1");
            loginPage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");

            loginPage.SignInButton().Click();
        }
        

        //TEST EDIT CONTRACTOR WITH VALID DATA 
        [Given(@"Invoice Validator page is displayed")]
        public void GivenInvoiceValidatorPageIsDisplayed()
        {
            ContractorHomePage contractorHomePage = new ContractorHomePage(Driver);
            Assert.That(contractorHomePage.IsContractorHomePageDisplayed(), Is.True, "Contractor Home page is not displayed.");
        }

        [When(@"contractor clicks on Profile from header menu")]
        public void WhenContractorClicksOnProfileFromHeaderMenu()
        {
            ContractorHomePage contractorHomePage = new ContractorHomePage(Driver);
            contractorHomePage.ProfileButton().Click();
        }

        [Then(@"Profile page is displayed")]
        public void ThenProfilePageIsDisplayed()
        {
            ContractorProfilePage contractorProfilePage = new ContractorProfilePage(Driver);
            Assert.That(contractorProfilePage.IsContractorProfilePageDisplayed(), Is.True, "Contractor Profile page is not displayed.");
        }

        [When(@"contractor enters valid data")]
        public void WhenContractorEntersValidData()
        {
            ContractorProfilePage contractorProfilePage = new ContractorProfilePage(Driver);
            //clear input fields
            contractorProfilePage.AddressField().Clear();
            contractorProfilePage.BankNameField().Clear();
            contractorProfilePage.AccountNumberField().Clear();
            contractorProfilePage.AgencyNameField().Clear();
            contractorProfilePage.RegistryNumberForCountry().Clear();
            contractorProfilePage.TaxIdentificationNumber().Clear();
            contractorProfilePage.TelephoneField().Clear();


            //enter data in input fields
            contractorProfilePage.AddressField().SendKeys(address);
            contractorProfilePage.BankNameField().SendKeys(bankName);
            contractorProfilePage.AccountNumberField().SendKeys(accountNumber);
            contractorProfilePage.AgencyNameField().SendKeys(agencyName);
            contractorProfilePage.RegistryNumberForCountry().SendKeys(registryNumber);
            contractorProfilePage.TaxIdentificationNumber().SendKeys(taxNumber);
            contractorProfilePage.TelephoneField().SendKeys(telNumber);

            dictReadDataDuringEdition = contractorProfilePage.StoreProfileDataToDictionary();
        }

        [When(@"clicks Save button")]
        public void WhenClicksSaveButton()
        {
            ContractorProfilePage contractorProfilePage = new ContractorProfilePage(Driver);
            contractorProfilePage.SaveButton().Click();
        }

        [When(@"page is redirected to Home page")]
        public void WhenPageIsRedirectedToHomePage()
        {
            ContractorHomePage contractorHomePage = new ContractorHomePage(Driver);
            Assert.That(contractorHomePage.IsContractorHomePageDisplayed(), Is.True, "Contractor Home page is not displayed.");
        }

        [When(@"clicks on Profile from header menu")]
        public void WhenClicksOnProfileFromHeaderMenu()
        {
            ContractorHomePage contractorHomePage = new ContractorHomePage(Driver);
            contractorHomePage.ProfileButton().Click();
        }

        [Then(@"changed data is displayed")]
        public void ThenChangedDataIsDisplayed()
        {
            ContractorProfilePage contractorProfilePage = new ContractorProfilePage(Driver);
            //Assert.AreEqual(address, contractorProfilePage.AddressField().GetAttribute("value"));
            //Assert.AreEqual(bankName, contractorProfilePage.BankNameField().GetAttribute("value"));
            //Assert.AreEqual(accountNumber, contractorProfilePage.AccountNumberField().GetAttribute("value"));
            //Assert.AreEqual(agencyName, contractorProfilePage.AgencyNameField().GetAttribute("value"));
            //Assert.AreEqual(registryNumber, contractorProfilePage.RegistryNumberForCountry().GetAttribute("value"));
            //Assert.AreEqual(taxNumber, contractorProfilePage.TaxIdentificationNumber().GetAttribute("value"));
            //Assert.AreEqual(telNumber, contractorProfilePage.TelephoneField().GetAttribute("value"));

            dictReadEditedData = contractorProfilePage.StoreProfileDataToDictionary();

            Assert.AreEqual(dictReadDataDuringEdition, dictReadEditedData);

        }



        //TEST EDIT CONTRACTOR WITH INVALID DATA
        [Given(@"Page Invoice Validator is displayed")]
        public void GivenPageInvoiceValidatorIsDisplayed()
        {
            ContractorHomePage contractorHomePage = new ContractorHomePage(Driver);
            Assert.That(contractorHomePage.IsContractorHomePageDisplayed(), Is.True, "Contractor Home page is not displayed.");
        }

        [When(@"contractor clicks on Profile button in header menu")]
        public void WhenContractorClicksOnProfileButtonInHeaderMenu()
        {
            ContractorHomePage contractorHomePage = new ContractorHomePage(Driver);
            contractorHomePage.ProfileButton().Click();
        }

        [Then(@"Contractor Profile page is displayed")]
        public void ThenContractorProfilePageIsDisplayed()
        {
            ContractorProfilePage contractorProfilePage = new ContractorProfilePage(Driver);
            Assert.That(contractorProfilePage.IsContractorProfilePageDisplayed(), Is.True, "Contractor Profile page is not displayed.");
        }

        [When(@"contractor enters invalid data")]
        public void WhenContractorEntersInvalidData()
        {
            ContractorProfilePage contractorProfilePage = new ContractorProfilePage(Driver);

            //clear input fields
            contractorProfilePage.AddressField().Clear();
            contractorProfilePage.BankNameField().Clear();
            contractorProfilePage.AccountNumberField().Clear();
            contractorProfilePage.AgencyNameField().Clear();
            contractorProfilePage.RegistryNumberForCountry().Clear();
            contractorProfilePage.TaxIdentificationNumber().Clear();
            contractorProfilePage.TelephoneField().Clear();

            //enter data in input fields
            contractorProfilePage.AddressField().SendKeys(invalidAddress);
            contractorProfilePage.BankNameField().SendKeys(invalidBankName);
            contractorProfilePage.AccountNumberField().SendKeys(invalidAccNumber);
            contractorProfilePage.AgencyNameField().SendKeys(invalidAgencyName);
            contractorProfilePage.RegistryNumberForCountry().SendKeys(invalidRegistryNumber);
            contractorProfilePage.TaxIdentificationNumber().SendKeys(invalidTaxNumber);
            contractorProfilePage.TelephoneField().SendKeys(invalidTelNumber);

        }
        
        [When(@"clicks button Save")]
        public void WhenClicksButtonSave()
        {
            ContractorProfilePage contractorProfilePage = new ContractorProfilePage(Driver);
            contractorProfilePage.SaveButton().Click();
        }

        [Then(@"Error messages are displayed on page")]
        public void ThenErrorMessagesAreDisplayedOnPage()
        {
            ContractorProfilePage contractorProfilePage = new ContractorProfilePage(Driver);
            ContractorHomePage contractorHomePage = new ContractorHomePage(Driver);

            //loop for error messages depending on local language
            if (contractorHomePage.LanguageDropDown().Text.Contains("EN"))
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
