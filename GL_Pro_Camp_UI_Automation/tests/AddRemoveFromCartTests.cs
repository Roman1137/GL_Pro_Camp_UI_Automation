using FluentAssert;
using NUnit.Framework;

namespace GL_Pro_Camp_UI_Automation.tests
{
    [TestFixture]
    public class AddRemoveFromCartTests: BaseTest
    {
        [Test]
        public void Add_And_Remove_Items_From_Cart()
        {
            var timesToRepeat = 3;
            for (int i = 0; i < timesToRepeat; i++)
            {
                App.UsersMainPage.Open();
                var desiredProductIndex = 0;
                App.UsersMainPage.ClickAtProductByIndex(desiredProductIndex);

                App.ProductPage.AddProductToCart();
            }
            App.CartTab.InitCheckout();

            App.CartPage.RemoveAllProductsOneByOne();
            App.UsersMainPage.Open();
            var itemsOnCart = App.CartTab.GetItemsInCartQuantity();
            itemsOnCart.ShouldBeEqualTo(0, "Cart should not contain any items after complete removal all of them");
        }
    }
}
