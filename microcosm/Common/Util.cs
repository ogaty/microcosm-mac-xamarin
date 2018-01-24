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

        public static Position Rotate(double x, double y, double degree)
        {
            // ホロスコープは180°から始まる
            degree += 180.0;

            var rad = (degree / 180.0) * Math.PI;
            var newX = x * Math.Cos(rad) - y * Math.Sin(rad);
            var newY = x * Math.Sin(rad) + y * Math.Cos(rad);

            return new Position(newX, newY);
        }
    }

}
