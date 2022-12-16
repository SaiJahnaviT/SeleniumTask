using AventStack.ExtentReports;
using OpenQA.Selenium;
using SauceDemoCommonLibrary.Extension_methods;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SauceDemoCommonLibrary.Base;
using Microsoft.AspNetCore.Http.Internal;

namespace SauceDemoLibrary.Pages
{
    public class InventoryPage : BasePage
    {
        #region Locators

        string InventoryItemsListPath = "inventory_item";

        #endregion

        Dictionary<string, string[]> All_items = new Dictionary<string, string[]>();

        public static Dictionary<string, string> Cart_items= new Dictionary<string, string>();

        public  void AddAllItems()
        {
            foreach (var element in utility.GetList(utility.GetInputByDivClass(InventoryItemsListPath)))
            {

                string[] texts = utility.GetAllText(element);
                All_items[utility.GetItemName(texts)] = utility.GetItemValues(texts);
            }
        }

        public void AddToCart(string name)
        {
            foreach (var item in All_items)
            {
                
                if (item.Key == name)
                {
                    try
                    {
                        driver.FindElement(By.Id(item.Value[1])).Click();
                        step.Log(Status.Info, item.Key + " is added to cart");
    
                        Cart_items[name] = item.Value[0];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    All_items.Remove(item.Key);
                }

            }
        }

        public bool CheckItemsAdded(string item)
        {
            return Cart_items.ContainsKey(item);
            
        }

    }
}
