using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Validator_Test.Pages.Admin
{
    class CreateAccountingPeriodPage
    {
        private IWebDriver driver;


        public CreateAccountingPeriodPage(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']")));

        }

        public bool IsCreateAccountingPeriodPageDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/AccountingPeriods/Create"));
        }

        


        //elements
        public IWebElement MonthDropDown()
        {
            
            By month = By.Id("Month");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(month));
        }


        public IWebElement YearInputField()
        {
            By yearField = By.Id("Year");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(yearField));
        }

        //claim issue
        public IWebElement ClaimIssueDateDropDown()
        {
            By claimIssueDate = By.Id("ClaimDate");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(claimIssueDate));
        }

        public IWebElement ClaimIssueMonthSwitcher()
        {
            By claimIssueMonthSwitcher = By.XPath("//div[@class='datepicker dropdown-menu'][1]//div[1]//th[@class='switch']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(claimIssueMonthSwitcher));
        }

        public IWebElement ClaimIssueYearSwitcher()
        {
            By claimIssueYearSwitcher = By.XPath("//div[@class='datepicker dropdown-menu'][1]//div[2]//th[@class='switch']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(claimIssueYearSwitcher));
        }


        public IWebElement ClaimIssueDayPicker()
        {
            By claimIssueDay = By.XPath("//div[@class='datepicker dropdown-menu'][1]//div[1]//tr[1]//td[@class='day '][1]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(claimIssueDay));
        }

        public IWebElement ClaimIssueMonthPickerEn()
        {
            By claimIssueMonth = By.XPath("//div[@class='datepicker dropdown-menu'][1]//div[2]//span[contains(., 'June')]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(claimIssueMonth));
        }

        public IWebElement ClaimIssueMonthPickerRs()
        {
            By claimIssueMonth = By.XPath("//div[@class='datepicker dropdown-menu'][1]//div[2]//span[contains(., 'June')]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(claimIssueMonth));
        }



        public IWebElement ClaimIssueYearPicker()
        {
            By claimIssueYear = By.XPath("//div[@class='datepicker dropdown-menu'][1]//div[3]//span[contains(., '2015')]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(claimIssueYear));
        }





        //claim payment
        public IWebElement ClaimPaymentDateDropDown()
        {
            By claimPaymentDate = By.Id("ClaimPaymentDate");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(claimPaymentDate));
        }

        public IWebElement ClaimPaymentMonthSwitcher()
        {
            By claimPaymentMonthSwitcher = By.XPath("//div[@class='datepicker dropdown-menu'][2]//div[1]//th[@class='switch']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(claimPaymentMonthSwitcher));
        }

        public IWebElement ClaimPaymentYearSwitcher()
        {
            By claimPaymentYearSwitcher = By.XPath("//div[@class='datepicker dropdown-menu'][2]//div[2]//th[@class='switch']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(claimPaymentYearSwitcher));
        }


        public IWebElement ClaimPaymentDayPicker()
        {
            By claimPaymentDay = By.XPath("//div[@class='datepicker dropdown-menu'][2]//div[1]//tr[5]//td[4]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(claimPaymentDay));
        }

        public IWebElement ClaimPaymentMonthPickerEn()
        {
            By claimPaymentMonth = By.XPath("//div[@class='datepicker dropdown-menu'][2]//div[2]//span[contains(., 'June')]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(claimPaymentMonth));
        }

        public IWebElement ClaimPaymentMonthPickerRs()
        {
            By claimPaymentMonth = By.XPath("//div[@class='datepicker dropdown-menu'][2]//div[2]//span[contains(., 'June')]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(claimPaymentMonth));
        }

        public IWebElement ClaimPaymentYearPicker()
        {
            By claimPaymentYear = By.XPath("//div[@class='datepicker dropdown-menu'][2]//div[3]//span[contains(., '2015')]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(claimPaymentYear));
        }



        public IWebElement ActiveCheckBox()
        {
            By activeCheckbox = By.Name("Active");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(activeCheckbox));
        }

        public IWebElement CreateButton()
        {
            By createButton = By.XPath("//input[@type='submit']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(createButton));
        }



        //error messages
        public IWebElement ExistingAccPeriodErrorMessage()
        {
            By errorMsg = By.XPath("//span//span[contains(string(),'Specified accounting period already exists.')]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(errorMsg));
        }

        public IWebElement YearErrorMessage()
        {
            By year = By.Id("Year-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(year));
        }

        public IWebElement ClaimIssueFormatErrorMessage()
        {
            By claimIssue = By.XPath("//span[contains(string(), 'Claim date is not valid.') or contains(string(), 'Datum izdavanja fakture je neispravan.')]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(claimIssue));
        }

        public IWebElement ClaimPaymentFormatErrorMessage()
        {
            By claimPayment = By.XPath("//span[contains(string(), 'Claim payment date is not valid.') or contains(string(),'Datum prometa usluga je neispravan.')]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(claimPayment));
        }
    

        public IWebElement ClaimIssueEmptyErrorMessage()
        {
            By claimIssue = By.Id("ClaimDate-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(claimIssue));
        }

        public IWebElement ClaimPaymentEmptyErrorMessage()
        {
            By claimPayment = By.Id("ClaimPaymentDate-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(claimPayment));
        }



        //functions
        public static int GenerateRandomYear()
        {
            var random = new Random();
            var list = new List<int>();
            int number = random.Next(1990, 2101);

            list.Add(number);
            
            var listOfNumbers = list;
            int lastNumber = listOfNumbers.Last();
            return lastNumber;
        }

        public static string GenerateBoundariesYearValues()
        {
            var list = new List<string>();
            Random rnd = new Random();

            list.Add("1990");
            list.Add("1991");
            list.Add("2099");
            list.Add("2100");

            var listOfNumbers = list;
            string year = listOfNumbers[rnd.Next(listOfNumbers.Count)];
            return year;

        }

        public static string GenerateInvalidBoundariesYearValues()
        {
            var list = new List<string>();
            Random rnd = new Random();

            list.Add("1989");
            list.Add("2101");

            var listOfNumbers = list;
            string year = listOfNumbers[rnd.Next(listOfNumbers.Count)];
            return year;

        }

        public static string PrintRSDate()
        {
            string date = DateTime.Now.ToString("d.MM.yyyy.");
            return date;
        }

        public static string PrintENDate()
        {
            string date = DateTime.Now.ToString("d/MM/yyyy");
            return date;
        }

        public static string GenerateENMonths()
        {
            var list = new List<string>();
            Random rnd = new Random();

            list.Add("January");
            list.Add("February");
            list.Add("March");
            list.Add("April");
            list.Add("May");
            list.Add("June");
            list.Add("July");
            list.Add("August");
            list.Add("September");
            list.Add("October");
            list.Add("November");
            list.Add("December");

            var listOfNumbers = list;
            string month = listOfNumbers[rnd.Next(listOfNumbers.Count)];
            return month;

        }

        public static string GenerateRSMonths()
        {
            var list = new List<string>();
            Random rnd = new Random();

            list.Add("januar");
            list.Add("februar");
            list.Add("mart");
            list.Add("april");
            list.Add("maj");
            list.Add("jun");
            list.Add("jul");
            list.Add("avgust");
            list.Add("septembar");
            list.Add("oktobar");
            list.Add("novembar");
            list.Add("decembar");

            var listOfNumbers = list;
            string month = listOfNumbers[rnd.Next(listOfNumbers.Count)];
            return month;

        }

        //actions

        

        public void SelectMonth(string month)
        {
            SelectElement selectMonth = new SelectElement(MonthDropDown());
            selectMonth.SelectByText(month);
        }


        /*first we select day(first in month), after that we switch to month and 
         * select month and than switch to year and select year*/
        public void SelectClaimIssueDate(IWebElement element)
        {
            ClaimIssueDateDropDown().Click();
            ClaimIssueDayPicker().Click();
            ClaimIssueMonthSwitcher().Click();
            element.Click();
            ClaimIssueMonthSwitcher().Click();
            ClaimIssueYearSwitcher().Click();
            ClaimIssueYearPicker().Click();
        }

        /*we select day(last in month), after that we switch to month and
         * select month and than switch to year and select year*/
        public void SelectClaimPaymentDate(IWebElement element)
        {
            ClaimPaymentDateDropDown().Click();
            ClaimPaymentDayPicker().Click();
            ClaimPaymentMonthSwitcher().Click();
            element.Click();
            ClaimPaymentMonthSwitcher().Click();
            ClaimPaymentYearSwitcher().Click();
            ClaimPaymentYearPicker().Click();
        }



        public void EnterYear(string year)
        {
            YearInputField().Clear();
            YearInputField().SendKeys(year);
        }

        public void ClickCreate()
        {
            CreateButton().Click();
        }


        public void EnterInvalidDateFormat(string issueDate, string paymentDate)
        {
           ClaimIssueDateDropDown().SendKeys(issueDate);
           YearInputField().Click();

           ClaimPaymentDateDropDown().SendKeys(paymentDate);
           YearInputField().Click();

        }

        public void ClearFields()
        {
            YearInputField().Clear();
            ClaimIssueDateDropDown().Clear();
            YearInputField().Click();
            ClaimPaymentDateDropDown().Clear();
            YearInputField().Click();
        }

        public void CheckActiveCheckbox()
        {
            ActiveCheckBox().Click();
        }

        public void ClickYearInputField()
        {
            YearInputField().Click();
        }
    }
}
