using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestingFramework.CommonFunctions;
using TestingFramework.Helper;
using TestingFramework.Hooks;
using TestingFramework.Locators;

namespace TestingFramework.Steps
{
    [Binding]
    public class OrangeHRMSteps
    {
        WebdriverMethods objWebdriverMethods = new WebdriverMethods();
        OrangeHRMCommonFunctions objOrangeHRMFunctions = new OrangeHRMCommonFunctions();
        string userName = OrangeHRMCommonFunctions.RandomString(8);

        [Given(@"User is at Orange HRM")]
        public void GivenUserIsAtOrangeHRM()
        {
            try
            {
                objWebdriverMethods.LaunchURL();
            }
            catch (Exception e)
            {
                Hook.test.Log(Status.Fail, e.Message);
                Hook.exceptions.Add(e.Message);
            }
            finally
            {
                ReportsHelper.TakeScreenshot("URL launched successfully");
            }
        }

        [When(@"User enters the username and password")]
        public void WhenUserEntersTheUsernameAndPassword()
        {
            try
            {
                objOrangeHRMFunctions.UserEnterTheCredentials();
            }
            catch (Exception e)
            {
                Hook.test.Log(Status.Fail, e.Message);
                Hook.exceptions.Add(e.Message);
            }
            finally
            {
                ReportsHelper.TakeScreenshot("Credentials entered successfully");
            }
        }

        [When(@"User clicks on Login button")]
        public void WhenUserClicksOnLoginButton()
        {
            try
            {
                objOrangeHRMFunctions.clickOnLoginButton();
            }
            catch (Exception e)
            {
                Hook.test.Log(Status.Fail, e.Message);
                Hook.exceptions.Add(e.Message);
            }
            finally
            {
                ReportsHelper.TakeScreenshot("Clicked Login successfully");
            }
        }

        [Then(@"User is on dashboard page")]
        public void ThenUserIsOnDashboardPage()
        {
            try
            {
                Assert.AreEqual(objWebdriverMethods.GetText(AdminLocators.HeadingText), "Dashboard");
            }
            catch (Exception e)
            {
                Hook.test.Log(Status.Fail, e.Message);
                Hook.exceptions.Add(e.Message);
            }
            finally
            {
                ReportsHelper.TakeScreenshot("User is on Dashboard Page");
            }
        }
      

        [Then(@"User click on save")]
        public void ThenUserClickOnSave()
        {
            try
            {
                objOrangeHRMFunctions.clickOnSaveButton();
            }
            catch (Exception e)
            {
                Hook.test.Log(Status.Fail, e.Message);
                Hook.exceptions.Add(e.Message);
            }
            finally
            {
                ReportsHelper.TakeScreenshot("Clicked on save button successfully");
            }
        }


        [Then(@"User Click on Admin tab")]
        public void ThenUserClickOnAdminTab()
        {
            try
            {
                objOrangeHRMFunctions.ClickOnAdminTab();
            }
            catch (Exception e)
            {
                Hook.test.Log(Status.Fail, e.Message);
                Hook.exceptions.Add(e.Message);
            }
            finally
            {
                ReportsHelper.TakeScreenshot("Clicked on Admin tab successfully");
            }
        }



        [Then(@"User click on Add button")]
        public void ThenUserClickOnAddButton()
        {
            try
            {
                objOrangeHRMFunctions.ClickOnAddButton();
            }
            catch (Exception e)
            {
                Hook.test.Log(Status.Fail, e.Message);
                Hook.exceptions.Add(e.Message);
            }
            finally
            {
                ReportsHelper.TakeScreenshot("Clicked on Add button successfully");
            }
        }

        [Then(@"User add the details '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void ThenUserAddTheDetails(string userRole, string employeeName, string status, string password)
        {
            try
            {
                objOrangeHRMFunctions.AddAdminDetails(userRole, employeeName, userName, status, password);
            }
            catch (Exception e)
            {
                Hook.test.Log(Status.Fail, e.Message);
                Hook.exceptions.Add(e.Message);
            }
            finally
            {
                ReportsHelper.TakeScreenshot("Details provided successfully");
            }
        }

        

        [Then(@"User Deletes the added record")]
        public void ThenUserDeletesTheAddedRecord()
        {
            try
            {
                objOrangeHRMFunctions.deleteUser(userName);
            }
            catch (Exception e)
            {
                Hook.test.Log(Status.Fail, e.Message);
                Hook.exceptions.Add(e.Message);
            }
            finally
            {
                ReportsHelper.TakeScreenshot("Details deleted successfully");
            }
        }


        [Then(@"User verifies the added admin '(.*)' '(.*)' '(.*)'")]
        public void ThenUserVerifiesTheAddedAdmin(string userRole, string employeeName, string status)
        {
            try
            {
                objOrangeHRMFunctions.VerifyUserAdded(userRole, employeeName, userName, status);
            }
            catch (Exception e)
            {
                Hook.test.Log(Status.Fail, e.Message);
                Hook.exceptions.Add(e.Message);
            }
            finally
            {
                ReportsHelper.TakeScreenshot("Details verified successfully");
            }

        }

    }
}
