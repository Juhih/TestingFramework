using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingFramework.Locators
{
    public  class LoginLocators
    {
        public static By Username = By.Id("txtUsername");
        public static By Password = By.Id("txtPassword");
        public static By LoginButton = By.Id("btnLogin");
    }
}
 