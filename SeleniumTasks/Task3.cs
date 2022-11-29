using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V105.DOMDebugger;

namespace SeleniumTasks
{
    internal class Task3
    {
        IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }
        [Test]
        public void task_3()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            String title = driver.Title;
            int title_length = driver.Title.Length;
            Console.WriteLine(title);
            Console.WriteLine(title_length);
            string url = driver.Url;
            int url_length = driver.Url.Length;
            Console.WriteLine(url);
            Console.WriteLine(url_length);
            String sourcecode = driver.PageSource;
            //Console.WriteLine(sourcecode);
            int sourcecode_length = driver.PageSource.Length;
            Console.WriteLine(sourcecode_length);
        }
        [TearDown]
        public void Close()
        {
            driver.Close();
        }
    }
}
