using System;
namespace microcosm.Config
{
    public class ConfigSave
    {
        public ConfigSave()
        {
        }

        public static void SaveXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ConfigData));
            var root = Util.ContainerDirectory + "/Documents/microcosm";

            var cfg = root + "/system/config.csm";

            FileStream fs = new FileStream(cfg.Path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            serializer.Serialize(sw, config);
            sw.Dispose();
            fs.Dispose();

        }
    }
}
