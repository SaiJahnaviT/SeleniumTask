using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoLibrary.Pages;
using TechTalk.SpecFlow.Infrastructure;

namespace BDDSauceDemoTest.StepDefinitions
{
    [Binding]
    public sealed class CartStepDefinitions : BaseTest
    {
        CartPage cartPage= new CartPage();

        [When(@"I Click on Cart Button")]
        public void WhenIClickOnCartButton()
        {
            cartPage.GoToCart();
        }

        [Then(@"I am Navigated to Cart Page")]
        public void ThenIAmNavigatedToCartPage()
        {
            Assert.True(cartPage.CheckNavigatedToCart());
        }

        [When(@"I Check the Cart Items")]
        public void WhenICheckTheCartItems()
        {
            Assert.True(cartPage.CartItemsDisplayed());
        }

        [Then(@"I am Able to see the Added Items in the Cart\.")]
        public void ThenIAmAbleToSeeTheAddedItemsInTheCart_()
        {
            Assert.True(cartPage.CheckCartItems());
        }

    }
}