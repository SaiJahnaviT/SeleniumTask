using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BDDSauceDemoTest.ScreenShot;
using OpenQA.Selenium;
using System.Data;
using TechTalk.SpecFlow;

namespace BDDSauceDemoTest.Hooks
{
    [Binding]
    public sealed class Hooks : BaseTest
    {
        ExtentTest scenario, step;
        static string reportpath = Directory.GetParent(@"../../../").FullName 
            + Path.DirectorySeparatorChar + "Result" 
            + Path.DirectorySeparatorChar + "Result_" 
            + DateTime.Now.ToString("ddMMyyyy HHmmss");
        Screenshots screenshot= new Screenshots();
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
        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }
        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            if(scenarioContext.TestError == null)
            {
                step.Log(Status.Pass, scenarioContext.StepContext.StepInfo.Text);
            }
            else if(scenarioContext.TestError != null) 
            {
                string base64=screenshot.getScreenShot();
                step.Log(Status.Fail, scenarioContext.StepContext.StepInfo.Text,MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
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

        
    }
}