
//using SauceDemoLibrary.Extension_methods;
using OpenQA.Selenium;
using SauceDemoCommonLibrary.Extension_methods;
using SauceDemoCommonLibrary.Utility;
using SauceDemoCommonLibrary.Base;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Configuration;

namespace SauceDemoLibrary.Pages
{
    public class LoginPage : BasePage
    {
        
        By UserName=>By.XPath( "//input[@id='user-name']");
        By Password =>By.XPath("//input[@id='password']");
        By LoginBtn =By.XPath( "//input[@id='login-button']");
        By login_logo = By.ClassName("login_logo");
        By error = By.XPath("//h3[@data-test='error']");

        public void GotoUrl()
        {

            utility.NaviagateToUrl(System.Configuration.ConfigurationManager.AppSettings["SauceDemoUrl"]);


        }
        public void Login(string userName, string password)
        {
            utility.Sendkeys(UserName,userName);
            utility.Sendkeys(Password,password);
            
       
        }
        public bool checkLoginPage()
        {
            return utility.IsDisplayed(login_logo);
        }
        public void ClickLogin()
        {
           // wait.waitElementIsVisible(LoginBtn);
            utility.ClickElement(LoginBtn);

        }
        public bool CheckNaviagatedToInventory()
        {
            return utility.URLContains("inventory");
        }
        
        public string CheckError()
        {
            if (utility.IsDisplayed(error))
            {
                return utility.gettext(error);
            }
            else
            {
                return "False";
            }

        }


    }
}
