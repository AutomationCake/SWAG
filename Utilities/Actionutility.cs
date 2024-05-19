using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAG.Utilities
{
    public class Actionutility
    {

        public static void Click(IWebDriver driver, By ele)
        {
            try
            {
                WaitForClickable(driver, ele);
                driver.FindElement(ele).Click();
            }
            catch (Exception ex)
            {
                throw new Exception(ele + " - " + ex.Message);
            }
        }

        public static void JSClick(IWebDriver driver, By ele)
        {
            try
            {
                WaitForVisible(driver, ele);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].click();", driver.FindElement(ele));
            }
            catch (Exception ex)
            {
                throw new Exception(ele + " - " + ex.Message);
            }
        }

        public static void ActionClick(IWebDriver driver, By ele)
        {
            try
            {
                WaitForVisible(driver, ele);
                Actions action = new Actions(driver);
                action.MoveToElement(driver.FindElement(ele)).Click().Build().Perform();
            }
            catch (Exception ex)
            {
                throw new Exception(ele + " - " + ex.Message);
            }
        }

        public static void MouseHover(IWebDriver driver, By ele)
        {
            try
            {
                WaitForVisible(driver, ele);
                Actions action = new Actions(driver);
                action.MoveToElement(driver.FindElement(ele)).Build().Perform();
            }
            catch (Exception ex)
            {
                throw new Exception(ele + " - " + ex.Message);
            }
        }

        public static void DoubleClick(IWebDriver driver, By ele)
        {
            try
            {
                WaitForVisible(driver, ele);
                Actions action = new Actions(driver);
                action.MoveToElement(driver.FindElement(ele)).DoubleClick().Build().Perform();
            }
            catch (Exception ex)
            {
                throw new Exception(ele + " - " + ex.Message);
            }
        }


        public static void RightClick(IWebDriver driver, By ele)
        {
            try
            {
                WaitForVisible(driver, ele);
                Actions action = new Actions(driver);
                action.MoveToElement(driver.FindElement(ele)).ContextClick().Build().Perform();
            }
            catch (Exception ex)
            {
                throw new Exception(ele + " - " + ex.Message);
            }
        }

        public static void ScrollIntoView(IWebDriver driver, By ele)
        {
            try
            {
                WaitForVisible(driver, ele);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(ele));
            }
            catch (Exception ex)
            {
                throw new Exception(ele + " - " + ex.Message);
            }
        }

        public static void SendKeys(IWebDriver driver, By ele, string input)
        {
            try
            {
                WaitForVisible(driver, ele);
                driver.FindElement(ele).SendKeys(input);
            }
            catch (Exception ex)
            {
                throw new Exception(ele + " - " + ex.Message);
            }
        }

        public static void WaitForClickable(IWebDriver driver, By ele)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ele));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void WaitForVisible(IWebDriver driver, By ele)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ele));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public static void WaitForExists(IWebDriver driver, By ele)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(ele));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void WaitForVisibilityOfAllElementsLocatedBy(IWebDriver dirver, By ele)
        {
            WebDriverWait wait = new WebDriverWait(dirver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(ele));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static bool IsElementDisplayed(IWebDriver driver, By element)
        {
            try
            {
                
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                if (wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element)).Displayed)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public static void SelectByIndex(IWebDriver driver, By ele, int index)
        {
            try
            {
                WaitForClickable(driver, ele);
                SelectElement select = new SelectElement(driver.FindElement(ele));
                select.SelectByIndex(index);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public static void SelectByText(IWebDriver driver, By ele, string input)
        {
            try
            {
                WaitForClickable(driver, ele);
                SelectElement select = new SelectElement(driver.FindElement(ele));
                select.SelectByText(input);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void SelectByValue(IWebDriver driver, By ele, string input)
        {
            try
            {
                WaitForClickable(driver, ele);
                SelectElement select = new SelectElement(driver.FindElement(ele));
                select.SelectByValue(input);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string GetSelectedOption(IWebDriver driver, By ele)
        {
            try
            {
                WaitForVisible(driver, ele);
                SelectElement select = new SelectElement(driver.FindElement(ele));
                string getSelectedOption = select.SelectedOption.Text;
                return getSelectedOption;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string GetAttribute(IWebDriver driver, By ele, string attribute)
        {
            try
            {
                string value = driver.FindElement(ele).GetAttribute(attribute);
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string GetValue(IWebDriver driver, By ele)
        {
            try
            {
                string value = driver.FindElement(ele).GetAttribute("value");
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string GetClass(IWebDriver driver, By ele)
        {
            try
            {
                string value = driver.FindElement(ele).GetAttribute("class");
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string GetName(IWebDriver driver, By ele)
        {
            try
            {
                string value = driver.FindElement(ele).GetAttribute("name");
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string GetText(IWebDriver driver, By ele)
        {
            try
            {
                string value = driver.FindElement(ele).Text;
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
