using System;
using System.Collections.Generic;
using System.Linq;
using GL_Pro_Camp_UI_Automation.app;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GL_Pro_Camp_UI_Automation.pages
{
    public class ProductPage : BasePage
    {
        public ProductPage(Application app) : base(app)
        {
        }

        private void WaitUntiloaded()
        {
            App.Wait.Until(dr => AddToCartButtonElement.Displayed);
        }

        public void AddProductToCart()
        {
            this.WaitUntiloaded();

            var itemsInCartCountBefore = App.CartTab.GetItemsInCartQuantity();
            if (this.IsSizeDropDownPresent())
            {
                this.SelectSmallSize();
            }
            this.AddToCartButtonElement.Click();
            App.CartTab.WaitUntilCartQuantityIs(itemsInCartCountBefore + 1);
        }

        private bool IsSizeDropDownPresent()
        {
            return this.SizeDropDownElements.Count > 0;
        }

        private void SelectSmallSize()
        {
            var select = new SelectElement(SizeDropDownElements.First());
            select.SelectByText("Small");
        }

        // locators
        private string AddToCartButtonLocator => "[name=add_cart_product]";
        private string SizeDropDownLocator => "[name='options[Size]']";


        // webelements
        private IWebElement AddToCartButtonElement => Driver.FindElement(By.CssSelector(this.AddToCartButtonLocator));
        private List<IWebElement> SizeDropDownElements => Driver.FindElements(By.CssSelector(this.SizeDropDownLocator)).ToList();
    }
}
