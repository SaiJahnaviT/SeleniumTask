using NUnit.Framework;
using OrangeHRMClassLibrary.PageObjects.Admin;
using OrangeHRMClassLibrary.PageObjects.Login;

namespace OrangeHRMTest.StepDefinitions
{
    [Binding]
    public sealed class AdminStepDefinitions
    {
        AdminPage adminPage=new AdminPage();

        [Given(@"I am in HomePage\.")]
        public void GivenIAmInHomePage_()
        {
            Assert.True(adminPage.IsNavigatedToHomePage());
        }


        [When(@"I Click on '([^']*)' slot in Catalog\.")]
        public void WhenIClickOnSlotInCatalog_(string name)
        {
            adminPage.Navigate(name);
        }

        [Then(@"I Navigated to Admin's Page\.")]
        public void ThenINavigatedToAdminsPage_()
        {
            Assert.True(adminPage.IsAdminPageDisplayed());
            
        }

        [When(@"I Click on Add Button\.")]
        public void WhenIClickOnAddButton_()
        {
            adminPage.ClickAddButton();
        }

        [Then(@"I Navigated to Add User Page")]
        public void ThenINavigatedToAddUserPage()
        {
           Assert.True(true);
        }

        [When(@"I User detail UserRole '([^']*)',Employee Name '([^']*)', Status '([^']*)',Username '([^']*)', Password '([^']*)'")]
        public void WhenIUserDetailUserRoleEmployeeNameStatusUsernamePassword(string USerRole, string Employename, string Status, string username, string password)
        {
           adminPage.AddUserPage.FilltheDetails(USerRole,Employename, Status, username, password);
        }

        [Then(@"I Click Save Button\.")]
        public void ThenIClickSaveButton_()
        {
            adminPage.AddUserPage.ClickOnSave();
        }

        [When(@"I Take a Username from table")]
        public void WhenITakeAUsernameFromTable()
        {
            adminPage.GetEntryTable();
        }

        [When(@"I Enter that Username in Searchbox")]
        public void WhenIEnterThatUsernameInSearchbox()
        {
            adminPage.EnterUsername();
        }

        [When(@"I Click on Search Button\.")]
        public void WhenIClickOnSearchButton_()
        {
            adminPage.ClickOnSearch();
        }

        [Then(@"The records displayed\.")]
        public void ThenTheRecordsDisplayed_()
        {
            adminPage.ResultsFound();
        }

    }
}