using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading;
using TestingFramework.Hooks;
using TestingFramework.Locators;

namespace TestingFramework.CommonFunctions
{
    public class OrangeHRMCommonFunctions
    {
        WebdriverMethods objWebdriverMethods = new WebdriverMethods();
        public void UserEnterTheCredentials()
        {
            objWebdriverMethods.Sendkeys(LoginLocators.Username, WebdriverMethods.GetValueFromJsonFile("UserName"));
            objWebdriverMethods.Sendkeys(LoginLocators.Password, WebdriverMethods.GetValueFromJsonFile("Password"));
        }

        public void ClickOnLoginButton()
        {
            objWebdriverMethods.Click(LoginLocators.LoginButton);            
        }

        public void ClickOnAdminTab()
        {
            objWebdriverMethods.Click(AdminLocators.AdminTab);
        }

        public void ClickOnAddButton()
        {
            objWebdriverMethods.Click(AdminLocators.AddButton);
        }

        public void AddAdminDetails(string userRole, string employeeName, string userName, string status, string password)
        {
            objWebdriverMethods.SelectValueFromDropdown(AdminLocators.UserRoleDropdown, userRole);
            objWebdriverMethods.Sendkeys(AdminLocators.EmployeeNameField, employeeName);
            objWebdriverMethods.Sendkeys(AdminLocators.UserNameField, userName);
            objWebdriverMethods.SelectValueFromDropdown(AdminLocators.StatusDropdown, status);
            objWebdriverMethods.Sendkeys(AdminLocators.PasswordField, password);
            objWebdriverMethods.Sendkeys(AdminLocators.ConfirmPasswordField, password);

        }

        public void ClickOnSaveButton()
        {
            Thread.Sleep(500);
            objWebdriverMethods.Click(AdminLocators.SaveButton);
        }


        public bool VerifyUserAdded(string userRole, string employeeName, string userName, string status)
        {
            objWebdriverMethods.WaitForElementToDisplay(AdminLocators.AdminTable);
            bool isRecordFound = false;
            try
            {
                var adminTable = DriverInitialize.driver.FindElement(AdminLocators.AdminTable);
                IList<IWebElement> Rows = adminTable.FindElements(By.TagName("tr"));
                foreach (IWebElement row in Rows)
                {                    
                    IList<IWebElement> Cells = row.FindElements(By.TagName("td"));
                    
                        if (Cells[1].Text.Equals(userName) &&
                            Cells[2].Text.Equals(userRole) &&
                            Cells[3].Text.Equals(employeeName)&&
                            Cells[4].Text.Equals(status))
                        {
                            isRecordFound = true;
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                Hook.exceptions.Add(e.Message);
            }

            return isRecordFound;
        }

        public void DeleteUser(string userName)
        {
            objWebdriverMethods.Click(By.XPath(AdminLocators.DeleteChecbox.Replace("<<UserName>>", userName)));
            objWebdriverMethods.Click(AdminLocators.DeleteButton);
            objWebdriverMethods.Click(AdminLocators.OkButton);
        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            var rString = "";
            for (var i = 0; i < length; i++)
            {
                rString += ((char)(random.Next(1, 26) + 64)).ToString().ToLower();
            }
            return(rString);
        }
    }
}
