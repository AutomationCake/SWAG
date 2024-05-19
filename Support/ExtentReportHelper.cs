using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;


namespace SWAG.Support
{

    public class ExtentReportsHelper
    {



        public static ExtentReports GetExtent(string featureFileName)
        {
            ExtentReports _extent;

            string projectDirectory1 = Environment.CurrentDirectory;
            string getPath = projectDirectory1.Substring(0, projectDirectory1.LastIndexOf("bin"));
            string reportPath = getPath + "Report\\" + featureFileName + ".html";
            var htmlReporter = new ExtentSparkReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);


            return _extent;
        }

        public static ExtentTest CreateTest(ExtentReports extent, string testName)
        {
            ExtentTest _test = extent.CreateTest(testName);
            return _test;
        }

        public static void LogStepStatus(ExtentTest _test, Status status, string stepName)
        {
            _test.Log(status, stepName);
        }


        public static void MarkUp(ExtentTest _test, Status status, string stepName)
        {
            _test.Log(status, MarkupHelper.CreateLabel(stepName, ExtentColor.Red));
        }

        public static void ScreenshotAttach(ExtentTest _test, Status status, string path)
        {
            _test.Log(status, "Snapshot below: " + _test.AddScreenCaptureFromPath(path));
        }

        public static void FlushReport(ExtentReports _extent)
        {
            _extent.Flush();
        }
    }

}
