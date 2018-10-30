using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Validator_Test.Pages.Contractor
{
    class ContractorProfilePage
    {
        private IWebDriver driver;

        //page
        public ContractorProfilePage(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']")));
        }

        public bool IsContractorProfilePageDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/users/edit/443"));
        }



        //elements
        public IWebElement AgencyNameField()
        {
            By agencyName = By.Id("ContractorData_CompanyName");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(agencyName));
        }

        public IWebElement AddressField()
        {
            By addressField = By.Id("ContractorData_Address");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(addressField));
        }

        public IWebElement BankNameField()
        {
            By bankName = By.Id("ContractorData_BankName");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(bankName));
        }

        public IWebElement AccountNumberField()
        {
            By accNumber = By.Id("ContractorData_AccountNumber");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(accNumber));
        }

        public IWebElement RegistryNumberForCountry()
        {
            By registryNumber = By.Id("ContractorData_RegNumberForIndustry");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(registryNumber));
        }

        public IWebElement TaxIdentificationNumber()
        {
            By taxNumber = By.Id("ContractorData_TaxIdentificationNum");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(taxNumber));
        }

        public IWebElement TelephoneField()
        {
            By telephoneField = By.Id("ContractorData_Telephone");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(telephoneField));
        }

        public IWebElement SaveButton()
        {
            By saveBtn = By.XPath("//input[@class='btn btn-default']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(saveBtn));
        }

        //error messages
        public IWebElement AddressErrorMessage()
        {
            By errorMsg = By.Id("ContractorData_Address-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }

        public IWebElement BankNameErrorMessage()
        {
            By errorMsg = By.Id("ContractorData_BankName-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }

        public IWebElement AccountNumerErrorMessage()
        {
            By errorMsg = By.Id("ContractorData_AccountNumber-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }

        public IWebElement AgencyNameErrorMessage()
        {
            By errorMsg = By.Id("ContractorData_CompanyName-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }

        public IWebElement RegistryNumberErrorMessage()
        {
            By errorMsg = By.Id("ContractorData_RegNumberForIndustry-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }

        public IWebElement TaxNumberErrorMessage()
        {
            By errorMsg = By.Id("ContractorData_TaxIdentificationNum-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }

        public IWebElement TelephoneErrorMessage()
        {
            By errorMsg = By.Id("ContractorData_Telephone-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }


        //actions
        public enum ProfileFields
        {
            Address,
            BankName,
            AccountNumber,
            AgencyName,
            RegistryNumberForCountry,
            TaxIdentificationNumber,
            Telephone
        }

        public Dictionary<ProfileFields, string> StoreProfileDataToDictionary()
        {
            var dict = new Dictionary<ProfileFields, string>
            {
                {ProfileFields.Address, AddressField().GetAttribute("value")},
                {ProfileFields.BankName, BankNameField().GetAttribute("value")},
                {ProfileFields.AccountNumber, AccountNumberField().GetAttribute("value")},
                {ProfileFields.AgencyName, AgencyNameField().GetAttribute("value")},
                {ProfileFields.RegistryNumberForCountry, RegistryNumberForCountry().GetAttribute("value")},
                {ProfileFields.TaxIdentificationNumber, TaxIdentificationNumber().GetAttribute("value")},
                {ProfileFields.Telephone, TelephoneField().GetAttribute("value")}
            };
            return dict;
        }

        public void ClearAllProfileFields()
        {
            AddressField().Clear();
            BankNameField().Clear();
            AccountNumberField().Clear();
            AgencyNameField().Clear();
            RegistryNumberForCountry().Clear();
            TaxIdentificationNumber().Clear();
            TelephoneField().Clear();
        }


        public void FillAllProfileFields(string address, string bankName, string accountNumber, 
            string agencyName, string registryNumber, string taxNumber, string telNumber)
        {
            AddressField().SendKeys(address);
            BankNameField().SendKeys(bankName);
            AccountNumberField().SendKeys(accountNumber);
            AgencyNameField().SendKeys(agencyName);
            RegistryNumberForCountry().SendKeys(registryNumber);
            TaxIdentificationNumber().SendKeys(taxNumber);
            TelephoneField().SendKeys(telNumber);
        }

        public void ClickSave()
        {
            SaveButton().Click();
        }
    }
}
