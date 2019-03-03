using GL_Pro_Camp_UI_Automation.app;
using NUnit.Framework;

namespace GL_Pro_Camp_UI_Automation.tests
{
    public class BaseTest
    {
        protected Application App { get; set; }

        [SetUp]
        public void SetUp()
        {
            this.App = new Application();
        }

        [TearDown]
        public void Quit()
        {
            this.App.Quit();
        }
    }
}
