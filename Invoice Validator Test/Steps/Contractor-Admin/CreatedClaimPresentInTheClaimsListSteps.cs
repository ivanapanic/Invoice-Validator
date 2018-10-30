using Invoice_Validator_Test.Pages;
using Invoice_Validator_Test.Pages.Admin;
using Invoice_Validator_Test.Pages.Admin.Contractor_Claims;
using Invoice_Validator_Test.Pages.Contractor;
using Invoice_Validator_Test.Pages.Contractor.Claims;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Web.UI.WebControls;
using TechTalk.SpecFlow;

namespace Invoice_Validator_Test.Steps.Contractor_Admin
{
    [Binding]
    public class CreatedClaimPresentInTheClaimsListSteps : BaseSteps
    {
        private CreateClaimPage createClaimPage = new CreateClaimPage(Driver);
        private HomePage homePage = new HomePage(Driver);
        private ClaimsListPage claimsListPage = new ClaimsListPage(Driver);
        private LoginPage loginPage = new LoginPage(Driver);
        private ContractorClaimsListPage contractorClaimsListPage = new ContractorClaimsListPage(Driver);

        public void CreateClaimPageTests()
        {
            LoginPage loginPage = new LoginPage(Driver);
            CreateClaimPage contractorHomePage = new CreateClaimPage(Driver);
            HomePage homePage = new HomePage(Driver);

            loginPage.LoginAsContractor();
            homePage.SetRandomLocalLanguage();
        }

        public void ClaimsListPageTests()
        {
            LoginPage loginPage = new LoginPage(Driver);
            HomePage homePage = new HomePage(Driver);

            loginPage.LoginAsAdmin();
            homePage.NavigateToClaimsListPage();
        }

        //VARIABLES
        string accNumToPay = GenerateRandomData.GenerateRandomNumber(3) + "-" +
            GenerateRandomData.GenerateRandomNumber(13) + "-" +
            GenerateRandomData.GenerateRandomNumber(2);

        static string monthlyClaim = GenerateRandomData.GenerateRandomNumber(5);
        static string uniqa = GenerateRandomData.GenerateRandomNumber(3);
        static string bicycle = GenerateRandomData.GenerateRandomNumber(4);


        //TEST CREATED CLAIM IS PRESENT IN THE CLAIMS LIST USING FILTER/SEARCH FORM
        [Given(@"User is logged in as contractor")]
        public void GivenUserIsLoggedInAsContractor()
        {
            CreateClaimPageTests();
        }

        [Given(@"Contractor Home page is displayed")]
        public void GivenContractorHomePageIsDisplayed()
        {
            Assert.That(homePage.IsHomePageDisplayed(), Is.True, "Contractor Home page is not displayed.");
        }

        [When(@"contractor enters data in create claim form")]
        public void WhenContractorEntersDataInCreateClaimForm()
        {
            createClaimPage.SelectAccountingPeriod();
            //clear input fields
            createClaimPage.ClearCreateClaimFields();

            //enter data in input fields
            createClaimPage.FillAllCreateClaimFields(accNumToPay, monthlyClaim, uniqa, bicycle);
        }



        [When(@"clicks Create button on create claim page")]
        public void WhenClicksCreateButtonOnCreateClaimPage()
        {
            createClaimPage.ClickCreate();
        }

        [When(@"contractor clicks on sign out button")]
        public void WhenContractorClicksOnSignOutButton()
        {

            homePage.SignOut();
        }

        [Then(@"page is redirected to login page")]
        public void ThenPageIsRedirectedToLoginPage()
        {
            Assert.That(loginPage.IsLoginPageDisplayed(), Is.True, "Login page is not displayed.");
        }

        [When(@"user logs in as admin")]
        public void WhenUserLogsInAsAdmin()
        {
            ClaimsListPageTests();
        }

        [When(@"redirect page to Contractor claims page")]
        public void WhenRedirectPageToContractorClaimsPage()
        {
            Assert.That(contractorClaimsListPage.IsContractorClaimsListPageDisplayed(), Is.True, "Contractor Claims List page is not displayed.");
        }



        //filter form
        [When(@"admin enters data for filtering claim")]
        public void WhenAddDataForFilteringClaim()
        {
            contractorClaimsListPage.FillFieldsForFilter();
        }


        [Then(@"contractors's created claim is displayed in list")]
        public void ThenContractorsSCreatedClaimIsDisplayedInList()
        {
            Assert.AreEqual(accNumToPay, contractorClaimsListPage.Table().FindElement(By.XPath("//td[5][contains(string(), '" + accNumToPay + "')]")).Text);
        }


        //search form
        [When(@"admin enters data for searching claim")]
        public void WhenAddDataForSearchingClaim()
        {
            contractorClaimsListPage.FilterSerachSwitch();

            //loop for criteria dropdown depending on local language
            if (homePage.LanguageDropDown().Text.Contains("EN"))
            {
                contractorClaimsListPage.FillFieldsForSearch(accNumToPay, "Account number to pay");
            }
            else
            {
                contractorClaimsListPage.FillFieldsForSearch(accNumToPay, "Obračunski period");
            }

        }


        [Then(@"created claim is displayed in list")]
        public void ThenCreatedClaimIsDisplayedInList()
        {
            Assert.AreEqual(accNumToPay, contractorClaimsListPage.Table().FindElement(By.XPath("//td[5][contains(string(), '" + accNumToPay + "')]")).Text);
        }
    }
}


