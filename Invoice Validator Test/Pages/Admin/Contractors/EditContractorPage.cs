using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Validator_Test.Pages.Admin
{
    class EditContractorPage
    {
        private IWebDriver driver;

        public EditContractorPage(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']")));

        }

        public bool IsContractorEditPageDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/ContractorDatas/Edit/"));
        }


        //elements
        public IWebElement UsernameField()
        {

            By usernameField = By.Id("User_Username");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(usernameField));

        }

        public IWebElement PCCIdField()
        {

            By pccIdField = By.Id("PCCID");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(pccIdField));

        }
       

        public IWebElement FirstNameField()
        {
            By firstName = By.Id("User_Name");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(firstName));
        }

        public IWebElement LastNameField()
        {
            By lastName = By.Id("User_Surname");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(lastName));
        }

        public IWebElement ActiveCheckbox()
        {
            By checkbox = By.Id("User_Active");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(checkbox));
        }


        public IWebElement SaveButton()
        {
            By saveButton = By.XPath("//input[@class='btn btn-default']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(saveButton));
        }

        //functions
        public enum EditContractorFields
        {
            Username,
            PccID,
            FirstName,
            LastName
        }

        public Dictionary<EditContractorFields, string> StoreProfileDataToDictionary()
        {
            var dict = new Dictionary<EditContractorFields, string>
            {
                {EditContractorFields.Username, UsernameField().GetAttribute("value")},
                {EditContractorFields.PccID, PCCIdField().GetAttribute("value")},
                {EditContractorFields.FirstName, FirstNameField().GetAttribute("value")},
                {EditContractorFields.LastName, LastNameField().GetAttribute("value")}
            };
            return dict;
        }
    }
}
