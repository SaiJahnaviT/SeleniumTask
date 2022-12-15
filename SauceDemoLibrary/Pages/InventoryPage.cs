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

        By inventory_List => By.XPath("//div[@class='inventory_item']");
        
        

        #endregion

        Dictionary<string, string[]> All_items = new Dictionary<string, string[]>();
        public static Dictionary<string, string> Cart_items= new Dictionary<string, string>();
        public InventoryPage()
        {
            foreach (var i in utility.GetList(inventory_List))
            {

                string[] texts = i.Text.Split("\n");
                string price = texts[2].Trim();
                string addtocart = texts[3].ToLower() + " " + texts[0].ToLower().Trim();
                addtocart = addtocart.Replace(" ", "-");
                string remove = "remove " + texts[0].ToLower().Trim();
                remove= remove.Replace(" ", "-");
                string[] array = { price, addtocart,remove };
                All_items[texts[0].Trim()] = array;
            }

        }
        public void AddToCart(string name)
        {
            Console.WriteLine(name);
            foreach (var item in All_items)
            {
                
                if (item.Key == name)
                {
                    try
                    {
                        driver.FindElement(By.Id(item.Value[1])).Click();
                        // test.Log(Status.Info, item.Key + " is added to cart");
    
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

        public bool Check_items_added(string item)
        {
            return Cart_items.ContainsKey(item);
            
        }
        
        

        
    }
}
