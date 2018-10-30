using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using NUnit.Framework;

namespace Invoice_Validator_Test.Pages.Admin
{
    class ContractorListPage
    {
        private IWebDriver driver;

        public ContractorListPage(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']")));
        }

        public bool IsConractorsListPageDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/ContractorDatas"));
        }



        //elements
        public IWebElement Table()
        {
            By contractorsTable = By.XPath("//table[@class='table']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(contractorsTable));
        }


        public IWebElement ContractorsPCCIdColumn()
        {
            By contractorsPCCID = By.XPath("//table[@class='table']//tr//td[6]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(contractorsPCCID));
        }


        public IWebElement ContractorsEditColumn()
        {
            By editColumn = By.XPath("//table[@class='table']//tr//td[7]//a[1]");
            //By editColumn = By.XPath("//table[@class='table']//tr[6]//td//a[1]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(editColumn));
        }

        //actions
        public void NavigateToEditContractorPage()
        {
            Assert.That(IsConractorsListPageDisplayed, Is.True, "Contractors List page is not displayed.");

            //contractorListPage.Table().FindElement(By.XPath("//tr[contains(string(), '" + GenerateRandomData.GenerateRow(listPage.Table()) + "')]//td[7]//a[1]")).Click();
            Table().FindElement(By.XPath("//tr[contains(string(), '" + "Username" + "')]//td[7]//a[1]")).Click();

        }
    }
}
