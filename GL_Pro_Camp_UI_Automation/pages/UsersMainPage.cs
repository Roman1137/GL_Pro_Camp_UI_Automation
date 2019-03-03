using System.Collections.Generic;
using System.Linq;
using GL_Pro_Camp_UI_Automation.app;
using OpenQA.Selenium;

namespace GL_Pro_Camp_UI_Automation.pages
{
    public class UsersMainPage: BasePage
    {
        public UsersMainPage(Application app) : base(app) { }

        public void Open()
        {
            Driver.Url = App.ConfigManager.BaseUrl;
        }

        public void ClickAtProductByIndex(int productIndex)
        {
            var product = this.ProductsElements[productIndex];
            product.Click();
        }

        // locators
        private string ProductLocator => ".product";

        // webelements
        private List<IWebElement> ProductsElements => Driver.FindElements(By.CssSelector(this.ProductLocator)).ToList();

    }
}
