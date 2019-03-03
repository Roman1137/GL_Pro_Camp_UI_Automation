using GL_Pro_Camp_UI_Automation.app;
using NUnit.Framework;

namespace GL_Pro_Camp_UI_Automation.tests
{
    public class BaseTest
    {
        public Application app;

        [SetUp]
        public void SetUp()
        {
            this.app = new Application();
        }

        [TearDown]
        public void Quit()
        {
            this.app.Quit();
        }
    }
}
