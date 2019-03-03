using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;

namespace GL_Pro_Camp_UI_Automation.app
{
    public class Application
    {
        public EventFiringWebDriver driver { get; }
        public ConfigManager ConfigManager { get; set; }

        public Application()
        {
            this.ConfigManager = new ConfigManager();

            this.driver = new EventFiringWebDriver(new ChromeDriver());
            this.driver.Manage().Window.Maximize();


            this.InitializeWebdriverEvents();
        }

        public void Quit()
        {
            bool isSomeTestFailed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed;
            if (isSomeTestFailed)
            {
                this.TakeScreenShot();
            }

            driver.Close();
            driver.Quit();
            driver.Dispose();
            driver = null;
        }

        private void TakeScreenShot()
        {
            var fileName = TestContext.CurrentContext.TestDirectory + "\\" +
                           DateTime.Now.ToString("yy-MM-dd-HH-mm-ss-FFF") + "-" + GetType().Name + "-" +
                           TestContext.CurrentContext.Test.FullName + "." + ScreenshotImageFormat.Jpeg;
            try
            {
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
                TestContext.AddTestAttachment(fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void InitializeWebdriverEvents()
        {
            driver.FindingElement += (sender, args) => Console.WriteLine($"Looking for elemet {args.FindMethod}");
            driver.FindElementCompleted += (sender, args) => Console.WriteLine($"Element {args.FindMethod} was found");
            driver.ElementClicking += (sender, args) => Console.WriteLine($"Clicking element {args.Element}");
            driver.ElementClicked += (sender, args) => Console.WriteLine($"Element {args.Element} was clicked");
            driver.Navigating += (sender, args) => Console.WriteLine($"Navigating to {args.Url}");
            driver.Navigated += (sender, args) => Console.WriteLine($"Navigated to {args.Url}");
        }
    }
}
