using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;
using SWAG.Pages;
using SWAG.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace SWAG.Support
{
    [Binding]
    public class AdditionalHook : ExtentReportsHelper
    {   
        private static ChromeOptions chromeOptions()
        { 
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            //options.AddArgument("--headless");
            return options;
        }


        private static ChromeOptions Sauce_ChromeOptions()
        {
            var browserOptions = new ChromeOptions();
            browserOptions.PlatformName = "Windows 11";
            browserOptions.BrowserVersion = "latest";
            var sauceOptions = new Dictionary<string, object>();
            sauceOptions.Add("username", "oauth-mmraj137-e3d07");
            sauceOptions.Add("accessKey", "*****9b5d");
            sauceOptions.Add("build", "<your build id>");
            sauceOptions.Add("name", "<your test name>");
            browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

            return browserOptions;
        }

        [BeforeFeature]
        public static void BeforeFeature(IObjectContainer container, FeatureContext feature)
        {

            Hooks getContianer = new Hooks(container);
            IWebDriver? driver = null;

           // mASsfasdf

            switch ("chrome")
            {
                case "chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver(chromeOptions());
                    break;   
            }
            var featureFile = feature.FeatureInfo.Title;
            ExtentReports report = GetExtent(featureFile.ToString());

            getContianer._container.RegisterInstanceAs<ExtentReports>(report);
            getContianer._container.RegisterInstanceAs<IWebDriver>(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");


            LoginPage.login(driver, "standard_user", "secret_sauce");
            
            try {
                driver.SwitchTo().Alert().Accept();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        [AfterFeature]
        public static void AfterFeature(IObjectContainer container)
        {

            Hooks getContianer = new Hooks(container);
            var driver = getContianer._container.Resolve<IWebDriver>();
            var report = getContianer._container.Resolve<ExtentReports>();
            Console.WriteLine("AfterFeature", report);
            FlushReport(report);
            driver.Quit();
        }
    }
}
