using Raizen.TestFunctional.Template.Mobile.Configurations.Parameters;
using RaizenTestFuncional;
using RaizenTestFuncional.Reports;
using TechTalk.SpecFlow;

namespace Raizen.TestFunctional.Template.Mobile.Configurations
{
    [Binding]
    sealed class Execution : DriverFactory
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Params.ConfigParams();
            EnviromentMobile();
            Reports.InitializeReport();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            QuitAndroidDriver();
            QuitiOSDriver();
            Reports.FinalizeReport();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            Reports.TestFeature(context);
        }

        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext context)
        {
            Reports.TestScenario(context);   
        }

        [AfterStep]
        public static void AfterStep(ScenarioContext context)
        {
            Reports.InsertSteps(context);
        }
    }
}
