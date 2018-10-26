using Invoice_Validator_Test.Pages;
using Invoice_Validator_Test.Pages.Contractor;
using Invoice_Validator_Test.Pages.Contractor.Claims;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Data;
using System.Collections;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Invoice_Validator_Test.Steps.Contractor
{
    [Binding]
    public class CreateClaimSteps : BaseSteps
    {

        //VARIABLES
        //valid data
        string accNumToPay = GenerateRandomData.GenerateRandomNumber(3) + "-" +
            GenerateRandomData.GenerateRandomNumber(13) + "-" +
            GenerateRandomData.GenerateRandomNumber(2);
        static string monthlyClaim = GenerateRandomData.GenerateRandomNumber(5);
        static string uniqa = GenerateRandomData.GenerateRandomNumber(3);
        static string bicycle = GenerateRandomData.GenerateRandomNumber(4);

        //get total
        static int totalOfClaims = GenerateRandomData.SumNumbers(Convert.ToInt32(monthlyClaim), Convert.ToInt32(uniqa)*(-1), Convert.ToInt32(bicycle));
        string total = Convert.ToString(totalOfClaims);

        //invalid data
        string invalidAccNumToPay = GenerateRandomData.GenerateRandomNumber(12);
        string invalidMonthlyClaim = "0" + GenerateRandomData.GenerateRandomNumber(4);
        string invalidUniqa = "0" + GenerateRandomData.GenerateRandomNumber(3);
        string invalidBicycle = "0" + GenerateRandomData.GenerateRandomNumber(3);




        //LOGIN
        [Given(@"Log in as contractor")]
        public void GivenLogInAsContractor()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080/Account/Login/?ReturnUrl=%2F");

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.UsernameInputField().SendKeys("IQService.contractor1");
            loginPage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");

            loginPage.SignInButton().Click();
        }
        



        //TEST CREATE CLAIM WITH VALID DATA
        [Given(@"Invoice Validator is displayed")]
        public void GivenInvoiceValidatorIsDisplayed()
        {
            ContractorHomePage contractorHomePage = new ContractorHomePage(Driver);
            Assert.That(contractorHomePage.IsContractorHomePageDisplayed(), Is.True, "Contractor Home page is not displayed.");
        }

        [When(@"contractor enters valid data in create claim form")]
        public void WhenContractorEntersValidDataInCreateClaimForm()
        {
            ContractorHomePage contractorHomePage = new ContractorHomePage(Driver);
            GenerateRandomData.SelectRandomElement(contractorHomePage.AccPeriodCreateClaimDropdown());

            //clear input fields
            contractorHomePage.AccNumberToPayInputField().Clear();
            contractorHomePage.MonthlyClaimInputField().Clear();

            //enter data in input fields
            contractorHomePage.AccNumberToPayInputField().SendKeys(accNumToPay);
            contractorHomePage.MonthlyClaimInputField().SendKeys(monthlyClaim);
            contractorHomePage.UniqaInputField().SendKeys(uniqa);
            contractorHomePage.BicycleInputField().SendKeys(bicycle);

            //check total amount
            contractorHomePage.TotalInputField().Text.Equals(total);



        }

        [When(@"clicks Create button")]
        public void WhenClicksCreateButton()
        {
            ContractorHomePage contractorHomePage = new ContractorHomePage(Driver);
            contractorHomePage.CreateClaimButton().Click();
        }

        [When(@"page is redirected to Claims list page")]
        public void WhenPageIsRedirectedToClaimsListPage()
        {
            ClaimsListPage claimsListPage = new ClaimsListPage(Driver);
            Assert.That(claimsListPage.IsClaimsListPageDisplayed(), Is.True, "Claims list page is not displayed.");
        }

        [Then(@"created claim is displayed on top of the list")]
        public void ThenCreatedClaimIsDisplayedInTheList()
        {
            //created claim should be present in the first row
            ClaimsListPage claimsListPage = new ClaimsListPage(Driver);
            Assert.AreEqual(accNumToPay, claimsListPage.Table().FindElement(By.XPath("//tbody//tr[1]//td[4]")).Text);
        }





        //TEST CREATE CLAIM WITH INVALID DATA
        [Given(@"Page Invoice is displayed")]
        public void GivenPageInvoiceIsDisplayed()
        {
            ContractorHomePage contractorHomePage = new ContractorHomePage(Driver);
            Assert.That(contractorHomePage.IsContractorHomePageDisplayed(), Is.True, "Contractor Home page is not displayed.");
        }

        [When(@"contractor enters invalid data in create claim form")]
        public void WhenContractorEntersInvalidDataInCreateClaimForm()
        {
            ContractorHomePage contractorHomePage = new ContractorHomePage(Driver);
            GenerateRandomData.SelectRandomElement(contractorHomePage.AccPeriodCreateClaimDropdown());

            //clear input fields
            contractorHomePage.AccNumberToPayInputField().Clear();
            contractorHomePage.MonthlyClaimInputField().Clear();

            //enter data in input fields
            contractorHomePage.AccNumberToPayInputField().SendKeys(invalidAccNumToPay);
            contractorHomePage.MonthlyClaimInputField().SendKeys(invalidMonthlyClaim);
            contractorHomePage.UniqaInputField().SendKeys(invalidUniqa);
            contractorHomePage.BicycleInputField().SendKeys(invalidBicycle);
        }
        
        [When(@"clicks button Create")]
        public void WhenClicksButtonCreate()
        {
            ContractorHomePage contractorHomePage = new ContractorHomePage(Driver);
            contractorHomePage.CreateClaimButton().Click();
        }


        [Then(@"Messages about errors are displayed")]
        public void ThenMessagesAboutErrorsAreDisplayed()
        {
            ContractorHomePage contractorHomePage = new ContractorHomePage(Driver);

            //loop for error messages depending on local language
            if (contractorHomePage.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual("Invalid format. Please enter a valid format: xxx-xxxxxxxxxxxxx-xx.", contractorHomePage.AccNumToPayErrorMsg().Text);
                Assert.AreEqual("Input for amount is not valid.", contractorHomePage.MonthlyClaimErrorMsg().Text);
                Assert.AreEqual("Input for amount is not valid.", contractorHomePage.UniqaErrorMsg().Text);
                Assert.AreEqual("Input for amount is not valid.", contractorHomePage.BicycleErrorMsg().Text);
            }
            else
            {
                Assert.AreEqual("Neispravan format. Unesite broj u formatu: xxx-xxxxxxxxxxxxx-xx.", contractorHomePage.AccNumToPayErrorMsg().Text);
                Assert.AreEqual("Uneti iznos nije ispravan.", contractorHomePage.MonthlyClaimErrorMsg().Text);
                Assert.AreEqual("Uneti iznos nije ispravan.", contractorHomePage.UniqaErrorMsg().Text);
                Assert.AreEqual("Uneti iznos nije ispravan.", contractorHomePage.BicycleErrorMsg().Text);
            }
        }
        

    }
}
