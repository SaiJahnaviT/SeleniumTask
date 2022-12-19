using AventStack.ExtentReports;
using OpenQA.Selenium;
using OrangeHRMClassLibrary.Elements;
using OrangeHRMClassLibrary.Navigation;
using OrangeHRMCommonLibrary.Base;
using OrangeHRMCommonLibrary.Extension_methods;
using OrangeHRMCommonLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMClassLibrary.PageObjects.Recruitment
{
    public class RecruitmentPage :BasePage
    {
        

        public bool IsRecruitmentPageDisplayed()
        {
            wait.waitElementIsVisible(utility.GetInputByDivClass(Logos.Title));
            return utility.IsDisplayed(utility.GetInputByDivClass(Logos.Title));
        }

        public void ClickOnAddButton()
        {
            
            wait.waitElementIsVisible(utility.GetInputByButtonClass(Buttons.AddButton));
            utility.ClickElement(utility.GetInputByButtonClass(Buttons.AddButton));
            step.Log(Status.Info, "Add Button Clicked");
        }

        public bool IsAddCandidatePageDisplayed()
        {

            wait.waitforUrl("addCandidate");
            return utility.URLContains("addCandidate");
        }

        public void FillDetails(string Firstname,string Lastname,string EmailID)
        {
            wait.waitElementIsVisible(utility.GetInputByInputName(TextBox.Firstname));
            utility.Sendkeys(utility.GetInputByInputName(TextBox.Firstname), Firstname);
            utility.Sendkeys(utility.GetInputByInputName(TextBox.Lastname), Lastname);
            utility.Sendkeys(utility.GetTextboxByLabelName(TextBox.EmailID),EmailID);
            step.Log(Status.Info, "Details Entered");
            
        }
        public void ClickOnSave()
        {
            utility.JavaScriptScroll(utility.GetButton(Buttons.Submit));
            utility.ClickElement(utility.GetButton(Buttons.Submit));
            
        }

        public bool CheckApplicationStatus()
        {
            wait.waitElementIsVisible(By.XPath($"//form[@class='{Logos.ApplicationStage}']"));
            return utility.IsDisplayed(By.XPath($"//form[@class='{Logos.ApplicationStage}']"));
        }

        public bool IsErrorDisplayed()
        {
            wait.waitElementIsVisible(By.XPath($"//span[text()='{Logos.Required}']"));
            utility.JavaScriptScroll(By.XPath($"//span[text()='{Logos.Required}']"));
            return utility.IsDisplayed(By.XPath($"//span[text()='{Logos.Required}']"));
        }
    }
}
