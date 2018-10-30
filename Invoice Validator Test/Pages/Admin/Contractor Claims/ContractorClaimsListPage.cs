using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Validator_Test.Pages.Admin.Contractor_Claims
{
    class ContractorClaimsListPage
    {
        private IWebDriver driver;

        public ContractorClaimsListPage(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']")));

        }


        public bool IsContractorClaimsListPageDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/Claims"));
        }

        //elements
        public By filter = By.XPath("//button[@id='search-filter-btn'][contains(string(), 'Filter')]");
        public IWebElement FilterSearchButton()
        {
            By button = By.Id("search-filter-btn");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(button));
        }


        //filter
        public IWebElement AccountingPeriodFrom()
        {
            By accFrom = By.Id("AccountingPeriodFrom");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(accFrom));
        }

        public IWebElement AccountingPeriodTo()
        {
            By accTo = By.Id("AccountingPeriodTo");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(accTo));
        }

        public IWebElement UsernameInputfield()
        {
            By username = By.Id("Username");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(username));
        }

        public IWebElement TotalFrom()
        {
            By totalFrom = By.Id("TotalFrom");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(totalFrom));
        }

        public IWebElement TotalTo()
        {
            By totalTo = By.Id("TotalTo");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(totalTo));
        }

        public IWebElement FilterSubmitButton()
        {
            By filterSubmit = By.XPath("//button[@type='submit'][contains(string(), 'Filter') or contains(string(), 'Filtriranje')]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(filterSubmit));
        }


        //search
        public IWebElement InputSearchCriteria()
        {
            By inputCriteria = By.Id("searchQueryInput");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(inputCriteria));
        }

        public IWebElement SelectSearchCriteria()
        {
            By selectCriteria = By.Id("queryFor");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(selectCriteria));
        }

        public IWebElement OrderBy()
        {
            By order = By.XPath("//div[@id='searchDiv']//td[3]//select");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(order));
        }

        public IWebElement SearchSubmitButton()
        {
            By searchSubmit = By.XPath("//button[@type='submit'][contains(string(), 'Search') or contains(string(), 'Pretraživanje')]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchSubmit));
        }



        //table
        public IWebElement Table()
        {
            By table = By.XPath("//table[@class='table']");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(table));
        }


        public IWebElement AccNumToPayColumn()
        {
            By accNum = By.XPath("//table[@class='table']//td[5]");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(accNum));
        }

        //actions
        public void FillFieldsForFilter()
        {
            UsernameInputfield().SendKeys(ConfigurationManager.AppSettings["usernameContractor"]);
            TotalFrom().SendKeys("0");
            TotalTo().SendKeys(GenerateRandomData.GenerateRandomNumber(15));
            FilterSubmitButton().Click();
        }

        public void FillFieldsForSearch(string accNumToPay, string textCriteria)
        {
            InputSearchCriteria().SendKeys(accNumToPay);
            SelectElement selectCriteria = new SelectElement(SelectSearchCriteria());
            selectCriteria.SelectByText(textCriteria);
            GenerateRandomData.SelectRandomElement(OrderBy());
            SearchSubmitButton().Click();
        }

        public void FilterSerachSwitch()
        {
            FilterSearchButton().Click();
        }

    }
}
