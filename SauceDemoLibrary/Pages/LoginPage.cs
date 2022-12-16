using OpenQA.Selenium;
using SauceDemoCommonLibrary.Extension_methods;
using SauceDemoCommonLibrary.Utility;
using SauceDemoCommonLibrary.Base;
using AventStack.ExtentReports;
using System.Configuration;

using System.Xml.Linq;

namespace SauceDemoLibrary.Pages
{
    public class LoginPage : BasePage
    {
        #region Locators

        string UsernameTextbox = "user-name";

        string PasswordTextbox= "password";

        string LoginButton = "login-button";

        string LoginLogo = "login_logo";

        string Error = "//h3[@data-test='error']";

        #endregion

        public void GoToUrl()
        {
            utility.NaviagateToUrl(ConfigurationManager.AppSettings["SauceDemoUrl"]);
        }

        public void Login(string userName, string password)
        {
            utility.Sendkeys(By.Id($"{UsernameTextbox}"),userName);
            utility.Sendkeys(By.Id($"{PasswordTextbox}"),password);
        }

        public bool CheckLoginPage()
        {
            step.Log(Status.Info, "Naviagted to SauceDemo Login");
            return utility.IsDisplayed(utility.GetInputByDivClass(LoginLogo));
        }

        public void ClickLogin()
        {
           // wait.waitElementIsVisible(LoginBtn);
            utility.ClickElement(By.Id($"{LoginButton}"));
            step.Log(Status.Info, "Login Button Clicked");
        }

        public bool CheckNaviagatedToInventory()
        {
            return utility.URLContains("inventory");  
        }
        
        public string CheckError()
        {
            if (utility.IsDisplayed(By.XPath($"{Error}")))
            {
                
                string ErrorText= utility.GetText(By.XPath($"{Error}"));
                step.Log(Status.Info, ErrorText);
                return ErrorText;
            }
            else
            {
                return "False";
            }

        }

    }
}
