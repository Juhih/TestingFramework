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

        public void clickOnLoginButton()
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

        public void AddAdminDetails(string UserRole, string EmployeeName, string UserName, string Status, string Password)
        {
            objWebdriverMethods.SelectValueFromDropdown(AdminLocators.UserRoleDropdown, UserRole);
            objWebdriverMethods.Sendkeys(AdminLocators.EmployeeNameField, EmployeeName);
            objWebdriverMethods.Sendkeys(AdminLocators.UserNameField, UserName);
            objWebdriverMethods.SelectValueFromDropdown(AdminLocators.StatusDropdown, Status);
            objWebdriverMethods.Sendkeys(AdminLocators.PasswordField, Password);
            objWebdriverMethods.Sendkeys(AdminLocators.ConfirmPasswordField, Password);

        }

        public void clickOnSaveButton()
        {
            Thread.Sleep(500);
            objWebdriverMethods.Click(AdminLocators.SaveButton);
        }


        public bool VerifyUserAdded(string UserRole, string EmployeeName, string UserName, string Status)
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
                    
                        if (Cells[1].Text.Equals(UserName) &&
                            Cells[2].Text.Equals(UserRole) &&
                            Cells[3].Text.Equals(EmployeeName)&&
                            Cells[4].Text.Equals(Status))
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

        public void deleteUser(string UserName)
        {
            objWebdriverMethods.Click(By.XPath(AdminLocators.DeleteChecbox.Replace("<<UserName>>", UserName)));
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
