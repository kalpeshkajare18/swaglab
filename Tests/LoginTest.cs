using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs.Tests
{
    internal class LoginTest
    {

        private IWebDriver driver;
        public LoginTest(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void VerifyTitle()
        {
          String ActualValue = driver.Title;
            Console.WriteLine(ActualValue);
            String ExpectedValue = "Swag Labs";
            Assert.AreEqual(ActualValue, ExpectedValue);
        }

        By invalidUser = By.XPath("//h3[contains(text(),\"Epic sadface:\")]");

        public void invalidInput()
        {
            String ActualValue = driver.FindElement(invalidUser).Text;
            Console.WriteLine(ActualValue);
            String ExpectedValue = "Username and password do not match any user in this service";
            Assert.AreEqual(ActualValue, ExpectedValue);
        }
    }
}
