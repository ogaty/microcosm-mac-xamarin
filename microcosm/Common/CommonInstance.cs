using System;
using microcosm.Config;
using microcosm.Views;

namespace microcosm.Common
{
    public class CommonInstance
    {
        private static CommonInstance instance = new CommonInstance();
        public ViewController controller;
        public UserAddViewController userAdd;
        public UserEditViewController userEdit;
        public ConfigData config;
        public SettingData[] settings;
        public int[] customRings = { 1, 3, 3, 1, 1, 1, 1 };

        public SettingData currentSetting;
        public int currentSettingIndex;

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
