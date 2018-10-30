using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Invoice_Validator_Test.Pages
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']")));
        }


        public bool IsLoginPageDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/Account/Login/"));
        }




        //elements
        public IWebElement UsernameInputField()
        {
            By usernameField = By.Id("Username");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(usernameField));
        }

        public IWebElement PasswordInputField()
        {
            By passwordField = By.Id("Password");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(passwordField));
        }

        public IWebElement SignInButton()
        {
            By signinBtn = By.XPath("//button[@class='btn btn-default btn-primary']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(signinBtn));
        }





        //error messages
        public IWebElement InvalidDataErrorMessage()
        {          
            By errorMsg = By.XPath("//div[@class='alert alert-warning']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }

        public IWebElement EmptyFieldsErrorMessage()
        {
            By errorMsg = By.XPath("//div[@class='alert alert-warning']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorMsg));
        }


        //actions
        public void LoginAsAdmin()
        {
            UsernameInputField().SendKeys(ConfigurationManager.AppSettings["usernameAdmin"]);
            PasswordInputField().SendKeys(ConfigurationManager.AppSettings["password"]);
            SignInButton().Click();
        }

        public void LoginAsContractor()
        {
            UsernameInputField().SendKeys(ConfigurationManager.AppSettings["usernameContractor"]);
            PasswordInputField().SendKeys(ConfigurationManager.AppSettings["password"]);
            SignInButton().Click();
        }
    }
}
