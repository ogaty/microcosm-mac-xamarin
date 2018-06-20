using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using microcosm.Common;
using microcosm.Models;

namespace microcosm.Config
{
    
    /// <summary>
    /// 実際のsettingが最終的に格納されるところ
    /// 複数クラスが存在（0～9）
    /// </summary>
    public class SettingData
    {
        public const int xmlVersion = 2;
        public int version;

        public SettingXml xmlData;
        public SettingXml2 xmlData2;
        public string dispName { get; set; }

        public int bands;

        public bool[] dispCircle = new bool[] {
            true, false, false, false, false, false
        };

        // アスペクト種別の表示
        // [0] | 11, 22, 33, 44, 55, 66, 77
        // [7] | 12, 13, 14, 15, 16, 17
        // [13] | 23, 24, 25, 26, 27
        // [18] | 34, 35, 36, 37
        // [22] | 45, 46, 47
        // [25] | 56, 57
        // [27] | 67
        public List<Dictionary<AspectKind, bool>> dispAspectCategory = new List<Dictionary<AspectKind, bool>>();

        // [from, to]
        public bool[,] aspectConjunction;
        public bool[,] aspectOpposition;
        public bool[,] aspectSquare;
        public bool[,] aspectTrine;
        public bool[,] aspectSextile;
        public bool[,] aspectInconjunct;
        public bool[,] aspectSesquiquadrate;
        public bool[,] aspectSemiSextile;
        public bool[,] aspectSemiQuintile;
        public bool[,] aspectSemiSquare;
        public bool[,] aspectNovile;
        public bool[,] aspectSeptile;
        public bool[,] aspectQuintile;
        public bool[,] aspectBiQuintile;

        // [from, to]
        // アスペクトそのものを表示するか
        public bool[,] dispAspect2;
        public bool[,] dispAspect3;
        public bool[,] dispAspect4;
        public bool[,] dispAspect5;

        // オーブ
        // ソフト/ハード、1種2種150、太陽/月/その他の組み合わせ 2*3*3=18通り
        public List<Dictionary<OrbKind, double>> orbs = new List<Dictionary<OrbKind, double>>();
        private double[] orb_sun_soft_1st;
        private double[] orb_sun_soft_2nd;
        private double[] orb_sun_soft_150;
        private double[] orb_sun_hard_1st;
        private double[] orb_sun_hard_2nd;
        private double[] orb_sun_hard_150;
        private double[] orb_moon_soft_1st;
        private double[] orb_moon_soft_2nd;
        private double[] orb_moon_soft_150;
        private double[] orb_moon_hard_1st;
        private double[] orb_moon_hard_2nd;
        private double[] orb_moon_hard_150;
        private double[] orb_other_soft_1st;
        private double[] orb_other_soft_2nd;
        private double[] orb_other_soft_150;
        private double[] orb_other_hard_1st;
        private double[] orb_other_hard_2nd;
        private double[] orb_other_hard_150;

        // 天体を表示
        // [ringInex][planetIndex]
        // 円ごとなので、配列個数は7
        public List<Dictionary<int, bool>> dispPlanet = new List<Dictionary<int, bool>>();

        // 天体のアスペクトを表示
        // [ringIndex][aspectAbsolute]
        // 11-77まで28個
        public List<Dictionary<int, bool>> dispAspectPlanet = new List<Dictionary<int, bool>>();
        private bool[] aspectSun = new bool[28];
        private bool[] aspectMoon = new bool[28];
        private bool[] aspectMercury = new bool[28];
        private bool[] aspectVenus = new bool[28];
        private bool[] aspectMars = new bool[28];
        private bool[] aspectJupiter = new bool[28];
        private bool[] aspectSaturn = new bool[28];
        private bool[] aspectUranus = new bool[28];
        private bool[] aspectNeptune = new bool[28];
        private bool[] aspectPluto = new bool[28];
        private bool[] aspectDh = new bool[28];
        private bool[] aspectAsc = new bool[28];
        private bool[] aspectMc = new bool[28];
        private bool[] aspectChiron = new bool[28];
        private bool[] aspectEarth = new bool[28];
        private bool[] aspectLilith = new bool[28];
        private bool[] aspectCeres = new bool[28];
        private bool[] aspectParas = new bool[28];
        private bool[] aspectJuno = new bool[28];
        private bool[] aspectVesta = new bool[28];
        private bool[] aspectEris = new bool[28];
        private bool[] aspectSedna = new bool[28];
        private bool[] aspectHaumea = new bool[28];
        private bool[] aspectMakemake = new bool[28];
        private bool[] aspectVt = new bool[28];
        private bool[] aspectPof = new bool[28];

        string defaultAspect = "true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false";
        string defaultAspectAllfalse = "false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false";

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="no">設定番号</param>
        /// <param name="xml">xmlファイル nullable</param>
        public SettingData(int no, SettingXml xml)
        {
            Init(no, xml);
        }

        public void Init(int no, SettingXml xml)
        {

            if (xml == null)
            {
                xmlData = new SettingXml();
                this.dispName = "表示設定" + no.ToString();
            }
            else
            {
                xmlData = xml;
                this.dispName = xml.dispname;
            }

            // N-N、N-P、N-Tのアスペクトそのもの
            // category, planetかかわらず表示させない
            // dispAspect[0][2] => N-T
            // dispAspect[1][3] => P-4
            // [0][2] と [2][0]は同じ
            dispAspect2 = new bool[7, 7] {
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true }
            };
            dispAspect3 = new bool[7, 7] {
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true }
            };
            dispAspect4 = new bool[7, 7] {
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true }
            };
            dispAspect5 = new bool[7, 7] {
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true }
            };

            if (xmlData.version == 0)
            {
                Convert();
            }
            else
            {
                InitSet();
            }
        }

        /// <summary>
        /// serializeしたxmlをsettingに落とし込む
        /// wpfソースではなぜかMainWindow.csでやっていたやつ
        /// </summary>
        private void InitSet()
        {
            version = xmlData.version;

            SetDispPlanet();
            SetDispAspectPlanet();
            SetDispAspectCategory();
            SetDispAspect();
            SetOrbs();
        }

        private void Convert()
        {
            xmlData.version = 2;
            ConvertDispPlanet();
            ConvertDispAspectPlanet();
            ConvertDispAspectCategory();
            ConvertDispAspect();
            ConvertOrbs();
        }

        /// <summary>
        /// 天体表示(旧)
        /// </summary>
        private void ConvertDispPlanet()
        {
            Dictionary<int, bool> dp = new Dictionary<int, bool>();

            Dictionary<int, bool> planet1 = new Dictionary<int, bool>
            {
                { CommonData.ZODIAC_NUMBER_SUN, xmlData.dispPlanetSun11 },
                { CommonData.ZODIAC_NUMBER_MOON, xmlData.dispPlanetMoon11 },
                { CommonData.ZODIAC_NUMBER_MERCURY, xmlData.dispPlanetMercury11 },
                { CommonData.ZODIAC_NUMBER_VENUS, xmlData.dispPlanetVenus11 },
                { CommonData.ZODIAC_NUMBER_MARS, xmlData.dispPlanetMars11 },
                { CommonData.ZODIAC_NUMBER_JUPITER, xmlData.dispPlanetJupiter11 },
                { CommonData.ZODIAC_NUMBER_SATURN, xmlData.dispPlanetSaturn11 },
                { CommonData.ZODIAC_NUMBER_URANUS, xmlData.dispPlanetUranus11 },
                { CommonData.ZODIAC_NUMBER_NEPTUNE, xmlData.dispPlanetNeptune11 },
                { CommonData.ZODIAC_NUMBER_PLUTO, xmlData.dispPlanetPluto11 },
                { CommonData.ZODIAC_NUMBER_DH_TRUENODE, xmlData.dispPlanetDh11 },
                { CommonData.ZODIAC_NUMBER_ASC, xmlData.dispPlanetAsc11 },
                { CommonData.ZODIAC_NUMBER_MC, xmlData.dispPlanetMc11 },
                { CommonData.ZODIAC_NUMBER_CHIRON, xmlData.dispPlanetChiron11 },
                { CommonData.ZODIAC_NUMBER_EARTH, xmlData.dispPlanetEarth11 },
                { CommonData.ZODIAC_NUMBER_LILITH, xmlData.dispPlanetLilith11 },
                { CommonData.ZODIAC_NUMBER_CERES, false },
                { CommonData.ZODIAC_NUMBER_PALLAS, false },
                { CommonData.ZODIAC_NUMBER_JUNO, false },
                { CommonData.ZODIAC_NUMBER_VESTA, false },
                { CommonData.ZODIAC_NUMBER_ERIS, false },
                { CommonData.ZODIAC_NUMBER_SEDNA, false },
                { CommonData.ZODIAC_NUMBER_HAUMEA, false },
                { CommonData.ZODIAC_NUMBER_MAKEMAKE, false },
                { CommonData.ZODIAC_NUMBER_VT, false },
                { CommonData.ZODIAC_NUMBER_POF, false },
            };

            dispPlanet.Add(planet1);

            Dictionary<int, bool> planet2 = new Dictionary<int, bool>
            {
                { CommonData.ZODIAC_NUMBER_SUN, xmlData.dispPlanetSun22 },
                { CommonData.ZODIAC_NUMBER_MOON, xmlData.dispPlanetMoon22 },
                { CommonData.ZODIAC_NUMBER_MERCURY, xmlData.dispPlanetMercury22 },
                { CommonData.ZODIAC_NUMBER_VENUS, xmlData.dispPlanetVenus22 },
                { CommonData.ZODIAC_NUMBER_MARS, xmlData.dispPlanetMars22 },
                { CommonData.ZODIAC_NUMBER_JUPITER, xmlData.dispPlanetJupiter22 },
                { CommonData.ZODIAC_NUMBER_SATURN, xmlData.dispPlanetSaturn22 },
                { CommonData.ZODIAC_NUMBER_URANUS, xmlData.dispPlanetUranus22 },
                { CommonData.ZODIAC_NUMBER_NEPTUNE, xmlData.dispPlanetNeptune22 },
                { CommonData.ZODIAC_NUMBER_PLUTO, xmlData.dispPlanetPluto22 },
                { CommonData.ZODIAC_NUMBER_DH_TRUENODE, xmlData.dispPlanetDh22 },
                { CommonData.ZODIAC_NUMBER_ASC, xmlData.dispPlanetAsc22 },
                { CommonData.ZODIAC_NUMBER_MC, xmlData.dispPlanetMc22 },
                { CommonData.ZODIAC_NUMBER_CHIRON, xmlData.dispPlanetChiron22 },
                { CommonData.ZODIAC_NUMBER_EARTH, xmlData.dispPlanetEarth22 },
                { CommonData.ZODIAC_NUMBER_LILITH, xmlData.dispPlanetLilith22 },
                { CommonData.ZODIAC_NUMBER_CERES, false },
                { CommonData.ZODIAC_NUMBER_PALLAS, false },
                { CommonData.ZODIAC_NUMBER_JUNO, false },
                { CommonData.ZODIAC_NUMBER_VESTA, false },
                { CommonData.ZODIAC_NUMBER_ERIS, false },
                { CommonData.ZODIAC_NUMBER_SEDNA, false },
                { CommonData.ZODIAC_NUMBER_HAUMEA, false },
                { CommonData.ZODIAC_NUMBER_MAKEMAKE, false },
                { CommonData.ZODIAC_NUMBER_VT, false },
                { CommonData.ZODIAC_NUMBER_POF, false },
            };

            dispPlanet.Add(planet2);

            Dictionary<int, bool> planet3 = new Dictionary<int, bool>
            {
                { CommonData.ZODIAC_NUMBER_SUN, xmlData.dispPlanetSun33 },
                { CommonData.ZODIAC_NUMBER_MOON, xmlData.dispPlanetMoon33 },
                { CommonData.ZODIAC_NUMBER_MERCURY, xmlData.dispPlanetMercury33 },
                { CommonData.ZODIAC_NUMBER_VENUS, xmlData.dispPlanetVenus33 },
                { CommonData.ZODIAC_NUMBER_MARS, xmlData.dispPlanetMars33 },
                { CommonData.ZODIAC_NUMBER_JUPITER, xmlData.dispPlanetJupiter33 },
                { CommonData.ZODIAC_NUMBER_SATURN, xmlData.dispPlanetSaturn33 },
                { CommonData.ZODIAC_NUMBER_URANUS, xmlData.dispPlanetUranus33 },
                { CommonData.ZODIAC_NUMBER_NEPTUNE, xmlData.dispPlanetNeptune33 },
                { CommonData.ZODIAC_NUMBER_PLUTO, xmlData.dispPlanetPluto33 },
                { CommonData.ZODIAC_NUMBER_DH_TRUENODE, xmlData.dispPlanetDh33 },
                { CommonData.ZODIAC_NUMBER_ASC, xmlData.dispPlanetAsc33 },
                { CommonData.ZODIAC_NUMBER_MC, xmlData.dispPlanetMc33 },
                { CommonData.ZODIAC_NUMBER_CHIRON, xmlData.dispPlanetChiron33 },
                { CommonData.ZODIAC_NUMBER_EARTH, xmlData.dispPlanetEarth33 },
                { CommonData.ZODIAC_NUMBER_LILITH, xmlData.dispPlanetLilith33 },
                { CommonData.ZODIAC_NUMBER_CERES, false },
                { CommonData.ZODIAC_NUMBER_PALLAS, false },
                { CommonData.ZODIAC_NUMBER_JUNO, false },
                { CommonData.ZODIAC_NUMBER_VESTA, false },
                { CommonData.ZODIAC_NUMBER_ERIS, false },
                { CommonData.ZODIAC_NUMBER_SEDNA, false },
                { CommonData.ZODIAC_NUMBER_HAUMEA, false },
                { CommonData.ZODIAC_NUMBER_MAKEMAKE, false },
                { CommonData.ZODIAC_NUMBER_VT, false },
                { CommonData.ZODIAC_NUMBER_POF, false },
            };

            dispPlanet.Add(planet3);

            Dictionary<int, bool> planet4 = new Dictionary<int, bool>
            {
                { CommonData.ZODIAC_NUMBER_SUN, false },
                { CommonData.ZODIAC_NUMBER_MOON, false },
                { CommonData.ZODIAC_NUMBER_MERCURY, false },
                { CommonData.ZODIAC_NUMBER_VENUS, false },
                { CommonData.ZODIAC_NUMBER_MARS, false },
                { CommonData.ZODIAC_NUMBER_JUPITER, false },
                { CommonData.ZODIAC_NUMBER_SATURN, false },
                { CommonData.ZODIAC_NUMBER_URANUS, false },
                { CommonData.ZODIAC_NUMBER_NEPTUNE, false },
                { CommonData.ZODIAC_NUMBER_PLUTO, false },
                { CommonData.ZODIAC_NUMBER_DH_TRUENODE, false },
                { CommonData.ZODIAC_NUMBER_ASC, false },
                { CommonData.ZODIAC_NUMBER_MC, false },
                { CommonData.ZODIAC_NUMBER_CHIRON, false },
                { CommonData.ZODIAC_NUMBER_EARTH, false },
                { CommonData.ZODIAC_NUMBER_LILITH, false },
                { CommonData.ZODIAC_NUMBER_CERES, false },
                { CommonData.ZODIAC_NUMBER_PALLAS, false },
                { CommonData.ZODIAC_NUMBER_JUNO, false },
                { CommonData.ZODIAC_NUMBER_VESTA, false },
                { CommonData.ZODIAC_NUMBER_ERIS, false },
                { CommonData.ZODIAC_NUMBER_SEDNA, false },
                { CommonData.ZODIAC_NUMBER_HAUMEA, false },
                { CommonData.ZODIAC_NUMBER_MAKEMAKE, false },
                { CommonData.ZODIAC_NUMBER_VT, false },
                { CommonData.ZODIAC_NUMBER_POF, false },
            };

            dispPlanet.Add(planet4);

            Dictionary<int, bool> planet5 = new Dictionary<int, bool>
            {
                { CommonData.ZODIAC_NUMBER_SUN, false },
                { CommonData.ZODIAC_NUMBER_MOON, false },
                { CommonData.ZODIAC_NUMBER_MERCURY, false },
                { CommonData.ZODIAC_NUMBER_VENUS, false },
                { CommonData.ZODIAC_NUMBER_MARS, false },
                { CommonData.ZODIAC_NUMBER_JUPITER, false },
                { CommonData.ZODIAC_NUMBER_SATURN, false },
                { CommonData.ZODIAC_NUMBER_URANUS, false },
                { CommonData.ZODIAC_NUMBER_NEPTUNE, false },
                { CommonData.ZODIAC_NUMBER_PLUTO, false },
                { CommonData.ZODIAC_NUMBER_DH_TRUENODE, false },
                { CommonData.ZODIAC_NUMBER_ASC, false },
                { CommonData.ZODIAC_NUMBER_MC, false },
                { CommonData.ZODIAC_NUMBER_CHIRON, false },
                { CommonData.ZODIAC_NUMBER_EARTH, false },
                { CommonData.ZODIAC_NUMBER_LILITH, false },
                { CommonData.ZODIAC_NUMBER_CERES, false },
                { CommonData.ZODIAC_NUMBER_PALLAS, false },
                { CommonData.ZODIAC_NUMBER_JUNO, false },
                { CommonData.ZODIAC_NUMBER_VESTA, false },
                { CommonData.ZODIAC_NUMBER_ERIS, false },
                { CommonData.ZODIAC_NUMBER_SEDNA, false },
                { CommonData.ZODIAC_NUMBER_HAUMEA, false },
                { CommonData.ZODIAC_NUMBER_MAKEMAKE, false },
                { CommonData.ZODIAC_NUMBER_VT, false },
                { CommonData.ZODIAC_NUMBER_POF, false },
            };

            dispPlanet.Add(planet5);

            Dictionary<int, bool> planet6 = new Dictionary<int, bool>
            {
                { CommonData.ZODIAC_NUMBER_SUN, false },
                { CommonData.ZODIAC_NUMBER_MOON, false },
                { CommonData.ZODIAC_NUMBER_MERCURY, false },
                { CommonData.ZODIAC_NUMBER_VENUS, false },
                { CommonData.ZODIAC_NUMBER_MARS, false },
                { CommonData.ZODIAC_NUMBER_JUPITER, false },
                { CommonData.ZODIAC_NUMBER_SATURN, false },
                { CommonData.ZODIAC_NUMBER_URANUS, false },
                { CommonData.ZODIAC_NUMBER_NEPTUNE, false },
                { CommonData.ZODIAC_NUMBER_PLUTO, false },
                { CommonData.ZODIAC_NUMBER_DH_TRUENODE, false },
                { CommonData.ZODIAC_NUMBER_ASC, false },
                { CommonData.ZODIAC_NUMBER_MC, false },
                { CommonData.ZODIAC_NUMBER_CHIRON, false },
                { CommonData.ZODIAC_NUMBER_EARTH, false },
                { CommonData.ZODIAC_NUMBER_LILITH, false },
                { CommonData.ZODIAC_NUMBER_CERES, false },
                { CommonData.ZODIAC_NUMBER_PALLAS, false },
                { CommonData.ZODIAC_NUMBER_JUNO, false },
                { CommonData.ZODIAC_NUMBER_VESTA, false },
                { CommonData.ZODIAC_NUMBER_ERIS, false },
                { CommonData.ZODIAC_NUMBER_SEDNA, false },
                { CommonData.ZODIAC_NUMBER_HAUMEA, false },
                { CommonData.ZODIAC_NUMBER_MAKEMAKE, false },
                { CommonData.ZODIAC_NUMBER_VT, false },
                { CommonData.ZODIAC_NUMBER_POF, false },
            };

            dispPlanet.Add(planet6);

            Dictionary<int, bool> planet7 = new Dictionary<int, bool>
            {
                { CommonData.ZODIAC_NUMBER_SUN, false },
                { CommonData.ZODIAC_NUMBER_MOON, false },
                { CommonData.ZODIAC_NUMBER_MERCURY, false },
                { CommonData.ZODIAC_NUMBER_VENUS, false },
                { CommonData.ZODIAC_NUMBER_MARS, false },
                { CommonData.ZODIAC_NUMBER_JUPITER, false },
                { CommonData.ZODIAC_NUMBER_SATURN, false },
                { CommonData.ZODIAC_NUMBER_URANUS, false },
                { CommonData.ZODIAC_NUMBER_NEPTUNE, false },
                { CommonData.ZODIAC_NUMBER_PLUTO, false },
                { CommonData.ZODIAC_NUMBER_DH_TRUENODE, false },
                { CommonData.ZODIAC_NUMBER_ASC, false },
                { CommonData.ZODIAC_NUMBER_MC, false },
                { CommonData.ZODIAC_NUMBER_CHIRON, false },
                { CommonData.ZODIAC_NUMBER_EARTH, false },
                { CommonData.ZODIAC_NUMBER_LILITH, false },
                { CommonData.ZODIAC_NUMBER_CERES, false },
                { CommonData.ZODIAC_NUMBER_PALLAS, false },
                { CommonData.ZODIAC_NUMBER_JUNO, false },
                { CommonData.ZODIAC_NUMBER_VESTA, false },
                { CommonData.ZODIAC_NUMBER_ERIS, false },
                { CommonData.ZODIAC_NUMBER_SEDNA, false },
                { CommonData.ZODIAC_NUMBER_HAUMEA, false },
                { CommonData.ZODIAC_NUMBER_MAKEMAKE, false },
                { CommonData.ZODIAC_NUMBER_VT, false },
                { CommonData.ZODIAC_NUMBER_POF, false },
            };

            dispPlanet.Add(planet7);
        }

        #region oldorb
        /// <summary>
        /// オーブ設定(旧)
        /// </summary>
        private void ConvertOrbs()
        {
            double[] localorbs = new double[6];

            localorbs[0] = xmlData.orb_sun_soft_1st_0;
            localorbs[1] = xmlData.orb_sun_soft_1st_1;
            localorbs[2] = xmlData.orb_sun_soft_1st_2;
            localorbs[3] = xmlData.orb_sun_soft_1st_3;
            localorbs[4] = xmlData.orb_sun_soft_1st_4;
            localorbs[5] = xmlData.orb_sun_soft_1st_5;
            xmlData.orb_sun_soft_1st = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_sun_hard_1st_0;
            localorbs[1] = xmlData.orb_sun_hard_1st_1;
            localorbs[2] = xmlData.orb_sun_hard_1st_2;
            localorbs[3] = xmlData.orb_sun_hard_1st_3;
            localorbs[4] = xmlData.orb_sun_hard_1st_4;
            localorbs[5] = xmlData.orb_sun_hard_1st_5;
            xmlData.orb_sun_hard_1st = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_moon_soft_1st_0;
            localorbs[1] = xmlData.orb_moon_soft_1st_1;
            localorbs[2] = xmlData.orb_moon_soft_1st_2;
            localorbs[3] = xmlData.orb_moon_soft_1st_3;
            localorbs[4] = xmlData.orb_moon_soft_1st_4;
            localorbs[5] = xmlData.orb_moon_soft_1st_5;
            xmlData.orb_moon_soft_1st = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_moon_hard_1st_0;
            localorbs[1] = xmlData.orb_moon_hard_1st_1;
            localorbs[2] = xmlData.orb_moon_hard_1st_2;
            localorbs[3] = xmlData.orb_moon_hard_1st_3;
            localorbs[4] = xmlData.orb_moon_hard_1st_4;
            localorbs[5] = xmlData.orb_moon_hard_1st_5;
            xmlData.orb_moon_hard_1st = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_other_soft_1st_0;
            localorbs[1] = xmlData.orb_other_soft_1st_1;
            localorbs[2] = xmlData.orb_other_soft_1st_2;
            localorbs[3] = xmlData.orb_other_soft_1st_3;
            localorbs[4] = xmlData.orb_other_soft_1st_4;
            localorbs[5] = xmlData.orb_other_soft_1st_5;
            xmlData.orb_other_soft_1st = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_other_hard_1st_0;
            localorbs[1] = xmlData.orb_other_hard_1st_1;
            localorbs[2] = xmlData.orb_other_hard_1st_2;
            localorbs[3] = xmlData.orb_other_hard_1st_3;
            localorbs[4] = xmlData.orb_other_hard_1st_4;
            localorbs[5] = xmlData.orb_other_hard_1st_5;
            xmlData.orb_other_hard_1st = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_sun_soft_2nd_0;
            localorbs[1] = xmlData.orb_sun_soft_2nd_1;
            localorbs[2] = xmlData.orb_sun_soft_2nd_2;
            localorbs[3] = xmlData.orb_sun_soft_2nd_3;
            localorbs[4] = xmlData.orb_sun_soft_2nd_4;
            localorbs[5] = xmlData.orb_sun_soft_2nd_5;
            xmlData.orb_sun_soft_2nd = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_sun_hard_2nd_0;
            localorbs[1] = xmlData.orb_sun_hard_2nd_1;
            localorbs[2] = xmlData.orb_sun_hard_2nd_2;
            localorbs[3] = xmlData.orb_sun_hard_2nd_3;
            localorbs[4] = xmlData.orb_sun_hard_2nd_4;
            localorbs[5] = xmlData.orb_sun_hard_2nd_5;
            xmlData.orb_sun_hard_2nd = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_moon_soft_2nd_0;
            localorbs[1] = xmlData.orb_moon_soft_2nd_1;
            localorbs[2] = xmlData.orb_moon_soft_2nd_2;
            localorbs[3] = xmlData.orb_moon_soft_2nd_3;
            localorbs[4] = xmlData.orb_moon_soft_2nd_4;
            localorbs[5] = xmlData.orb_moon_soft_2nd_5;
            xmlData.orb_moon_soft_2nd = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_moon_hard_2nd_0;
            localorbs[1] = xmlData.orb_moon_hard_2nd_1;
            localorbs[2] = xmlData.orb_moon_hard_2nd_2;
            localorbs[3] = xmlData.orb_moon_hard_2nd_3;
            localorbs[4] = xmlData.orb_moon_hard_2nd_4;
            localorbs[5] = xmlData.orb_moon_hard_2nd_5;
            xmlData.orb_moon_hard_2nd = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_other_soft_2nd_0;
            localorbs[1] = xmlData.orb_other_soft_2nd_1;
            localorbs[2] = xmlData.orb_other_soft_2nd_2;
            localorbs[3] = xmlData.orb_other_soft_2nd_3;
            localorbs[4] = xmlData.orb_other_soft_2nd_4;
            localorbs[5] = xmlData.orb_other_soft_2nd_5;
            xmlData.orb_other_soft_2nd = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_other_hard_2nd_0;
            localorbs[1] = xmlData.orb_other_hard_2nd_1;
            localorbs[2] = xmlData.orb_other_hard_2nd_2;
            localorbs[3] = xmlData.orb_other_hard_2nd_3;
            localorbs[4] = xmlData.orb_other_hard_2nd_4;
            localorbs[5] = xmlData.orb_other_hard_2nd_5;
            xmlData.orb_other_hard_2nd = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_sun_soft_150_0;
            localorbs[1] = xmlData.orb_sun_soft_150_1;
            localorbs[2] = xmlData.orb_sun_soft_150_2;
            localorbs[3] = xmlData.orb_sun_soft_150_3;
            localorbs[4] = xmlData.orb_sun_soft_150_4;
            localorbs[5] = xmlData.orb_sun_soft_150_5;
            xmlData.orb_sun_soft_150 = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_sun_hard_150_0;
            localorbs[1] = xmlData.orb_sun_hard_150_1;
            localorbs[2] = xmlData.orb_sun_hard_150_2;
            localorbs[3] = xmlData.orb_sun_hard_150_3;
            localorbs[4] = xmlData.orb_sun_hard_150_4;
            localorbs[5] = xmlData.orb_sun_hard_150_5;
            xmlData.orb_sun_hard_150 = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_moon_soft_150_0;
            localorbs[1] = xmlData.orb_moon_soft_150_1;
            localorbs[2] = xmlData.orb_moon_soft_150_2;
            localorbs[3] = xmlData.orb_moon_soft_150_3;
            localorbs[4] = xmlData.orb_moon_soft_150_4;
            localorbs[5] = xmlData.orb_moon_soft_150_5;
            xmlData.orb_moon_soft_150 = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_moon_hard_150_0;
            localorbs[1] = xmlData.orb_moon_hard_150_1;
            localorbs[2] = xmlData.orb_moon_hard_150_2;
            localorbs[3] = xmlData.orb_moon_hard_150_3;
            localorbs[4] = xmlData.orb_moon_hard_150_4;
            localorbs[5] = xmlData.orb_moon_hard_150_5;
            xmlData.orb_moon_hard_150 = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_other_soft_150_0;
            localorbs[1] = xmlData.orb_other_soft_150_1;
            localorbs[2] = xmlData.orb_other_soft_150_2;
            localorbs[3] = xmlData.orb_other_soft_150_3;
            localorbs[4] = xmlData.orb_other_soft_150_4;
            localorbs[5] = xmlData.orb_other_soft_150_5;
            xmlData.orb_other_soft_150 = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_other_hard_150_0;
            localorbs[1] = xmlData.orb_other_hard_150_1;
            localorbs[2] = xmlData.orb_other_hard_150_2;
            localorbs[3] = xmlData.orb_other_hard_150_3;
            localorbs[4] = xmlData.orb_other_hard_150_4;
            localorbs[5] = xmlData.orb_other_hard_150_5;
            xmlData.orb_other_hard_150 = ConvertString(localorbs);

            Dictionary<OrbKind, double> o11 = new Dictionary<OrbKind, double>
            {
                { OrbKind.SUN_SOFT_1ST, xmlData.orb_sun_soft_1st_0 },
                { OrbKind.SUN_HARD_1ST, xmlData.orb_sun_hard_1st_0 },
                { OrbKind.SUN_SOFT_2ND, xmlData.orb_sun_soft_2nd_0},
                { OrbKind.SUN_HARD_2ND, xmlData.orb_sun_hard_2nd_0},
                { OrbKind.SUN_SOFT_150, xmlData.orb_sun_soft_150_0},
                { OrbKind.SUN_HARD_150, xmlData.orb_sun_hard_150_0},
                { OrbKind.MOON_SOFT_1ST, xmlData.orb_moon_soft_1st_0},
                { OrbKind.MOON_HARD_1ST, xmlData.orb_moon_hard_1st_0},
                { OrbKind.MOON_SOFT_2ND, xmlData.orb_moon_soft_2nd_0},
                { OrbKind.MOON_HARD_2ND, xmlData.orb_moon_hard_2nd_0},
                { OrbKind.MOON_SOFT_150, xmlData.orb_moon_soft_150_0},
                { OrbKind.MOON_HARD_150, xmlData.orb_moon_hard_150_0},
                { OrbKind.OTHER_SOFT_1ST, xmlData.orb_other_soft_1st_0},
                { OrbKind.OTHER_HARD_1ST, xmlData.orb_other_hard_1st_0},
                { OrbKind.OTHER_SOFT_2ND, xmlData.orb_other_soft_2nd_0},
                { OrbKind.OTHER_HARD_2ND, xmlData.orb_other_hard_2nd_0},
                { OrbKind.OTHER_SOFT_150, xmlData.orb_other_soft_150_0},
                { OrbKind.OTHER_HARD_150, xmlData.orb_other_hard_150_0}
            };

            orbs.Add(o11);
            // 複数リングでオーブを変えるなんて基本やらないでしょ
        }

        #endregion

        #region olddispaspect
        private void ConvertDispAspectPlanet()
        {
            bool[] bools = new bool[28];
            bools[0] = xmlData.aspectSun11;
            bools[1] = xmlData.aspectSun22;
            bools[2] = xmlData.aspectSun33;
            bools[3] = xmlData.aspectSun12;
            bools[4] = xmlData.aspectSun13;
            bools[5] = xmlData.aspectSun23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectSun = ConvertString(bools);

            bools[0] = xmlData.aspectMoon11;
            bools[1] = xmlData.aspectMoon22;
            bools[2] = xmlData.aspectMoon33;
            bools[3] = xmlData.aspectMoon12;
            bools[4] = xmlData.aspectMoon13;
            bools[5] = xmlData.aspectMoon23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectMoon = ConvertString(bools);

            bools[0] = xmlData.aspectVenus11;
            bools[1] = xmlData.aspectVenus22;
            bools[2] = xmlData.aspectVenus33;
            bools[3] = xmlData.aspectVenus12;
            bools[4] = xmlData.aspectVenus13;
            bools[5] = xmlData.aspectVenus23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectVenus = ConvertString(bools);

            bools[0] = xmlData.aspectMars11;
            bools[1] = xmlData.aspectMars22;
            bools[2] = xmlData.aspectMars33;
            bools[3] = xmlData.aspectMars12;
            bools[4] = xmlData.aspectMars13;
            bools[5] = xmlData.aspectMars23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectMars = ConvertString(bools);

            bools[0] = xmlData.aspectJupiter11;
            bools[1] = xmlData.aspectJupiter22;
            bools[2] = xmlData.aspectJupiter33;
            bools[3] = xmlData.aspectJupiter12;
            bools[4] = xmlData.aspectJupiter13;
            bools[5] = xmlData.aspectJupiter23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectJupiter = ConvertString(bools);

            bools[0] = xmlData.aspectSaturn11;
            bools[1] = xmlData.aspectSaturn22;
            bools[2] = xmlData.aspectSaturn33;
            bools[3] = xmlData.aspectSaturn12;
            bools[4] = xmlData.aspectSaturn13;
            bools[5] = xmlData.aspectSaturn23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectSaturn = ConvertString(bools);

            bools[0] = xmlData.aspectUranus11;
            bools[1] = xmlData.aspectUranus22;
            bools[2] = xmlData.aspectUranus33;
            bools[3] = xmlData.aspectUranus12;
            bools[4] = xmlData.aspectUranus13;
            bools[5] = xmlData.aspectUranus23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectUranus = ConvertString(bools);

            bools[0] = xmlData.aspectNeptune11;
            bools[1] = xmlData.aspectNeptune22;
            bools[2] = xmlData.aspectNeptune33;
            bools[3] = xmlData.aspectNeptune12;
            bools[4] = xmlData.aspectNeptune13;
            bools[5] = xmlData.aspectNeptune23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectNeptune = ConvertString(bools);

            bools[0] = xmlData.aspectPluto11;
            bools[1] = xmlData.aspectPluto22;
            bools[2] = xmlData.aspectPluto33;
            bools[3] = xmlData.aspectPluto12;
            bools[4] = xmlData.aspectPluto13;
            bools[5] = xmlData.aspectPluto23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectPluto = ConvertString(bools);

            bools[0] = xmlData.aspectDh11;
            bools[1] = xmlData.aspectDh22;
            bools[2] = xmlData.aspectDh33;
            bools[3] = xmlData.aspectDh12;
            bools[4] = xmlData.aspectDh13;
            bools[5] = xmlData.aspectDh23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectDh = ConvertString(bools);

            bools[0] = xmlData.aspectChiron11;
            bools[1] = xmlData.aspectChiron22;
            bools[2] = xmlData.aspectChiron33;
            bools[3] = xmlData.aspectChiron12;
            bools[4] = xmlData.aspectChiron13;
            bools[5] = xmlData.aspectChiron23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectChiron = ConvertString(bools);

            bools[0] = xmlData.aspectAsc11;
            bools[1] = xmlData.aspectAsc22;
            bools[2] = xmlData.aspectAsc33;
            bools[3] = xmlData.aspectAsc12;
            bools[4] = xmlData.aspectAsc13;
            bools[5] = xmlData.aspectAsc23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectAsc = ConvertString(bools);

            bools[0] = xmlData.aspectMc11;
            bools[1] = xmlData.aspectMc22;
            bools[2] = xmlData.aspectMc33;
            bools[3] = xmlData.aspectMc12;
            bools[4] = xmlData.aspectMc13;
            bools[5] = xmlData.aspectMc23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectMc = ConvertString(bools);

            bools[0] = xmlData.aspectEarth11;
            bools[1] = xmlData.aspectEarth22;
            bools[2] = xmlData.aspectEarth33;
            bools[3] = xmlData.aspectEarth12;
            bools[4] = xmlData.aspectEarth13;
            bools[5] = xmlData.aspectEarth23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectEarth = ConvertString(bools);

            bools[0] = xmlData.aspectLilith11;
            bools[1] = xmlData.aspectLilith22;
            bools[2] = xmlData.aspectLilith33;
            bools[3] = xmlData.aspectLilith12;
            bools[4] = xmlData.aspectLilith13;
            bools[5] = xmlData.aspectLilith23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectLilith = ConvertString(bools);

            for (int i = 0; i < 28; i++)
            {
                bools[i] = false;
            }
            string allFalse = ConvertString(bools);
            xmlData.aspectCeres = allFalse;
            xmlData.aspectParas = allFalse;
            xmlData.aspectJuno = allFalse;
            xmlData.aspectVesta = allFalse;
            xmlData.aspectEris = allFalse;
            xmlData.aspectSedna = allFalse;
            xmlData.aspectHaumea = allFalse;
            xmlData.aspectMakemake = allFalse;
            xmlData.aspectVt = allFalse;
            xmlData.aspectPof = allFalse;
        }

        #endregion

        private void ConvertDispAspectCategory()
        {
            Dictionary<AspectKind, bool> dac11 = new Dictionary<AspectKind, bool>();
            dac11.Add(AspectKind.CONJUNCTION, xmlData.aspectConjunction11);
            dac11.Add(AspectKind.OPPOSITION, xmlData.aspectOpposition11);
            dac11.Add(AspectKind.SQUARE, xmlData.aspectSquare11);
            dac11.Add(AspectKind.TRINE, xmlData.aspectTrine11);
            dac11.Add(AspectKind.SEXTILE, xmlData.aspectSextile11);
            dac11.Add(AspectKind.INCONJUNCT, xmlData.aspectInconjunct11);
            dac11.Add(AspectKind.SESQUIQUADRATE, xmlData.aspectSesquiquadrate11);
            dac11.Add(AspectKind.SEMISEXTILE, false);
            dac11.Add(AspectKind.SEMISQUARE, false);
            dac11.Add(AspectKind.SEMIQINTILE, false);
            dac11.Add(AspectKind.SEPTILE, false);
            dac11.Add(AspectKind.NOVILE, false);
            dac11.Add(AspectKind.QUINTILE, false);
            dac11.Add(AspectKind.BIQUINTILE, false);
            dispAspectCategory.Add(dac11);

            Dictionary<AspectKind, bool> dac22 = new Dictionary<AspectKind, bool>();
            dac22.Add(AspectKind.CONJUNCTION, xmlData.aspectConjunction22);
            dac22.Add(AspectKind.OPPOSITION, xmlData.aspectOpposition22);
            dac22.Add(AspectKind.TRINE, xmlData.aspectTrine22);
            dac22.Add(AspectKind.SQUARE, xmlData.aspectSquare22);
            dac22.Add(AspectKind.SEXTILE, xmlData.aspectSextile22);
            dac22.Add(AspectKind.INCONJUNCT, xmlData.aspectInconjunct22);
            dac22.Add(AspectKind.SESQUIQUADRATE, xmlData.aspectSesquiquadrate22);
            dispAspectCategory.Add(dac22);

            Dictionary<AspectKind, bool> dac33 = new Dictionary<AspectKind, bool>();
            dac33.Add(AspectKind.CONJUNCTION, xmlData.aspectConjunction33);
            dac33.Add(AspectKind.OPPOSITION, xmlData.aspectOpposition33);
            dac33.Add(AspectKind.TRINE, xmlData.aspectTrine33);
            dac33.Add(AspectKind.SQUARE, xmlData.aspectSquare33);
            dac33.Add(AspectKind.SEXTILE, xmlData.aspectSextile33);
            dac33.Add(AspectKind.INCONJUNCT, xmlData.aspectInconjunct33);
            dac33.Add(AspectKind.SESQUIQUADRATE, xmlData.aspectSesquiquadrate33);
            dispAspectCategory.Add(dac33);

            Dictionary<AspectKind, bool> dac12 = new Dictionary<AspectKind, bool>();
            dac12.Add(AspectKind.CONJUNCTION, xmlData.aspectConjunction12);
            dac12.Add(AspectKind.OPPOSITION, xmlData.aspectOpposition12);
            dac12.Add(AspectKind.TRINE, xmlData.aspectTrine12);
            dac12.Add(AspectKind.SQUARE, xmlData.aspectSquare12);
            dac12.Add(AspectKind.SEXTILE, xmlData.aspectSextile12);
            dac12.Add(AspectKind.INCONJUNCT, xmlData.aspectInconjunct12);
            dac12.Add(AspectKind.SESQUIQUADRATE, xmlData.aspectSesquiquadrate12);
            dispAspectCategory.Add(dac12);

            Dictionary<AspectKind, bool> dac13 = new Dictionary<AspectKind, bool>();
            dac13.Add(AspectKind.CONJUNCTION, xmlData.aspectConjunction13);
            dac13.Add(AspectKind.OPPOSITION, xmlData.aspectOpposition13);
            dac13.Add(AspectKind.TRINE, xmlData.aspectTrine13);
            dac13.Add(AspectKind.SQUARE, xmlData.aspectSquare13);
            dac13.Add(AspectKind.SEXTILE, xmlData.aspectSextile13);
            dac13.Add(AspectKind.INCONJUNCT, xmlData.aspectInconjunct13);
            dac13.Add(AspectKind.SESQUIQUADRATE, xmlData.aspectSesquiquadrate13);
            dispAspectCategory.Add(dac13);

            Dictionary<AspectKind, bool> dac23 = new Dictionary<AspectKind, bool>();
            dac23.Add(AspectKind.CONJUNCTION, xmlData.aspectConjunction23);
            dac23.Add(AspectKind.OPPOSITION, xmlData.aspectOpposition23);
            dac23.Add(AspectKind.TRINE, xmlData.aspectTrine23);
            dac23.Add(AspectKind.SQUARE, xmlData.aspectSquare23);
            dac23.Add(AspectKind.SEXTILE, xmlData.aspectSextile23);
            dac23.Add(AspectKind.INCONJUNCT, xmlData.aspectInconjunct23);
            dac23.Add(AspectKind.SESQUIQUADRATE, xmlData.aspectSesquiquadrate23);
            dispAspectCategory.Add(dac23);

            for (int i = 0; i < 28; i++)
            {
            }
        }

        private double[] ConvertDouble(string[] strings)
        {
            double[] ret = new double[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                ret[i] = double.Parse(strings[i]);
            }
            return ret;
        }

        private string ConvertString(double[] doubles)
        {
            string[] ret = new string[doubles.Length];
            for (int i = 0; i < doubles.Length; i++)
            {
                ret[i] = doubles[i].ToString();
            }
            return string.Join(",", ret);
        }

        private string ConvertString(bool[] bools)
        {
            string[] ret = new string[bools.Length];
            for (int i = 0; i < bools.Length; i++)
            {
                ret[i] = bools[i].ToString();
            }
            return string.Join(",", ret);
        }

        private bool[] ConvertBool(string[] strings)
        {
            bool[] ret = new bool[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                ret[i] = strings[i].ToLower() == "true" ? true : false;
            }
            return ret;
        }

        /// <summary>
        /// 天体表示(新)
        /// 結局力技が一番わかりやすい
        /// </summary>
        public void SetDispPlanet()
        {
            Dictionary<int, bool> dp = new Dictionary<int, bool>();

            Dictionary<int, bool> planet1 = new Dictionary<int, bool>
            {
                { CommonData.ZODIAC_NUMBER_SUN, xmlData.dispPlanetSun11 },
                { CommonData.ZODIAC_NUMBER_MOON, xmlData.dispPlanetMoon11 },
                { CommonData.ZODIAC_NUMBER_MERCURY, xmlData.dispPlanetMercury11 },
                { CommonData.ZODIAC_NUMBER_VENUS, xmlData.dispPlanetVenus11 },
                { CommonData.ZODIAC_NUMBER_MARS, xmlData.dispPlanetMars11 },
                { CommonData.ZODIAC_NUMBER_JUPITER, xmlData.dispPlanetJupiter11 },
                { CommonData.ZODIAC_NUMBER_SATURN, xmlData.dispPlanetSaturn11 },
                { CommonData.ZODIAC_NUMBER_URANUS, xmlData.dispPlanetUranus11 },
                { CommonData.ZODIAC_NUMBER_NEPTUNE, xmlData.dispPlanetNeptune11 },
                { CommonData.ZODIAC_NUMBER_PLUTO, xmlData.dispPlanetPluto11 },
                { CommonData.ZODIAC_NUMBER_DH_TRUENODE, xmlData.dispPlanetDh11 },
                { CommonData.ZODIAC_NUMBER_ASC, xmlData.dispPlanetAsc11 },
                { CommonData.ZODIAC_NUMBER_MC, xmlData.dispPlanetMc11 },
                { CommonData.ZODIAC_NUMBER_CHIRON, xmlData.dispPlanetChiron11 },
                { CommonData.ZODIAC_NUMBER_EARTH, xmlData.dispPlanetEarth11 },
                { CommonData.ZODIAC_NUMBER_LILITH, xmlData.dispPlanetLilith11 },
                { CommonData.ZODIAC_NUMBER_CERES, xmlData.dispPlanetCeres11 },
                { CommonData.ZODIAC_NUMBER_PALLAS, xmlData.dispPlanetPallas11 },
                { CommonData.ZODIAC_NUMBER_JUNO, xmlData.dispPlanetJuno11 },
                { CommonData.ZODIAC_NUMBER_VESTA, xmlData.dispPlanetVesta11 },
                { CommonData.ZODIAC_NUMBER_ERIS, xmlData.dispPlanetEris11 },
                { CommonData.ZODIAC_NUMBER_SEDNA, xmlData.dispPlanetSedna11 },
                { CommonData.ZODIAC_NUMBER_HAUMEA, xmlData.dispPlanetHaumea11 },
                { CommonData.ZODIAC_NUMBER_MAKEMAKE, xmlData.dispPlanetMakemake11 },
                { CommonData.ZODIAC_NUMBER_VT, xmlData.dispPlanetVt11 },
                { CommonData.ZODIAC_NUMBER_POF, xmlData.dispPlanetPof11 },
            };

            dispPlanet.Add(planet1);

            Dictionary<int, bool> planet2 = new Dictionary<int, bool>
            {
                { CommonData.ZODIAC_NUMBER_SUN, xmlData.dispPlanetSun22 },
                { CommonData.ZODIAC_NUMBER_MOON, xmlData.dispPlanetMoon22 },
                { CommonData.ZODIAC_NUMBER_MERCURY, xmlData.dispPlanetMercury22 },
                { CommonData.ZODIAC_NUMBER_VENUS, xmlData.dispPlanetVenus22 },
                { CommonData.ZODIAC_NUMBER_MARS, xmlData.dispPlanetMars22 },
                { CommonData.ZODIAC_NUMBER_JUPITER, xmlData.dispPlanetJupiter22 },
                { CommonData.ZODIAC_NUMBER_SATURN, xmlData.dispPlanetSaturn22 },
                { CommonData.ZODIAC_NUMBER_URANUS, xmlData.dispPlanetUranus22 },
                { CommonData.ZODIAC_NUMBER_NEPTUNE, xmlData.dispPlanetNeptune22 },
                { CommonData.ZODIAC_NUMBER_PLUTO, xmlData.dispPlanetPluto22 },
                { CommonData.ZODIAC_NUMBER_DH_TRUENODE, xmlData.dispPlanetDh22 },
                { CommonData.ZODIAC_NUMBER_ASC, xmlData.dispPlanetAsc22 },
                { CommonData.ZODIAC_NUMBER_MC, xmlData.dispPlanetMc22 },
                { CommonData.ZODIAC_NUMBER_CHIRON, xmlData.dispPlanetChiron22 },
                { CommonData.ZODIAC_NUMBER_EARTH, xmlData.dispPlanetEarth22 },
                { CommonData.ZODIAC_NUMBER_LILITH, xmlData.dispPlanetLilith22 },
                { CommonData.ZODIAC_NUMBER_CERES, xmlData.dispPlanetCeres22 },
                { CommonData.ZODIAC_NUMBER_PALLAS, xmlData.dispPlanetPallas22 },
                { CommonData.ZODIAC_NUMBER_JUNO, xmlData.dispPlanetJuno22 },
                { CommonData.ZODIAC_NUMBER_VESTA, xmlData.dispPlanetVesta22 },
                { CommonData.ZODIAC_NUMBER_ERIS, xmlData.dispPlanetEris22 },
                { CommonData.ZODIAC_NUMBER_SEDNA, xmlData.dispPlanetSedna22 },
                { CommonData.ZODIAC_NUMBER_HAUMEA, xmlData.dispPlanetHaumea22 },
                { CommonData.ZODIAC_NUMBER_MAKEMAKE, xmlData.dispPlanetMakemake22 },
                { CommonData.ZODIAC_NUMBER_VT, xmlData.dispPlanetVt22 },
                { CommonData.ZODIAC_NUMBER_POF, xmlData.dispPlanetPof22 },
            };

            dispPlanet.Add(planet2);

            Dictionary<int, bool> planet3 = new Dictionary<int, bool>
            {
                { CommonData.ZODIAC_NUMBER_SUN, xmlData.dispPlanetSun33 },
                { CommonData.ZODIAC_NUMBER_MOON, xmlData.dispPlanetMoon33 },
                { CommonData.ZODIAC_NUMBER_MERCURY, xmlData.dispPlanetMercury33 },
                { CommonData.ZODIAC_NUMBER_VENUS, xmlData.dispPlanetVenus33 },
                { CommonData.ZODIAC_NUMBER_MARS, xmlData.dispPlanetMars33 },
                { CommonData.ZODIAC_NUMBER_JUPITER, xmlData.dispPlanetJupiter33 },
                { CommonData.ZODIAC_NUMBER_SATURN, xmlData.dispPlanetSaturn33 },
                { CommonData.ZODIAC_NUMBER_URANUS, xmlData.dispPlanetUranus33 },
                { CommonData.ZODIAC_NUMBER_NEPTUNE, xmlData.dispPlanetNeptune33 },
                { CommonData.ZODIAC_NUMBER_PLUTO, xmlData.dispPlanetPluto33 },
                { CommonData.ZODIAC_NUMBER_DH_TRUENODE, xmlData.dispPlanetDh33 },
                { CommonData.ZODIAC_NUMBER_ASC, xmlData.dispPlanetAsc33 },
                { CommonData.ZODIAC_NUMBER_MC, xmlData.dispPlanetMc33 },
                { CommonData.ZODIAC_NUMBER_CHIRON, xmlData.dispPlanetChiron33 },
                { CommonData.ZODIAC_NUMBER_EARTH, xmlData.dispPlanetEarth33 },
                { CommonData.ZODIAC_NUMBER_LILITH, xmlData.dispPlanetLilith33 },
                { CommonData.ZODIAC_NUMBER_CERES, xmlData.dispPlanetCeres33 },
                { CommonData.ZODIAC_NUMBER_PALLAS, xmlData.dispPlanetPallas33 },
                { CommonData.ZODIAC_NUMBER_JUNO, xmlData.dispPlanetJuno33 },
                { CommonData.ZODIAC_NUMBER_VESTA, xmlData.dispPlanetVesta33 },
                { CommonData.ZODIAC_NUMBER_ERIS, xmlData.dispPlanetEris33 },
                { CommonData.ZODIAC_NUMBER_SEDNA, xmlData.dispPlanetSedna33 },
                { CommonData.ZODIAC_NUMBER_HAUMEA, xmlData.dispPlanetHaumea33 },
                { CommonData.ZODIAC_NUMBER_MAKEMAKE, xmlData.dispPlanetMakemake33 },
                { CommonData.ZODIAC_NUMBER_VT, xmlData.dispPlanetVt33 },
                { CommonData.ZODIAC_NUMBER_POF, xmlData.dispPlanetPof33 },
            };

            dispPlanet.Add(planet3);

            Dictionary<int, bool> planet4 = new Dictionary<int, bool>
            {
                { CommonData.ZODIAC_NUMBER_SUN, xmlData.dispPlanetSun44 },
                { CommonData.ZODIAC_NUMBER_MOON, xmlData.dispPlanetMoon44 },
                { CommonData.ZODIAC_NUMBER_MERCURY, xmlData.dispPlanetMercury44 },
                { CommonData.ZODIAC_NUMBER_VENUS, xmlData.dispPlanetVenus44 },
                { CommonData.ZODIAC_NUMBER_MARS, xmlData.dispPlanetMars44 },
                { CommonData.ZODIAC_NUMBER_JUPITER, xmlData.dispPlanetJupiter44 },
                { CommonData.ZODIAC_NUMBER_SATURN, xmlData.dispPlanetSaturn44 },
                { CommonData.ZODIAC_NUMBER_URANUS, xmlData.dispPlanetUranus44 },
                { CommonData.ZODIAC_NUMBER_NEPTUNE, xmlData.dispPlanetNeptune44 },
                { CommonData.ZODIAC_NUMBER_PLUTO, xmlData.dispPlanetPluto44 },
                { CommonData.ZODIAC_NUMBER_DH_TRUENODE, xmlData.dispPlanetDh44 },
                { CommonData.ZODIAC_NUMBER_ASC, xmlData.dispPlanetAsc44 },
                { CommonData.ZODIAC_NUMBER_MC, xmlData.dispPlanetMc44 },
                { CommonData.ZODIAC_NUMBER_CHIRON, xmlData.dispPlanetChiron44 },
                { CommonData.ZODIAC_NUMBER_EARTH, xmlData.dispPlanetEarth44 },
                { CommonData.ZODIAC_NUMBER_LILITH, xmlData.dispPlanetLilith44 },
                { CommonData.ZODIAC_NUMBER_CERES, xmlData.dispPlanetCeres44 },
                { CommonData.ZODIAC_NUMBER_PALLAS, xmlData.dispPlanetPallas44 },
                { CommonData.ZODIAC_NUMBER_JUNO, xmlData.dispPlanetJuno44 },
                { CommonData.ZODIAC_NUMBER_VESTA, xmlData.dispPlanetVesta44 },
                { CommonData.ZODIAC_NUMBER_ERIS, xmlData.dispPlanetEris44 },
                { CommonData.ZODIAC_NUMBER_SEDNA, xmlData.dispPlanetSedna44 },
                { CommonData.ZODIAC_NUMBER_HAUMEA, xmlData.dispPlanetHaumea44 },
                { CommonData.ZODIAC_NUMBER_MAKEMAKE, xmlData.dispPlanetMakemake44 },
                { CommonData.ZODIAC_NUMBER_VT, xmlData.dispPlanetVt44 },
                { CommonData.ZODIAC_NUMBER_POF, xmlData.dispPlanetPof44 },
            };

            dispPlanet.Add(planet4);

            Dictionary<int, bool> planet5 = new Dictionary<int, bool>
            {
                { CommonData.ZODIAC_NUMBER_SUN, xmlData.dispPlanetSun55 },
                { CommonData.ZODIAC_NUMBER_MOON, xmlData.dispPlanetMoon55 },
                { CommonData.ZODIAC_NUMBER_MERCURY, xmlData.dispPlanetMercury55 },
                { CommonData.ZODIAC_NUMBER_VENUS, xmlData.dispPlanetVenus55 },
                { CommonData.ZODIAC_NUMBER_MARS, xmlData.dispPlanetMars55 },
                { CommonData.ZODIAC_NUMBER_JUPITER, xmlData.dispPlanetJupiter55 },
                { CommonData.ZODIAC_NUMBER_SATURN, xmlData.dispPlanetSaturn55 },
                { CommonData.ZODIAC_NUMBER_URANUS, xmlData.dispPlanetUranus55 },
                { CommonData.ZODIAC_NUMBER_NEPTUNE, xmlData.dispPlanetNeptune55 },
                { CommonData.ZODIAC_NUMBER_PLUTO, xmlData.dispPlanetPluto55 },
                { CommonData.ZODIAC_NUMBER_DH_TRUENODE, xmlData.dispPlanetDh55 },
                { CommonData.ZODIAC_NUMBER_ASC, xmlData.dispPlanetAsc55 },
                { CommonData.ZODIAC_NUMBER_MC, xmlData.dispPlanetMc55 },
                { CommonData.ZODIAC_NUMBER_CHIRON, xmlData.dispPlanetChiron55 },
                { CommonData.ZODIAC_NUMBER_EARTH, xmlData.dispPlanetEarth55 },
                { CommonData.ZODIAC_NUMBER_LILITH, xmlData.dispPlanetLilith55 },
                { CommonData.ZODIAC_NUMBER_CERES, xmlData.dispPlanetCeres55 },
                { CommonData.ZODIAC_NUMBER_PALLAS, xmlData.dispPlanetPallas55 },
                { CommonData.ZODIAC_NUMBER_JUNO, xmlData.dispPlanetJuno55 },
                { CommonData.ZODIAC_NUMBER_VESTA, xmlData.dispPlanetVesta55 },
                { CommonData.ZODIAC_NUMBER_ERIS, xmlData.dispPlanetEris55 },
                { CommonData.ZODIAC_NUMBER_SEDNA, xmlData.dispPlanetSedna55 },
                { CommonData.ZODIAC_NUMBER_HAUMEA, xmlData.dispPlanetHaumea55 },
                { CommonData.ZODIAC_NUMBER_MAKEMAKE, xmlData.dispPlanetMakemake55 },
                { CommonData.ZODIAC_NUMBER_VT, xmlData.dispPlanetVt55 },
                { CommonData.ZODIAC_NUMBER_POF, xmlData.dispPlanetPof55 },
            };

            dispPlanet.Add(planet5);
        }


        #region neworbs
        /// <summary>
        /// オーブ設定(新)
        /// </summary>
        private void SetOrbs()
        {
            orb_sun_soft_1st = ConvertDouble(xmlData.orb_sun_soft_1st.Split(','));
            orb_sun_soft_2nd = ConvertDouble(xmlData.orb_sun_soft_2nd.Split(','));
            orb_sun_soft_150 = ConvertDouble(xmlData.orb_sun_soft_150.Split(','));
            orb_sun_hard_1st = ConvertDouble(xmlData.orb_sun_hard_1st.Split(','));
            orb_sun_hard_2nd = ConvertDouble(xmlData.orb_sun_hard_2nd.Split(','));
            orb_sun_hard_150 = ConvertDouble(xmlData.orb_sun_hard_150.Split(','));
            orb_moon_soft_1st = ConvertDouble(xmlData.orb_moon_soft_1st.Split(','));
            orb_moon_soft_2nd = ConvertDouble(xmlData.orb_moon_soft_2nd.Split(','));
            orb_moon_soft_150 = ConvertDouble(xmlData.orb_moon_soft_150.Split(','));
            orb_moon_hard_1st = ConvertDouble(xmlData.orb_moon_hard_1st.Split(','));
            orb_moon_hard_2nd = ConvertDouble(xmlData.orb_moon_hard_2nd.Split(','));
            orb_moon_hard_150 = ConvertDouble(xmlData.orb_moon_hard_150.Split(','));
            orb_other_soft_1st = ConvertDouble(xmlData.orb_other_soft_1st.Split(','));
            orb_other_soft_2nd = ConvertDouble(xmlData.orb_other_soft_2nd.Split(','));
            orb_other_soft_150 = ConvertDouble(xmlData.orb_other_soft_150.Split(','));
            orb_other_hard_1st = ConvertDouble(xmlData.orb_other_hard_1st.Split(','));
            orb_other_hard_2nd = ConvertDouble(xmlData.orb_other_hard_2nd.Split(','));
            orb_other_hard_150 = ConvertDouble(xmlData.orb_other_hard_150.Split(','));

            orbs.Add(GetOrbDictionary(0));
        }

        private Dictionary<OrbKind, double> GetOrbDictionary(int n)
        {
            Dictionary<OrbKind, double> o = new Dictionary<OrbKind, double>();
            o.Add(OrbKind.SUN_HARD_1ST, orb_sun_hard_1st[n]);
            o.Add(OrbKind.SUN_SOFT_1ST, orb_sun_soft_1st[n]);
            o.Add(OrbKind.SUN_HARD_2ND, orb_sun_hard_2nd[n]);
            o.Add(OrbKind.SUN_SOFT_2ND, orb_sun_soft_2nd[n]);
            o.Add(OrbKind.SUN_HARD_150, orb_sun_hard_150[n]);
            o.Add(OrbKind.SUN_SOFT_150, orb_sun_soft_150[n]);
            o.Add(OrbKind.MOON_HARD_1ST, orb_moon_hard_1st[n]);
            o.Add(OrbKind.MOON_SOFT_1ST, orb_moon_soft_1st[n]);
            o.Add(OrbKind.MOON_HARD_2ND, orb_moon_hard_2nd[n]);
            o.Add(OrbKind.MOON_SOFT_2ND, orb_moon_soft_2nd[n]);
            o.Add(OrbKind.MOON_HARD_150, orb_moon_hard_150[n]);
            o.Add(OrbKind.MOON_SOFT_150, orb_moon_soft_150[n]);
            o.Add(OrbKind.OTHER_HARD_1ST, orb_other_hard_1st[n]);
            o.Add(OrbKind.OTHER_SOFT_1ST, orb_other_soft_1st[n]);
            o.Add(OrbKind.OTHER_HARD_2ND, orb_other_hard_2nd[n]);
            o.Add(OrbKind.OTHER_SOFT_2ND, orb_other_soft_2nd[n]);
            o.Add(OrbKind.OTHER_HARD_150, orb_other_hard_150[n]);
            o.Add(OrbKind.OTHER_SOFT_150, orb_other_soft_150[n]);

            return o;
        }

        #endregion

        public void SetDispAspectPlanet()
        {
            for (int i = 0; i < 28; i++)
            {
                dispAspectPlanet.Add(GetDispAspectDictionary(i));
            }
        }

        /// <summary>
        /// 太陽、月がアスペクトを表示させるか
        /// </summary>
        /// <returns>The disp aspect dictionary.</returns>
        /// <param name="n">N.</param>
        private Dictionary<int, bool> GetDispAspectDictionary(int n)
        {
            Dictionary<int, bool> da = new Dictionary<int, bool>();
            xmlData.aspectSun = xmlData.aspectSun ?? defaultAspect;
            bool[] bools = ConvertBool(xmlData.aspectSun.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_SUN, bools[n]);

            xmlData.aspectMoon = xmlData.aspectMoon ?? defaultAspect;
            bools = ConvertBool(xmlData.aspectMoon.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_MOON, bools[n]);

            xmlData.aspectMercury = xmlData.aspectMercury ?? defaultAspect;
            bools = ConvertBool(xmlData.aspectMercury.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_MERCURY, bools[n]);

            xmlData.aspectVenus = xmlData.aspectVenus ?? defaultAspect;
            bools = ConvertBool(xmlData.aspectVenus.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_VENUS, bools[n]);

            xmlData.aspectMars = xmlData.aspectMars ?? defaultAspect;
            bools = ConvertBool(xmlData.aspectMars.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_MARS, bools[n]);

            xmlData.aspectJupiter = xmlData.aspectJupiter ?? defaultAspect;
            bools = ConvertBool(xmlData.aspectJupiter.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_JUPITER, bools[n]);

            xmlData.aspectSaturn = xmlData.aspectSaturn ?? defaultAspect;
            bools = ConvertBool(xmlData.aspectSaturn.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_SATURN, bools[n]);

            xmlData.aspectUranus = xmlData.aspectUranus ?? defaultAspect;
            bools = ConvertBool(xmlData.aspectUranus.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_URANUS, bools[n]);

            xmlData.aspectNeptune = xmlData.aspectNeptune ?? defaultAspect;
            bools = ConvertBool(xmlData.aspectNeptune.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_NEPTUNE, bools[n]);

            xmlData.aspectPluto = xmlData.aspectPluto ?? defaultAspect;
            bools = ConvertBool(xmlData.aspectPluto.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_PLUTO, bools[n]);

            xmlData.aspectDh = xmlData.aspectDh ?? defaultAspect;
            bools = ConvertBool(xmlData.aspectDh.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_DH_TRUENODE, bools[n]);

            xmlData.aspectAsc = xmlData.aspectAsc ?? defaultAspect;
            bools = ConvertBool(xmlData.aspectAsc.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_ASC, bools[n]);

            xmlData.aspectMc = xmlData.aspectMc ?? defaultAspect;
            bools = ConvertBool(xmlData.aspectMc.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_MC, bools[n]);

            xmlData.aspectChiron = xmlData.aspectChiron ?? defaultAspect;
            bools = ConvertBool(xmlData.aspectChiron.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_CHIRON, bools[n]);

            xmlData.aspectEarth = xmlData.aspectEarth ?? defaultAspectAllfalse;
            bools = ConvertBool(xmlData.aspectEarth.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_EARTH, bools[n]);

            xmlData.aspectLilith = xmlData.aspectLilith ?? defaultAspectAllfalse;
            bools = ConvertBool(xmlData.aspectLilith.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_LILITH, bools[n]);

            xmlData.aspectCeres = xmlData.aspectCeres ?? defaultAspectAllfalse;
            bools = ConvertBool(xmlData.aspectCeres.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_CERES, bools[n]);

            xmlData.aspectParas = xmlData.aspectParas ?? defaultAspectAllfalse;
            bools = ConvertBool(xmlData.aspectParas.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_PALLAS, bools[n]);

            xmlData.aspectJuno = xmlData.aspectJuno ?? defaultAspectAllfalse;
            bools = ConvertBool(xmlData.aspectJuno.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_JUNO, bools[n]);

            xmlData.aspectVesta = xmlData.aspectVesta ?? defaultAspectAllfalse;
            bools = ConvertBool(xmlData.aspectVesta.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_VESTA, bools[n]);

            xmlData.aspectEris = xmlData.aspectEris ?? defaultAspectAllfalse;
            bools = ConvertBool(xmlData.aspectEris.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_ERIS, bools[n]);

            xmlData.aspectSedna = xmlData.aspectSedna ?? defaultAspectAllfalse;
            bools = ConvertBool(xmlData.aspectSedna.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_SEDNA, bools[n]);

            xmlData.aspectHaumea = xmlData.aspectHaumea ?? defaultAspectAllfalse;
            bools = ConvertBool(xmlData.aspectHaumea.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_HAUMEA, bools[n]);

            xmlData.aspectMakemake = xmlData.aspectMakemake ?? defaultAspectAllfalse;
            bools = ConvertBool(xmlData.aspectMakemake.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_MAKEMAKE, bools[n]);

            xmlData.aspectVt = xmlData.aspectVt ?? defaultAspectAllfalse;
            bools = ConvertBool(xmlData.aspectVt.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_VT, bools[n]);

            xmlData.aspectPof = xmlData.aspectPof ?? defaultAspectAllfalse;
            bools = ConvertBool(xmlData.aspectPof.Split(','));
            da.Add(CommonData.ZODIAC_NUMBER_POF, bools[n]);

            return da;
        }

        private void SetDispAspectCategory()
        {
            aspectConjunction = new bool[7, 7];
            aspectOpposition = new bool[7, 7];
            aspectTrine = new bool[7, 7];
            aspectSquare = new bool[7, 7];
            aspectSextile = new bool[7, 7];
            aspectInconjunct = new bool[7, 7];
            aspectSesquiquadrate = new bool[7, 7];
            aspectSemiSquare = new bool[7, 7];
            aspectSemiSextile = new bool[7, 7];
            aspectSemiQuintile = new bool[7, 7];
            aspectNovile = new bool[7, 7];
            aspectSeptile = new bool[7, 7];
            aspectQuintile = new bool[7, 7];
            aspectBiQuintile = new bool[7, 7];

            aspectConjunction[0, 0] = xmlData.aspectConjunction11;
            aspectOpposition[0, 0] = xmlData.aspectOpposition11;
            aspectTrine[0, 0] = xmlData.aspectTrine11;
            aspectSquare[0, 0] = xmlData.aspectSquare11;
            aspectSextile[0, 0] = xmlData.aspectSextile11;
            aspectInconjunct[0, 0] = xmlData.aspectInconjunct11;
            aspectSesquiquadrate[0, 0] = xmlData.aspectSesquiquadrate11;
            aspectSemiSquare[0, 0] = xmlData.aspectSemiSquare11;
            aspectSemiSextile[0, 0] = xmlData.aspectSemiSextile11;
            aspectSemiQuintile[0, 0] = xmlData.aspectSemiQuintile11;
            aspectNovile[0, 0] = xmlData.aspectNovile11;
            aspectSeptile[0, 0] = xmlData.aspectSeptile11;
            aspectQuintile[0, 0] = xmlData.aspectQuintile11;
            aspectBiQuintile[0, 0] = xmlData.aspectBiQuintile11;

            aspectConjunction[1, 1] = xmlData.aspectConjunction22;
            aspectOpposition[1, 1] = xmlData.aspectOpposition22;
            aspectTrine[1, 1] = xmlData.aspectTrine22;
            aspectSquare[1, 1] = xmlData.aspectSquare22;
            aspectSextile[1, 1] = xmlData.aspectSextile22;
            aspectInconjunct[1, 1] = xmlData.aspectInconjunct22;
            aspectSesquiquadrate[1, 1] = xmlData.aspectSesquiquadrate22;
            aspectSemiSquare[1, 1] = xmlData.aspectSemiSquare22;
            aspectSemiSextile[1, 1] = xmlData.aspectSemiSextile22;
            aspectSemiQuintile[1, 1] = xmlData.aspectSemiQuintile22;
            aspectNovile[1, 1] = xmlData.aspectNovile22;
            aspectSeptile[1, 1] = xmlData.aspectSeptile22;
            aspectQuintile[1, 1] = xmlData.aspectQuintile22;
            aspectBiQuintile[1, 1] = xmlData.aspectBiQuintile22;

            aspectConjunction[2, 2] = xmlData.aspectConjunction33;
            aspectOpposition[2, 2] = xmlData.aspectOpposition33;
            aspectTrine[2, 2] = xmlData.aspectTrine33;
            aspectSquare[2, 2] = xmlData.aspectSquare33;
            aspectSextile[2, 2] = xmlData.aspectSextile33;
            aspectInconjunct[2, 2] = xmlData.aspectInconjunct33;
            aspectSesquiquadrate[2, 2] = xmlData.aspectSesquiquadrate33;
            aspectSemiSquare[2, 2] = xmlData.aspectSemiSquare33;
            aspectSemiSextile[2, 2] = xmlData.aspectSemiSextile33;
            aspectSemiQuintile[2, 2] = xmlData.aspectSemiQuintile33;
            aspectNovile[2, 2] = xmlData.aspectNovile33;
            aspectSeptile[2, 2] = xmlData.aspectSeptile33;
            aspectQuintile[2, 2] = xmlData.aspectQuintile33;
            aspectBiQuintile[2, 2] = xmlData.aspectBiQuintile33;

            aspectConjunction[0, 1] = xmlData.aspectConjunction12;
            aspectOpposition[0, 1] = xmlData.aspectOpposition12;
            aspectTrine[0, 1] = xmlData.aspectTrine12;
            aspectSquare[0, 1] = xmlData.aspectSquare12;
            aspectSextile[0, 1] = xmlData.aspectSextile12;
            aspectInconjunct[0, 1] = xmlData.aspectInconjunct12;
            aspectSesquiquadrate[0, 1] = xmlData.aspectSesquiquadrate12;
            aspectSemiSquare[0, 1] = xmlData.aspectSemiSquare12;
            aspectSemiSextile[0, 1] = xmlData.aspectSemiSextile12;
            aspectSemiQuintile[0, 1] = xmlData.aspectSemiQuintile12;
            aspectNovile[0, 1] = xmlData.aspectNovile12;
            aspectSeptile[0, 1] = xmlData.aspectSeptile12;
            aspectQuintile[0, 1] = xmlData.aspectQuintile12;
            aspectBiQuintile[0, 1] = xmlData.aspectBiQuintile12;

            aspectConjunction[0, 2] = xmlData.aspectConjunction13;
            aspectOpposition[0, 2] = xmlData.aspectOpposition13;
            aspectTrine[0, 2] = xmlData.aspectTrine13;
            aspectSquare[0, 2] = xmlData.aspectSquare13;
            aspectSextile[0, 2] = xmlData.aspectSextile13;
            aspectInconjunct[0, 2] = xmlData.aspectInconjunct13;
            aspectSesquiquadrate[0, 2] = xmlData.aspectSesquiquadrate13;
            aspectSemiSquare[0, 2] = xmlData.aspectSemiSquare13;
            aspectSemiSextile[0, 2] = xmlData.aspectSemiSextile13;
            aspectSemiQuintile[0, 2] = xmlData.aspectSemiQuintile13;
            aspectNovile[0, 2] = xmlData.aspectNovile13;
            aspectSeptile[0, 2] = xmlData.aspectSeptile13;
            aspectQuintile[0, 2] = xmlData.aspectQuintile13;
            aspectBiQuintile[0, 2] = xmlData.aspectBiQuintile13;

            aspectConjunction[1, 2] = xmlData.aspectConjunction23;
            aspectOpposition[1, 2] = xmlData.aspectOpposition23;
            aspectTrine[1, 2] = xmlData.aspectTrine23;
            aspectSquare[1, 2] = xmlData.aspectSquare23;
            aspectSextile[1, 2] = xmlData.aspectSextile23;
            aspectInconjunct[1, 2] = xmlData.aspectInconjunct23;
            aspectSesquiquadrate[1, 2] = xmlData.aspectSesquiquadrate23;
            aspectSemiSquare[1, 2] = xmlData.aspectSemiSquare23;
            aspectSemiSextile[1, 2] = xmlData.aspectSemiSextile23;
            aspectSemiQuintile[1, 2] = xmlData.aspectSemiQuintile23;
            aspectNovile[1, 2] = xmlData.aspectNovile23;
            aspectSeptile[1, 2] = xmlData.aspectSeptile23;
            aspectQuintile[1, 2] = xmlData.aspectQuintile23;
            aspectBiQuintile[1, 2] = xmlData.aspectBiQuintile23;

            aspectConjunction[3, 3] = xmlData.aspectConjunction44;
            aspectOpposition[3, 3] = xmlData.aspectOpposition44;
            aspectTrine[3, 3] = xmlData.aspectTrine44;
            aspectSquare[3, 3] = xmlData.aspectSquare44;
            aspectSextile[3, 3] = xmlData.aspectSextile44;
            aspectInconjunct[3, 3] = xmlData.aspectInconjunct44;
            aspectSesquiquadrate[3, 3] = xmlData.aspectSesquiquadrate44;
            aspectSemiSquare[3, 3] = xmlData.aspectSemiSquare44;
            aspectSemiSextile[3, 3] = xmlData.aspectSemiSextile44;
            aspectSemiQuintile[3, 3] = xmlData.aspectSemiQuintile44;
            aspectNovile[3, 3] = xmlData.aspectNovile44;
            aspectSeptile[3, 3] = xmlData.aspectSeptile44;
            aspectQuintile[3, 3] = xmlData.aspectQuintile44;
            aspectBiQuintile[3, 3] = xmlData.aspectBiQuintile44;

            aspectConjunction[0, 3] = xmlData.aspectConjunction14;
            aspectOpposition[0, 3] = xmlData.aspectOpposition14;
            aspectTrine[0, 3] = xmlData.aspectTrine14;
            aspectSquare[0, 3] = xmlData.aspectSquare14;
            aspectSextile[0, 3] = xmlData.aspectSextile14;
            aspectInconjunct[0, 3] = xmlData.aspectInconjunct14;
            aspectSesquiquadrate[0, 3] = xmlData.aspectSesquiquadrate14;
            aspectSemiSquare[0, 3] = xmlData.aspectSemiSquare14;
            aspectSemiSextile[0, 3] = xmlData.aspectSemiSextile14;
            aspectSemiQuintile[0, 3] = xmlData.aspectSemiQuintile14;
            aspectNovile[0, 3] = xmlData.aspectNovile14;
            aspectSeptile[0, 3] = xmlData.aspectSeptile14;
            aspectQuintile[0, 3] = xmlData.aspectQuintile14;
            aspectBiQuintile[0, 3] = xmlData.aspectBiQuintile14;

            aspectConjunction[1, 3] = xmlData.aspectConjunction24;
            aspectOpposition[1, 3] = xmlData.aspectOpposition24;
            aspectTrine[1, 3] = xmlData.aspectTrine24;
            aspectSquare[1, 3] = xmlData.aspectSquare24;
            aspectSextile[1, 3] = xmlData.aspectSextile24;
            aspectInconjunct[1, 3] = xmlData.aspectInconjunct24;
            aspectSesquiquadrate[1, 3] = xmlData.aspectSesquiquadrate24;
            aspectSemiSquare[1, 3] = xmlData.aspectSemiSquare24;
            aspectSemiSextile[1, 3] = xmlData.aspectSemiSextile24;
            aspectSemiQuintile[1, 3] = xmlData.aspectSemiQuintile24;
            aspectNovile[1, 3] = xmlData.aspectNovile24;
            aspectSeptile[1, 3] = xmlData.aspectSeptile24;
            aspectQuintile[1, 3] = xmlData.aspectQuintile24;
            aspectBiQuintile[1, 3] = xmlData.aspectBiQuintile24;

            aspectConjunction[2, 3] = xmlData.aspectConjunction34;
            aspectOpposition[2, 3] = xmlData.aspectOpposition34;
            aspectTrine[2, 3] = xmlData.aspectTrine34;
            aspectSquare[2, 3] = xmlData.aspectSquare34;
            aspectSextile[2, 3] = xmlData.aspectSextile34;
            aspectInconjunct[2, 3] = xmlData.aspectInconjunct34;
            aspectSesquiquadrate[2, 3] = xmlData.aspectSesquiquadrate34;
            aspectSemiSquare[2, 3] = xmlData.aspectSemiSquare34;
            aspectSemiSextile[2, 3] = xmlData.aspectSemiSextile34;
            aspectSemiQuintile[2, 3] = xmlData.aspectSemiQuintile34;
            aspectNovile[2, 3] = xmlData.aspectNovile34;
            aspectSeptile[2, 3] = xmlData.aspectSeptile34;
            aspectQuintile[2, 3] = xmlData.aspectQuintile34;
            aspectBiQuintile[2, 3] = xmlData.aspectBiQuintile34;

            aspectConjunction[4, 4] = xmlData.aspectConjunction55;
            aspectOpposition[4, 4] = xmlData.aspectOpposition55;
            aspectTrine[4, 4] = xmlData.aspectTrine55;
            aspectSquare[4, 4] = xmlData.aspectSquare55;
            aspectSextile[4, 4] = xmlData.aspectSextile55;
            aspectInconjunct[4, 4] = xmlData.aspectInconjunct55;
            aspectSesquiquadrate[4, 4] = xmlData.aspectSesquiquadrate55;
            aspectSemiSquare[4, 4] = xmlData.aspectSemiSquare55;
            aspectSemiSextile[4, 4] = xmlData.aspectSemiSextile55;
            aspectSemiQuintile[4, 4] = xmlData.aspectSemiQuintile55;
            aspectNovile[4, 4] = xmlData.aspectNovile55;
            aspectSeptile[4, 4] = xmlData.aspectSeptile55;
            aspectQuintile[4, 4] = xmlData.aspectQuintile55;
            aspectBiQuintile[4, 4] = xmlData.aspectBiQuintile55;

            aspectConjunction[0, 4] = xmlData.aspectConjunction15;
            aspectOpposition[0, 4] = xmlData.aspectOpposition15;
            aspectTrine[0, 4] = xmlData.aspectTrine15;
            aspectSquare[0, 4] = xmlData.aspectSquare15;
            aspectSextile[0, 4] = xmlData.aspectSextile15;
            aspectInconjunct[0, 4] = xmlData.aspectInconjunct15;
            aspectSesquiquadrate[0, 4] = xmlData.aspectSesquiquadrate15;
            aspectSemiSquare[0, 4] = xmlData.aspectSemiSquare15;
            aspectSemiSextile[0, 4] = xmlData.aspectSemiSextile15;
            aspectSemiQuintile[0, 4] = xmlData.aspectSemiQuintile15;
            aspectNovile[0, 4] = xmlData.aspectNovile15;
            aspectSeptile[0, 4] = xmlData.aspectSeptile15;
            aspectQuintile[0, 4] = xmlData.aspectQuintile15;
            aspectBiQuintile[0, 4] = xmlData.aspectBiQuintile15;

            aspectConjunction[1, 4] = xmlData.aspectConjunction25;
            aspectOpposition[1, 4] = xmlData.aspectOpposition25;
            aspectTrine[1, 4] = xmlData.aspectTrine25;
            aspectSquare[1, 4] = xmlData.aspectSquare25;
            aspectSextile[1, 4] = xmlData.aspectSextile25;
            aspectInconjunct[1, 4] = xmlData.aspectInconjunct25;
            aspectSesquiquadrate[1, 4] = xmlData.aspectSesquiquadrate25;
            aspectSemiSquare[1, 4] = xmlData.aspectSemiSquare25;
            aspectSemiSextile[1, 4] = xmlData.aspectSemiSextile25;
            aspectSemiQuintile[1, 4] = xmlData.aspectSemiQuintile25;
            aspectNovile[1, 4] = xmlData.aspectNovile25;
            aspectSeptile[1, 4] = xmlData.aspectSeptile25;
            aspectQuintile[1, 4] = xmlData.aspectQuintile25;
            aspectBiQuintile[1, 4] = xmlData.aspectBiQuintile25;

            aspectConjunction[2, 4] = xmlData.aspectConjunction35;
            aspectOpposition[2, 4] = xmlData.aspectOpposition35;
            aspectTrine[2, 4] = xmlData.aspectTrine35;
            aspectSquare[2, 4] = xmlData.aspectSquare35;
            aspectSextile[2, 4] = xmlData.aspectSextile35;
            aspectInconjunct[2, 4] = xmlData.aspectInconjunct35;
            aspectSesquiquadrate[2, 4] = xmlData.aspectSesquiquadrate35;
            aspectSemiSquare[2, 4] = xmlData.aspectSemiSquare35;
            aspectSemiSextile[2, 4] = xmlData.aspectSemiSextile35;
            aspectSemiQuintile[2, 4] = xmlData.aspectSemiQuintile35;
            aspectNovile[2, 4] = xmlData.aspectNovile35;
            aspectSeptile[2, 4] = xmlData.aspectSeptile35;
            aspectQuintile[2, 4] = xmlData.aspectQuintile35;
            aspectBiQuintile[2, 4] = xmlData.aspectBiQuintile35;

            aspectConjunction[3, 4] = xmlData.aspectConjunction45;
            aspectOpposition[3, 4] = xmlData.aspectOpposition45;
            aspectTrine[3, 4] = xmlData.aspectTrine45;
            aspectSquare[3, 4] = xmlData.aspectSquare45;
            aspectSextile[3, 4] = xmlData.aspectSextile45;
            aspectInconjunct[3, 4] = xmlData.aspectInconjunct45;
            aspectSesquiquadrate[3, 4] = xmlData.aspectSesquiquadrate45;
            aspectSemiSquare[3, 4] = xmlData.aspectSemiSquare45;
            aspectSemiSextile[3, 4] = xmlData.aspectSemiSextile45;
            aspectSemiQuintile[3, 4] = xmlData.aspectSemiQuintile45;
            aspectNovile[3, 4] = xmlData.aspectNovile45;
            aspectSeptile[3, 4] = xmlData.aspectSeptile45;
            aspectQuintile[3, 4] = xmlData.aspectQuintile45;
            aspectBiQuintile[3, 4] = xmlData.aspectBiQuintile45;

            /*
            SetDefaultAspectCategory();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (j >= i)
                    {
                        dispAspectCategory.Add(GetDispAspectCategoryDictionary(i, j));
                    }
                }
            }
            */
        }

        /// <summary>
        /// アスペクトそのものを表示
        /// </summary>
        private void SetDispAspect()
        {
            dispAspect2[0, 0] = xmlData.dispAspect211;
            dispAspect2[1, 1] = xmlData.dispAspect222;
            dispAspect2[2, 2] = xmlData.dispAspect233;
            dispAspect2[0, 1] = xmlData.dispAspect212;
            dispAspect2[0, 2] = xmlData.dispAspect213;
            dispAspect2[1, 2] = xmlData.dispAspect223;
            dispAspect2[0, 3] = xmlData.dispAspect214;
            dispAspect2[1, 3] = xmlData.dispAspect224;
            dispAspect2[2, 3] = xmlData.dispAspect234;
            dispAspect2[3, 3] = xmlData.dispAspect244;
            dispAspect2[0, 4] = xmlData.dispAspect215;
            dispAspect2[1, 4] = xmlData.dispAspect225;
            dispAspect2[2, 4] = xmlData.dispAspect235;
            dispAspect2[3, 4] = xmlData.dispAspect245;
            dispAspect2[4, 4] = xmlData.dispAspect255;

            dispAspect3[0, 0] = xmlData.dispAspect311;
            dispAspect3[1, 1] = xmlData.dispAspect322;
            dispAspect3[2, 2] = xmlData.dispAspect333;
            dispAspect3[0, 1] = xmlData.dispAspect312;
            dispAspect3[0, 2] = xmlData.dispAspect313;
            dispAspect3[1, 2] = xmlData.dispAspect323;
            dispAspect3[0, 3] = xmlData.dispAspect314;
            dispAspect3[1, 3] = xmlData.dispAspect324;
            dispAspect3[2, 3] = xmlData.dispAspect334;
            dispAspect3[3, 3] = xmlData.dispAspect344;
            dispAspect3[0, 4] = xmlData.dispAspect315;
            dispAspect3[1, 4] = xmlData.dispAspect325;
            dispAspect3[2, 4] = xmlData.dispAspect335;
            dispAspect3[3, 4] = xmlData.dispAspect345;
            dispAspect3[4, 4] = xmlData.dispAspect355;

            dispAspect4[0, 0] = xmlData.dispAspect411;
            dispAspect4[1, 1] = xmlData.dispAspect422;
            dispAspect4[2, 2] = xmlData.dispAspect433;
            dispAspect4[0, 1] = xmlData.dispAspect412;
            dispAspect4[0, 2] = xmlData.dispAspect413;
            dispAspect4[1, 2] = xmlData.dispAspect423;
            dispAspect4[0, 3] = xmlData.dispAspect414;
            dispAspect4[1, 3] = xmlData.dispAspect424;
            dispAspect4[2, 3] = xmlData.dispAspect434;
            dispAspect4[3, 3] = xmlData.dispAspect444;
            dispAspect4[0, 4] = xmlData.dispAspect415;
            dispAspect4[1, 4] = xmlData.dispAspect425;
            dispAspect4[2, 4] = xmlData.dispAspect435;
            dispAspect4[3, 4] = xmlData.dispAspect445;
            dispAspect4[4, 4] = xmlData.dispAspect455;

            dispAspect5[0, 0] = xmlData.dispAspect511;
            dispAspect5[1, 1] = xmlData.dispAspect522;
            dispAspect5[2, 2] = xmlData.dispAspect533;
            dispAspect5[0, 1] = xmlData.dispAspect512;
            dispAspect5[0, 2] = xmlData.dispAspect513;
            dispAspect5[1, 2] = xmlData.dispAspect523;
            dispAspect5[0, 3] = xmlData.dispAspect514;
            dispAspect5[1, 3] = xmlData.dispAspect524;
            dispAspect5[2, 3] = xmlData.dispAspect534;
            dispAspect5[3, 3] = xmlData.dispAspect544;
            dispAspect5[0, 4] = xmlData.dispAspect515;
            dispAspect5[1, 4] = xmlData.dispAspect525;
            dispAspect5[2, 4] = xmlData.dispAspect535;
            dispAspect5[3, 4] = xmlData.dispAspect545;
            dispAspect5[4, 4] = xmlData.dispAspect555;

        }

        private vodi ConvertDispAspect()
        {
            
        }

        private void SetDefaultAspectCategory()
        {
            // 11 22 33 12 13 23 44 55 66 77 14 15 16 17 24 25 26 27 34 35 36 37 45 46 47 56 57 67
            // Enumで見よう
            if (xmlData.aspectConjunction == null)
            {
                xmlData.aspectConjunction = GetDefaultAspectCategory();
            }
            if (xmlData.aspectOpposition == null)
            {
                xmlData.aspectOpposition = GetDefaultAspectCategory();
            }
            if (xmlData.aspectTrine == null)
            {
                xmlData.aspectTrine = GetDefaultAspectCategory();
            }
            if (xmlData.aspectSquare == null)
            {
                xmlData.aspectSquare = GetDefaultAspectCategory();
            }
            if (xmlData.aspectSextile == null)
            {
                xmlData.aspectSextile = GetDefaultAspectCategory();
            }
            if (xmlData.aspectInconjunct == null)
            {
                xmlData.aspectInconjunct = GetDefaultAspectCategory();
            }
            if (xmlData.aspectSesquiquadrate == null)
            {
                xmlData.aspectSesquiquadrate = GetDefaultAspectCategory();
            }
            if (xmlData.aspectSemiSquare == null)
            {
                xmlData.aspectSemiSquare = GetDefaultAspectCategory();
            }
            if (xmlData.aspectSemiSextile == null)
            {
                xmlData.aspectSemiSextile = GetDefaultAspectCategory();
            }
            if (xmlData.aspectSemiQuintile == null)
            {
                xmlData.aspectSemiQuintile = GetDefaultAspectCategory();
            }
            if (xmlData.aspectNovile == null)
            {
                xmlData.aspectNovile = GetDefaultAspectCategory();
            }
            if (xmlData.aspectSeptile == null)
            {
                xmlData.aspectSeptile = GetDefaultAspectCategory();
            }
            if (xmlData.aspectQuintile == null)
            {
                xmlData.aspectQuintile = GetDefaultAspectCategory();
            }
            if (xmlData.aspectBiQuintile == null)
            {
                xmlData.aspectBiQuintile = GetDefaultAspectCategory();
            }
        }

        /// <summary>
        /// 新バージョン用aspectCategory設定
        /// </summary>
        /// <returns>The disp aspect category dictionary.</returns>
        /// <param name="n">From</param>
        /// <param name="m">To</param>
        private Dictionary<AspectKind, bool> GetDispAspectCategoryDictionary(int n, int m)
        {
            bool[] conjunction = ConvertBool(xmlData.aspectConjunction.Split(','));
            bool[] opposition = ConvertBool(xmlData.aspectOpposition.Split(','));
            bool[] trine = ConvertBool(xmlData.aspectTrine.Split(','));
            bool[] square = ConvertBool(xmlData.aspectSquare.Split(','));
            bool[] sextile = ConvertBool(xmlData.aspectSextile.Split(','));
            bool[] inconjunct = ConvertBool(xmlData.aspectInconjunct.Split(','));
            bool[] sesquiquadrate = ConvertBool(xmlData.aspectSesquiquadrate.Split(','));
            bool[] semisquare = ConvertBool(xmlData.aspectSemiSquare.Split(','));
            bool[] semisextile = ConvertBool(xmlData.aspectSemiSextile.Split(','));
            bool[] semiquintile = ConvertBool(xmlData.aspectSemiQuintile.Split(','));
            bool[] novile = ConvertBool(xmlData.aspectNovile.Split(','));
            bool[] septile = ConvertBool(xmlData.aspectSeptile.Split(','));
            bool[] quintile = ConvertBool(xmlData.aspectQuintile.Split(','));
            bool[] biquintile = ConvertBool(xmlData.aspectBiQuintile.Split(','));

            aspectConjunction = new bool[7, 7];
            aspectOpposition = new bool[7, 7];
            aspectTrine = new bool[7, 7];
            aspectSquare = new bool[7, 7];
            aspectSextile = new bool[7, 7];
            aspectInconjunct = new bool[7, 7];
            aspectSesquiquadrate = new bool[7, 7];
            aspectSemiSquare = new bool[7, 7];
            aspectSemiSextile = new bool[7, 7];
            aspectSemiQuintile = new bool[7, 7];
            aspectNovile = new bool[7, 7];
            aspectSeptile = new bool[7, 7];
            aspectQuintile = new bool[7, 7];
            aspectBiQuintile = new bool[7, 7];
            int count = 0;
            aspectConjunction[0, 0] = conjunction[count];
            aspectOpposition[0, 0] = opposition[count];
            aspectTrine[0, 0] = trine[count];
            aspectSquare[0, 0] = square[count];
            aspectSextile[0, 0] = sextile[count];
            aspectInconjunct[0, 0] = inconjunct[count];
            aspectSesquiquadrate[0, 0] = sesquiquadrate[count];
            aspectSemiSquare[0, 0] = semisquare[count];
            aspectSemiSextile[0, 0] = semisextile[count];
            aspectSemiQuintile[0, 0] = semiquintile[count];
            aspectNovile[0, 0] = novile[count];
            aspectSeptile[0, 0] = septile[count];
            aspectQuintile[0, 0] = quintile[count];
            aspectBiQuintile[0, 0] = biquintile[count];
            count++;
            aspectConjunction[1, 1] = conjunction[count];
            aspectOpposition[1, 1] = opposition[count];
            aspectTrine[1, 1] = trine[count];
            aspectSquare[1, 1] = square[count];
            aspectSextile[1, 1] = sextile[count];
            aspectInconjunct[1, 1] = inconjunct[count];
            aspectSesquiquadrate[1, 1] = sesquiquadrate[count];
            aspectSemiSquare[1, 1] = semisquare[count];
            aspectSemiSextile[1, 1] = semisextile[count];
            aspectSemiQuintile[1, 1] = semiquintile[count];
            aspectNovile[1, 1] = novile[count];
            aspectSeptile[1, 1] = septile[count];
            aspectQuintile[1, 1] = quintile[count];
            aspectBiQuintile[1, 1] = biquintile[count];
            count++;
            aspectConjunction[2, 2] = conjunction[count];
            aspectOpposition[2, 2] = opposition[count];
            aspectTrine[2, 2] = trine[count];
            aspectSquare[2, 2] = square[count];
            aspectSextile[2, 2] = sextile[count];
            aspectInconjunct[2, 2] = inconjunct[count];
            aspectSesquiquadrate[2, 2] = sesquiquadrate[count];
            aspectSemiSquare[2, 2] = semisquare[count];
            aspectSemiSextile[2, 2] = semisextile[count];
            aspectSemiQuintile[2, 2] = semiquintile[count];
            aspectNovile[2, 2] = novile[count];
            aspectSeptile[2, 2] = septile[count];
            aspectQuintile[2, 2] = quintile[count];
            aspectBiQuintile[2, 2] = biquintile[count];
            count++;
            aspectConjunction[0, 1] = conjunction[count];
            aspectOpposition[0, 1] = opposition[count];
            aspectTrine[0, 1] = trine[count];
            aspectSquare[0, 1] = square[count];
            aspectSextile[0, 1] = sextile[count];
            aspectInconjunct[0, 1] = inconjunct[count];
            aspectSesquiquadrate[0, 1] = sesquiquadrate[count];
            aspectSemiSquare[0, 1] = semisquare[count];
            aspectSemiSextile[0, 1] = semisextile[count];
            aspectSemiQuintile[0, 1] = semiquintile[count];
            aspectNovile[0, 1] = novile[count];
            aspectSeptile[0, 1] = septile[count];
            aspectQuintile[0, 1] = quintile[count];
            aspectBiQuintile[0, 1] = biquintile[count];
            count++;
            aspectConjunction[0, 2] = conjunction[count];
            aspectOpposition[0, 2] = opposition[count];
            aspectTrine[0, 2] = trine[count];
            aspectSquare[0, 2] = square[count];
            aspectSextile[0, 2] = sextile[count];
            aspectInconjunct[0, 2] = inconjunct[count];
            aspectSesquiquadrate[0, 2] = sesquiquadrate[count];
            aspectSemiSquare[0, 2] = semisquare[count];
            aspectSemiSextile[0, 2] = semisextile[count];
            aspectSemiQuintile[0, 2] = semiquintile[count];
            aspectNovile[0, 2] = novile[count];
            aspectSeptile[0, 2] = septile[count];
            aspectQuintile[0, 2] = quintile[count];
            aspectBiQuintile[0, 2] = biquintile[count];
            count++;
            aspectConjunction[1, 2] = conjunction[count];
            aspectOpposition[1, 2] = opposition[count];
            aspectTrine[1, 2] = trine[count];
            aspectSquare[1, 2] = square[count];
            aspectSextile[1, 2] = sextile[count];
            aspectInconjunct[1, 2] = inconjunct[count];
            aspectSesquiquadrate[1, 2] = sesquiquadrate[count];
            aspectSemiSquare[1, 2] = semisquare[count];
            aspectSemiSextile[1, 2] = semisextile[count];
            aspectSemiQuintile[1, 2] = semiquintile[count];
            aspectNovile[1, 2] = novile[count];
            aspectSeptile[1, 2] = septile[count];
            aspectQuintile[1, 2] = quintile[count];
            aspectBiQuintile[1, 2] = biquintile[count];
            count++;
            aspectConjunction[3, 3] = conjunction[count];
            aspectOpposition[3, 3] = opposition[count];
            aspectTrine[3, 3] = trine[count];
            aspectSquare[3, 3] = square[count];
            aspectSextile[3, 3] = sextile[count];
            aspectInconjunct[3, 3] = inconjunct[count];
            aspectSesquiquadrate[3, 3] = sesquiquadrate[count];
            aspectSemiSquare[3, 3] = semisquare[count];
            aspectSemiSextile[3, 3] = semisextile[count];
            aspectSemiQuintile[3, 3] = semiquintile[count];
            aspectNovile[3, 3] = novile[count];
            aspectSeptile[3, 3] = septile[count];
            aspectQuintile[3, 3] = quintile[count];
            aspectBiQuintile[3, 3] = biquintile[count];
            count++;
            aspectConjunction[4, 4] = conjunction[count];
            aspectOpposition[4, 4] = opposition[count];
            aspectTrine[4, 4] = trine[count];
            aspectSquare[4, 4] = square[count];
            aspectSextile[4, 4] = sextile[count];
            aspectInconjunct[4, 4] = inconjunct[count];
            aspectSesquiquadrate[4, 4] = sesquiquadrate[count];
            aspectSemiSquare[4, 4] = semisquare[count];
            aspectSemiSextile[4, 4] = semisextile[count];
            aspectSemiQuintile[4, 4] = semiquintile[count];
            aspectNovile[4, 4] = novile[count];
            aspectSeptile[4, 4] = septile[count];
            aspectQuintile[4, 4] = quintile[count];
            aspectBiQuintile[4, 4] = biquintile[count];
            count++;
            aspectConjunction[5, 5] = conjunction[count];
            aspectOpposition[5, 5] = opposition[count];
            aspectTrine[5, 5] = trine[count];
            aspectSquare[5, 5] = square[count];
            aspectSextile[5, 5] = sextile[count];
            aspectInconjunct[5, 5] = inconjunct[count];
            aspectSesquiquadrate[5, 5] = sesquiquadrate[count];
            aspectSemiSquare[5, 5] = semisquare[count];
            aspectSemiSextile[5, 5] = semisextile[count];
            aspectSemiQuintile[5, 5] = semiquintile[count];
            aspectNovile[5, 5] = novile[count];
            aspectSeptile[5, 5] = septile[count];
            aspectQuintile[5, 5] = quintile[count];
            aspectBiQuintile[5, 5] = biquintile[count];
            count++;
            aspectConjunction[6, 6] = conjunction[count];
            aspectOpposition[6, 6] = opposition[count];
            aspectTrine[6, 6] = trine[count];
            aspectSquare[6, 6] = square[count];
            aspectSextile[6, 6] = sextile[count];
            aspectInconjunct[6, 6] = inconjunct[count];
            aspectSesquiquadrate[6, 6] = sesquiquadrate[count];
            aspectSemiSquare[6, 6] = semisquare[count];
            aspectSemiSextile[6, 6] = semisextile[count];
            aspectSemiQuintile[6, 6] = semiquintile[count];
            aspectNovile[6, 6] = novile[count];
            aspectSeptile[6, 6] = septile[count];
            aspectQuintile[6, 6] = quintile[count];
            aspectBiQuintile[6, 6] = biquintile[count];

            Dictionary<AspectKind, bool> dac = new Dictionary<AspectKind, bool>();
            dac.Add(AspectKind.CONJUNCTION, aspectConjunction[n, m]);
            dac.Add(AspectKind.OPPOSITION, aspectOpposition[n, m]);
            dac.Add(AspectKind.TRINE, aspectTrine[n, m]);
            dac.Add(AspectKind.SQUARE, aspectSquare[n, m]);
            dac.Add(AspectKind.SEXTILE, aspectSextile[n, m]);
            dac.Add(AspectKind.INCONJUNCT, aspectInconjunct[n, m]);
            dac.Add(AspectKind.SESQUIQUADRATE, aspectSesquiquadrate[n, m]);
            dac.Add(AspectKind.SEMISEXTILE, aspectSemiSextile[n, m]);
            dac.Add(AspectKind.SEMIQINTILE, aspectSemiQuintile[n, m]);
            dac.Add(AspectKind.SEMISQUARE, aspectSemiSquare[n, m]);
            dac.Add(AspectKind.NOVILE, aspectNovile[n, m]);
            dac.Add(AspectKind.SEPTILE, aspectSeptile[n, m]);
            dac.Add(AspectKind.QUINTILE, aspectQuintile[n, m]);
            dac.Add(AspectKind.BIQUINTILE, aspectBiQuintile[n, m]);

            return dac;
        }

        /// <summary>
        /// aspectCategoryデフォルト設定
        /// </summary>
        /// <returns>The default aspect category.</returns>
        private string GetDefaultAspectCategory() {
            return "true,true,true,true,true,true," +
                "false,false,false,false," + // 44 55 66 77
                "false,false,false,false," + // 14 15 16 17
                "false,false,false,false," + // 24 25 26 27
                "false,false,false,false," + // 34 35 36 37
                "false,false,false," + // 45 46 47
                "false,false," + // 56 57
                "false"; // 67
        }
    }
}

