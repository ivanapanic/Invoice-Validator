using NUnit.Framework;
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
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']")));

        }

        public bool IsHomePageDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(""));
        }



        //header elements

        //language
        public IWebElement LanguageDropDown()
        {
            By languageDropdown = By.XPath("//ul[@class='nav navbar-nav navbar-right']//li[@class='dropdown']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(languageDropdown));

        }

        public IWebElement OpenLanguageDropdown()
        {
            By languageDropdown = By.XPath("//ul[@class='nav navbar-nav navbar-right']//li[@class='dropdown open']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(languageDropdown));
        }

        public IWebElement EnLanguage()
        {
            By languageDropdown = By.XPath("//ul[@class='nav navbar-nav navbar-right']//li[@class='dropdown open']//li[1]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(languageDropdown));
        }

        public IWebElement RsLanguage()
        {
            By languageDropdown = By.XPath("//ul[@class='nav navbar-nav navbar-right']//li[@class='dropdown open']//li[2]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(languageDropdown));
        }




        //sign out
        public IWebElement SignOutButton()
        {
            By signOut = By.XPath("//a[@href='/account/signout']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(signOut));
        }

        //ADMIN
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

        public IWebElement ClaimCategoriesDropdownCreate()
        {
            By accPeriodCreate = By.XPath("//a[@href='/ClaimCategories/Create']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(accPeriodCreate));
        }

        public IWebElement ClaimCategoriesDropdownList()
        {
            By accPeriodList = By.XPath("//a[@href='/ClaimCategories']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(accPeriodList));
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

        //CONTRACTOR
        public IWebElement InvoiceValidatorButton()
        {
            By invoiceButton = By.XPath("//a[@href='/']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(invoiceButton));
        }

        public IWebElement ProfileButton()
        {
            By profileButton = By.XPath("//a[@href='/users/edit/443']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(profileButton));
        }

        //admin actions

        //get random row from list
        public static int GenerateLanguage()
        {
            Random rnd = new Random();
            int li = rnd.Next(1, 3);
            return li;
        }
        public void SetRandomLocalLanguage()
        {
            LanguageDropDown().Click();
            OpenLanguageDropdown().FindElement(By.XPath("//li[" + GenerateLanguage() + "]"));
        }


        public void NavigateToCreateAccountingPage()
        {
            AccountingPeriodHeaderDropdown().Click();
            AccountingPeriodDropdownCreate().Click();
        }

        public void NavigateToCreateContractorPage()
        {
            ContractorDropdown().Click();
            ContractorDropdownCreate().Click();
        }

        public void NavigateToContratorsListPage()
        {
            ContractorDropdown().Click();
            ContractorDropdownList().Click();
        }

        public void NavigateToClaimsListPage()
        {
            Assert.That(IsHomePageDisplayed(), Is.True, "Contractor Home page is not displayed.");
            ContractorClaimsDropdown().Click();
            ContractorClaimsDropdownList().Click();
        }

        public void NavigateToCreateCategoryPage()
        {
            ClaimCategoriesDropdown().Click();
            ClaimCategoriesDropdownCreate().Click();
        }

        //contractor
        //actions
        public void NavigateToContractorProfilePage()
        {
            Assert.That(IsHomePageDisplayed(), Is.True, "Contractor Home page is not displayed.");
            ProfileButton().Click();
        }

        public void SignOut()
        {
            SignOutButton().Click();
        }
    }
}
