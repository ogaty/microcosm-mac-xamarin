using System;
using System.Collections.Generic;
using System.IO;
using Foundation;

namespace microcosm.Models
{
    /// <summary>
    /// MacだとSystem.Windows.Controls.TreeViewItemが使えないので独自拡張
    /// Tag部分に入れていた拡張をこちらに移す
    /// </summary>
    public class TreeViewItem : NSObject
    {
        // windows側のHeaderの名残、実際はfileNameと同一
        public string Header;
        public bool isDir;
        public string FullPath;
        public string fileName;
        public string trimName {
            get {
                return Path.GetFileNameWithoutExtension(fileName);
            }
        }
        // インポート拡張ファイル
        public bool isMcsm {
            get {
                return fileName.EndsWith(".mcsm", StringComparison.CurrentCulture);
            }
        }

        public List<NSObject> Items;

        public TreeViewItem(string fileName, string FullPath)
        {
            this.fileName = this.Header = fileName;
            this.FullPath = FullPath;
            this.isDir = false;
            Items = new List<Foundation.NSObject>();
        }
    }
}
