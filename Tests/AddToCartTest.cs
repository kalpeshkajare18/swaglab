using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs.Tests
{
    internal class AddToCartTest
    {
        private IWebDriver driver;
        public AddToCartTest(IWebDriver driver)
        {
            this.driver = driver;
        }

        By orderPlaced = By.XPath("//h2[text()='THANK YOU FOR YOUR ORDER']");
        By inventoryName = By.XPath("//div[@class='inventory_item_name']");
        public void placedOrder()
        {
            String ActualValue = driver.FindElement(orderPlaced).Text;
            Console.WriteLine(ActualValue);
            String ExpectedValue = "THANK YOU FOR YOUR ORDER";
            Assert.AreEqual(ActualValue, ExpectedValue);
        }
        public void verifyAddedProduct()
        {
            String ActualValue = driver.FindElement(inventoryName).Text;
            Console.WriteLine(ActualValue);
            String ExpectedValue = "Sauce Labs Fleece Jacket";
            Assert.AreEqual(ActualValue, ExpectedValue);
        }

    }
}
