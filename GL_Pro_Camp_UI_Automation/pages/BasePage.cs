using System;
using System.Linq;
using System.Text;
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

        public static Random random = new Random((int)DateTime.Now.Ticks);

        public static string GetRandomStringValue(int length)
        {
            const string pool = "abcdefghijklmnopqrstuvwxyz";
            var chars = Enumerable.Range(0, length)
                .Select(x => pool[random.Next(0, pool.Length)]);
            return new string(chars.ToArray());
        }

        public static string GetRandomNumberValue(int length)
        {
            const string pool = "0123456789";
            var chars = Enumerable.Range(0, length)
                .Select(x => pool[random.Next(0, pool.Length)]);
            return new string(chars.ToArray());
        }

        public static void ClearAndSendKeys(IWebElement element, string textToSend)
        {
            element.Clear();
            element.SendKeys(textToSend);
        }
    }
}
