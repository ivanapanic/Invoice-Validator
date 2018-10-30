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
using Invoice_Validator_Test.Pages.Admin;

namespace Invoice_Validator_Test.Steps.Contractor
{
    [Binding]
    public class CreateClaimSteps : BaseSteps
    {
        private CreateClaimPage createClaimPage = new CreateClaimPage(Driver);
        private HomePage homePage = new HomePage(Driver);
        private ClaimsListPage claimsListPage = new ClaimsListPage(Driver);

        public void CreateClaimPageTests()
        {
            LoginPage loginPage = new LoginPage(Driver);
            CreateClaimPage contractorHomePage = new CreateClaimPage(Driver);
            HomePage homePage = new HomePage(Driver);

            loginPage.LoginAsContractor();
            homePage.SetRandomLocalLanguage();
        }

        //VARIABLES
        //valid data
        string accNumToPay = GenerateRandomData.GenerateRandomNumber(3) + "-" +
            GenerateRandomData.GenerateRandomNumber(13) + "-" +
            GenerateRandomData.GenerateRandomNumber(2);
        static string monthlyClaim = GenerateRandomData.GenerateRandomNumber(5);
        static string uniqa = GenerateRandomData.GenerateRandomNumber(3);
        static string bicycle = GenerateRandomData.GenerateRandomNumber(4);

        //get total
        static int totalOfClaims = GenerateRandomData.SumNumbers(Convert.ToInt32(monthlyClaim), Convert.ToInt32(uniqa) * (-1), Convert.ToInt32(bicycle));
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
            CreateClaimPageTests();
        }




        //TEST CREATE CLAIM WITH VALID DATA
        [Given(@"Invoice Validator is displayed")]
        public void GivenInvoiceValidatorIsDisplayed()
        {
            Assert.That(homePage.IsHomePageDisplayed(), Is.True, "Contractor Home page is not displayed.");
        }

        [When(@"contractor enters valid data in create claim form")]
        public void WhenContractorEntersValidDataInCreateClaimForm()
        {
            createClaimPage.SelectAccountingPeriod();
            //clear input fields
            createClaimPage.ClearCreateClaimFields();

            //enter data in input fields
            createClaimPage.FillAllCreateClaimFields(accNumToPay, monthlyClaim, uniqa, bicycle);

            //check total amount
            createClaimPage.TotalInputField().Text.Equals(total);



        }

        [When(@"clicks Create button")]
        public void WhenClicksCreateButton()
        {
            createClaimPage.ClickCreate();
        }

        [When(@"page is redirected to Claims list page")]
        public void WhenPageIsRedirectedToClaimsListPage()
        {
            Assert.That(claimsListPage.IsClaimsListPageDisplayed(), Is.True, "Claims list page is not displayed.");
        }

        [Then(@"created claim is displayed on top of the list")]
        public void ThenCreatedClaimIsDisplayedInTheList()
        {
            //created claim should be present in the first row
            Assert.AreEqual(accNumToPay, claimsListPage.Table().FindElement(By.XPath("//tbody//tr[1]//td[4]")).Text);
        }





        //TEST CREATE CLAIM WITH INVALID DATA
        [Given(@"Page Invoice is displayed")]
        public void GivenPageInvoiceIsDisplayed()
        {
            Assert.That(homePage.IsHomePageDisplayed(), Is.True, "Contractor Home page is not displayed.");
        }

        [When(@"contractor enters invalid data in create claim form")]
        public void WhenContractorEntersInvalidDataInCreateClaimForm()
        {
            //clear input fields
            createClaimPage.ClearCreateClaimFields();

            //enter data in input fields
            createClaimPage.FillAllCreateClaimFields(invalidAccNumToPay, invalidMonthlyClaim, invalidUniqa, invalidBicycle);
        }

        [When(@"clicks button Create")]
        public void WhenClicksButtonCreate()
        {
            createClaimPage.CreateClaimButton().Click();
        }


        [Then(@"Messages about errors are displayed")]
        public void ThenMessagesAboutErrorsAreDisplayed()
        {
            //loop for error messages depending on local language
            if (homePage.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual("Invalid format. Please enter a valid format: xxx-xxxxxxxxxxxxx-xx.", createClaimPage.AccNumToPayErrorMsg().Text);
                Assert.AreEqual("Input for amount is not valid.", createClaimPage.MonthlyClaimErrorMsg().Text);
                Assert.AreEqual("Input for amount is not valid.", createClaimPage.UniqaErrorMsg().Text);
                Assert.AreEqual("Input for amount is not valid.", createClaimPage.BicycleErrorMsg().Text);
            }
            else
            {
                Assert.AreEqual("Neispravan format. Unesite broj u formatu: xxx-xxxxxxxxxxxxx-xx.", createClaimPage.AccNumToPayErrorMsg().Text);
                Assert.AreEqual("Uneti iznos nije ispravan.", createClaimPage.MonthlyClaimErrorMsg().Text);
                Assert.AreEqual("Uneti iznos nije ispravan.", createClaimPage.UniqaErrorMsg().Text);
                Assert.AreEqual("Uneti iznos nije ispravan.", createClaimPage.BicycleErrorMsg().Text);
            }


        }
    }
}
