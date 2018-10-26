using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Validator_Test.Pages.Admin
{
    class CreateContractorPage
    {
        private IWebDriver driver;


        public CreateContractorPage(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']")));

        }

        public bool IsCreateContractorPageDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/ContractorDatas/Create"));
        }

        //elements
        public IWebElement UsernameContractorInputField()
        {
            By usernameField = By.Id("Username");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(usernameField));
        }

        public IWebElement PCCIdInputField()
        {
            By pccIdField = By.Id("PCCID");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(pccIdField));
        }

        public IWebElement FirstNameInputField()
        {
            By firstName = By.Id("Firstname");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(firstName));
        }

        public IWebElement LastNameInputField()
        {
            By lastName = By.Id("Surname");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(lastName));
        }

        public IWebElement CreateButton()
        {
            By createButton = By.CssSelector("input[type='submit']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(createButton));
        }



        //error messages
        public IWebElement UsernameErrorMessage()
        {
            By errorMsg = By.XPath("//span[contains(string(), 'Username already exsits.') or contains(string(), 'Korisničko ime već postoji.')]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }

        public IWebElement PCCIdErrorMessage()
        {
            By errorMsg = By.XPath("//span[contains(string(), 'PCC id already exsits.') or contains(string(), 'PCC ID već postoji.')]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }


        public IWebElement UsernameEmptyErrorMessage()
        {
            By errorMsg = By.Id("Username-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }

        public IWebElement PCCIdEmptyErrorMessage()
        {
            By errorMsg = By.Id("PCCID-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }

        public IWebElement FirstNameEmptyErrorMessage()
        {
            By errorMsg = By.Id("Firstname-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }

        public IWebElement LastNameEmptyErrorMessage()
        {
            By errorMsg = By.Id("Surname-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }

        
    }
}
