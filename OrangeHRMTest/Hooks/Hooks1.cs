using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OrangeHRMClassLibrary.PageObjects.Login;

namespace OrangeHRMTest.Hooks
{
    [Binding]
    public sealed class Hooks : BaseTest
    {
        static string reportpath = Directory.GetParent(@"../../../").FullName
             + Path.DirectorySeparatorChar + "Result"
             + Path.DirectorySeparatorChar + "Result_"
             + DateTime.Now.ToString("ddMMyyyy HHmmss");
        

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportpath);
            extentReports = new AventStack.ExtentReports.ExtentReports();
            extentReports.AttachReporter(htmlReporter);

        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            test = extentReports.CreateTest(context.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            Setup();
            scenario = test.CreateNode(scenarioContext.ScenarioInfo.Title);

        }

        [BeforeScenario("@login")]
        public void BeforeScenarioWithTag()
        {

            LoginPage loginPage =new LoginPage();
            loginPage.StartApplication();
            loginPage.IsLoginPageDisplayed();
            loginPage.EnterUserCredentials("Admin","admin123");
            loginPage.ClickLoginButton();
        }


        

        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError == null)
            {
                step.Log(Status.Pass, scenarioContext.StepContext.StepInfo.Text);
            }
            else if (scenarioContext.TestError != null)
            {
                string base64 = getScreenShot();
                step.Log(Status.Fail, scenarioContext.StepContext.StepInfo.Text);
                step.Log(Status.Fail, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            TearDown();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extentReports.Flush();
        }
        public string getScreenShot()
        {
            return (string)((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
        }

    }
}