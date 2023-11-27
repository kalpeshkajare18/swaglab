using OpenQA.Selenium;
using SwagLabs.Pages;
using SwagLabs.Tests;
using System;
using TechTalk.SpecFlow;

namespace SwagLabs.StepDefinitions
{
    [Binding]
    public class AddToCartFunctionalityStepDefinitions
    {
        public IWebDriver driver;
        LoginTest loginTest;
        AddToCart add;
        AddToCartTest addProductTest;
        AboutPage about;
        LoginPage loginPage;

        public AddToCartFunctionalityStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"User count the products")]
        public void GivenUserCountTheProducts()
        {
            add = new AddToCart(driver);
            addProductTest = new AddToCartTest(driver);
            add.ProductCount();
            Thread.Sleep(1000);
        }

        [When(@"User added highest price product into cart")]
        public void WhenUserAddedHighestPriceProductIntoCart()
        {
            add.HighestPrice();
            add.addedProduct();
            Thread.Sleep(1000);
        }

        [When(@"User click on Checkout button")]
        public void WhenUserClickOnCheckoutButton()
        {
            addProductTest.verifyAddedProduct();
            add.checkout();
            Thread.Sleep(1000);
        }

        [When(@"User enter firstname, lastname and zipcode")]
        public void WhenUserEnterFirstnameLastnameAndZipcode()
        {
            add.enterDetails();
            Thread.Sleep(1000);
        }

        [When(@"User click on Continue and Finish button")]
        public void WhenUserClickOnContinueAndFinishButton()
        {
            addProductTest.verifyAddedProduct();
            add.finish();
            Thread.Sleep(1000);
        }

        [Then(@"Successful message should be dislayed to the user")]
        public void ThenSuccessfulMessageShouldBeDislayedToTheUser()
        {
            addProductTest.placedOrder();
            Thread.Sleep(1000);
        }

        [When(@"User logout from the application")]
        public void WhenUserLogoutFromTheApplication()
        {
            loginPage = new LoginPage(driver);
            about = new AboutPage(driver);
            about.gotoMenu();
            Thread.Sleep(1000);
            loginPage.logout();
            Thread.Sleep(1000);
        }

        [Then(@"User should redireced to the login page")]
        public void ThenUserShouldRedirecedToTheLoginPage()
        {
            loginTest = new LoginTest(driver);
            Thread.Sleep(1000);
            loginTest.VerifyTitle();
        }

    }
}
