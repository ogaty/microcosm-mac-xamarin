using System;
using microcosm.Config;

namespace microcosm.Common
{
    public class CommonInstance
    {
        private static CommonInstance instance = new CommonInstance();
        public ConfigData config;
        public SettingData[] settings;

        private CommonInstance()
        {
        }

        public static CommonInstance getInstance() 
        {
            return instance;
        }
    }
}
