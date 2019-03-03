using FluentAssert;
using NUnit.Framework;

namespace GL_Pro_Camp_UI_Automation.tests
{
    [TestFixture]
    public class LeftMenuNavigationTests: BaseTest
    {
        [Test]
        public void Verify_H1_Is_Present_At_Each_Menu_Item_And_SubItem()
        {
            App.AdminLoginPage.Open().Login();
            App.AdminMainPage.WaitUntilLoaded();

            var menuItemsCount = App.AdminMainPage.GetMenuItemsCount();
            for (int menuItemIndex = 0; menuItemIndex < menuItemsCount; menuItemIndex++)
            {
                App.AdminMainPage.SelectMenuItemByIndex(menuItemIndex);
                var isHeaderPresent = App.AdminMainPage.IsHeaderPresent();
                isHeaderPresent.ShouldBeTrue($"h1 element is not present at the menu item with index {menuItemIndex}");

                var menuSubItemCount = App.AdminMainPage.GetMenuSubitemsCount();
                if (menuSubItemCount > 0)
                {
                    for (int menuSubItemIndex = 0; menuSubItemIndex < menuSubItemCount; menuSubItemIndex++)
                    {
                        App.AdminMainPage.SelectMenuSubItemByIndex(menuSubItemIndex);
                        isHeaderPresent = App.AdminMainPage.IsHeaderPresent();
                        isHeaderPresent.ShouldBeTrue($"h1 element is not present at the sub menu item with index {menuSubItemIndex} of menu item {menuItemIndex}");
                    }
                }
            }
        }
    }
}
