using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoLibrary.Pages;
using TechTalk.SpecFlow.Infrastructure;

namespace BDDSauceDemoTest.StepDefinitions
{
    [Binding]
    public sealed class InventoryStepDefinitions : BaseTest
    {
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        private readonly ScenarioContext _scenariosContext;

        public InventoryStepDefinitions(ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext scenariosContext)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
            _scenariosContext = scenariosContext;
        }
        InventoryPage inventoryPage=new InventoryPage();
        [When(@"I Add items to the Cart\.")]
        public void WhenIAddItemsToTheCart_(Table table)
        {
            int i = 1;
            foreach(var item in table.Rows)
            {
                inventoryPage.AddToCart(item[0]);
                _scenariosContext.Add(i.ToString(), item[0]);
                i++;
            }
        }

        [Then(@"Item are Added\.")]
        public void ThenItemAreAdded_()
        {
            foreach(var items in _scenariosContext)
            {
                Assert.True(inventoryPage.Check_items_added((string)items.Value));
            }
        }




    }
}