using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
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
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                driver = new ChromeDriver(options);
            }

            else if (browser.ToLower().Equals("internetexplorer"))
            {
                new WebDriverManager.DriverManager().SetUpDriver(new InternetExplorerConfig());
                var options = new InternetExplorerOptions()
                {
                    IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                    IgnoreZoomLevel = true,
                    EnableNativeEvents = false
                };
                driver = new InternetExplorerDriver(options);
                
            }

            else if (browser.ToLower().Equals("firefox"))
            {
                new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                FirefoxOptions options = new FirefoxOptions();
                options.BrowserExecutableLocation = ("C:\\Users\\Juhi.Hazari\\AppData\\Local\\Mozilla Firefox\\firefox.exe"); //This is the location where you have installed Firefox on your machine
                driver = new FirefoxDriver(options);
            }

        }

        public static void WebdriverClose()
        {
            driver.Quit();
        }
    }
}

