using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TestingFramework.Hooks
{
    [Binding]
    public sealed class Hook
    {
        public static ExtentTest featureName;
        public static ExtentTest scenario;
        public static ExtentTest steps;
        public static ExtentReports extent;
        public static List<string> exceptions;
        public static ExtentTest test;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            string reportDateAndTime = DateTime.Now.ToString("MMddyyyyHHmmss");
            string Reportpath = AppDomain.CurrentDomain.BaseDirectory + "TestReport\\FALATestReport" + reportDateAndTime;
            extent = new ExtentReports();
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(Reportpath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            htmlReporter.Config.DocumentTitle = "Automation Testing Report";
            htmlReporter.Config.ReportName = "Regression Testing";
            extent.AttachReporter(htmlReporter);
        }


        [BeforeFeature]
        [Obsolete]
        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
            Console.WriteLine("BeforeFeature");
        }

        [BeforeScenario]
        [Obsolete]
        public static void BeforeScenario()
        {
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            exceptions = new List<string>();
            DriverInitialize.CallDriver();
        }

        [BeforeStep]
        public static void InsertReportingSteps(ScenarioContext ScenarioContext)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    steps = scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "When")
                {
                    steps = scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "Then")
                {
                    steps = scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "And")
                {
                    steps = scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                }
                test = steps.Log(Status.Info);
            }
        }


        [AfterScenario]
        public static void AfterScenario()
        {
            DriverInitialize.WebdriverClose();
            if (exceptions.Count > 0)
                Assert.Fail();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
        }

    }
}
