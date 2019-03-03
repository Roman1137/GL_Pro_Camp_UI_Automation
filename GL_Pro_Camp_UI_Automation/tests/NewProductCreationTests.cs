using FluentAssert;
using NUnit.Framework;

namespace GL_Pro_Camp_UI_Automation.tests
{
    [TestFixture]
    public class NewProductCreationTests : BaseTest
    {
        [Test]
        public void Verify_New_Product_Creation_And_Presense()
        {
            App.AdminLoginPage.Open().Login();
            App.AdminMainPage.GoToCatalogTab();

            App.CatalogTab.InitNewProductCreation();


            var productName = App.AddNewProductPage.SwitchToGeneralTab()
                .EnableStatus()
                .EnterCode()
                .UploadFile()
                .EnterDateFrom()
                .EnterDateTo()
                .PopulateNameField();

            App.AddNewProductPage.SwitchInformationTab()
                .SelectManufacturer()
                .PopulateKeywordsField()
                .PopulateShortDescriptionField()
                .PopulateDescriptionField()
                .PopulateHeadTitleField()
                .PopulateMetaDescriptionField();

            App.AddNewProductPage.SwitchToPricesTab()
                .PopulatePurchasePriceField()
                .SelectCurrency()
                .PopulatePriceUsd()
                .PopulatePriceEur();

            App.AddNewProductPage.SaveProduct();
            App.CatalogTab.IsProductDisplayedInCatalog(productName)
                .ShouldBeTrue($"Product with name {productName} should be displayed in catalog");

            App.UsersMainPage.Open()
                .ClickAtProductName(productName);
            App.ProductPage.AddProductToCart();

            App.UsersMainPage.Open()
                .ClickAtRandomProductNameExceptFor(productName);
            App.ProductPage.AddProductToCart();

            App.CartTab.InitCheckout();
            App.CartPage.RemoveAllProductsOneByOne();
            App.UsersMainPage.Open();
            var itemsOnCart = App.CartTab.GetItemsInCartQuantity();
            itemsOnCart.ShouldBeEqualTo(0, "Cart should not contain any items after complete removal all of them");
        }
    }
}
