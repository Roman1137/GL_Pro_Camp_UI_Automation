using System;
using GL_Pro_Camp_UI_Automation.pages;
using GL_Pro_Camp_UI_Automation.pages.addNewProduct;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;

namespace GL_Pro_Camp_UI_Automation.app
{
    public class Application
    {
        public EventFiringWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        public ConfigManager ConfigManager { get; set; }

        public AdminLoginPage AdminLoginPage { get; set; }
        public AdminMainPage AdminMainPage { get; set; }
        public CartPage CartPage { get; set; }
        public ProductPage ProductPage { get; set; }
        public UsersMainPage UsersMainPage { get; set; }
        public CartTab CartTab { get; set; }
        public CatalogTab CatalogTab { get; set; }
        public AddNewProductPage AddNewProductPage { get; set; }

        public Application()
        {
            this.Driver = new EventFiringWebDriver(new ChromeDriver());
            this.Driver.Manage().Window.Maximize();
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(10));

            this.ConfigManager = new ConfigManager();
    
            this.InitializeWebdriverEvents();
            this.InitializePages();
        }

        private void InitializePages()
        {
            this.AdminLoginPage = new AdminLoginPage(this);
            this.AdminMainPage = new AdminMainPage(this);
            this.CartPage = new CartPage(this);
            this.ProductPage = new ProductPage(this);
            this.UsersMainPage = new UsersMainPage(this);
            this.CartTab = new CartTab(this);
            this.CatalogTab = new CatalogTab(this);
            this.AddNewProductPage = new AddNewProductPage(this);
        }

        public void Quit()
        {
            bool isSomeTestFailed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed;
            if (isSomeTestFailed)
            {
                this.TakeScreenShot();
            }

            Driver.Close();
            Driver.Quit();
            Driver.Dispose();
            Driver = null;
        }

        private void TakeScreenShot()
        {
            var fileName = TestContext.CurrentContext.TestDirectory + "\\" +
                           DateTime.Now.ToString("yy-MM-dd-HH-mm-ss-FFF") + "-" + GetType().Name + "-" +
                           TestContext.CurrentContext.Test.FullName + "." + ScreenshotImageFormat.Jpeg;
            try
            {
                ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
                TestContext.AddTestAttachment(fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void InitializeWebdriverEvents()
        {
            Driver.FindingElement += (sender, args) => Console.WriteLine($"Looking for elemet {args.FindMethod}");
            Driver.FindElementCompleted += (sender, args) => Console.WriteLine($"Element {args.FindMethod} was found");
            Driver.ElementClicking += (sender, args) => Console.WriteLine($"Clicking element {args.Element}");
            Driver.ElementClicked += (sender, args) => Console.WriteLine($"Element {args.Element} was clicked");
            Driver.Navigating += (sender, args) => Console.WriteLine($"Navigating to {args.Url}");
            Driver.Navigated += (sender, args) => Console.WriteLine($"Navigated to {args.Url}");
        }
    }
}
