
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OrangeHRMClassLibrary.Elements;
using OrangeHRMCommonLibrary.Base;
using OrangeHRMCommonLibrary.Extension_methods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMClassLibrary.PageObjects.Login
{
    public class LoginPage : BasePage
    {

        public void StartApplication(string url)
        {

            utility.NaviagateToUrl(url);
        }

        public bool IsLoginPageDisplayed()
        {
            wait.waitElementIsVisible(By.XPath(Logos.LoginLogo));
            return utility.IsDisplayed(By.XPath(Logos.LoginLogo));
        }

        public void EnterUserCredentials(string username, string password)
        {

            utility.Sendkeys(utility.GetInputByInputName(TextBox.UsernameLoginTextbox), username);
            utility.Sendkeys(utility.GetInputByInputName(TextBox.PasswordLoginTextbox), password);
        }

        public void ClickLoginButton()
        {
            utility.ClickElement(utility.GetButton(Buttons.Submit));
            
        }

        public bool IsLoggedIn()
        {
            wait.waitElementIsVisible(utility.GetInputByDivClass(Logos.OrangeHRMBrandLogo));
            return utility.IsDisplayed(utility.GetInputByDivClass(Logos.OrangeHRMBrandLogo));
        }

    }
}
