using NUnit.Framework;
using OrangeHRMClassLibrary.PageObjects.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMTest.StepDefinitions
{
    [Binding]
    public sealed class LeaveStepDefinitions
    {
        LeavePage leavePage = new LeavePage();

        [Then(@"I Navigated to Leave Page\.")]
        public void ThenINavigatedToLeavePage_()
        {
            leavePage.IsNavigatedToLeave();
        }

        [When(@"I Take a Dates from Record Table\.")]
        public void WhenITakeADatesFromRecordTable_()
        {
            leavePage.GetDates();
        }

        [When(@"I Enter that Dates in Searchbox\.")]
        public void WhenIEnterThatDatesInSearchbox_()
        {
            leavePage.EnterDates();
        }

        [Then(@"The Similar records displayed\.")]
        public void ThenTheSimilarRecordsDisplayed_()
        {
            Assert.True(leavePage.IsRecordsDisplayed());    
        }



    }
}
