using GL_Pro_Camp_UI_Automation.app;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GL_Pro_Camp_UI_Automation.pages.addNewProduct
{
    public class InformationTab: BasePage
    {
        public InformationTab(Application app) : base(app)
        {
        }

        public InformationTab SelectManufacturer()
        {
            new SelectElement(this.ManufacturerDropDownElement).SelectByText("ACME Corp.");
            return this;
        }

        public InformationTab PopulateKeywordsField()
        {
            this.KeywordsFieldElement.SendKeys(GetRandomStringValue(10));
            return this;
        }

        public InformationTab PopulateShortDescriptionField()
        {
            this.ShortDescriptionFieldElement.SendKeys(GetRandomStringValue(10));
            return this;
        }

        public InformationTab PopulateDescriptionField()
        {
            this.DescriptionElement.SendKeys(GetRandomStringValue(10));
            return this;
        }

        public InformationTab PopulateHeadTitleField()
        {
            this.HeadTitleElement.SendKeys(GetRandomStringValue(10));
            return this;
        }

        public InformationTab PopulateMetaDescriptionField()
        {
            this.MetaDescriptionElement.SendKeys(GetRandomStringValue(10));
            return this;
        }

        // locators 
        private string ManufactureDropDownLocator => "[name=manufacturer_id]";
        private string KeywordsFieldLocator => "[name=keywords]";
        public string ShortDescriptionFieldLocator => "[name='short_description[en]']";
        public string DescriptionLocator => ".trumbowyg-editor";
        public string HeadTitleLocator => "[name='head_title[en]']";
        public string MetaDescriptionLocator => "[name='meta_description[en]']";

        // webelements
        private IWebElement ManufacturerDropDownElement =>Driver.FindElement(By.CssSelector(this.ManufactureDropDownLocator));
        private IWebElement KeywordsFieldElement => Driver.FindElement(By.CssSelector(this.KeywordsFieldLocator));
        public IWebElement ShortDescriptionFieldElement => Driver.FindElement(By.CssSelector(this.ShortDescriptionFieldLocator));
        public IWebElement DescriptionElement => Driver.FindElement(By.CssSelector(this.DescriptionLocator));
        public IWebElement HeadTitleElement => Driver.FindElement(By.CssSelector(this.HeadTitleLocator));
        public IWebElement MetaDescriptionElement => Driver.FindElement(By.CssSelector(this.MetaDescriptionLocator));
    }
}
