using System;
using System.IO;

namespace microcosm.Models
{
    public class UserDirTree
    {
        public UserDirTree()
        {
        }

        public static TreeViewItem CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            if (!Directory.Exists(directoryInfo.FullName))
            {
                Directory.CreateDirectory(directoryInfo.FullName);
            }

            var directoryNode = new TreeViewItem { Header = directoryInfo.Name };

            foreach (var directory in directoryInfo.GetDirectories())
            {
                // ディレクトリ
                TreeViewItem item = CreateDirectoryNode(directory);
                item.isDir = true;
                item.Tag = new DbItem
                {
                    fileName = directory.FullName,
                    isDir = true
                };
                directoryNode.Items.Add(item);
            }

            foreach (var file in directoryInfo.GetFiles())
            {
                // ファイル(２階層はサポートしない)
                if (Directory.Exists(file.FullName)) {
                    continue;
                }
                string trimName = Path.GetFileNameWithoutExtension(file.Name);
                TreeViewItem item = new TreeViewItem { Header = trimName };
                item.isDir = false;
                item.Tag = new DbItem
                {
                    fileName = file.FullName,
                    isDir = false
                };
                directoryNode.Items.Add(item);
            }

            return directoryNode;
        }

    }
}
