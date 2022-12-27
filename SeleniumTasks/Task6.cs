using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumTasks.Driver;

namespace SeleniumTasks
{
    internal class Task6 : Driverinit
    {
       

        [Test]
        public void saucedemo()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();
            Dictionary<string, string> Product = new Dictionary<string, string>();
            Dictionary<string,string> cart_products= new Dictionary<string, string>();
            Dictionary<string,string> checkout_products= new Dictionary<string, string>();
            ;
            Product[driver.FindElement(By.XPath("//a[@id='item_4_title_link']/div")).Text] = driver.FindElement(By.XPath("(//a[@id='item_4_title_link'])/parent::div/following::div/div")).Text;
            Product[driver.FindElement(By.XPath("//a[@id='item_5_title_link']/div")).Text] = driver.FindElement(By.XPath("(//a[@id='item_5_title_link'])/parent::div/following::div/div")).Text;


            foreach (var product in Product)
            {
                Console.WriteLine(product.Key + " " + product.Value);
            }
            driver.FindElement(By.XPath("(//a[@id='item_4_title_link'])/parent::div/following::div/button")).Click();
            driver.FindElement(By.XPath("(//a[@id='item_5_title_link'])/parent::div/following::div/button")).Click();

            driver.FindElement(By.XPath("//a[@class='shopping_cart_link']")).Click();
            Thread.Sleep(3000);
            cart_products[driver.FindElement(By.XPath("//a[@id='item_4_title_link']/div")).Text] = driver.FindElement(By.XPath("(//a[@id='item_4_title_link'])/following-sibling::div[2]/div")).Text;
            cart_products[driver.FindElement(By.XPath("//a[@id='item_5_title_link']/div")).Text] = driver.FindElement(By.XPath("(//a[@id='item_5_title_link'])/following-sibling::div[2]/div")).Text;

            driver.FindElement(By.Id("checkout")).Click() ;

            driver.FindElement(By.Id("first-name")).SendKeys("abc");
            driver.FindElement(By.Id("last-name")).SendKeys("xyz");
            driver.FindElement(By.Id("postal-code")).SendKeys("123456");
            driver.FindElement(By.Id("continue")).Click();

            checkout_products[driver.FindElement(By.XPath("//a[@id='item_4_title_link']/div")).Text] = driver.FindElement(By.XPath("(//a[@id='item_4_title_link'])/following-sibling::div[2]/div")).Text;
            checkout_products[driver.FindElement(By.XPath("//a[@id='item_5_title_link']/div")).Text] = driver.FindElement(By.XPath("(//a[@id='item_5_title_link'])/following-sibling::div[2]/div")).Text;

            double total = 0;
            foreach(var key in Product.Keys)
            {
                Assert.IsTrue(Product[key] == cart_products[key]);
                Assert.IsTrue(cart_products[key] == checkout_products[key]);
                //Console.WriteLine(Product[key].Replace("$",""));
                total += double.Parse(Product[key].Replace("$",""));
            }
            string subtotal = driver.FindElement(By.XPath("//div[@class='summary_info']/div[5]")).Text;
            double dsubtotal= double.Parse(subtotal.Remove(0,13));
            Assert.IsTrue(total== dsubtotal);
            Console.WriteLine(total);
            driver.FindElement(By.Id("finish")).Click() ;
            Assert.True(driver.FindElement(By.XPath("//span[contains(text(),'Checkout: Complete!')]")).Displayed);

        }
    }
}
