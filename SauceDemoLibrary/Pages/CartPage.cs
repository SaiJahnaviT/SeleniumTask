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
        By cart = By.XPath("//a[@class='shopping_cart_link']");
        By cart_List_path => By.XPath("//div[@class='cart_item']");

        public void GoToCart()
        {
            utility.ClickElement(cart);
        }
        public bool Cart_items_Displayed()
        {
            foreach(var item in utility.GetList(cart_List_path))
            {
                return item.Displayed;
            }
            return false;
        }

        public bool checkcartitems()
        {
            IList<IWebElement> cart_list = utility.GetList(cart_List_path);
            foreach (var item in cart_list)
            {
                string[] texts = item.Text.Split('\n');
                string price = texts[3].Trim();
                if (InventoryPage.Cart_items.CheckHasValue(price))
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
