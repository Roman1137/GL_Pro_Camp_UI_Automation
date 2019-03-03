using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GL_Pro_Camp_UI_Automation.app;
using OpenQA.Selenium;

namespace GL_Pro_Camp_UI_Automation.pages
{
    public class CatalogTab: BasePage
    {
        public CatalogTab(Application app) : base(app)
        {
        }

        private void WaitUntilLoaded()
        {
            App.Wait.Until(dr => AddNewProductButton.Displayed);
        }

        public void InitNewProductCreation()
        {
            this.WaitUntilLoaded();
            this.AddNewProductButton.Click();
        }

        public bool IsProductDisplayedInCatalog(string productName)
        {
            var productCount = this.CatalogItemsElements.Where(el => el.Text.Contains(productName)).Count();
            return productCount > 0;
        }

        //locators 
        private string ButtonLocator => ".button";
        private string CatalogItemsLocator => ".dataTable .row";

        // webelements
        private IWebElement AddNewProductButton =>
            Driver.FindElements(By.CssSelector(this.ButtonLocator)).First(el => el.Text.Contains("Add New Product"));

        private List<IWebElement> CatalogItemsElements =>
            Driver.FindElements(By.CssSelector(this.CatalogItemsLocator)).ToList();

    }
}
