using System;
using Foundation;

namespace microcosm.Common
{
    public static class Util
    {
        [System.Runtime.InteropServices.DllImport("/System/Library/Frameworks/Foundation.framework/Foundation")]
        public static extern IntPtr NSHomeDirectory();

        public static NSString ContainerDirectory => (NSString)ObjCRuntime.Runtime.GetNSObject(NSHomeDirectory());

        public static string root { get => ContainerDirectory + "/Documents/microcosm"; }
    }
}
