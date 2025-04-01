using OpenQA.Selenium;
using SWAG.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SWAG.Pages
{
    public class LoginPage
    {
        public static By username { get { return By.Id("user-name"); } }

        public static By password { get { return By.Id("password"); } }

        public static By loginbutton { get { return By.Id("login-button"); } }

        public static void login(IWebDriver driver, string _username,string _password )
        {
            Actionutility.SendKeys(driver, username, _username);
            Actionutility.SendKeys(driver, password, _password);
            Actionutility.Click(driver, loginbutton);
        }



    }


  
}
