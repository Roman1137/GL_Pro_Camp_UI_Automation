using GL_Pro_Camp_UI_Automation.app;
using OpenQA.Selenium;

namespace GL_Pro_Camp_UI_Automation.pages
{
    public class AdminLoginPage: BasePage
    {
        private string Urn { get; } = "admin";
        public AdminLoginPage(Application app) : base(app) { }

        public void Login()
        {
            this.UsernameElement.SendKeys(App.ConfigManager.Login);
            this.PasswordElement.SendKeys(App.ConfigManager.Password);
            this.LoginButtonElement.Click();
        }

        public AdminLoginPage Open()
        {
            Driver.Url = App.ConfigManager.BaseUrl + this.Urn;
            return this;
        }

        // locators
        private string UsernameLocator => "[data-type=text]";
        private string PasswordLocator => "[data-type=password]";
        private string LoginButtonLocator => "[name=login]";

        // webelements
        private IWebElement UsernameElement => Driver.FindElement(By.CssSelector(this.UsernameLocator));
        private IWebElement PasswordElement => Driver.FindElement(By.CssSelector(this.PasswordLocator));
        private IWebElement LoginButtonElement => Driver.FindElement(By.CssSelector(this.LoginButtonLocator));
    }
}
