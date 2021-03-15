using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Linq;

namespace Appium_Test_from_Android_Taskboard_app
{
    public class AppiumTests
    {
        private AndroidDriver<AndroidElement> driver;

        [OneTimeSetUp]
        public void Setup()
        {
            var appiumOptions = new AppiumOptions() { PlatformName = "Android" };
            appiumOptions.AddAdditionalCapability("app", @"C:\Users\stoia\OneDrive\Desktop\Projects\taskboard-androidclient.apk");
            driver = new AndroidDriver<AndroidElement>(
               new Uri("http://[::1]:4723/wd/hub"), appiumOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [Test]
        public void Tests()
        {
            var connectButton = driver.FindElementById("taskboard.androidclient:id/buttonConnect");
            connectButton.Click();
            var firstTaskTitle = driver.FindElementById("taskboard.androidclient:id/textViewTitle");

            Assert.AreEqual(firstTaskTitle.Text, ("Project skeleton"));

            var addButton = driver.FindElementById("taskboard.androidclient:id/buttonAdd");
            addButton.Click();
            var titleField = driver.FindElementById("taskboard.androidclient:id/editTextTitle");
            titleField.SendKeys("Test Task");
            var descField = driver.FindElementById("taskboard.androidclient:id/editTextDescription");
            descField.SendKeys("Test description");
            var createButton = driver.FindElementById("taskboard.androidclient:id/buttonCreate");
            createButton.Click();
           

            var searhField = driver.FindElementById("taskboard.androidclient:id/editTextKeyword");
            searhField.SendKeys("Test Task");
            var searchButton = driver.FindElementById("taskboard.androidclient:id/buttonSearch");
            searchButton.Click();
            var result = driver.FindElementsById("taskboard.androidclient:id/textViewTitle");
            var listRes = result.Select(res => res.Text).ToArray();
            Assert.AreEqual(listRes[0], "Test Task");
        }
        
    }
}