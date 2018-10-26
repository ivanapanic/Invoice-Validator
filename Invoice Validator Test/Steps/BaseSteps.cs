﻿using Invoice_Validator_Test.Pages;
using Invoice_Validator_Test.Pages.Admin;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Invoice_Validator_Test.Steps
{
    [Binding]
    public class BaseSteps
    {
        public static IWebDriver Driver { get; private set; }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }


        [AfterScenario]
        public static void AfterScenario()
        {
            Driver.Quit();
        }
    }
}
