using System;
using microcosm.Config;

namespace microcosm.Common
{
    public class CommonInstance
    {
        private static CommonInstance instance = new CommonInstance();
        public ConfigData config;
        public SettingData[] settings;

        public SettingData currentSetting;

        public string SelectedDirectoryName;
        public string SelectedDirectoryFullPath;

        private CommonInstance()
        {
        }

        public static CommonInstance getInstance() 
        {
            return instance;
        }
    }
}
