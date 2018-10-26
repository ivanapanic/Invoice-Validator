using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Validator_Test.Pages.Contractor
{
    class ContractorHomePage
    {
        private IWebDriver driver;

        //elements
        public ContractorHomePage(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']")));
        }

        public bool IsContractorHomePageDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/Claims/Create"));
        }

        public IWebElement InvoiceValidatorButton()
        {
            By invoiceButton = By.XPath("//a[@href='/']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(invoiceButton));
        }

        
        public IWebElement LanguageDropDown()
        {
            By languageDropdown = By.XPath("//ul[@class='nav navbar-nav navbar-right']//li[@class='dropdown']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(languageDropdown));

        }

        public IWebElement ProfileButton()
        {
            By profileButton = By.XPath("//a[@href='/users/edit/443']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(profileButton));
        }


        //create claim form on contractor home page
        public IWebElement AccPeriodCreateClaimDropdown()
        {
            By accPeriod = By.Id("AccountingPeriodId");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(accPeriod));
        }

        public IWebElement AccPeriodSeptember2030Dropdown()
        {
            By accPeriod = By.XPath("//select[@id='AccountingPeriodId']//option[text()='October 2030']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(accPeriod));
        }

        public IWebElement AccNumberToPayInputField()
        {
            By accNumber = By.Id("AccountNumberToPay");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(accNumber));
        }

        public IWebElement MonthlyClaimInputField()
        {
            By monthlyClaim = By.Id("5");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(monthlyClaim));
        }

        public IWebElement UniqaInputField()
        {
            By uniqaField = By.Id("8");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(uniqaField));
        }

        public IWebElement BicycleInputField()
        {
            By bicycleField = By.Id("11");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(bicycleField));
        }

        public IWebElement TotalInputField()
        {
            By totalField = By.Id("Total");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(totalField));
        }

        public IWebElement CreateClaimButton()
        {
            By createBtn = By.XPath("//input[@class='btn btn-default']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(createBtn));
        }



        //errors
        public IWebElement AccNumToPayErrorMsg()
        {
            By errorMsg = By.Id("AccountNumberToPay-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }

        public IWebElement MonthlyClaimErrorMsg()
        {
            By errorMsg = By.Id("5-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }

        public IWebElement UniqaErrorMsg()
        {
            By errorMsg = By.Id("8-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }

        public IWebElement BicycleErrorMsg()
        {
            By errorMsg = By.Id("11-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }


        
    }
}
