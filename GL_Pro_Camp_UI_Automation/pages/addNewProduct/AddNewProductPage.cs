using System.Collections.Generic;
using System.Linq;
using GL_Pro_Camp_UI_Automation.app;
using OpenQA.Selenium;

namespace GL_Pro_Camp_UI_Automation.pages.addNewProduct
{
    public class AddNewProductPage: BasePage
    {
        public GeneralTab GeneralTab { get; set; }
        public InformationTab InformationTab { get; set; }
        public PricesTab PricesTab { get; set; }
        public AddNewProductPage(Application app) : base(app)
        {
            this.GeneralTab = new GeneralTab(app);
            this.InformationTab = new InformationTab(app);
            this.PricesTab = new PricesTab(app);
        }

        public GeneralTab SwitchToGeneralTab()
        {
            this.GeneralTabElement.Click();
            this.WaitUntilTabIsActive(this.GeneralTabElement);
            return this.GeneralTab;
        }

        public InformationTab SwitchInformationTab()
        {
            this.InformationTabElement.Click();
            this.WaitUntilTabIsActive(this.InformationTabElement);
            return this.InformationTab;
        }

        public PricesTab SwitchToPricesTab()
        {
            this.PricesTabElement.Click();
            this.WaitUntilTabIsActive(this.PricesTabElement);
            return this.PricesTab;
        }

        public void SaveProduct()
        {
            this.SaveButtonElement.Click();
        }

        private void WaitUntilTabIsActive(IWebElement tabElement)
        {
            App.Wait.Until(el => tabElement.GetAttribute("class").Equals(this.ActiveTabLoator));
        }

        // locators
        private string TabsLocator => ".index li";
        private string ActiveTabLoator => "active";
        private string SaveButtonLocator => "[name=save]";

        // webElements
        private List<IWebElement> TabsElements => Driver.FindElements(By.CssSelector(this.TabsLocator)).ToList();
        private IWebElement GeneralTabElement => this.TabsElements.First(el => el.Text.Contains("General"));
        private IWebElement InformationTabElement => this.TabsElements.First(el => el.Text.Contains("Information"));
        private IWebElement PricesTabElement => this.TabsElements.First(el => el.Text.Contains("Prices"));
        private IWebElement SaveButtonElement => Driver.FindElement(By.CssSelector(this.SaveButtonLocator));
    }
}
