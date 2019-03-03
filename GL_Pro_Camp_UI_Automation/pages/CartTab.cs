using System;
using GL_Pro_Camp_UI_Automation.app;
using OpenQA.Selenium;

namespace GL_Pro_Camp_UI_Automation.pages
{
    public class CartTab: BasePage
    {
        public CartTab(Application app) : base(app)
        {
        }

        public void WaitUntilCartQuantityIs(int quantityToWait)
        {
            App.Wait.Until(dr => this.CartQuantityElement.Text == quantityToWait.ToString());
        }

        public int GetItemsInCartQuantity()
        {
            return Int32.Parse(this.CartQuantityElement.Text);
        }

        public void InitCheckout()
        {
            this.CheckoutButtonElement.Click();
        }

        // locators
        private string CartQuantityLocator => "#cart .quantity";
        private string CheckoutButtonLocator => "#cart .link";

        // webelements
        private IWebElement CartQuantityElement => Driver.FindElement(By.CssSelector(this.CartQuantityLocator));
        private IWebElement CheckoutButtonElement => Driver.FindElement(By.CssSelector(this.CheckoutButtonLocator));
    }
}
