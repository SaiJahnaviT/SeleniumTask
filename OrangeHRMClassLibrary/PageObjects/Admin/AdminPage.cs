using AventStack.ExtentReports;
using OpenQA.Selenium;
using OrangeHRMClassLibrary.Elements;
using OrangeHRMClassLibrary.Navigation;
using OrangeHRMCommonLibrary.Base;
using OrangeHRMCommonLibrary.Extension_methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMClassLibrary.PageObjects.Admin
{
    public class AdminPage : BasePage
    {
        
        string Search;

        public AddUserPage AddUserPage;

        public bool IsNavigatedToHomePage()
        {

            wait.waitElementIsVisible(utility.GetInputByDivClass(Logos.OrangeHRMBrandLogo));
            return utility.IsDisplayed(utility.GetInputByDivClass(Logos.OrangeHRMBrandLogo));
        }

        public void Navigate(string name)
        {
            Navigate navigate = new Navigate();
            navigate.AddCatalogItems();
            navigate.NavigatetoPage(name);
            step.Log(Status.Info, "Navigated to " + name);

        }

        public bool IsAdminPageDisplayed()
        {
            wait.waitElementIsVisible(utility.GetInputByDivClass(Logos.Title));
            return utility.IsDisplayed(utility.GetInputByDivClass(Logos.Title));
        }

        public void EnterUsername()
        {
            utility.Sendkeys(utility.GetTextboxByLabelName(TextBox.UserName),Search);
            step.Log(Status.Info, Search + "Entered in Text Box");
        }

        public void ClickOnSearch()
        {
            utility.ClickElement(utility.GetButton(Buttons.Submit));
            step.Log(Status.Info, "Search Button Clicked");
        }

        public void Reset()
        {
            utility.ClickElement(utility.GetInputByButtonClass(Buttons.ResetButton));
        }

        public void ClickAddButton()
        {
            utility.ClickElement(utility.GetInputByButtonClass(Buttons.AddButton)); 
            AddUserPage= new AddUserPage();
        }
        
        public void GetEntryTable()
        {
            wait.waitElementIsVisible(utility.GetInputByDivClass(Table.EntryTable));
            Search =utility.GetFirstInputFromTable(Table.EntryTable);
            step.Log(Status.Info, "Retriving Data from table");
        }

        public void ResultsFound()
        {

            utility.UntilLoad();
            utility.JavaScriptScroll(By.XPath(Logos.RecordsDetailswithHeader));
            string Results=utility.FindElement(By.XPath(Logos.RecordsDetailswithHeader)).Text;
            Console.WriteLine(Results);
        }

    }
}
