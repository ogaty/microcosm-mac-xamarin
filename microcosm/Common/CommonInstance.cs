using System;
using microcosm.Config;

namespace microcosm.Common
{
    public class CommonInstance
    {
        private static CommonInstance instance = new CommonInstance();
        public ViewController controller;
        public ConfigData config;
        public SettingData[] settings;

        public SettingData currentSetting;

        public string SelectedDirectoryName;
        public string SelectedDirectoryFullPath;

        public string searchPlace = "";

        private CommonInstance()
        {
        }

        public static CommonInstance getInstance() 
        {
            return instance;
        }
    }
}
