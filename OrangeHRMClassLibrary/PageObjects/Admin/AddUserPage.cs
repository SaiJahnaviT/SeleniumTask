using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OrangeHRMClassLibrary.Elements;
using OrangeHRMCommonLibrary.Base;
using OrangeHRMCommonLibrary.Extension_methods;
using OrangeHRMCommonLibrary.Utility;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMClassLibrary.PageObjects.Admin
{
    public class AddUserPage : BasePage
    {
        string AutoSuggest = "//div[@role='listbox']";

        public void FilltheDetails(string USerRole,string Employeename,string status,string Username,string Password)
        {
            wait.waitElementIsVisible(utility.GetDropDownByLabelName(DropDowns.UserRole));
            utility.ClickElement(utility.GetDropDownByLabelName(DropDowns.UserRole));
            wait.waitElementIsVisible(By.XPath(AutoSuggest));
            utility.AutoSuggestElement(By.XPath(AutoSuggest), USerRole);

            
            wait.waitElementIsVisible(By.XPath(DropDowns.EmployeeName));
            utility.ClickElement(By.XPath(DropDowns.EmployeeName));
            utility.Sendkeys(By.XPath(DropDowns.EmployeeName),Employeename);
            utility.SelectOptionWithIndex(By.XPath(AutoSuggest));

            utility.ClickElement(utility.GetDropDownByLabelName(DropDowns.Status));
            utility.AutoSuggestElement(By.XPath(AutoSuggest), status);

            utility.Sendkeys(utility.GetTextboxByLabelName(TextBox.UserName), Username);

            utility.Sendkeys(utility.GetTextboxByLabelName(TextBox.Password), Password);

            utility.Sendkeys(utility.GetTextboxByLabelName(TextBox.ConfrimPassword), Password);

            step.Log(Status.Info, "Details Entered");


        }

        public void ClickOnSave()
        {
            utility.JavaScriptScroll(utility.GetButton(Buttons.Submit));
            IWebElement SaveButton= utility.FindElement(utility.GetButton(Buttons.Submit));

            wait.waitElementIsVisible(utility.GetButton(Buttons.Submit));
            utility.utility.UntilLoad();
            SaveButton.Click();
            try
            {
                wait.waitElementIsVisible(utility.GetInputByDivClass(Logos.Title));
                step.Log(Status.Info, "User Added");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Check the Details");
            }
        }
    }
}
