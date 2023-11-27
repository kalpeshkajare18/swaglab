using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs.Pages
{
    internal class LoginPage
    {

        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By userName = By.Id("user-name");
        By password = By.Id("password");
        By loginButton = By.Id("login-button");
        By logoutbtn = By.XPath("//a[@id='logout_sidebar_link']");

        public String entername(string username)
        {
            driver.FindElement(userName).SendKeys(username);
            return username;
        }

        public String enterpass(string pass)
        {
            driver.FindElement(password).SendKeys(pass);
            return pass;
        }

        public void loginbutton()
        {
            driver.FindElement(loginButton).Click();
        }
        public void logout()
        {
            driver.FindElement(logoutbtn).Click();
        }
    }
}
