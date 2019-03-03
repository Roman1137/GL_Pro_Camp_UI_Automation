using System.Configuration;

namespace GL_Pro_Camp_UI_Automation.app
{
    public class ConfigManager
    {
        private KeyValueConfigurationCollection confCollection;
        public string Login => this.confCollection["login"].Value;
        public string Password => this.confCollection["password"].Value;
        public ConfigManager()
        {
            Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            this.confCollection = configManager.AppSettings.Settings;
        }
    }
}
