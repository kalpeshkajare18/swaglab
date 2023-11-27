using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SwagLabs.Pages;
using SwagLabs.StepDefinitions;
using System.Diagnostics;
using TechTalk.SpecFlow.CommonModels;
using NUnit.Framework;

namespace SwagLabs.Pages
{
    internal class AddToCart
    {
        private IWebDriver driver;

        public AddToCart(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ProductCount() 
        {
            IList<IWebElement> Products = driver.FindElements(By.XPath("//div[@class = \"inventory_item_name\"]"));
            Console.WriteLine(Products.Count);
            foreach (IWebElement product in Products)
            {
                Console.WriteLine(product.Text);
            }

         /*   Console.WriteLine(products.Count);
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i].Text);
            }
         */
        }

        public void HighestPrice()
        {
            IList<IWebElement> prices = driver.FindElements(By.XPath("//div[@class='inventory_item_price']"));
            IList<IWebElement> buttons = driver.FindElements(By.XPath("//button[@class='btn_primary btn_inventory']"));

            double highestPrice = double.MinValue;
            int indexOfHighestPrice = -1;

            // Find the highest price and its index
            for (int i = 0; i < prices.Count; i++)
            {
                string priceText = prices[i].Text.Replace("$", "");
                double price = double.Parse(priceText);

                if (price > highestPrice)
                {
                    highestPrice = price;
                    indexOfHighestPrice = i;
                }
            }

            // Click the button corresponding to the highest price
            if (indexOfHighestPrice != -1)
            {
                buttons[indexOfHighestPrice].Click();
                Thread.Sleep(1000);
            }

            // Perform assertions or log the highest price
            Assert.AreEqual(49.99, highestPrice);
            Console.WriteLine($"Highest Price: {highestPrice}");

        }

        By cart = By.XPath("//a[@class='shopping_cart_link fa-layers fa-fw']//*[name()='svg']");
        By checkoutButton = By.XPath("//a[@class=\"btn_action checkout_button\"]");
        By firstname = By.XPath("//input[@id='first-name']");
        By lastname = By.XPath("//input[@id='last-name']");
        By pincode = By.XPath("//input[@id='postal-code']");
        By continueButton = By.XPath("//input[@value='CONTINUE']");
        By finishButton = By.XPath("//a[text()='FINISH']");
 

        public void addedProduct()
        {
            driver.FindElement(cart).Click();
        }

        public void checkout()
        {
            driver.FindElement(checkoutButton).Click();
        }

        public void enterDetails()
        {
            driver.FindElement(firstname).SendKeys("abc");
            driver.FindElement(lastname).SendKeys("xyz");
            driver.FindElement(pincode).SendKeys("12345");
            driver.FindElement(continueButton).Click();
        }
            public void finish()
        {
            driver.FindElement(finishButton).Click();
        }
     

    }
}
