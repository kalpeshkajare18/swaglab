using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SwagLabs.Pages;
using TechTalk.SpecFlow;
using System.Xml.Linq;
using SwagLabs.Tests;
using WebDriverManager.DriverConfigs.Impl;

namespace SwagLabs.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private readonly IObjectContainer _container;
        LoginPage login;
        LoginTest loginTest;

        //constructor
        public Hooks1(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario("@Tag")]
        public static void BeforeScenarioWithTag()
        {
           Console.WriteLine("running hooks");

        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            ChromeDriver driver = new ChromeDriver();

         //   IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://www.saucedemo.com/v1/";
            login = new LoginPage(driver);
            Thread.Sleep(1000);
            login.entername("standard_user");
            login.enterpass("secret_sauce");
            login.loginbutton();
            loginTest = new LoginTest(driver);
            loginTest.VerifyTitle();

            _container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Running after scenario...");
            var driver = _container.Resolve<IWebDriver>();

            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}