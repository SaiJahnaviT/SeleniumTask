using NUnit.Framework;
using OrangeHRMClassLibrary.PageObjects.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMTest.StepDefinitions
{
    [Binding]
    public sealed class TimeStepDefinitions
    {
        TimePage timePage=new TimePage();

        [Then(@"I Navigated to Time Page\.")]
        public void ThenINavigatedToTimePage_()
        {
           Assert.True( timePage.IsNavigatedToTime());
        }

        [Then(@"Time Sheet Table of Employees is Displayed\.")]
        public void ThenTimeSheetTableOfEmployeesIsDisplayed_()
        {
            Assert.True(timePage.IsTableDisplayed());
        }


    }
}
