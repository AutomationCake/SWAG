
using AventStack.ExtentReports;
using BoDi;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace SWAG.Support
{
    [Binding]
    public sealed class Hooks : AdditionalHook
    {
        public readonly IObjectContainer _container;


        private string Capture(IWebDriver dirver, string input)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)dirver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();

            string projectDirectory1 = Environment.CurrentDirectory;
            string getPath = projectDirectory1.Substring(0, projectDirectory1.LastIndexOf("bin"));
            string screenshotPath = getPath + "ErrorScreenshot\\" + input + ".png";

            screenshot.SaveAsFile(screenshotPath);
            return screenshotPath;
        }

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario()]
        public void BeforeScenarioWithTag(ScenarioContext _scenarioContext)
        {
            var scenarioName = _scenarioContext.ScenarioInfo.Title;
            var extent = _container.Resolve<ExtentReports>();

            ExtentTest test = CreateTest(extent, scenarioName.ToString());
            _container.RegisterInstanceAs<ExtentTest>(test);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var stepText = scenarioContext.StepContext.StepInfo.Text;
            var driver = _container.Resolve<IWebDriver>();
            var test = _container.Resolve<ExtentTest>();

            if (scenarioContext.TestError == null)
            {
                LogStepStatus(test, Status.Pass, $"{stepType} {stepText}");
            }
            else
            {
                LogStepStatus(test, Status.Fail, $"{stepType} {stepText}");
                MarkUp(test, Status.Fail, scenarioContext.TestError.ToString());
                ScreenshotAttach(test, Status.Fail, Capture(driver, stepType+ stepText));
            }
        }



    }
}