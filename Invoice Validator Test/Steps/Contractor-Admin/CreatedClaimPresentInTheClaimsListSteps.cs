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
            Driver.Navigate().GoToUrl("http://intnstest:50080/Account/Login/?ReturnUrl=%2F");

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.UsernameInputField().SendKeys("IQService.contractor1");
            loginPage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");

            loginPage.SignInButton().Click();
        }

        [Given(@"Contractor Home page is displayed")]
        public void GivenContractorHomePageIsDisplayed()
        {
            ContractorHomePage contractorHomePage = new ContractorHomePage(Driver);
            Assert.That(contractorHomePage.IsContractorHomePageDisplayed(), Is.True, "Contractor Home page is not displayed.");
        }

        [When(@"contractor enters data in create claim form")]
        public void WhenContractorEntersDataInCreateClaimForm()
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
        }



        [When(@"clicks Create button on create claim page")]
        public void WhenClicksCreateButtonOnCreateClaimPage()
        {
            ContractorHomePage contractorHomePage = new ContractorHomePage(Driver);
            contractorHomePage.CreateClaimButton().Click();
        }

        [When(@"contractor clicks on sign out button")]
        public void WhenContractorClicksOnSignOutButton()
        {

            AdminHomePage adminHomePage = new AdminHomePage(Driver);
            adminHomePage.SignOut().Click();
        }

        [Then(@"page is redirected to login page")]
        public void ThenPageIsRedirectedToLoginPage()
        {
            LoginPage loginPage = new LoginPage(Driver);
            Assert.That(loginPage.IsLoginPageDisplayed(), Is.True, "Login page is not displayed.");
        }

        [When(@"user logs in as admin")]
        public void WhenUserLogsInAsAdmin()
        {
            LoginPage loginPage = new LoginPage(Driver);

            //clear input fields
            loginPage.UsernameInputField().Clear();
            loginPage.PasswordInputField().Clear();

            //enter data in input fields
            loginPage.UsernameInputField().SendKeys("IQService.admin1");
            loginPage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");

            loginPage.SignInButton().Click();
        }

        [Then(@"Admin home is displayed")]
        public void ThenAdminHomeIsDisplayed()
        {
            AdminHomePage adminHomePage = new AdminHomePage(Driver);
            adminHomePage.IsAdminHomePageDisplayed();
        }

        [When(@"admin clicks on List button in Contractors claims dropdown in Header menu")]
        public void WhenAdminClicksOnListButtonInContractorsClaimsDropdownInHeaderMenu()
        {
            AdminHomePage adminHomePage = new AdminHomePage(Driver);
            adminHomePage.ContractorClaimsDropdown().Click();
            adminHomePage.ContractorClaimsDropdownList().Click();
        }


        [Then(@"page is redirected to Contractor claims page")]
        public void ThenPageIsRedirectedToContractorClaimsPage()
        {
            ContractorClaimsListPage contractorClaimsListPage = new ContractorClaimsListPage(Driver);
            Assert.That(contractorClaimsListPage.IsContractorClaimsListPageDisplayed(), Is.True, "Contractor Claims List page is not displayed.");
        }



        //filter form
        [When(@"admin enters data for filtering claim")]
        public void WhenAddDataForFilteringClaim()
        {

            ContractorClaimsListPage contractorClaimsListPage = new ContractorClaimsListPage(Driver);
            contractorClaimsListPage.UsernameInputfield().SendKeys("IQService.contractor1");
            contractorClaimsListPage.TotalFrom().SendKeys("0");
            contractorClaimsListPage.TotalTo().SendKeys(GenerateRandomData.GenerateRandomNumber(15));
            contractorClaimsListPage.FilterSubmitButton().Click();
        }


        [Then(@"contractors's created claim is displayed in list")]
        public void ThenContractorsSCreatedClaimIsDisplayedInList()
        {
            ContractorClaimsListPage contractorClaimsListPage = new ContractorClaimsListPage(Driver);
            Assert.AreEqual(accNumToPay, contractorClaimsListPage.Table().FindElement(By.XPath("//td[5][contains(string(), '" + accNumToPay + "')]")).Text);
        }


        //search form
        [When(@"admin enters data for searching claim")]
        public void WhenAddDataForSearchingClaim()
        {
            ContractorClaimsListPage contractorClaimsListPage = new ContractorClaimsListPage(Driver);
            ContractorHomePage contractorHomePage = new ContractorHomePage(Driver);
            contractorClaimsListPage.FilterSearchButton().Click();

            contractorClaimsListPage.InputSearchCriteria().SendKeys(accNumToPay);
            SelectElement selectCriteria = new SelectElement(contractorClaimsListPage.SelectSearchCriteria());

            //loop for criteria dropdown depending on local language
            if (contractorHomePage.LanguageDropDown().Text.Contains("EN"))
            {
                selectCriteria.SelectByText("Account number to pay");
            }
            else
            {
                selectCriteria.SelectByText("Obračunski period");
            }
            GenerateRandomData.SelectRandomElement(contractorClaimsListPage.OrderBy());


            contractorClaimsListPage.SearchSubmitButton().Click();

        }


        [Then(@"created claim is displayed in list")]
        public void ThenCreatedClaimIsDisplayedInList()
        {
            ContractorClaimsListPage contractorClaimsListPage = new ContractorClaimsListPage(Driver);
            Assert.AreEqual(accNumToPay, contractorClaimsListPage.Table().FindElement(By.XPath("//td[5][contains(string(), '" + accNumToPay + "')]")).Text);

        }
    }
}


