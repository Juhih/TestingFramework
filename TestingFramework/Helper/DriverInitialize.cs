using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;
using TestingFramework.CommonFunctions;
using WebDriverManager.DriverConfigs.Impl;

namespace TestingFramework
{
    public class DriverInitialize
    {
        public static IWebDriver driver;

        public static void CallDriver()
        {          
            var browser = WebdriverMethods.GetValueFromJsonFile("Browser");

            if (browser.ToLower().Equals("chrome"))
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
            }

            else if (browser.ToLower().Equals("internetexplorer"))
            {
                new WebDriverManager.DriverManager().SetUpDriver(new InternetExplorerConfig());
                driver = new InternetExplorerDriver();
            }

            else if (browser.ToLower().Equals("firefox"))
            {
                new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                driver = new FirefoxDriver();
            }

        }

        public static void WebdriverClose()
        {
            driver.Quit();
        }
    }
}

