using HtmlAgilityPack;
using Invoice_Validator_Test.Pages.Admin.Accounting_Periods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Invoice_Validator_Test.Pages
{
    class GenerateRandomData
    {
        //random values
        public static string GenerateRandomNumber(int lenght)
        {
            var numbers = "123456789";
            var random = new Random();
            var randomNumber = new string(Enumerable.Repeat(numbers, lenght).Select(s => s[random.Next(s.Length)]).ToArray());
            return randomNumber;
        }

        public static string GenerateRandomString(int lenght)
        {
            var characters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
            var random = new Random();
            var randomChar = new string(Enumerable.Repeat(characters, lenght).Select(s => s[random.Next(s.Length)]).ToArray());
            return randomChar;
        }

        public static string GenerateRandomSpecialCharacters(int lenght)
        {
            var characters = "!@#$%^&*()_+{}][|?/><,.;':";
            var random = new Random();
            var randomChar = new string(Enumerable.Repeat(characters, lenght).Select(s => s[random.Next(s.Length)]).ToArray());
            return randomChar;
        }


        //sum numbers
        public static int SumNumbers(int a, int b, int c)
        {
            List<int> listOfClaims = new List<int>();
            listOfClaims.Add(a);
            listOfClaims.Add(b);
            listOfClaims.Add(c);
            int sum = listOfClaims.Sum();
            return sum;
        }

        //get random element from dropdown
        public static void SelectRandomElement(IWebElement element)
        {
            SelectElement selectElement = new SelectElement(element);
            IList<IWebElement> elementCount = selectElement.Options;
            int count = elementCount.Count;
            Random rnd = new Random();
            selectElement.SelectByIndex(rnd.Next(0, count));

        }

        //get random row from list
        public static int GenerateRow(IWebElement element)
        {
            int iRowsCount = element.FindElements(By.XPath("//tr")).Count - 1;
            Random rnd = new Random();
            int rows = rnd.Next(0, iRowsCount);
            return rows;
        }      
    }
}
