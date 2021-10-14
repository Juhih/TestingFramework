using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingFramework.Locators
{
    public class AdminLocators
    {

        public static By HeadingText = By.XPath("//*[@class='head']/h1");
        public static By AdminTab = By.Id("menu_admin_viewAdminModule");
        public static By AddButton = By.Id("btnAdd");
        public static By UserRoleDropdown = By.Id("systemUser_userType");
        public static By EmployeeNameField = By.Id("systemUser_employeeName_empName");
        public static By UserNameField = By.Id("systemUser_userName");
        public static By StatusDropdown = By.Id("systemUser_status");
        public static By PasswordField = By.Id("systemUser_password");
        public static By ConfirmPasswordField = By.Id("systemUser_confirmPassword");
        public static By SaveButton = By.Id("btnSave");
        public static By AdminTable = By.XPath("//table[@id ='resultTable']/tbody");
        public static string DeleteChecbox = "//td/a[contains(text(),'<<UserName>>')]//preceding::td[1]/input[@type='checkbox']";
        public static By DeleteButton = By.Id("btnDelete");
        public static By OkButton = By.Id("dialogDeleteBtn");
    }
}
