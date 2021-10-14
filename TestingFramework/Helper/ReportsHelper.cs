using AventStack.ExtentReports;
using OpenQA.Selenium;
using Selenium.Axe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestingFramework.Hooks;

namespace TestingFramework.Helper
{
    public class ReportsHelper
    {
        public static void TakeScreenshot(string message)
        {
            var reportsDirectory = Directory.GetCurrentDirectory();
            string currentDateAndTime = DateTime.Now.ToString("MMddyyyyHHmmss");
            reportsDirectory = Path.Combine(reportsDirectory, "TestReport");
            var screenshot = ((ITakesScreenshot)DriverInitialize.driver).GetScreenshot();
            var failedScreenshot = $"{reportsDirectory}/{currentDateAndTime}.png";
            screenshot.SaveAsFile(failedScreenshot, ScreenshotImageFormat.Png);
            Hook.test.Log(Status.Info, message, MediaEntityBuilder.CreateScreenCaptureFromPath(failedScreenshot).Build());
        }


        public static void CreateAcessibilityReport()
        {
            AxeResult results = new AxeBuilder(DriverInitialize.driver).Analyze();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "AxeReport"+DateTime.Now.ToString("MMddyyyyHHmmss")+".html");
            DriverInitialize.driver.CreateAxeHtmlReport(results, path);
        }


       
    }
}
