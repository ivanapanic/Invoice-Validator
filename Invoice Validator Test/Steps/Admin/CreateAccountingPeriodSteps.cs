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
            Driver.Navigate().GoToUrl("http://intnstest:50080/Account/Login/?ReturnUrl=%2F");

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.UsernameInputField().SendKeys("IQService.admin1");
            loginPage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");

            loginPage.SignInButton().Click();
        }


        //TEST CREATE ACCOUNTING PERIOD WITH ACTIVE CHECKBOX
        [Given(@"Admin clicks on Create in Accounting periods dropdown")]
        public void GivenAdminClicksOnCreateInAccountingPeriodsDropdown()
        {
            AdminHomePage adminHomePage = new AdminHomePage(Driver);
            adminHomePage.AccountingPeriodHeaderDropdown().Click();
            adminHomePage.AccountingPeriodDropdownCreate().Click();
        }

        [Then(@"Create Accounting page is displayed")]
        public void ThenCreateAccountingPageIsDisplayed()
        {
            CreateAccountingPeriodPage createAccountingPeriodPage = new CreateAccountingPeriodPage(Driver);
            Assert.That(createAccountingPeriodPage.IsCreateAccountingPeriodPageDisplayed(), Is.True, "Create Acc Period is not displayed");
        }

        [When(@"admin enters valid data for new accounting period and leave checkbox checked")]
        public void WhenAdminEntersValidDataForNewAccountingPeriodAndLeaveCheckboxChecked()
        {
            CreateAccountingPeriodPage createAccountingPeriodPage = new CreateAccountingPeriodPage(Driver);
            AdminHomePage adminHomePage = new AdminHomePage(Driver);
            AccountingPeriodListPage accountingPeriodListPage = new AccountingPeriodListPage(Driver);

            //loop for month dropdowns depending on local language
            SelectElement selectMonth = new SelectElement(createAccountingPeriodPage.MonthDropDown());
            if (adminHomePage.LanguageDropDown().Text.Contains("EN"))
            {
                selectMonth.SelectByText(monthEn);

                //select claim issue date
                /*first we select day(first in month), after that we switch to month and 
                 * select month and than switch to year and select year*/
                createAccountingPeriodPage.ClaimIssueDateDropDown().Click();
                createAccountingPeriodPage.ClaimIssueDayPicker().Click();
                createAccountingPeriodPage.ClaimIssueMonthSwitcher().Click();
                createAccountingPeriodPage.ClaimIssueMonthPickerEn().Click();
                createAccountingPeriodPage.ClaimIssueMonthSwitcher().Click();
                createAccountingPeriodPage.ClaimIssueYearSwitcher().Click();
                createAccountingPeriodPage.ClaimIssueYearPicker().Click();

                //select claim payment date
                /*first we click on year input field to close claim issue calendar*/
                createAccountingPeriodPage.YearInputField().Click();
                /* then we select day(last in month), after that we switch to month and
                 *select month and than switch to year and select year*/
                createAccountingPeriodPage.ClaimPaymentDateDropDown().Click();
                createAccountingPeriodPage.ClaimPaymentDayPicker().Click();
                createAccountingPeriodPage.ClaimPaymentMonthSwitcher().Click();
                createAccountingPeriodPage.ClaimPaymentMonthPickerEn().Click();
                createAccountingPeriodPage.ClaimPaymentMonthSwitcher().Click();
                createAccountingPeriodPage.ClaimPaymentYearSwitcher().Click();
                createAccountingPeriodPage.ClaimPaymentYearPicker().Click();
            }
            else
            {
                selectMonth.SelectByText(monthRs);

                //select claim issue date
                createAccountingPeriodPage.ClaimIssueDateDropDown().Click();
                createAccountingPeriodPage.ClaimIssueDayPicker().Click();
                createAccountingPeriodPage.ClaimIssueMonthSwitcher().Click();
                createAccountingPeriodPage.ClaimIssueMonthPickerRs().Click();
                createAccountingPeriodPage.ClaimIssueMonthSwitcher().Click();
                createAccountingPeriodPage.ClaimIssueYearSwitcher().Click();
                createAccountingPeriodPage.ClaimIssueYearPicker().Click();

                createAccountingPeriodPage.YearInputField().Click();

                //select claim payment date
                createAccountingPeriodPage.ClaimPaymentDateDropDown().Click();
                createAccountingPeriodPage.ClaimPaymentDayPicker().Click();
                createAccountingPeriodPage.ClaimPaymentMonthSwitcher().Click();
                createAccountingPeriodPage.ClaimPaymentMonthPickerRs().Click();
                createAccountingPeriodPage.ClaimPaymentMonthSwitcher().Click();
                createAccountingPeriodPage.ClaimPaymentYearSwitcher().Click();
                createAccountingPeriodPage.ClaimPaymentYearPicker().Click();


            }

            
            createAccountingPeriodPage.YearInputField().Clear();
            createAccountingPeriodPage.YearInputField().SendKeys(year);
        
        }



        [When(@"admin clicks on button create")]
        public void WhenAdminClicksOnButtonCreate()
        {
            AccountingPeriodListPage listPage = new AccountingPeriodListPage(Driver);
            CreateAccountingPeriodPage createAccountingPeriodPage = new CreateAccountingPeriodPage(Driver);
            /*first we click on year input filed to close claim payment calendar*/
            createAccountingPeriodPage.YearInputField().Click();

            createAccountingPeriodPage.CreateButton().Click();

        }

        [Then(@"page is redirected to Accounting periods list page")]
        public void ThenPageIsRedirectedToAccountingPeriodsListPage()
        {
            AccountingPeriodListPage accountingPeriodListPage = new AccountingPeriodListPage(Driver);
            Assert.That(accountingPeriodListPage.IsAccountingPeriodListPageDisplayed(), Is.True, "Accounting periods list page is not displayed.");
        }

        [Then(@"new accounting period is displayed in list as active")]
        public void ThenNewAccountingPeriodIsDisplayedInListAsActive()
        {

            string accountingPeriodEn = monthEn + " " + year;
            string accountingPeriodRs = monthRs + " " + year;

            AccountingPeriodListPage accountingPeriodListPage = new AccountingPeriodListPage(Driver);
            AdminHomePage adminHomePage = new AdminHomePage(Driver);

            /*loop for status(active/inactive) of accounting period displayed in the list 
            depending on local language*/
            if (adminHomePage.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual("Yes", accountingPeriodListPage.Table().FindElement(By.XPath("//tr[contains(string(), '" + accountingPeriodEn + "')]//td[4]")).Text);
            }
            else
            {
                Assert.AreEqual("Da", accountingPeriodListPage.Table().FindElement(By.XPath("//tr[contains(string(), '" + accountingPeriodRs + "')]//td[4]")).Text);
            }
        }










        //TEST CREATE ACCOUNTING PERIOD WITH INACTIVE CHECKBOX
        [Given(@"Admin clicks on Create in Accounting period dropdown")]
        public void GivenAdminClicksOnCreateInAccountingPeriodDropdown()
        {
            AdminHomePage homePage = new AdminHomePage(Driver);

            homePage.AccountingPeriodHeaderDropdown().Click();
            homePage.AccountingPeriodDropdownCreate().Click();

        }

        [Then(@"Page Create Accounting period is displayed")]
        public void ThenPageCreateAccountingPeriodIsDisplayed()
        {
            CreateAccountingPeriodPage createAccPeriod = new CreateAccountingPeriodPage(Driver);
            Assert.That(createAccPeriod.IsCreateAccountingPeriodPageDisplayed(), Is.True, "Create Accounting period page is not displayed.");
        }

        [When(@"admin enters valid data in create accounting period form")]
        public void WhenAdminEntersValidDataInCreateAccountingPeriodForm()
        {

            CreateAccountingPeriodPage createAccountingPeriodPage = new CreateAccountingPeriodPage(Driver);
            AdminHomePage adminHomePage = new AdminHomePage(Driver);


            //loop for month dropdowns depending on local language
            SelectElement selectMonth = new SelectElement(createAccountingPeriodPage.MonthDropDown());
            if (adminHomePage.LanguageDropDown().Text.Contains("EN"))
            {
                selectMonth.SelectByText(monthEn);

                //select claim issue date
                /*first we select day(first in month), after that we switch to month and 
                 * select month and than switch to year and select year*/
                createAccountingPeriodPage.ClaimIssueDateDropDown().Click();
                createAccountingPeriodPage.ClaimIssueDayPicker().Click();
                createAccountingPeriodPage.ClaimIssueMonthSwitcher().Click();
                createAccountingPeriodPage.ClaimIssueMonthPickerEn().Click();
                createAccountingPeriodPage.ClaimIssueMonthSwitcher().Click();
                createAccountingPeriodPage.ClaimIssueYearSwitcher().Click();
                createAccountingPeriodPage.ClaimIssueYearPicker().Click();

                //select claim payment date
                /*first we click on year input field to close claim issue calendar*/
                createAccountingPeriodPage.YearInputField().Click();
                /* then we select day(last in month), after that we switch to month and
                 *select month and than switch to year and select year*/
                createAccountingPeriodPage.ClaimPaymentDateDropDown().Click();
                createAccountingPeriodPage.ClaimPaymentDayPicker().Click();
                createAccountingPeriodPage.ClaimPaymentMonthSwitcher().Click();
                createAccountingPeriodPage.ClaimPaymentMonthPickerEn().Click();
                createAccountingPeriodPage.ClaimPaymentMonthSwitcher().Click();
                createAccountingPeriodPage.ClaimPaymentYearSwitcher().Click();
                createAccountingPeriodPage.ClaimPaymentYearPicker().Click();
            }
            else
            {
                selectMonth.SelectByText(monthRs);

                //select claim issue date
                createAccountingPeriodPage.ClaimIssueDateDropDown().Click();
                createAccountingPeriodPage.ClaimIssueDayPicker().Click();
                createAccountingPeriodPage.ClaimIssueMonthSwitcher().Click();
                createAccountingPeriodPage.ClaimIssueMonthPickerRs().Click();
                createAccountingPeriodPage.ClaimIssueMonthSwitcher().Click();
                createAccountingPeriodPage.ClaimIssueYearSwitcher().Click();
                createAccountingPeriodPage.ClaimIssueYearPicker().Click();

                createAccountingPeriodPage.YearInputField().Click();

                //select claim payment date
                createAccountingPeriodPage.ClaimPaymentDateDropDown().Click();
                createAccountingPeriodPage.ClaimPaymentDayPicker().Click();
                createAccountingPeriodPage.ClaimPaymentMonthSwitcher().Click();
                createAccountingPeriodPage.ClaimPaymentMonthPickerRs().Click();
                createAccountingPeriodPage.ClaimPaymentMonthSwitcher().Click();
                createAccountingPeriodPage.ClaimPaymentYearSwitcher().Click();
                createAccountingPeriodPage.ClaimPaymentYearPicker().Click();


            }


            createAccountingPeriodPage.YearInputField().Clear();
            createAccountingPeriodPage.YearInputField().SendKeys(year);



        }

        [When(@"admin uncheck Active checkbox")]
        public void WhenAdminUncheckActiveCheckbox()
        {
            CreateAccountingPeriodPage createAccPeriod = new CreateAccountingPeriodPage(Driver);
            /*first we click on year input filed to close claim payment calendar*/
            createAccPeriod.YearInputField().Click();
            /*then we uncheck checkbox*/
            createAccPeriod.ActiveCheckBox().Click();
        }

        [When(@"admin clicks on create")]
        public void WhenAdminClicksOnCreate()
        {
            CreateAccountingPeriodPage createAccPeriod = new CreateAccountingPeriodPage(Driver);
            createAccPeriod.CreateButton().Click();
        }

        [Then(@"page is redirected to List of Accounting periods page")]
        public void PageIsRedirectedToListOfAccountingPeriodsPage()
        {
            AccountingPeriodListPage accListPage = new AccountingPeriodListPage(Driver);
            Assert.That(accListPage.IsAccountingPeriodListPageDisplayed(), Is.True, "Create Accounting period page is not displayed.");
        }

        [Then(@"new accounting period is displayed in list as inactive")]
        public void ThenNewAccountingPeriodIsDisplayedInListAsInactive()
        {
            string accountingPeriodEn = monthEn + " " + year;
            string accountingPeriodRs = monthRs + " " + year;
            AccountingPeriodListPage accListPage = new AccountingPeriodListPage(Driver);
            AdminHomePage homePage = new AdminHomePage(Driver);

            //loop for status(active/inactive) of accounting period displayed in the list depending on local language
            if (homePage.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual("No", accListPage.Table().FindElement(By.XPath("//tr[contains(string(), '" + accountingPeriodEn + "')]//td[4]")).Text);
            }
            else
            {
                Assert.AreEqual("Ne", accListPage.Table().FindElement(By.XPath("//tr[contains(string(), '" + accountingPeriodRs + "')]//td[4]")).Text);
            }



        }


        //TEST CREATE ACCOUNTING PERIOD WITH INVALID YEAR AND DATE FORMAT
        [Given(@"Admin clicks on Create button in Accounting period dropdown")]
        public void GivenAdminClicksOnCreateButtonInAccountingPeriodDropdown()
        {
            AdminHomePage homePage = new AdminHomePage(Driver);
            homePage.AccountingPeriodHeaderDropdown().Click();
            homePage.AccountingPeriodDropdownCreate().Click();
        }

        [Then(@"Page Create Accounting period with Create form is displayed")]
        public void ThenPageCreateAccountingPeriodWithCreateFormIsDisplayed()
        {
            CreateAccountingPeriodPage createAccPeriod = new CreateAccountingPeriodPage(Driver);
            Assert.That(createAccPeriod.IsCreateAccountingPeriodPageDisplayed(), Is.True, "Create Accounting period page is not displayed.");
        }

        [When(@"admin enters invalid data in create accounting period form")]
        public void WhenAdminEntersInvalidDataInCreateAccountingPeriodForm()
        {
            CreateAccountingPeriodPage createAccPeriod = new CreateAccountingPeriodPage(Driver);

            AdminHomePage homePage = new AdminHomePage(Driver);


            //loop for date format depending on local language
            if (homePage.LanguageDropDown().Text.Contains("EN"))
            {

                //first we select month and input invalid dates format
                SelectElement selectMonth = new SelectElement(createAccPeriod.MonthDropDown());
                selectMonth.SelectByText(monthEn);

                createAccPeriod.ClaimIssueDateDropDown().SendKeys(claimRSIssueDate);
                createAccPeriod.YearInputField().Click();

                createAccPeriod.ClaimPaymentDateDropDown().SendKeys(claimRSIssueDate);
                createAccPeriod.YearInputField().Click();

                /*then we click on create button to get error messages for 
                 claim issue and claim payment*/
                createAccPeriod.CreateButton().Click();

                /*in the end we input invalid year 
                 * because error messages for claim issue and claim payment 
                 * are not going to display if we first enter year and than claim issue and claim payment*/
                createAccPeriod.YearInputField().Clear();
               
                //and than again click create button to get year error message
                createAccPeriod.YearInputField().SendKeys(invalidYear);
            }
            else
            {

                SelectElement selectMonth = new SelectElement(createAccPeriod.MonthDropDown());
                selectMonth.SelectByText(monthRs);

                createAccPeriod.ClaimIssueDateDropDown().SendKeys(claimEnIssueDate);
                createAccPeriod.YearInputField().Click(); 

                createAccPeriod.ClaimPaymentDateDropDown().SendKeys(claimEnPaymentDate);
                createAccPeriod.YearInputField().Click(); 

                createAccPeriod.CreateButton().Click();

                createAccPeriod.YearInputField().Clear();

                createAccPeriod.YearInputField().SendKeys(invalidYear);
            }

            


        }

        [When(@"admin clicks on create button")]
        public void WhenAdminClicksOnCreateButton()
        {
            CreateAccountingPeriodPage createAccPeriod = new CreateAccountingPeriodPage(Driver);
            createAccPeriod.CreateButton().Click();
        }

        [Then(@"expected messages are displayed")]
        public void ThenExpectedMessagesAreDisplayed()
        {
            CreateAccountingPeriodPage createAccPeriod = new CreateAccountingPeriodPage(Driver);
            AdminHomePage homePage = new AdminHomePage(Driver);


            //loop for error messages depending on local language
            if (homePage.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual("Input for year must be between 1990 and 2100.", createAccPeriod.YearErrorMessage().Text);
                Assert.AreEqual("Claim date is not valid.", createAccPeriod.ClaimIssueFormatErrorMessage().Text);
                Assert.AreEqual("Claim payment date is not valid.", createAccPeriod.ClaimPaymentFormatErrorMessage().Text);
            }
            else
            {
                Assert.AreEqual("Unos za godinu mora biti između 1990 i 2100.", createAccPeriod.YearErrorMessage().Text);
                Assert.AreEqual("Datum izdavanja fakture je neispravan.", createAccPeriod.ClaimIssueFormatErrorMessage().Text);
                Assert.AreEqual("Datum prometa usluga je neispravan.", createAccPeriod.ClaimPaymentFormatErrorMessage().Text);
            }
        }




        //TEST CREATE ACCOUNTING PERIOD WITH EMPTY FIELDS
        [Given(@"Admin clicks on button Create in Accounting period dropdown")]
        public void GivenAdminlicksOnButtonCreateInAccountingePriodDropdown()
        {
            AdminHomePage homePage = new AdminHomePage(Driver);
            homePage.AccountingPeriodHeaderDropdown().Click();
            homePage.AccountingPeriodDropdownCreate().Click();
        }

        [Then(@"Page Create with Create Accounting period form is displayed")]
        public void ThenPageCreateWithCreateAccountingPeriodFormIsDisplayed()
        {
            CreateAccountingPeriodPage createAccPeriod = new CreateAccountingPeriodPage(Driver);
            Assert.That(createAccPeriod.IsCreateAccountingPeriodPageDisplayed(), Is.True, "Create Accounting period page is not displayed.");
        }

        [When(@"admin leaves fields empty")]
        public void WhenAdminLeavesFieldsEmpty()
        {
            CreateAccountingPeriodPage createAccPeriod = new CreateAccountingPeriodPage(Driver);
            createAccPeriod.YearInputField().Clear();
            createAccPeriod.CreateButton().Click();
        }

        [Then(@"expected error messages are displayed")]
        public void ThenExpectedErrorMessagesAreDisplayed()
        {
            CreateAccountingPeriodPage createAccPeriod = new CreateAccountingPeriodPage(Driver);
            AdminHomePage homePage = new AdminHomePage(Driver);

            //loop for error messages depending on local language
            if (homePage.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual("Input for year is required.", createAccPeriod.YearErrorMessage().Text);
                Assert.AreEqual("Input for claim date is required.", createAccPeriod.ClaimIssueEmptyErrorMessage().Text);
                Assert.AreEqual("Input for claim payment date is required.", createAccPeriod.ClaimPaymentEmptyErrorMessage().Text);
            }
            else
            {
                Assert.AreEqual("Unos godine je obavezan.", createAccPeriod.YearErrorMessage().Text);
                Assert.AreEqual("Unos datuma izdavanja fakture je obavezan.", createAccPeriod.ClaimIssueEmptyErrorMessage().Text);
                Assert.AreEqual("Unos datuma prometa usluga je obavezan.", createAccPeriod.ClaimPaymentEmptyErrorMessage().Text);
            }
        }
    }
}
