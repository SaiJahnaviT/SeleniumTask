using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMTest.Screenshots
{
    public class Screenshot : BaseTest
    {
        public string getScreenShot()
        {
            return (string) ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
        }
    }
}
