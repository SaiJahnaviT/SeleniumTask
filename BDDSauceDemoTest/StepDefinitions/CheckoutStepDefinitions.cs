using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoLibrary.Pages;
using TechTalk.SpecFlow.Infrastructure;

namespace BDDSauceDemoTest.StepDefinitions
{
    [Binding]
    public sealed class CheckoutStepDefinitions : BaseTest
    {
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        private readonly ScenarioContext _scenariosContext;

        public CheckoutStepDefinitions(ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext scenariosContext)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
            _scenariosContext = scenariosContext;
        }
        CheckoutPage checkoutPage= new CheckoutPage();

        [When(@"I Click on Checkout Button\.")]
        public void WhenIClickOnCheckoutButton_()
        {
            checkoutPage.ClickCheckoutBtn();
        }

        [Then(@"I am Naviagted to Details Page\.")]
        public void ThenIAmNaviagtedToDetailsPage_()
        {
            Assert.True(driver.Url.Contains("checkout-step-one"));
        }

        [When(@"I Fill the Details")]
        public void WhenIFillTheDetails(Table table)
        {
            foreach(var item in table.Rows)
            {
                checkoutPage.FillTheDetails(item[0], item[1], item[2]);
            }
        }


        [Then(@"I Click on Continue Button\.")]
        public void ThenIClickOnContinueButton_()
        {
            checkoutPage.ClickContinue();
        }

        [Then(@"I am Navigated to Final Checkout Page\.")]
        public void ThenIAmNavigatedToFinalCheckoutPage_()
        {
            Assert.True(driver.Url.Contains("checkout-step-two"));
        }
        [When(@"I Check Checkout Items and price\.")]
        public void WhenICheckCheckoutItemsAndPrice_()
        {
            checkoutPage.CheckCheckout();
        }
        [When(@"I Check the SubTotal Amount of items\.")]
        public void WhenICheckTheSubTotalAmountOfItems_()
        {
            
            Assert.True(checkoutPage.CalculateSubTotal() == checkoutPage.getSubTotal());
        }

        [Then(@"I Click on Finish Button\.")]
        public void ThenIClickOnFinishButton_()
        {
            checkoutPage.ClickFinishBtn();
        }

        [Then(@"Completed the Checkout Process\.")]
        public void ThenCompletedTheCheckoutProcess_()
        {
            Assert.True(driver.Url.Contains("checkout-complete"));
        }




    }
}