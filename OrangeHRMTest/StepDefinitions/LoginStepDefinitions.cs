using NUnit.Framework;
using OrangeHRMClassLibrary.PageObjects.Login;
using System.Configuration;

namespace OrangeHRMTest.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions : BaseTest
    {
        LoginPage loginPage=new LoginPage();

        [Given(@"I am Started the OrangeHRM Application")]
        public void GivenIAmStartedTheOrangeHRMApplication()
        {
            loginPage.StartApplication(ConfigurationManager.AppSettings["OrangeUrl"]);
        }

        [Then(@"Login Page Displayed\.")]
        public void ThenLoginPageDisplayed_()
        {
            Assert.True(loginPage.IsLoginPageDisplayed());
        }
        [When(@"I Enter Username '([^']*)' and Password '([^']*)'\.")]
        public void WhenIEnterUsernameAndPassword_(string admin, string password)
        {
            loginPage.EnterUserCredentials(admin, password);
        }
        [When(@"Click Login Button\.")]
        public void WhenClickLoginButton_()
        {
            loginPage.ClickLoginButton();
        }
        [Then(@"I Logged in Successfully to the Application\.")]
        public void ThenILoggedInSuccessfullyToTheApplication_()
        {
            Assert.True(loginPage.IsLoggedIn());
        }

    }
}