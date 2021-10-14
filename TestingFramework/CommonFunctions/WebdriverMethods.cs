using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingFramework.CommonFunctions
{
    public class WebdriverMethods
    {
        public void Sendkeys(By control, string value)
        {
            DriverInitialize.driver.FindElement(control).SendKeys(value);
        }

        public void Click(By control)
        {
            DriverInitialize.driver.FindElement(control).Click();
        }

        public void Clear(By control)
        {
            DriverInitialize.driver.FindElement(control).Clear();
        }

        public bool IsPageLoaded(By control)
        {
            return DriverInitialize.driver.FindElement(control).Displayed;
        }

        public void WaitForElementToDisplay(By control)
        {
            var wait = new WebDriverWait(DriverInitialize.driver, TimeSpan.FromSeconds(500));
            wait.Until(drv => drv.FindElement(control));
        }

       public static string GetValueFromJsonFile(string key)
        {
            IConfiguration Config = new ConfigurationBuilder()
               .AddJsonFile("appSettings.json")
               .Build();

            var value = Config.GetSection(key).Value;

            return value;
        }


        public void LaunchURL()
        {
            DriverInitialize.driver.Navigate().GoToUrl(GetValueFromJsonFile("URL"));
        }

        public string GetText(By control)
        {
            string value = DriverInitialize.driver.FindElement(control).Text;
            return value;
        }

        public void SelectValueFromDropdown(By control,string value)
        {
            SelectElement oSelect = new SelectElement(DriverInitialize.driver.FindElement(control));
            oSelect.SelectByText(value);
        }
    }
}
