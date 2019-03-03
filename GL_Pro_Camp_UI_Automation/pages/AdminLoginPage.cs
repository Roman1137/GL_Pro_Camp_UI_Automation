using System.Collections.Generic;
using System.Configuration;

namespace GL_Pro_Camp_UI_Automation.pages
{
    public class AdminLoginPage
    {
        private string login;
        private string password;
        public AdminLoginPage()
        {
            Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;
            //this.login = confCollection.[]

        }
        public void Login()
        {

        }
    }
}
