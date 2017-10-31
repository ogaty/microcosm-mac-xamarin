using System;
using System.Collections.Generic;

namespace microcosm.Models
{
    /// <summary>
    /// 天体計算データを格納
    /// </summary>
    public class PlanetData
    {
        public int no;
        public double absolute_position;
        public double speed;
        // PlanetData[1]のaspects1 = P-P
        public List<AspectInfo> aspects0;
        public List<AspectInfo> aspects1;
        public List<AspectInfo> aspects2;
        public List<AspectInfo> aspects3;
        public List<AspectInfo> aspects4;
        public List<AspectInfo> aspects5;
        public List<AspectInfo> aspects6;

        // 感受点
        public bool sensitive;

        public PlanetData()
        {
        }
    }
}
