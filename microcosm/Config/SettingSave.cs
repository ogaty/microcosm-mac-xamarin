using System;
using System.IO;
using System.Xml.Serialization;
using microcosm.Common;

namespace microcosm.Config
{
    public class SettingSave
    {
        public SettingSave()
        {
        }

        public static void SaveXml(SettingData[] settings)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SettingXml));
            var root = Util.ContainerDirectory + "/Documents/microcosm";

            for (int i = 0; i < 10; i++)
            {
                var cfg = root + "/system/setting" + i.ToString() + ".csm";

                FileStream fs = new FileStream(cfg, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                SettingXml input = ConvertSetting(settings[i]);
                serializer.Serialize(sw, input);
                sw.Dispose();
                fs.Dispose();
            }

        }

        public static SettingXml ConvertSetting(SettingData setting)
        {
            SettingXml ret = new SettingXml();

            return ret;
        }

    }
}
