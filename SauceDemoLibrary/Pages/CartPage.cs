using AventStack.ExtentReports;
using MongoDB.Driver;
using OpenQA.Selenium;
using SauceDemoCommonLibrary.Base;
using SauceDemoCommonLibrary.Extension_methods;
using SauceDemoCommonLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoLibrary.Pages
{
    public class CartPage : BasePage
    {
        string CartButton = "shopping_cart_link";
        string CartListPath = "cart_item";

        public void GoToCart()
        {
            utility.ClickElement(By.ClassName($"{CartButton}"));
            step.Log(Status.Info, "Clicked on Cart Button");
        }

        public bool CheckNavigatedToCart()
        {
            return utility.URLContains("cart");
        }

        public bool CartItemsDisplayed()
        {
            foreach(var item in utility.GetList(utility.GetInputByDivClass($"{CartListPath}")))
            {
                step.Log(Status.Info, "Cart Items are Displayed");
                return item.Displayed;
            }
            return false;
        }

        public bool CheckCartItems()
        {
            IList<IWebElement> cart_list = utility.GetList(utility.GetInputByDivClass($"{CartListPath}"));
            foreach (var item in cart_list)
            {
                string[] texts = item.Text.Split('\n');
                string price = texts[3].Trim();
                if (InventoryPage.Cart_items.ContainsValue(price))
                {

                    return true;

                }
                else
                {
                    return false;
                }

            }
            return true;
        }
        

    }
}
