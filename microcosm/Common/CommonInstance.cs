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
        public int[] customRings = { 1, 3, 3, 1, 1, 1, 1 };

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
