using Invoice_Validator_Test.Pages;
using Invoice_Validator_Test.Pages.Admin;
using Invoice_Validator_Test.Pages.Admin.Accounting_Periods;
using Invoice_Validator_Test.Steps;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using TechTalk.SpecFlow;

namespace Invoice_Validator_Test
{

    [Binding]
    public class CreateAccountingPeriodSteps : BaseSteps
    { 
        private LoginPage loginPage = new LoginPage(Driver);
        private CreateAccountingPeriodPage createAccountingPeriodPage = new CreateAccountingPeriodPage(Driver);
        private AccountingPeriodListPage accountingPeriodsListPage = new AccountingPeriodListPage(Driver);
        private HomePage homePage = new HomePage(Driver);

        public void CreateAccountingPeriodPageTests()
        {
            LoginPage loginPage = new LoginPage(Driver);
            HomePage homePage = new HomePage(Driver);

            loginPage.LoginAsAdmin();
            homePage.SetRandomLocalLanguage();
            homePage.NavigateToCreateAccountingPage();
        }

        //VARIABLES
        //valid

        string monthEn = CreateAccountingPeriodPage.GenerateENMonths();
        string monthRs = CreateAccountingPeriodPage.GenerateRSMonths();
        string year = CreateAccountingPeriodPage.GenerateRandomYear().ToString();


        //invalid
        string invalidYear = CreateAccountingPeriodPage.GenerateInvalidBoundariesYearValues();
        string claimRSIssueDate = CreateAccountingPeriodPage.PrintRSDate();
        string claimRSPayementDate = CreateAccountingPeriodPage.PrintRSDate();
        string claimEnIssueDate = CreateAccountingPeriodPage.PrintENDate();
        string claimEnPaymentDate = CreateAccountingPeriodPage.PrintENDate();

       


        //LOGIN
        [Given(@"Login with admin credentials")]
        public void GivenLoginWithAdminCredentials()
        {
            CreateAccountingPeriodPageTests();
        }


        //TEST CREATE ACCOUNTING PERIOD WITH ACTIVE CHECKBOX
        [Given(@"Create Accounting page is displayed")]
        public void ThenCreateAccountingPageIsDisplayed()
        {
            Assert.That(createAccountingPeriodPage.IsCreateAccountingPeriodPageDisplayed(), Is.True, "Create Acc Period is not displayed");
        }

        [When(@"admin enters valid data for new accounting period and leave checkbox checked")]
        public void WhenAdminEntersValidDataForNewAccountingPeriodAndLeaveCheckboxChecked()
        {
            //loop for month dropdowns depending on local language
            if (homePage.LanguageDropDown().Text.Contains("EN"))
            {
                createAccountingPeriodPage.SelectMonth(monthEn);
                createAccountingPeriodPage.SelectClaimIssueDate(createAccountingPeriodPage.ClaimIssueMonthPickerEn());
                createAccountingPeriodPage.ClickYearInputField(); //first we click on year input field to close claim issue calendar
                createAccountingPeriodPage.SelectClaimPaymentDate(createAccountingPeriodPage.ClaimPaymentMonthPickerEn());              
            }
            else
            {
                createAccountingPeriodPage.SelectMonth(monthRs);
                createAccountingPeriodPage.SelectClaimIssueDate(createAccountingPeriodPage.ClaimIssueMonthPickerRs());
                createAccountingPeriodPage.ClickYearInputField();
                createAccountingPeriodPage.SelectClaimPaymentDate(createAccountingPeriodPage.ClaimPaymentMonthPickerRs());
            }


            createAccountingPeriodPage.EnterYear(year);
        
        }



        [When(@"admin clicks on button create")]
        public void WhenAdminClicksOnButtonCreate()
        {
            /*first we click on year input filed to close claim payment calendar*/
            createAccountingPeriodPage.ClickYearInputField();
            createAccountingPeriodPage.ClickCreate();
        }

        [Then(@"page is redirected to Accounting periods list page")]
        public void ThenPageIsRedirectedToAccountingPeriodsListPage()
        {
            Assert.That(accountingPeriodsListPage.IsAccountingPeriodListPageDisplayed(), Is.True, "Accounting periods list page is not displayed.");
        }

        [Then(@"new accounting period is displayed in list as active")]
        public void ThenNewAccountingPeriodIsDisplayedInListAsActive()
        {
            string accountingPeriodEn = monthEn + " " + year;
            string accountingPeriodRs = monthRs + " " + year;
            /*loop for status(active/inactive) of accounting period displayed in the list 
            depending on local language*/
            if (homePage.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual("Yes", accountingPeriodsListPage.Table().FindElement(By.XPath("//tr[contains(string(), '" + accountingPeriodEn + "')]//td[4]")).Text);
            }
            else
            {
                Assert.AreEqual("Da", accountingPeriodsListPage.Table().FindElement(By.XPath("//tr[contains(string(), '" + accountingPeriodRs + "')]//td[4]")).Text);
            }
        }










        //TEST CREATE ACCOUNTING PERIOD WITH INACTIVE CHECKBOX
        [Given(@"Page Create Accounting period is displayed")]
        public void ThenPageCreateAccountingPeriodIsDisplayed()
        {
            Assert.That(createAccountingPeriodPage.IsCreateAccountingPeriodPageDisplayed(), Is.True, "Create Accounting period page is not displayed.");
        }

        [When(@"admin enters valid data in create accounting period form")]
        public void WhenAdminEntersValidDataInCreateAccountingPeriodForm()
        {

            //loop for month dropdowns depending on local language
            if (homePage.LanguageDropDown().Text.Contains("EN"))
            {
                createAccountingPeriodPage.SelectMonth(monthEn);
                createAccountingPeriodPage.SelectClaimIssueDate(createAccountingPeriodPage.ClaimIssueMonthPickerEn());
                createAccountingPeriodPage.ClickYearInputField(); //first we click on year input field to close claim issue calendar
                createAccountingPeriodPage.SelectClaimPaymentDate(createAccountingPeriodPage.ClaimPaymentMonthPickerEn());
            }
            else
            {
                createAccountingPeriodPage.SelectMonth(monthRs);
                createAccountingPeriodPage.SelectClaimIssueDate(createAccountingPeriodPage.ClaimIssueMonthPickerRs());
                createAccountingPeriodPage.ClickYearInputField();
                createAccountingPeriodPage.SelectClaimPaymentDate(createAccountingPeriodPage.ClaimPaymentMonthPickerRs());
            }


            createAccountingPeriodPage.EnterYear(year);
        }

        [When(@"admin uncheck Active checkbox")]
        public void WhenAdminUncheckActiveCheckbox()
        {
            /*first we click on year input filed to close claim payment calendar*/
            createAccountingPeriodPage.ClickYearInputField();
            /*then we uncheck checkbox*/
            createAccountingPeriodPage.CheckActiveCheckbox();
        }

        [When(@"admin clicks on create")]
        public void WhenAdminClicksOnCreate()
        {
            createAccountingPeriodPage.ClickCreate();
        }

        [Then(@"page is redirected to List of Accounting periods page")]
        public void PageIsRedirectedToListOfAccountingPeriodsPage()
        {
            Assert.That(accountingPeriodsListPage.IsAccountingPeriodListPageDisplayed(), Is.True, "Create Accounting period page is not displayed.");
        }

        [Then(@"new accounting period is displayed in list as inactive")]
        public void ThenNewAccountingPeriodIsDisplayedInListAsInactive()
        {
            string accountingPeriodEn = monthEn + " " + year;
            string accountingPeriodRs = monthRs + " " + year;

            //loop for status(active/inactive) of accounting period displayed in the list depending on local language
            if (homePage.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual("No", accountingPeriodsListPage.Table().FindElement(By.XPath("//tr[contains(string(), '" + accountingPeriodEn + "')]//td[4]")).Text);
            }
            else
            {
                Assert.AreEqual("Ne", accountingPeriodsListPage.Table().FindElement(By.XPath("//tr[contains(string(), '" + accountingPeriodRs + "')]//td[4]")).Text);
            }

        }


        //TEST CREATE ACCOUNTING PERIOD WITH INVALID YEAR AND DATE FORMAT
        [Given(@"Page Create Accounting period with Create form is displayed")]
        public void ThenPageCreateAccountingPeriodWithCreateFormIsDisplayed()
        {
            Assert.That(createAccountingPeriodPage.IsCreateAccountingPeriodPageDisplayed(), Is.True, "Create Accounting period page is not displayed.");
        }

        [When(@"admin enters invalid data in create accounting period form")]
        public void WhenAdminEntersInvalidDataInCreateAccountingPeriodForm()
        {
            //loop for date format depending on local language
            if (homePage.LanguageDropDown().Text.Contains("EN"))
            {
                createAccountingPeriodPage.SelectMonth(monthEn);
                createAccountingPeriodPage.EnterInvalidDateFormat(claimRSIssueDate, claimEnPaymentDate);
                createAccountingPeriodPage.ClickCreate();
                createAccountingPeriodPage.EnterYear(invalidYear);
            }
            else
            {
                createAccountingPeriodPage.SelectMonth(monthRs);
                createAccountingPeriodPage.EnterInvalidDateFormat(claimEnIssueDate, claimEnPaymentDate);
                createAccountingPeriodPage.ClickCreate();
                createAccountingPeriodPage.EnterYear(invalidYear);
            }
        }

        [When(@"admin clicks on create button")]
        public void WhenAdminClicksOnCreateButton()
        {
            createAccountingPeriodPage.ClickCreate();
        }

        [Then(@"expected messages are displayed")]
        public void ThenExpectedMessagesAreDisplayed()
        {
            //loop for error messages depending on local language
            if (homePage.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual("Input for year must be between 1990 and 2100.", createAccountingPeriodPage.YearErrorMessage().Text);
                Assert.AreEqual("Claim date is not valid.", createAccountingPeriodPage.ClaimIssueFormatErrorMessage().Text);
                Assert.AreEqual("Claim payment date is not valid.", createAccountingPeriodPage.ClaimPaymentFormatErrorMessage().Text);
            }
            else
            {
                Assert.AreEqual("Unos za godinu mora biti između 1990 i 2100.", createAccountingPeriodPage.YearErrorMessage().Text);
                Assert.AreEqual("Datum izdavanja fakture je neispravan.", createAccountingPeriodPage.ClaimIssueFormatErrorMessage().Text);
                Assert.AreEqual("Datum prometa usluga je neispravan.", createAccountingPeriodPage.ClaimPaymentFormatErrorMessage().Text);
            }
        }




        //TEST CREATE ACCOUNTING PERIOD WITH EMPTY FIELDS
        [Given(@"Page Create with Create Accounting period form is displayed")]
        public void ThenPageCreateWithCreateAccountingPeriodFormIsDisplayed()
        {
            Assert.That(createAccountingPeriodPage.IsCreateAccountingPeriodPageDisplayed(), Is.True, "Create Accounting period page is not displayed.");
        }

        [When(@"admin leaves fields empty")]
        public void WhenAdminLeavesFieldsEmpty()
        {
            createAccountingPeriodPage.ClearFields();
            createAccountingPeriodPage.ClickCreate();
        }

        [Then(@"expected error messages are displayed")]
        public void ThenExpectedErrorMessagesAreDisplayed()
        {
            //loop for error messages depending on local language
            if (homePage.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual("Input for year is required.", createAccountingPeriodPage.YearErrorMessage().Text);
                Assert.AreEqual("Input for claim date is required.", createAccountingPeriodPage.ClaimIssueEmptyErrorMessage().Text);
                Assert.AreEqual("Input for claim payment date is required.", createAccountingPeriodPage.ClaimPaymentEmptyErrorMessage().Text);
            }
            else
            {
                Assert.AreEqual("Unos godine je obavezan.", createAccountingPeriodPage.YearErrorMessage().Text);
                Assert.AreEqual("Unos datuma izdavanja fakture je obavezan.", createAccountingPeriodPage.ClaimIssueEmptyErrorMessage().Text);
                Assert.AreEqual("Unos datuma prometa usluga je obavezan.", createAccountingPeriodPage.ClaimPaymentEmptyErrorMessage().Text);
            }
        }
    }
}
