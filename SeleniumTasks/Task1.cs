using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace SeleniumTasks
{
    public class Task1
    { 

        [Test]
        public void Chrome()
        {
            
            IWebDriver driver1 = new ChromeDriver();
            driver1.Navigate().GoToUrl("https://www.google.com");
            driver1.Manage().Window.Maximize();
            IWebElement search_box = driver1.FindElement(By.ClassName("gLFyf"));
            //or
            driver1.FindElement(By.XPath("//input[@class='gLFyf']"));
            //or
            driver1.FindElement(By.Name("q"));
            search_box.SendKeys("India");

            driver1.FindElement(By.XPath("//body/div[1]/div[3]/form[1]/div[1]/div[1]/div[4]/center[1]/input[1]")).Click();

            driver1.Close();

            Assert.Pass();
        }
        [Test]
        public void Firefox()
        {
            IWebDriver driver2 = new FirefoxDriver();
            driver2.Navigate().GoToUrl("https://www.amazon.in/");
            bool a = driver2.FindElement(By.Id("a-page")).Displayed;
            Assert.IsTrue(a);
            driver2.Manage().Window.Maximize();
            IWebElement SearchBox = driver2.FindElement(By.Name("field-keywords"));
            SearchBox.SendKeys("tv");
            IWebElement Searchbutton = driver2.FindElement(By.CssSelector("input[value='Go']"));
            Searchbutton.Click();
            driver2.Close();
        }
        [Test]
        public void Edge()
        {
            IWebDriver driver3 = new EdgeDriver();
            driver3.Navigate().GoToUrl("https://www.youtube.com/");
            driver3.Manage().Window.Maximize();
            driver3.FindElement(By.XPath("//input[@id='search']")).SendKeys("chropath");
            driver3.FindElement(By.XPath("//button[@id='search-icon-legacy']")).Click();
            driver3.Close();

        }

    }
}