using System.Collections.Generic;
using System.Linq;
using GL_Pro_Camp_UI_Automation.app;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GL_Pro_Camp_UI_Automation.pages
{
    public class CartPage: BasePage
    {
        public CartPage(Application app) : base(app)
        {
        }

        private void WaitUntilLoaded()
        {
            App.Wait.Until(dr => dr.FindElement(By.CssSelector(this.ConfirmOrderButtonLocator)));
        }

        public void RemoveAllProductsOneByOne()
        {
            do
            {
                this.RemoveButtonElement.Click();
                this.WaitUntilOrderSummartTableIsUpdated();
            } while (RemoveButtonElements.Count > 0);
        }

        private void WaitUntilOrderSummartTableIsUpdated()
        {
            App.Wait.Until(ExpectedConditions.StalenessOf(DataSummaryTableElement));
        }

        // locators
        private string ConfirmOrderButtonLocator => "[name=confirm_order]";
        private string RemoveButtonLocator => "[name=remove_cart_item]";
        private string DataSummaryTableLocator => ".dataTable.rounded-corners";

        // web elements
        private IWebElement RemoveButtonElement => Driver.FindElement(By.CssSelector(this.RemoveButtonLocator));
        private List<IWebElement> RemoveButtonElements => Driver.FindElements(By.CssSelector(this.RemoveButtonLocator)).ToList();
        private IWebElement DataSummaryTableElement => Driver.FindElement(By.CssSelector(this.DataSummaryTableLocator));
    }
}
