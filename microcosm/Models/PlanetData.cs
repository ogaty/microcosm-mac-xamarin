using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace microcosm.Models
{
    /// <summary>
    /// 天体計算データを格納
    /// </summary>
    //
    [DataContract]
    public class PlanetData
    {
        [DataMember]
        public int no { get; set; }
        [DataMember]
        public double absolute_position { get; set; }
        [DataMember]
        public double speed { get; set; }
        // PlanetData[1]のaspects1 = P-P
        [IgnoreDataMember]
        public List<AspectInfo> aspects0;
        [IgnoreDataMember]
        public List<AspectInfo> aspects1;
        [IgnoreDataMember]
        public List<AspectInfo> aspects2;
        [IgnoreDataMember]
        public List<AspectInfo> aspects3;
        [IgnoreDataMember]
        public List<AspectInfo> aspects4;
        [IgnoreDataMember]
        public List<AspectInfo> aspects5;
        [IgnoreDataMember]
        public List<AspectInfo> aspects6;

        // 感受点
        [DataMember]
        public bool sensitive;

        public PlanetData()
        {
        }
    }
}
