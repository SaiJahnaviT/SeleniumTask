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
using AventStack.ExtentReports;

namespace SauceDemoLibrary.Pages
{
    public class CheckoutPage : CartPage
    {

        #region Locators

        string CheckoutButton = "checkout";

        string FirstNameTextbox = "first-name";

        string LastNameTextbox = "last-name";

        string PostalCodeTextbox = "postal-code";

        string ContinueButton = "continue";

        string SubTotalValue = "summary_subtotal_label";

        string FinishButton = "finish";

        #endregion

        public void ClickCheckoutBtn()
        {
            utility.ClickElement(By.Id($"{CheckoutButton}"));
            step.Log(Status.Info, "Checkout Button Clicked");
        }

        public bool CheckNaviagtedToDetailsPage()
        {
            return utility.URLContains("checkout-step-one");

        }

        public void FillTheDetails(string FirstName, string LastName, string PostalCode)
        {
            utility.Sendkeys(By.Id($"{FirstNameTextbox}"), FirstName);
            utility.Sendkeys(By.Id($"{LastNameTextbox}"), LastName);
            utility.Sendkeys(By.Id($"{PostalCodeTextbox}"), PostalCode);
            step.Log(Status.Info, "Details Filled");
        }

        public void ClickContinue()
        {
            utility.ClickElement(By.Id($"{ContinueButton}"));
            step.Log(Status.Info, "Continue Button Clicked");
        }

        public bool CheckNavigatedToCheckout()
        {
            return utility.URLContains("checkout-step-two");
        }

        public bool CheckCheckoutItems()
        {
            return CheckCartItems();
        }

        public double CalculateSubTotal()
        {
            double total = 0;
            foreach (var key in InventoryPage.Cart_items.Keys)
            {
                total += double.Parse(InventoryPage.Cart_items[key].Replace("$", ""));
            }
            step.Log(Status.Info, "Calculated Subtotal is "+total);
            return total;

        }

        public double GetSubTotal()
        {
            utility.JavaScriptScroll(By.ClassName($"{SubTotalValue}"));
            double subtotal = double.Parse(utility.GetText(By.ClassName($"{SubTotalValue}")).Remove(0, 13));
            step.Log(Status.Info, "SubTotal in Checkout Page is " + subtotal);
            return subtotal;
        }

        public void ClickFinishBtn()
        {
            utility.JavaScriptScroll(By.Id($"{FinishButton}"));
            utility.ClickElement(By.Id($"{FinishButton}"));
            step.Log(Status.Info, "Finish Button Clicked");
        }

        public bool CheckNavigatedToCompleteCheckout()
        {
            return utility.URLContains("checkout-complete");
        }
    }
}
