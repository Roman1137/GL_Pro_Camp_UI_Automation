using System;
using GL_Pro_Camp_UI_Automation.app;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestContext = NUnit.Framework.TestContext;

namespace GL_Pro_Camp_UI_Automation.pages.addNewProduct
{
    public class GeneralTab: BasePage
    {
        public GeneralTab(Application app) : base(app)
        {
        }

        public string PopulateNameField()
        {
            var productName = GetRandomStringValue(10);
            this.NameFieldElement.SendKeys(productName);
            return productName;
        }

        public GeneralTab EnableStatus()
        {
            this.EnableStatusRadioButtonElement.Click();
            return this;
        }

        public GeneralTab EnterCode()
        {
            this.CodeFieldElement.SendKeys(GetRandomNumberValue(5));
            return this;
        }

        public GeneralTab EnterDateFrom()
        {
            var dateFrom = DateTime.Today.Subtract(TimeSpan.FromDays(1)).ToString("dd/MM/yyyy");
            this.DateFromElement.SendKeys(dateFrom);
            return this;
        }

        public GeneralTab EnterDateTo()
        {
            var dateFrom = DateTime.Today.Subtract(TimeSpan.FromDays(1)).ToString("dd/MM/yyyy");
            this.DateFromElement.SendKeys(dateFrom);
            return this;
        }

        public GeneralTab UploadFile()
        {
            // Do not forget to select "Copy always" option at "Copy to Optput Diractory" dropdown 
            this.UploadFileFieldElement.SendKeys(TestContext.CurrentContext.TestDirectory + @"\files\NewProductPicture.png");
            return this;
        }

        // locators
        private string NameFieldLocator => "[name='name[en]']";
        private string EnableStatusRadioButtonLocator => "[type=radio][value='1']";
        private string CodeFieldLocator => "[name=code]";
        private string UploadFileFieldLocator => "[type=file]";
        private string DateFromLocator => "[name=date_valid_from]";
        private string DateToLocator => "[name=date_valid_to]";

        // webelements
        private IWebElement NameFieldElement => Driver.FindElement(By.CssSelector(this.NameFieldLocator));
        private IWebElement EnableStatusRadioButtonElement => Driver.FindElement(By.CssSelector(this.EnableStatusRadioButtonLocator));
        private IWebElement CodeFieldElement => Driver.FindElement(By.CssSelector(this.CodeFieldLocator));
        private IWebElement UploadFileFieldElement => Driver.FindElement(By.CssSelector(this.UploadFileFieldLocator));
        private IWebElement DateFromElement => Driver.FindElement(By.CssSelector(this.DateFromLocator));
        private IWebElement DateToElement => Driver.FindElement(By.CssSelector(this.DateToLocator));
    }
}
