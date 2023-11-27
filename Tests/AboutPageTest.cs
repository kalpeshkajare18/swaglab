using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs.Tests
{
    internal class AboutPageTest
    {
        private IWebDriver driver;
        public AboutPageTest(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void VerifyTitle()
        {
            String ActualValue = driver.Title;
            Console.WriteLine(ActualValue);
            String ExpectedValue = "Sauce Labs: Cross Browser Testing, Selenium Testing & Mobile Testing";
            Assert.AreEqual(ActualValue, ExpectedValue);
        }

        public void VerifyContinuousTestingTitle()
        {

            String ActualValue = driver.Title;
            Console.WriteLine(ActualValue);
            String ExpectedValue = "Incorporating Sauce Labs in Your CI Pipeline | Sauce Labs Documentation";
            Assert.AreEqual(ActualValue, ExpectedValue);
        }
      
    }
}
