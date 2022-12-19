using NUnit.Framework;
using OrangeHRMClassLibrary.PageObjects.Login;
using OrangeHRMClassLibrary.PageObjects.Recruitment;

namespace OrangeHRMTest.StepDefinitions
{
    [Binding]
    public sealed class RecruitmentStepDefinitions : BaseTest
    {
        RecruitmentPage recruitmentPage =new RecruitmentPage();

        [Then(@"I Navigated to Recruitment Page\.")]
        public void ThenINavigatedToRecruitmentPage_()
        {
            Assert.True(recruitmentPage.IsRecruitmentPageDisplayed());
        }


        [When(@"I Click on Add button")]
        public void WhenIClickOnAddButton()
        {
            recruitmentPage.ClickOnAddButton();
        }

        [Then(@"I Navigated to Add Candidate Page\.")]
        public void ThenINavigatedToAddCandidatePage_()
        {
            recruitmentPage.IsAddCandidatePageDisplayed();
        }

        [When(@"I Enter Details Firstname '([^']*)',Lastname '([^']*)',EmailID '([^']*)'")]
        public void WhenIEnterDetailsFirstnameLastnameEmailID(string firstname, string lastname, string email)
        {
            recruitmentPage.FillDetails(firstname, lastname, email);
        }

        [When(@"Click on Save button\.")]
        public void WhenClickOnSaveButton_()
        {
            recruitmentPage.ClickOnSave();
        }

        [Then(@"Application is Saved and viewed\.")]
        public void ThenApplicationIsSavedAndViewed_()
        {
            Assert.True(recruitmentPage.CheckApplicationStatus());
        }


        [Then(@"error Displayed\.")]
        public void ThenErrorDisplayed_()
        {
            Assert.True(recruitmentPage.IsErrorDisplayed());
        }




    }
}