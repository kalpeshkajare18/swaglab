using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SwagLabs.Tests;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs.Pages
{
    internal class AboutPage
    {
        private IWebDriver driver;
        AboutPageTest aboutTest;
        public AboutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By menu = By.XPath("//div[@class='bm-burger-button']/button");
        By about = By.XPath("//a[@id='about_sidebar_link']");
        By solutions = By.XPath("//span[normalize-space()='Solutions']");
        By continousTesting = By.XPath("//span[contains(text(),'Continuous testing')]");
        By popupClose = By.XPath("//button[@id = 'onetrust-accept-btn-handler']");

        public void gotoMenu()
        {
            driver.FindElement(menu).Click();
        }
        public void aboutSection()
        {
            driver.FindElement(about).Click();
            Thread.Sleep(1000);
            driver.FindElement(popupClose).Click();
            Thread.Sleep(1000);
        }

        public void continousTestingSection()
        {
           //Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(solutions)).Perform();
            Thread.Sleep(1000);
            IWebElement continousTestingElement = driver.FindElement(continousTesting);
            actions.MoveToElement(continousTestingElement).Perform();
            Thread.Sleep(1000);
            continousTestingElement.Click();
        }

        public void windowHandling()
        {
            aboutTest = new AboutPageTest(driver);
            Screenshot screenshot1 = ((ITakesScreenshot)driver).GetScreenshot();

            // Get the handles of all open windows
            var parentWindow = driver.CurrentWindowHandle;
            var windowHandles = driver.WindowHandles;

            // Switch to the new window
            foreach (var handle in windowHandles)
            {
                if (handle != parentWindow)
                {
                    driver.SwitchTo().Window(handle);
                    Thread.Sleep(1000);
                    aboutTest.VerifyContinuousTestingTitle();
                  //  screenshot1.SaveAsFile("C:\\Users\\sonali.parte\\source\\repos\\SwagLabs\\SwagLabs\\Screenshots\\CIPage.png", ScreenshotImageFormat.Png);
                    Thread.Sleep(1000);
                    break;
                }
            }
           driver.SwitchTo().Window(parentWindow);
           Thread.Sleep(1000);
         // screenshot1.SaveAsFile("C:\\Users\\sonali.parte\\source\\repos\\SwagLabs\\SwagLabs\\Screenshots\\AboutPage.png", ScreenshotImageFormat.Png);
           aboutTest.VerifyTitle();
        }
        
    }
       
}
