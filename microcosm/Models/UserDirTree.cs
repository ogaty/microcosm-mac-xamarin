using System;
using System.IO;
using System.Collections.Generic;
using microcosm.User;

namespace microcosm.Models
{
    /// <summary>
    /// DBのディレクトリツリー作成クラス
    /// </summary>
    public class UserDirTree
    {
        public UserDirTree()
        {
        }

        /// <summary>
        /// 再帰的にファイル一覧を取得
        /// System.Windows.Controls.TreeViewItemが無いから逆にすっきり
        /// </summary>
        /// <returns>The directory node.</returns>
        /// <param name="directoryInfo">Directory info.</param>
        public static TreeViewItem CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            Console.WriteLine(directoryInfo.FullName);
            if (!Directory.Exists(directoryInfo.FullName))
            {
                Directory.CreateDirectory(directoryInfo.FullName);
            }

            var directoryNode = new TreeViewItem(directoryInfo.Name, 
                                                 directoryInfo.FullName,
                                                 UserXml.GetUserDataFromXml(directoryInfo.FullName)
                                                );

            if (directoryInfo.GetDirectories().Length > 0 || directoryInfo.GetFiles().Length > 0) {
                directoryNode.isDir = true;
            }

            // ディレクトリ
            foreach (var directory in directoryInfo.GetDirectories())
            {
                TreeViewItem item = CreateDirectoryNode(directory);
                item.isDir = true;
                item.fileName = directory.Name;
                item.FullPath = directory.FullName;
                directoryNode.Items.Add(item);
            }

            // ファイル(２階層はサポートしない)
            foreach (var file in directoryInfo.GetFiles())
            {
                if (Directory.Exists(file.FullName)) {
                    continue;
                }
                if (!file.Name.EndsWith(".csm", StringComparison.CurrentCulture) &&
                    !file.Name.EndsWith(".mcsm", StringComparison.CurrentCulture)
                   ) {
                    continue;
                }

                TreeViewItem item = new TreeViewItem(file.Name, 
                                                     file.FullName, 
                                                     UserXml.GetUserDataFromXml(file.FullName));
                directoryNode.Items.Add(item);
            }

            return directoryNode;
        }

    }
}
