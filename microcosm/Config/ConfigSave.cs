using System;
using System.IO;
using System.Xml.Serialization;
using microcosm.Common;

namespace microcosm.Config
{
    public class ConfigSave
    {
        public ConfigSave()
        {
        }

        public static void SaveXml(ConfigData config)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ConfigData));
            var root = Util.ContainerDirectory + "/Documents/microcosm";

            var cfg = root + "/system/config.csm";

            FileStream fs = new FileStream(cfg, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            serializer.Serialize(sw, config);
            sw.Dispose();
            fs.Dispose();

        }
    }
}
