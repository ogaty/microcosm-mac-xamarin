using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace microcosm.Config
{
    /// <summary>
    /// XMLファイルからSettingを生成
    /// </summary>
    public static class SettingFromXml
    {
        /// <summary>
        /// XMLファイルからSettingを生成
        /// </summary>
        /// <returns>The setting from xml.</returns>
        /// <param name="xmlFile">Xml file.</param>
        /// <param name="no">設定No.</param>
        public static SettingData GetSettingFromXml(string xmlFile, int no)
        {
            SettingXml settingXml;
            SettingData setting;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SettingXml));
                FileStream fs = new FileStream(xmlFile, FileMode.Open);
                settingXml = (SettingXml)serializer.Deserialize(fs);
                fs.Dispose();
                setting = new SettingData(no, settingXml);
            }
            catch (IOException)
            {
                //                MessageBox.Show("設定ファイル読み込みに失敗しました。再作成します。");
                setting = new SettingData(no, null);
            }
            catch (InvalidOperationException)
            {
                setting = new SettingData(no, null);
            }


            return setting;
        }
    }
}
