using GL_Pro_Camp_UI_Automation.app;
using OpenQA.Selenium;

namespace GL_Pro_Camp_UI_Automation.pages
{
    public class BasePage
    {
        protected Application App { get; set; }
        protected IWebDriver Driver { get; set; }

        public BasePage(Application app)
        {
            this.App = app;
            this.Driver = app.Driver;
        }
    }
}
