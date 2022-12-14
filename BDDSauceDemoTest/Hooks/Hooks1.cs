using TechTalk.SpecFlow;

namespace BDDSauceDemoTest.Hooks
{
    [Binding]
    public sealed class LoginHooks : BaseTest
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario] 
        public void BeforeScenario()
        {
            Setup();
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
           TearDown();
        }
    }
}