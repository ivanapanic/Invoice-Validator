using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Validator_Test.Pages.Admin
{
    class AdminHomePage
    {
        private IWebDriver driver;

        public AdminHomePage(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']")));

        }

        public bool IsAdminHomePageDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(""));
        }



        //header elements

        //contractors
        public IWebElement ContractorDropdown()
        {
            By contractorDropdown = By.XPath("//div[@class='navbar-collapse collapse']//ul[2]//li//a[@class='dropdown-toggle']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contractorDropdown));
        }

        public IWebElement ContractorDropdownCreate()
        {
            By contractorCreate = By.XPath("//a[@href='/ContractorDatas/Create']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contractorCreate));
        }

        public IWebElement ContractorDropdownList()
        {
            By contractorList = By.XPath("//a[@href='/ContractorDatas']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contractorList));
        }

        //accounting period
        public IWebElement AccountingPeriodHeaderDropdown()
        {
            By accountingDoropdown = By.XPath("//div[@class='navbar-collapse collapse']//ul[3]//li//a[@class='dropdown-toggle']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(accountingDoropdown));
        }

        public IWebElement AccountingPeriodDropdownCreate()
        {
            By accPeriodCreate = By.XPath("//a[@href='/AccountingPeriods/Create']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(accPeriodCreate));
        }

        public IWebElement AccountingPeriodDropdownList()
        {
            By accPeriodList = By.XPath("//a[@href='/AccountingPeriods']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(accPeriodList));
        }


        //claim categories
        public IWebElement ClaimCategoriesDropdown()
        {
            By claimCategories = By.XPath("//div[@class='navbar-collapse collapse']//ul[4]//li//a[@class='dropdown-toggle']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(claimCategories));
        }

       

        //contractor claims
        public IWebElement ContractorClaimsDropdown()
        {
            By contractorClaims = By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']//ul[@class='nav navbar-nav'][5]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(contractorClaims));
        }

        public IWebElement ContractorClaimsDropdownList()
        {
            By claimsList = By.XPath("//a[@href='/Claims']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(claimsList));
        }


        //language
        public IWebElement LanguageDropDown()
        {
            By languageDropdown = By.XPath("//ul[@class='nav navbar-nav navbar-right']//li[@class='dropdown']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(languageDropdown));

        }




        //sign out
        public IWebElement SignOut()
        {
            By signOut = By.XPath("//a[@href='/account/signout']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(signOut));
        }


    }
}
