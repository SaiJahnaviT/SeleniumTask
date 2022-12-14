using MongoDB.Driver;
using OpenQA.Selenium;
using SauceDemoCommonLibrary.Utility;
using SauceDemoCommonLibrary.Extension_methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SauceDemoCommonLibrary.Base;

namespace SauceDemoLibrary.Pages
{
    public class CheckoutPage : CartPage
    {

        #region Locators
        By checkoutbtn => By.Id("checkout");
        By Checkout_List => By.XPath("");
        By firstname => By.Id("first-name");
        By lastname => By.Id("last-name");
        By Postalcode => By.Id("postal-code");
        By Continue => By.Id("continue");
        By SubTotal => By.ClassName("summary_subtotal_label");
        By Finishbtn => By.Id("finish");


        #endregion

        public void ClickCheckoutBtn()
        {
            utility.ClickElement(checkoutbtn);

        }

        public void FillTheDetails(string FirstName, string LastName, string PostalCode)
        {
            
            utility.Sendkeys(firstname, FirstName);
            utility.Sendkeys(lastname, LastName);
            utility.Sendkeys(Postalcode, PostalCode);
        }
        public void ClickContinue()
        {
            utility.ClickElement(Continue);

        }
        public bool CheckCheckout()
        {
            return checkcartitems();
        }

        public double CalculateSubTotal()
        {
            int count = 0;
            double total = 0;
            foreach (var key in InventoryPage.Cart_items.Keys)
            {
                count++;
                total += double.Parse(InventoryPage.Cart_items[key].Replace("$", ""));

            }
            return total;
        }

        public double getSubTotal()
        {
            utility.js_scroll(SubTotal);
            string t = utility.gettext(SubTotal);
            double price = double.Parse(t.Remove(0, 13));
            return price;
        }
        public void ClickFinishBtn()
        {
            utility.js_scroll(Finishbtn);
            utility.ClickElement(Finishbtn);
        }
    }
}
