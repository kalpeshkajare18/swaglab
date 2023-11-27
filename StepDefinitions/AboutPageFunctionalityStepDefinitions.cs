using OpenQA.Selenium;
using SwagLabs.Pages;
using SwagLabs.Tests;
using System;
using TechTalk.SpecFlow;

namespace SwagLabs.StepDefinitions
{
    [Binding]
    public class AboutPageFunctionalityStepDefinitions
    {
        public IWebDriver driver;
        AboutPage aboutPage;
        AboutPageTest aboutTest;

        public AboutPageFunctionalityStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [When(@"User click on menu bar and goto About section")]
        public void WhenUserClickOnMenuBarAndGotoAboutSection()
        {
            aboutPage = new AboutPage(driver);
            aboutTest = new AboutPageTest(driver);
            aboutPage.gotoMenu();
            aboutPage.aboutSection();
            aboutTest.VerifyTitle();
        }

        [When(@"User hovers on Solutions and click on Continuos Testing")]
        public void WhenUserHoversOnSolutionsAndClickOnContinuosTesting()
        {
            aboutPage.continousTestingSection();
          
        }

        [Then(@"User should redirected to CI page")]
        public void ThenUserShouldRedirectedToCIPage()
        {
            aboutPage.windowHandling();
  

        }
    }
}
