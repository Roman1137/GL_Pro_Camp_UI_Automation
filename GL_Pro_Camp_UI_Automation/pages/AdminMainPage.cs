using System.Collections.Generic;
using System.Linq;
using GL_Pro_Camp_UI_Automation.app;
using OpenQA.Selenium;

namespace GL_Pro_Camp_UI_Automation.pages
{
    public class AdminMainPage: BasePage
    {
        public AdminMainPage(Application app) : base(app)
        {
        }

        public void WaitUntilLoaded()
        {
            App.Wait.Until(dr => dr.FindElement(By.CssSelector(this.LogoutButonLocator)));
        }

        public bool IsHeaderPresent()
        {
            var elementsCount = Driver.FindElements(By.CssSelector(this.HeaderLocator)).Count;
            return elementsCount > 0;
        }

        public int GetMenuItemsCount()
        {
            return this.MenuItemsElements.Count;
        }

        public void SelectMenuItemByIndex(int menuItemIndex)
        {
            var menuItem = this.MenuItemsElements[menuItemIndex];
            menuItem.Click();
            this.WaitUntilMenuItemIsSelected(menuItemIndex);
        }

        private void WaitUntilMenuItemIsSelected(int menuItemIndex)
        {
            App.Wait.Until(dr => this.MenuItemsElements[menuItemIndex].GetAttribute("class") == this.SelectedLocator);
        }

        public int GetMenuSubitemsCount()
        {
            return this.MenuSubItemsElements.Count();
        }

        public void SelectMenuSubItemByIndex(int menuSubItemIndex)
        {
            var menuItem = this.MenuSubItemsElements[menuSubItemIndex];
            menuItem.Click();
            this.WaitUntilMenuSubItemIsSelected(menuSubItemIndex);
        }

        private void WaitUntilMenuSubItemIsSelected(int menuSubItemIndex)
        {
            App.Wait.Until(dr => this.MenuSubItemsElements[menuSubItemIndex].GetAttribute("class") == this.SelectedLocator);
        }


        // locators
        private string HeaderLocator => "h1";
        private string LogoutButonLocator => "[title=Logout]";
        private string MenuItemLocator => "#app-";
        private string SelectedLocator => "selected";
        private string MenuSubItemLocator => $"{MenuItemLocator}.{SelectedLocator} ul li";

        // webelements
        private IList<IWebElement> MenuItemsElements => Driver.FindElements(By.CssSelector(this.MenuItemLocator));
        private IList<IWebElement> MenuSubItemsElements => Driver.FindElements(By.CssSelector(this.MenuSubItemLocator));
    }
}
