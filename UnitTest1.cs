using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Drawing;
using System.IO;
using System.Threading;

namespace TestProject3
{
    [TestClass]


    public class CDHMobileUITests
    {

        private static AndroidDriver<AppiumWebElement> _driver;
        private static AppiumLocalService _appiumLocalService;
        [ClassInitialize]
        public static void ClassInitialize(TestContext a)
        {
            _appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().WithLogFile(new FileInfo(@"c:\temp\log.txt")).UsingDriverExecutable(new System.IO.FileInfo(@"C:\Program Files\nodejs\node.exe")).Build();
            _appiumLocalService.Start();
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel 4 API 30");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "ANDROID");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "11");
            //appiumOptions.AddAdditionalCapability(MobileCapabilityType.BrowserName, "Chrome");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "uiautomator2");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Program Files (x86)\Android\android-sdk\platform-tools\Dev-1MO-12.0.0-vc1799-TicketPin.apk");
            appiumOptions.AddAdditionalCapability("appPackage", "com.lighthouse1.mobilebenefits.a1mo2.Dev.v12_0_0.TicketPin");
            appiumOptions.AddAdditionalCapability("appActivity", "com.lighthouse1.mobilebenefits.activity.LoginActivity");
            appiumOptions.AddAdditionalCapability("isHeadless", true);

            _driver = new AndroidDriver<AppiumWebElement>(_appiumLocalService, appiumOptions);
            //_driver.CloseApp();
        }
        [TestInitialize]
        public void TestInitialize()
        {

            //_driver?.LaunchApp();
        }
        [TestMethod]

        public void LoginTest()
        {

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


            //new TouchAction(_driver).Tap(505, 1174).Perform();

            var userNameTextBox = _driver.FindElementById("com.lighthouse1.mobilebenefits.a1mo2.Dev.v12_0_0.TicketPin:id/textinputedittext_login_username");

            userNameTextBox.SendKeys("sigis2");
            var passwordTextBox = _driver.FindElementById("com.lighthouse1.mobilebenefits.a1mo2.Dev.v12_0_0.TicketPin:id/textinputedittext_login_password");
            passwordTextBox.SendKeys("Pass123!");
            var loginButton = _driver.FindElementById("com.lighthouse1.mobilebenefits.a1mo2.Dev.v12_0_0.TicketPin:id/button_login_primarybutton");
            loginButton.Click();
            var passCode = _driver.FindElementById("com.lighthouse1.mobilebenefits.a1mo2.Dev.v12_0_0.TicketPin:id/edittext_login_passcode");
            passCode.SendKeys("1111");
            passCode = _driver.FindElementById("com.lighthouse1.mobilebenefits.a1mo2.Dev.v12_0_0.TicketPin:id/edittext_login_passcode");
            passCode.SendKeys("1111");
            _driver.FindElementById("com.lighthouse1.mobilebenefits.a1mo2.Dev.v12_0_0.TicketPin:id/button_highlight_next").Click();
            //_driver.FindElementByLinkText("OK").Click();
            _driver.FindElementById("android:id/button1").Click();
            _driver.FindElementByAccessibilityId("Profile").Click();
            var customerName = _driver.FindElementById("com.lighthouse1.mobilebenefits.a1mo2.Dev.v12_0_0.TicketPin:id/textview_profile_consumerfullname").Text;
            Assert.AreEqual(customerName, "sigis2 sigis2");
            //passCodeSquare1.SendKeys("1");
            //passCodeSquare1.Click();
            //passCodeSquare1.SendKeys("1111");

            //TouchAction touchAction = new TouchAction(_driver);
            //touchAction.Tap(loginButton).Perform();
            //for (int i = 0; i < 8; i++)    
            //new TouchAction(_driver).Tap(244, 1642).Perform();

            //Thread.Sleep(20000);

        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver?.CloseApp();
        }
        [ClassCleanup]
        public static void ClassCleanup()
        {
            _appiumLocalService.Dispose();
        }
    }

}