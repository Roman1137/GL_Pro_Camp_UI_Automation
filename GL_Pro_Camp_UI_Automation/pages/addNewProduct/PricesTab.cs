using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GL_Pro_Camp_UI_Automation.app;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GL_Pro_Camp_UI_Automation.pages.addNewProduct
{
    public class PricesTab: BasePage
    {
        public PricesTab(Application app) : base(app)
        {
        }

        public PricesTab PopulatePurchasePriceField()
        {
            ClearAndSendKeys(this.PurchasePriceInputElement, GetRandomNumberValue(5));
            return this;
        }

        public PricesTab SelectCurrency()
        {
            new SelectElement(this.PurchasePriceDropDownElement).SelectByText("US Dollars");
            return this;
        }

        public PricesTab PopulatePriceUsd()
        {
            ClearAndSendKeys(this.PriceTaxUsdInputElement, GetRandomNumberValue(5));
            return this;
        }

        public PricesTab PopulatePriceEur()
        {
            ClearAndSendKeys(this.PriceTaxEurInputElement, GetRandomNumberValue(5));
            return this;
        }

        // locators
        public string PurchasePriceInputLocator => "[name=purchase_price]";
        public string PurchasePriceDropDownLocator => "[name=purchase_price_currency_code]";
        public string PriceTaxUsdInputLocator => "[name='gross_prices[USD]']";
        public string PriceTaxEurInputLocator => "[name='gross_prices[EUR]']";

        // webelements
        public IWebElement PurchasePriceInputElement => Driver.FindElement(By.CssSelector(this.PurchasePriceInputLocator));
        public IWebElement PurchasePriceDropDownElement => Driver.FindElement(By.CssSelector(this.PurchasePriceDropDownLocator));
        public IWebElement PriceTaxUsdInputElement => Driver.FindElement(By.CssSelector(this.PriceTaxUsdInputLocator));
        public IWebElement PriceTaxEurInputElement => Driver.FindElement(By.CssSelector(this.PriceTaxEurInputLocator));
    }
}
