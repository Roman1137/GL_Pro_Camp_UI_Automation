using System.Collections.Generic;
using System.Linq;
using GL_Pro_Camp_UI_Automation.app;
using OpenQA.Selenium;

namespace GL_Pro_Camp_UI_Automation.pages
{
    public class UsersMainPage: BasePage
    {
        public UsersMainPage(Application app) : base(app) { }

        public UsersMainPage Open()
        {
            Driver.Url = App.ConfigManager.BaseUrl;
            return this;
        }

        public void ClickAtProductByIndex(int productIndex)
        {
            var product = this.ProductsElements[productIndex];
            product.Click();
        }

        public void ClickAtProductName(string productName)
        {
            var product = this.ProductsElements.First(el => el.Text.Contains(productName));
            product.Click();
        }

        public void ClickAtRandomProductNameExceptFor(string productName)
        {
            var product = this.ProductsElements.First(el => !el.Text.Contains(productName));
            product.Click();
        }

        // locators
        private string ProductLocator => ".product";

        // webelements
        private List<IWebElement> ProductsElements => Driver.FindElements(By.CssSelector(this.ProductLocator)).ToList();

    }
}
