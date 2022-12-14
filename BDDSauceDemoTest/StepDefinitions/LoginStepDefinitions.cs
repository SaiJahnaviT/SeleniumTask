using NUnit.Framework;
using SauceDemoLibrary.Pages;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Configuration;

namespace BDDSauceDemoTest.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions : BaseTest
    {

        LoginPage loginPage=new LoginPage();
        

        [Given(@"I Started SauceDemo Application")]
        public void GivenIStartedSauceDemoApplication()
        {
            loginPage.GotoUrl();
           
        }
        [Then(@"Login Page Displayed")]
        public void ThenLoginPageDisplayed()
        {
            Assert.True(loginPage.checkLoginPage());
        }
        [When(@"I Enter USername '([^']*)' and Password '([^']*)'")]
        public void WhenIEnterUSernameAndPassword(string username, string password)
        {
            loginPage.Login(username, password);
        }
        [When(@"Click Login Button")]
        public void WhenClickLoginButton()
        {
            loginPage.ClickLogin();
        }
        [Then(@"I Looged in succesfully and Navigated to inventory page\.")]
        public void ThenILoogedInSuccesfullyAndNAvigatedToInventoryPage_()
        {
            Assert.True(driver.Url.Contains("inventory"));
        }
        [Then(@"Error Displayed,I am unable to Login")]
        public void ThenErrorDisplayedIAmUnableToLogin()
        {
            loginPage.CheckError();
        }



    }
}