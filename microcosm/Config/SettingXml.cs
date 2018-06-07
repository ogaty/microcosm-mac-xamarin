﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace microcosm.Config
{
    // ２次元配列がシリアライズできないのでコンバーターを用意
    public class SettingXml
    {
        [XmlElement("dispname")]
        public string dispname;

        [XmlElement("version")]
        public int version;

        // 第一種アスペクト
        [XmlElement("orb_sun_soft_1st")]
        public string orb_sun_soft_1st;
        [XmlElement("orb_sun_hard_1st")]
        public string orb_sun_hard_1st;
        [XmlElement("orb_moon_soft_1st")]
        public string orb_moon_soft_1st;
        [XmlElement("orb_moon_hard_1st")]
        public string orb_moon_hard_1st;
        [XmlElement("orb_other_soft_1st")]
        public string orb_other_soft_1st;
        [XmlElement("orb_other_hard_1st")]
        public string orb_other_hard_1st;
        // 第二種、第三種アスペクト
        [XmlElement("orb_sun_soft_2nd")]
        public string orb_sun_soft_2nd;
        [XmlElement("orb_sun_hard_2nd")]
        public string orb_sun_hard_2nd;
        [XmlElement("orb_moon_soft_2nd")]
        public string orb_moon_soft_2nd;
        [XmlElement("orb_moon_hard_2nd")]
        public string orb_moon_hard_2nd;
        [XmlElement("orb_other_soft_2nd")]
        public string orb_other_soft_2nd;
        [XmlElement("orb_other_hard_2nd")]
        public string orb_other_hard_2nd;
        // 150,135アスペクト
        [XmlElement("orb_sun_soft_150")]
        public string orb_sun_soft_150;
        [XmlElement("orb_sun_hard_150")]
        public string orb_sun_hard_150;
        [XmlElement("orb_moon_soft_150")]
        public string orb_moon_soft_150;
        [XmlElement("orb_moon_hard_150")]
        public string orb_moon_hard_150;
        [XmlElement("orb_other_soft_150")]
        public string orb_other_soft_150;
        [XmlElement("orb_other_hard_150")]
        public string orb_other_hard_150;

        // アスペクト表示 28個
        // 11, 22, 33, 44, 55, 66, 77
        // 12, 13, 14, 15, 16, 17
        // 23, 24, 25, 26, 27
        // 34, 35, 36, 37
        // 45, 46, 47
        // 56, 57
        // 67
        [XmlElement("aspectSun")]
        public string aspectSun;
        [XmlElement("aspectMoon")]
        public string aspectMoon;
        [XmlElement("aspectMercury")]
        public string aspectMercury;
        [XmlElement("aspectVenus")]
        public string aspectVenus;
        [XmlElement("aspectMars")]
        public string aspectMars;
        [XmlElement("aspectJupiter")]
        public string aspectJupiter;
        [XmlElement("aspectSaturn")]
        public string aspectSaturn;
        [XmlElement("aspectUranus")]
        public string aspectUranus;
        [XmlElement("aspectNeptune")]
        public string aspectNeptune;
        [XmlElement("aspectPluto")]
        public string aspectPluto;
        [XmlElement("aspectDh")]
        public string aspectDh;
        [XmlElement("aspectChiron")]
        public string aspectChiron;
        [XmlElement("aspectAsc")]
        public string aspectAsc;
        [XmlElement("aspectMc")]
        public string aspectMc;
        [XmlElement("aspectEarth")]
        public string aspectEarth;
        [XmlElement("aspectLilith")]
        public string aspectLilith;
        [XmlElement("aspectCeres")]
        public string aspectCeres;
        [XmlElement("aspectParas")]
        public string aspectParas;
        [XmlElement("aspectJuno")]
        public string aspectJuno;
        [XmlElement("aspectVesta")]
        public string aspectVesta;
        [XmlElement("aspectEris")]
        public string aspectEris;
        [XmlElement("aspectSedna")]
        public string aspectSedna;
        [XmlElement("aspectHaumea")]
        public string aspectHaumea;
        [XmlElement("aspectMakemake")]
        public string aspectMakemake;
        [XmlElement("aspectVt")]
        public string aspectVt;
        [XmlElement("aspectPof")]
        public string aspectPof;


        [XmlElement("dispAspect")]
        public bool[] dispAspect;

        #region aspect category
        [XmlElement("aspectConjunction")]
        public string aspectConjunction;
        [XmlElement("aspectOpposition")]
        public string aspectOpposition;
        [XmlElement("aspectTrine")]
        public string aspectTrine;
        [XmlElement("aspectSquare")]
        public string aspectSquare;
        [XmlElement("aspectSextile")]
        public string aspectSextile;
        [XmlElement("aspectInconjunct")]
        public string aspectInconjunct;
        [XmlElement("aspectSesquiquadrate")]
        public string aspectSesquiquadrate;
        [XmlElement("aspectSemiSquare")]
        public string aspectSemiSquare;
        [XmlElement("aspectSemiSextile")]
        public string aspectSemiSextile;
        [XmlElement("aspectSemiQuintile")]
        public string aspectSemiQuintile;
        [XmlElement("aspectNovile")]
        public string aspectNovile;
        [XmlElement("aspectSeptile")]
        public string aspectSeptile;
        [XmlElement("aspectQuintile")]
        public string aspectQuintile;
        [XmlElement("aspectBiQuintile")]
        public string aspectBiQuintile;
        #endregion


        // 以下旧バージョン

        #region orb 1st
        // 第一種アスペクト、一重～六重円
        [XmlElement("orb_sun_soft_1st_0")]
        public double orb_sun_soft_1st_0;
        [XmlElement("orb_sun_soft_1st_1")]
        public double orb_sun_soft_1st_1;
        [XmlElement("orb_sun_soft_1st_2")]
        public double orb_sun_soft_1st_2;
        [XmlElement("orb_sun_soft_1st_3")]
        public double orb_sun_soft_1st_3;
        [XmlElement("orb_sun_soft_1st_4")]
        public double orb_sun_soft_1st_4;
        [XmlElement("orb_sun_soft_1st_5")]
        public double orb_sun_soft_1st_5;


        [XmlElement("orb_sun_hard_1st_0")]
        public double orb_sun_hard_1st_0;
        [XmlElement("orb_sun_hard_1st_1")]
        public double orb_sun_hard_1st_1;
        [XmlElement("orb_sun_hard_1st_2")]
        public double orb_sun_hard_1st_2;
        [XmlElement("orb_sun_hard_1st_3")]
        public double orb_sun_hard_1st_3;
        [XmlElement("orb_sun_hard_1st_4")]
        public double orb_sun_hard_1st_4;
        [XmlElement("orb_sun_hard_1st_5")]
        public double orb_sun_hard_1st_5;


        [XmlElement("orb_moon_soft_1st_0")]
        public double orb_moon_soft_1st_0;
        [XmlElement("orb_moon_soft_1st_1")]
        public double orb_moon_soft_1st_1;
        [XmlElement("orb_moon_soft_1st_2")]
        public double orb_moon_soft_1st_2;
        [XmlElement("orb_moon_soft_1st_3")]
        public double orb_moon_soft_1st_3;
        [XmlElement("orb_moon_soft_1st_4")]
        public double orb_moon_soft_1st_4;
        [XmlElement("orb_moon_soft_1st_5")]
        public double orb_moon_soft_1st_5;


        [XmlElement("orb_moon_hard_1st_0")]
        public double orb_moon_hard_1st_0;
        [XmlElement("orb_moon_hard_1st_1")]
        public double orb_moon_hard_1st_1;
        [XmlElement("orb_moon_hard_1st_2")]
        public double orb_moon_hard_1st_2;
        [XmlElement("orb_moon_hard_1st_3")]
        public double orb_moon_hard_1st_3;
        [XmlElement("orb_moon_hard_1st_4")]
        public double orb_moon_hard_1st_4;
        [XmlElement("orb_moon_hard_1st_5")]
        public double orb_moon_hard_1st_5;


        [XmlElement("orb_other_soft_1st_0")]
        public double orb_other_soft_1st_0;
        [XmlElement("orb_other_soft_1st_1")]
        public double orb_other_soft_1st_1;
        [XmlElement("orb_other_soft_1st_2")]
        public double orb_other_soft_1st_2;
        [XmlElement("orb_other_soft_1st_3")]
        public double orb_other_soft_1st_3;
        [XmlElement("orb_other_soft_1st_4")]
        public double orb_other_soft_1st_4;
        [XmlElement("orb_other_soft_1st_5")]
        public double orb_other_soft_1st_5;


        [XmlElement("orb_other_hard_1st_0")]
        public double orb_other_hard_1st_0;
        [XmlElement("orb_other_hard_1st_1")]
        public double orb_other_hard_1st_1;
        [XmlElement("orb_other_hard_1st_2")]
        public double orb_other_hard_1st_2;
        [XmlElement("orb_other_hard_1st_3")]
        public double orb_other_hard_1st_3;
        [XmlElement("orb_other_hard_1st_4")]
        public double orb_other_hard_1st_4;
        [XmlElement("orb_other_hard_1st_5")]
        public double orb_other_hard_1st_5;
        #endregion

        // 第二種アスペクト、一重～五重円
        #region orb 2nd
        [XmlElement("orb_sun_soft_2nd_0")]
        public double orb_sun_soft_2nd_0;
        [XmlElement("orb_sun_soft_2nd_1")]
        public double orb_sun_soft_2nd_1;
        [XmlElement("orb_sun_soft_2nd_2")]
        public double orb_sun_soft_2nd_2;
        [XmlElement("orb_sun_soft_2nd_3")]
        public double orb_sun_soft_2nd_3;
        [XmlElement("orb_sun_soft_2nd_4")]
        public double orb_sun_soft_2nd_4;
        [XmlElement("orb_sun_soft_2nd_5")]
        public double orb_sun_soft_2nd_5;


        [XmlElement("orb_sun_hard_2nd_0")]
        public double orb_sun_hard_2nd_0;
        [XmlElement("orb_sun_hard_2nd_1")]
        public double orb_sun_hard_2nd_1;
        [XmlElement("orb_sun_hard_2nd_2")]
        public double orb_sun_hard_2nd_2;
        [XmlElement("orb_sun_hard_2nd_3")]
        public double orb_sun_hard_2nd_3;
        [XmlElement("orb_sun_hard_2nd_4")]
        public double orb_sun_hard_2nd_4;
        [XmlElement("orb_sun_hard_2nd_5")]
        public double orb_sun_hard_2nd_5;


        [XmlElement("orb_moon_soft_2nd_0")]
        public double orb_moon_soft_2nd_0;
        [XmlElement("orb_moon_soft_2nd_1")]
        public double orb_moon_soft_2nd_1;
        [XmlElement("orb_moon_soft_2nd_2")]
        public double orb_moon_soft_2nd_2;
        [XmlElement("orb_moon_soft_2nd_3")]
        public double orb_moon_soft_2nd_3;
        [XmlElement("orb_moon_soft_2nd_4")]
        public double orb_moon_soft_2nd_4;
        [XmlElement("orb_moon_soft_2nd_5")]
        public double orb_moon_soft_2nd_5;


        [XmlElement("orb_moon_hard_2nd_0")]
        public double orb_moon_hard_2nd_0;
        [XmlElement("orb_moon_hard_2nd_1")]
        public double orb_moon_hard_2nd_1;
        [XmlElement("orb_moon_hard_2nd_2")]
        public double orb_moon_hard_2nd_2;
        [XmlElement("orb_moon_hard_2nd_3")]
        public double orb_moon_hard_2nd_3;
        [XmlElement("orb_moon_hard_2nd_4")]
        public double orb_moon_hard_2nd_4;
        [XmlElement("orb_moon_hard_2nd_5")]
        public double orb_moon_hard_2nd_5;


        [XmlElement("orb_other_soft_2nd_0")]
        public double orb_other_soft_2nd_0;
        [XmlElement("orb_other_soft_2nd_1")]
        public double orb_other_soft_2nd_1;
        [XmlElement("orb_other_soft_2nd_2")]
        public double orb_other_soft_2nd_2;
        [XmlElement("orb_other_soft_2nd_3")]
        public double orb_other_soft_2nd_3;
        [XmlElement("orb_other_soft_2nd_4")]
        public double orb_other_soft_2nd_4;
        [XmlElement("orb_other_soft_2nd_5")]
        public double orb_other_soft_2nd_5;


        [XmlElement("orb_other_hard_2nd_0")]
        public double orb_other_hard_2nd_0;
        [XmlElement("orb_other_hard_2nd_1")]
        public double orb_other_hard_2nd_1;
        [XmlElement("orb_other_hard_2nd_2")]
        public double orb_other_hard_2nd_2;
        [XmlElement("orb_other_hard_2nd_3")]
        public double orb_other_hard_2nd_3;
        [XmlElement("orb_other_hard_2nd_4")]
        public double orb_other_hard_2nd_4;
        [XmlElement("orb_other_hard_2nd_5")]
        public double orb_other_hard_2nd_5;
        #endregion

        // 135/150
        #region orb 150
        [XmlElement("orb_sun_soft_150_0")]
        public double orb_sun_soft_150_0;
        [XmlElement("orb_sun_soft_150_1")]
        public double orb_sun_soft_150_1;
        [XmlElement("orb_sun_soft_150_2")]
        public double orb_sun_soft_150_2;
        [XmlElement("orb_sun_soft_150_3")]
        public double orb_sun_soft_150_3;
        [XmlElement("orb_sun_soft_150_4")]
        public double orb_sun_soft_150_4;
        [XmlElement("orb_sun_soft_150_5")]
        public double orb_sun_soft_150_5;


        [XmlElement("orb_sun_hard_150_0")]
        public double orb_sun_hard_150_0;
        [XmlElement("orb_sun_hard_150_1")]
        public double orb_sun_hard_150_1;
        [XmlElement("orb_sun_hard_150_2")]
        public double orb_sun_hard_150_2;
        [XmlElement("orb_sun_hard_150_3")]
        public double orb_sun_hard_150_3;
        [XmlElement("orb_sun_hard_150_4")]
        public double orb_sun_hard_150_4;
        [XmlElement("orb_sun_hard_150_5")]
        public double orb_sun_hard_150_5;


        [XmlElement("orb_moon_soft_150_0")]
        public double orb_moon_soft_150_0;
        [XmlElement("orb_moon_soft_150_1")]
        public double orb_moon_soft_150_1;
        [XmlElement("orb_moon_soft_150_2")]
        public double orb_moon_soft_150_2;
        [XmlElement("orb_moon_soft_150_3")]
        public double orb_moon_soft_150_3;
        [XmlElement("orb_moon_soft_150_4")]
        public double orb_moon_soft_150_4;
        [XmlElement("orb_moon_soft_150_5")]
        public double orb_moon_soft_150_5;


        [XmlElement("orb_moon_hard_150_0")]
        public double orb_moon_hard_150_0;
        [XmlElement("orb_moon_hard_150_1")]
        public double orb_moon_hard_150_1;
        [XmlElement("orb_moon_hard_150_2")]
        public double orb_moon_hard_150_2;
        [XmlElement("orb_moon_hard_150_3")]
        public double orb_moon_hard_150_3;
        [XmlElement("orb_moon_hard_150_4")]
        public double orb_moon_hard_150_4;
        [XmlElement("orb_moon_hard_150_5")]
        public double orb_moon_hard_150_5;


        [XmlElement("orb_other_soft_150_0")]
        public double orb_other_soft_150_0;
        [XmlElement("orb_other_soft_150_1")]
        public double orb_other_soft_150_1;
        [XmlElement("orb_other_soft_150_2")]
        public double orb_other_soft_150_2;
        [XmlElement("orb_other_soft_150_3")]
        public double orb_other_soft_150_3;
        [XmlElement("orb_other_soft_150_4")]
        public double orb_other_soft_150_4;
        [XmlElement("orb_other_soft_150_5")]
        public double orb_other_soft_150_5;


        [XmlElement("orb_other_hard_150_0")]
        public double orb_other_hard_150_0;
        [XmlElement("orb_other_hard_150_1")]
        public double orb_other_hard_150_1;
        [XmlElement("orb_other_hard_150_2")]
        public double orb_other_hard_150_2;
        [XmlElement("orb_other_hard_150_3")]
        public double orb_other_hard_150_3;
        [XmlElement("orb_other_hard_150_4")]
        public double orb_other_hard_150_4;
        [XmlElement("orb_other_hard_150_5")]
        public double orb_other_hard_150_5;
        #endregion

        [XmlElement("dispCircle")]
        public bool[] dispCircle;

        #region dispPlanet
        [XmlElement("dispPlanetSun11")]
        public bool dispPlanetSun11;
        [XmlElement("dispPlanetMoon11")]
        public bool dispPlanetMoon11;
        [XmlElement("dispPlanetMercury11")]
        public bool dispPlanetMercury11;
        [XmlElement("dispPlanetVenus11")]
        public bool dispPlanetVenus11;
        [XmlElement("dispPlanetMars11")]
        public bool dispPlanetMars11;
        [XmlElement("dispPlanetJupiter11")]
        public bool dispPlanetJupiter11;
        [XmlElement("dispPlanetSaturn11")]
        public bool dispPlanetSaturn11;
        [XmlElement("dispPlanetUranus11")]
        public bool dispPlanetUranus11;
        [XmlElement("dispPlanetNeptune11")]
        public bool dispPlanetNeptune11;
        [XmlElement("dispPlanetPluto11")]
        public bool dispPlanetPluto11;
        [XmlElement("dispPlanetDh11")]
        public bool dispPlanetDh11;
        [XmlElement("dispPlanetChiron11")]
        public bool dispPlanetChiron11;
        [XmlElement("dispPlanetAsc11")]
        public bool dispPlanetAsc11;
        [XmlElement("dispPlanetMc11")]
        public bool dispPlanetMc11;
        [XmlElement("dispPlanetEarth11")]
        public bool dispPlanetEarth11;
        [XmlElement("dispPlanetLilith11")]
        public bool dispPlanetLilith11;
        [XmlElement("dispPlanetSun22")]
        public bool dispPlanetSun22;
        [XmlElement("dispPlanetMoon22")]
        public bool dispPlanetMoon22;
        [XmlElement("dispPlanetMercury22")]
        public bool dispPlanetMercury22;
        [XmlElement("dispPlanetVenus22")]
        public bool dispPlanetVenus22;
        [XmlElement("dispPlanetMars22")]
        public bool dispPlanetMars22;
        [XmlElement("dispPlanetJupiter22")]
        public bool dispPlanetJupiter22;
        [XmlElement("dispPlanetSaturn22")]
        public bool dispPlanetSaturn22;
        [XmlElement("dispPlanetUranus22")]
        public bool dispPlanetUranus22;
        [XmlElement("dispPlanetNeptune22")]
        public bool dispPlanetNeptune22;
        [XmlElement("dispPlanetPluto22")]
        public bool dispPlanetPluto22;
        [XmlElement("dispPlanetDh22")]
        public bool dispPlanetDh22;
        [XmlElement("dispPlanetChiron22")]
        public bool dispPlanetChiron22;
        [XmlElement("dispPlanetAsc22")]
        public bool dispPlanetAsc22;
        [XmlElement("dispPlanetMc22")]
        public bool dispPlanetMc22;
        [XmlElement("dispPlanetEarth22")]
        public bool dispPlanetEarth22;
        [XmlElement("dispPlanetLilith22")]
        public bool dispPlanetLilith22;
        [XmlElement("dispPlanetSun33")]
        public bool dispPlanetSun33;
        [XmlElement("dispPlanetMoon33")]
        public bool dispPlanetMoon33;
        [XmlElement("dispPlanetMercury33")]
        public bool dispPlanetMercury33;
        [XmlElement("dispPlanetVenus33")]
        public bool dispPlanetVenus33;
        [XmlElement("dispPlanetMars33")]
        public bool dispPlanetMars33;
        [XmlElement("dispPlanetJupiter33")]
        public bool dispPlanetJupiter33;
        [XmlElement("dispPlanetSaturn33")]
        public bool dispPlanetSaturn33;
        [XmlElement("dispPlanetUranus33")]
        public bool dispPlanetUranus33;
        [XmlElement("dispPlanetNeptune33")]
        public bool dispPlanetNeptune33;
        [XmlElement("dispPlanetPluto33")]
        public bool dispPlanetPluto33;
        [XmlElement("dispPlanetDh33")]
        public bool dispPlanetDh33;
        [XmlElement("dispPlanetChiron33")]
        public bool dispPlanetChiron33;
        [XmlElement("dispPlanetAsc33")]
        public bool dispPlanetAsc33;
        [XmlElement("dispPlanetMc33")]
        public bool dispPlanetMc33;
        [XmlElement("dispPlanetEarth33")]
        public bool dispPlanetEarth33;
        [XmlElement("dispPlanetLilith33")]
        public bool dispPlanetLilith33;
        [XmlElement("dispPlanetSun44")]
        public bool dispPlanetSun44;
        [XmlElement("dispPlanetMoon44")]
        public bool dispPlanetMoon44;
        [XmlElement("dispPlanetMercury44")]
        public bool dispPlanetMercury44;
        [XmlElement("dispPlanetVenus44")]
        public bool dispPlanetVenus44;
        [XmlElement("dispPlanetMars44")]
        public bool dispPlanetMars44;
        [XmlElement("dispPlanetJupiter44")]
        public bool dispPlanetJupiter44;
        [XmlElement("dispPlanetSaturn44")]
        public bool dispPlanetSaturn44;
        [XmlElement("dispPlanetUranus44")]
        public bool dispPlanetUranus44;
        [XmlElement("dispPlanetNeptune44")]
        public bool dispPlanetNeptune44;
        [XmlElement("dispPlanetPluto44")]
        public bool dispPlanetPluto44;
        [XmlElement("dispPlanetDh44")]
        public bool dispPlanetDh44;
        [XmlElement("dispPlanetChiron44")]
        public bool dispPlanetChiron44;
        [XmlElement("dispPlanetAsc44")]
        public bool dispPlanetAsc44;
        [XmlElement("dispPlanetMc44")]
        public bool dispPlanetMc44;
        [XmlElement("dispPlanetEarth44")]
        public bool dispPlanetEarth44;
        [XmlElement("dispPlanetLilith44")]
        public bool dispPlanetLilith44;
        [XmlElement("dispPlanetSun55")]
        public bool dispPlanetSun55;
        [XmlElement("dispPlanetMoon55")]
        public bool dispPlanetMoon55;
        [XmlElement("dispPlanetMercury55")]
        public bool dispPlanetMercury55;
        [XmlElement("dispPlanetVenus55")]
        public bool dispPlanetVenus55;
        [XmlElement("dispPlanetMars55")]
        public bool dispPlanetMars55;
        [XmlElement("dispPlanetJupiter55")]
        public bool dispPlanetJupiter55;
        [XmlElement("dispPlanetSaturn55")]
        public bool dispPlanetSaturn55;
        [XmlElement("dispPlanetUranus55")]
        public bool dispPlanetUranus55;
        [XmlElement("dispPlanetNeptune55")]
        public bool dispPlanetNeptune55;
        [XmlElement("dispPlanetPluto55")]
        public bool dispPlanetPluto55;
        [XmlElement("dispPlanetDh55")]
        public bool dispPlanetDh55;
        [XmlElement("dispPlanetChiron55")]
        public bool dispPlanetChiron55;
        [XmlElement("dispPlanetAsc55")]
        public bool dispPlanetAsc55;
        [XmlElement("dispPlanetMc55")]
        public bool dispPlanetMc55;
        [XmlElement("dispPlanetEarth55")]
        public bool dispPlanetEarth55;
        [XmlElement("dispPlanetLilith55")]
        public bool dispPlanetLilith55;
        [XmlElement("dispPlanetCeres11")]
        public bool dispPlanetCeres11;
        [XmlElement("dispPlanetPallas11")]
        public bool dispPlanetPallas11;
        [XmlElement("dispPlanetJuno11")]
        public bool dispPlanetJuno11;
        [XmlElement("dispPlanetVesta11")]
        public bool dispPlanetVesta11;
        [XmlElement("dispPlanetEris11")]
        public bool dispPlanetEris11;
        [XmlElement("dispPlanetSedna11")]
        public bool dispPlanetSedna11;
        [XmlElement("dispPlanetHaumea11")]
        public bool dispPlanetHaumea11;
        [XmlElement("dispPlanetMakemake11")]
        public bool dispPlanetMakemake11;
        [XmlElement("dispPlanetVt11")]
        public bool dispPlanetVt11;
        [XmlElement("dispPlanetPof11")]
        public bool dispPlanetPof11;
        [XmlElement("dispPlanetCeres22")]
        public bool dispPlanetCeres22;
        [XmlElement("dispPlanetPallas22")]
        public bool dispPlanetPallas22;
        [XmlElement("dispPlanetJuno22")]
        public bool dispPlanetJuno22;
        [XmlElement("dispPlanetVesta22")]
        public bool dispPlanetVesta22;
        [XmlElement("dispPlanetEris22")]
        public bool dispPlanetEris22;
        [XmlElement("dispPlanetSedna22")]
        public bool dispPlanetSedna22;
        [XmlElement("dispPlanetHaumea22")]
        public bool dispPlanetHaumea22;
        [XmlElement("dispPlanetMakemake22")]
        public bool dispPlanetMakemake22;
        [XmlElement("dispPlanetVt22")]
        public bool dispPlanetVt22;
        [XmlElement("dispPlanetPof22")]
        public bool dispPlanetPof22;
        [XmlElement("dispPlanetCeres33")]
        public bool dispPlanetCeres33;
        [XmlElement("dispPlanetPallas33")]
        public bool dispPlanetPallas33;
        [XmlElement("dispPlanetJuno33")]
        public bool dispPlanetJuno33;
        [XmlElement("dispPlanetVesta33")]
        public bool dispPlanetVesta33;
        [XmlElement("dispPlanetEris33")]
        public bool dispPlanetEris33;
        [XmlElement("dispPlanetSedna33")]
        public bool dispPlanetSedna33;
        [XmlElement("dispPlanetHaumea33")]
        public bool dispPlanetHaumea33;
        [XmlElement("dispPlanetMakemake33")]
        public bool dispPlanetMakemake33;
        [XmlElement("dispPlanetVt33")]
        public bool dispPlanetVt33;
        [XmlElement("dispPlanetPof33")]
        public bool dispPlanetPof33;
        [XmlElement("dispPlanetCeres44")]
        public bool dispPlanetCeres44;
        [XmlElement("dispPlanetPallas44")]
        public bool dispPlanetPallas44;
        [XmlElement("dispPlanetJuno44")]
        public bool dispPlanetJuno44;
        [XmlElement("dispPlanetVesta44")]
        public bool dispPlanetVesta44;
        [XmlElement("dispPlanetEris44")]
        public bool dispPlanetEris44;
        [XmlElement("dispPlanetSedna44")]
        public bool dispPlanetSedna44;
        [XmlElement("dispPlanetHaumea44")]
        public bool dispPlanetHaumea44;
        [XmlElement("dispPlanetMakemake44")]
        public bool dispPlanetMakemake44;
        [XmlElement("dispPlanetVt44")]
        public bool dispPlanetVt44;
        [XmlElement("dispPlanetPof44")]
        public bool dispPlanetPof44;
        [XmlElement("dispPlanetCeres55")]
        public bool dispPlanetCeres55;
        [XmlElement("dispPlanetPallas55")]
        public bool dispPlanetPallas55;
        [XmlElement("dispPlanetJuno55")]
        public bool dispPlanetJuno55;
        [XmlElement("dispPlanetVesta55")]
        public bool dispPlanetVesta55;
        [XmlElement("dispPlanetEris55")]
        public bool dispPlanetEris55;
        [XmlElement("dispPlanetSedna55")]
        public bool dispPlanetSedna55;
        [XmlElement("dispPlanetHaumea55")]
        public bool dispPlanetHaumea55;
        [XmlElement("dispPlanetMakemake55")]
        public bool dispPlanetMakemake55;
        [XmlElement("dispPlanetVt55")]
        public bool dispPlanetVt55;
        [XmlElement("dispPlanetPof55")]
        public bool dispPlanetPof55;
       #endregion

        #region aspect Planet
        [XmlElement("aspectSun11")]
        public bool aspectSun11;
        [XmlElement("aspectMoon11")]
        public bool aspectMoon11;
        [XmlElement("aspectMercury11")]
        public bool aspectMercury11;
        [XmlElement("aspectVenus11")]
        public bool aspectVenus11;
        [XmlElement("aspectMars11")]
        public bool aspectMars11;
        [XmlElement("aspectJupiter11")]
        public bool aspectJupiter11;
        [XmlElement("aspectSaturn11")]
        public bool aspectSaturn11;
        [XmlElement("aspectUranus11")]
        public bool aspectUranus11;
        [XmlElement("aspectNeptune11")]
        public bool aspectNeptune11;
        [XmlElement("aspectPluto11")]
        public bool aspectPluto11;
        [XmlElement("aspectDh11")]
        public bool aspectDh11;
        [XmlElement("aspectChiron11")]
        public bool aspectChiron11;
        [XmlElement("aspectAsc11")]
        public bool aspectAsc11;
        [XmlElement("aspectMc11")]
        public bool aspectMc11;
        [XmlElement("aspectEarth11")]
        public bool aspectEarth11;
        [XmlElement("aspectLilith11")]
        public bool aspectLilith11;
        [XmlElement("aspectCeres11")]
        public bool aspectCeres11;
        [XmlElement("aspectPallas11")]
        public bool aspectPallas11;
        [XmlElement("aspectJuno11")]
        public bool aspectJuno11;
        [XmlElement("aspectVesta11")]
        public bool aspectVesta11;
        [XmlElement("aspectEris11")]
        public bool aspectEris11;
        [XmlElement("aspectSedna11")]
        public bool aspectSedna11;
        [XmlElement("aspectHaumea11")]
        public bool aspectHaumea11;
        [XmlElement("aspectMakemake11")]
        public bool aspectMakemake11;
        [XmlElement("aspectVt11")]
        public bool aspectVt11;
        [XmlElement("aspectPof11")]
        public bool aspectPof11;
        [XmlElement("aspectSun22")]
        public bool aspectSun22;
        [XmlElement("aspectMoon22")]
        public bool aspectMoon22;
        [XmlElement("aspectMercury22")]
        public bool aspectMercury22;
        [XmlElement("aspectVenus22")]
        public bool aspectVenus22;
        [XmlElement("aspectMars22")]
        public bool aspectMars22;
        [XmlElement("aspectJupiter22")]
        public bool aspectJupiter22;
        [XmlElement("aspectSaturn22")]
        public bool aspectSaturn22;
        [XmlElement("aspectUranus22")]
        public bool aspectUranus22;
        [XmlElement("aspectNeptune22")]
        public bool aspectNeptune22;
        [XmlElement("aspectPluto22")]
        public bool aspectPluto22;
        [XmlElement("aspectDh22")]
        public bool aspectDh22;
        [XmlElement("aspectChiron22")]
        public bool aspectChiron22;
        [XmlElement("aspectAsc22")]
        public bool aspectAsc22;
        [XmlElement("aspectMc22")]
        public bool aspectMc22;
        [XmlElement("aspectEarth22")]
        public bool aspectEarth22;
        [XmlElement("aspectLilith22")]
        public bool aspectLilith22;
        [XmlElement("aspectCeres22")]
        public bool aspectCeres22;
        [XmlElement("aspectPallas22")]
        public bool aspectPallas22;
        [XmlElement("aspectJuno22")]
        public bool aspectJuno22;
        [XmlElement("aspectVesta22")]
        public bool aspectVesta22;
        [XmlElement("aspectEris22")]
        public bool aspectEris22;
        [XmlElement("aspectSedna22")]
        public bool aspectSedna22;
        [XmlElement("aspectHaumea22")]
        public bool aspectHaumea22;
        [XmlElement("aspectMakemake22")]
        public bool aspectMakemake22;
        [XmlElement("aspectVt22")]
        public bool aspectVt22;
        [XmlElement("aspectPof22")]
        public bool aspectPof22;
        [XmlElement("aspectSun33")]
        public bool aspectSun33;
        [XmlElement("aspectMoon33")]
        public bool aspectMoon33;
        [XmlElement("aspectMercury33")]
        public bool aspectMercury33;
        [XmlElement("aspectVenus33")]
        public bool aspectVenus33;
        [XmlElement("aspectMars33")]
        public bool aspectMars33;
        [XmlElement("aspectJupiter33")]
        public bool aspectJupiter33;
        [XmlElement("aspectSaturn33")]
        public bool aspectSaturn33;
        [XmlElement("aspectUranus33")]
        public bool aspectUranus33;
        [XmlElement("aspectNeptune33")]
        public bool aspectNeptune33;
        [XmlElement("aspectPluto33")]
        public bool aspectPluto33;
        [XmlElement("aspectDh33")]
        public bool aspectDh33;
        [XmlElement("aspectChiron33")]
        public bool aspectChiron33;
        [XmlElement("aspectAsc33")]
        public bool aspectAsc33;
        [XmlElement("aspectMc33")]
        public bool aspectMc33;
        [XmlElement("aspectEarth33")]
        public bool aspectEarth33;
        [XmlElement("aspectLilith33")]
        public bool aspectLilith33;
        [XmlElement("aspectCeres33")]
        public bool aspectCeres33;
        [XmlElement("aspectPallas33")]
        public bool aspectPallas33;
        [XmlElement("aspectJuno33")]
        public bool aspectJuno33;
        [XmlElement("aspectVesta33")]
        public bool aspectVesta33;
        [XmlElement("aspectEris33")]
        public bool aspectEris33;
        [XmlElement("aspectSedna33")]
        public bool aspectSedna33;
        [XmlElement("aspectHaumea33")]
        public bool aspectHaumea33;
        [XmlElement("aspectMakemake33")]
        public bool aspectMakemake33;
        [XmlElement("aspectVt33")]
        public bool aspectVt33;
        [XmlElement("aspectPof33")]
        public bool aspectPof33;
        [XmlElement("aspectSun12")]
        public bool aspectSun12;
        [XmlElement("aspectMoon12")]
        public bool aspectMoon12;
        [XmlElement("aspectMercury12")]
        public bool aspectMercury12;
        [XmlElement("aspectVenus12")]
        public bool aspectVenus12;
        [XmlElement("aspectMars12")]
        public bool aspectMars12;
        [XmlElement("aspectJupiter12")]
        public bool aspectJupiter12;
        [XmlElement("aspectSaturn12")]
        public bool aspectSaturn12;
        [XmlElement("aspectUranus12")]
        public bool aspectUranus12;
        [XmlElement("aspectNeptune12")]
        public bool aspectNeptune12;
        [XmlElement("aspectPluto12")]
        public bool aspectPluto12;
        [XmlElement("aspectDh12")]
        public bool aspectDh12;
        [XmlElement("aspectChiron12")]
        public bool aspectChiron12;
        [XmlElement("aspectAsc12")]
        public bool aspectAsc12;
        [XmlElement("aspectMc12")]
        public bool aspectMc12;
        [XmlElement("aspectEarth12")]
        public bool aspectEarth12;
        [XmlElement("aspectLilith12")]
        public bool aspectLilith12;
        [XmlElement("aspectSun13")]
        public bool aspectSun13;
        [XmlElement("aspectMoon13")]
        public bool aspectMoon13;
        [XmlElement("aspectMercury13")]
        public bool aspectMercury13;
        [XmlElement("aspectVenus13")]
        public bool aspectVenus13;
        [XmlElement("aspectMars13")]
        public bool aspectMars13;
        [XmlElement("aspectJupiter13")]
        public bool aspectJupiter13;
        [XmlElement("aspectSaturn13")]
        public bool aspectSaturn13;
        [XmlElement("aspectUranus13")]
        public bool aspectUranus13;
        [XmlElement("aspectNeptune13")]
        public bool aspectNeptune13;
        [XmlElement("aspectPluto13")]
        public bool aspectPluto13;
        [XmlElement("aspectDh13")]
        public bool aspectDh13;
        [XmlElement("aspectChiron13")]
        public bool aspectChiron13;
        [XmlElement("aspectAsc13")]
        public bool aspectAsc13;
        [XmlElement("aspectMc13")]
        public bool aspectMc13;
        [XmlElement("aspectEarth13")]
        public bool aspectEarth13;
        [XmlElement("aspectLilith13")]
        public bool aspectLilith13;
        [XmlElement("aspectSun23")]
        public bool aspectSun23;
        [XmlElement("aspectMoon23")]
        public bool aspectMoon23;
        [XmlElement("aspectMercury23")]
        public bool aspectMercury23;
        [XmlElement("aspectVenus23")]
        public bool aspectVenus23;
        [XmlElement("aspectMars23")]
        public bool aspectMars23;
        [XmlElement("aspectJupiter23")]
        public bool aspectJupiter23;
        [XmlElement("aspectSaturn23")]
        public bool aspectSaturn23;
        [XmlElement("aspectUranus23")]
        public bool aspectUranus23;
        [XmlElement("aspectNeptune23")]
        public bool aspectNeptune23;
        [XmlElement("aspectPluto23")]
        public bool aspectPluto23;
        [XmlElement("aspectDh23")]
        public bool aspectDh23;
        [XmlElement("aspectChiron23")]
        public bool aspectChiron23;
        [XmlElement("aspectAsc23")]
        public bool aspectAsc23;
        [XmlElement("aspectMc23")]
        public bool aspectMc23;
        [XmlElement("aspectEarth23")]
        public bool aspectEarth23;
        [XmlElement("aspectLilith23")]
        public bool aspectLilith23;
        [XmlElement("aspectSun44")]
        public bool aspectSun44;
        [XmlElement("aspectMoon44")]
        public bool aspectMoon44;
        [XmlElement("aspectMercury44")]
        public bool aspectMercury44;
        [XmlElement("aspectVenus44")]
        public bool aspectVenus44;
        [XmlElement("aspectMars44")]
        public bool aspectMars44;
        [XmlElement("aspectJupiter44")]
        public bool aspectJupiter44;
        [XmlElement("aspectSaturn44")]
        public bool aspectSaturn44;
        [XmlElement("aspectUranus44")]
        public bool aspectUranus44;
        [XmlElement("aspectNeptune44")]
        public bool aspectNeptune44;
        [XmlElement("aspectPluto44")]
        public bool aspectPluto44;
        [XmlElement("aspectDh44")]
        public bool aspectDh44;
        [XmlElement("aspectChiron44")]
        public bool aspectChiron44;
        [XmlElement("aspectAsc44")]
        public bool aspectAsc44;
        [XmlElement("aspectMc44")]
        public bool aspectMc44;
        [XmlElement("aspectEarth44")]
        public bool aspectEarth44;
        [XmlElement("aspectLilith44")]
        public bool aspectLilith44;
        [XmlElement("aspectCeres44")]
        public bool aspectCeres44;
        [XmlElement("aspectPallas44")]
        public bool aspectPallas44;
        [XmlElement("aspectJuno44")]
        public bool aspectJuno44;
        [XmlElement("aspectVesta44")]
        public bool aspectVesta44;
        [XmlElement("aspectEris44")]
        public bool aspectEris44;
        [XmlElement("aspectSedna44")]
        public bool aspectSedna44;
        [XmlElement("aspectHaumea44")]
        public bool aspectHaumea44;
        [XmlElement("aspectMakemake44")]
        public bool aspectMakemake44;
        [XmlElement("aspectVt44")]
        public bool aspectVt44;
        [XmlElement("aspectPof44")]
        public bool aspectPof44;
        [XmlElement("aspectSun55")]
        public bool aspectSun55;
        [XmlElement("aspectMoon55")]
        public bool aspectMoon55;
        [XmlElement("aspectMercury55")]
        public bool aspectMercury55;
        [XmlElement("aspectVenus55")]
        public bool aspectVenus55;
        [XmlElement("aspectMars55")]
        public bool aspectMars55;
        [XmlElement("aspectJupiter55")]
        public bool aspectJupiter55;
        [XmlElement("aspectSaturn55")]
        public bool aspectSaturn55;
        [XmlElement("aspectUranus55")]
        public bool aspectUranus55;
        [XmlElement("aspectNeptune55")]
        public bool aspectNeptune55;
        [XmlElement("aspectPluto55")]
        public bool aspectPluto55;
        [XmlElement("aspectDh55")]
        public bool aspectDh55;
        [XmlElement("aspectChiron55")]
        public bool aspectChiron55;
        [XmlElement("aspectAsc55")]
        public bool aspectAsc55;
        [XmlElement("aspectMc55")]
        public bool aspectMc55;
        [XmlElement("aspectEarth55")]
        public bool aspectEarth55;
        [XmlElement("aspectLilith55")]
        public bool aspectLilith55;
        [XmlElement("aspectCeres55")]
        public bool aspectCeres55;
        [XmlElement("aspectPallas55")]
        public bool aspectPallas55;
        [XmlElement("aspectJuno55")]
        public bool aspectJuno55;
        [XmlElement("aspectVesta55")]
        public bool aspectVesta55;
        [XmlElement("aspectEris55")]
        public bool aspectEris55;
        [XmlElement("aspectSedna55")]
        public bool aspectSedna55;
        [XmlElement("aspectHaumea55")]
        public bool aspectHaumea55;
        [XmlElement("aspectMakemake55")]
        public bool aspectMakemake55;
        [XmlElement("aspectVt55")]
        public bool aspectVt55;
        [XmlElement("aspectPof55")]
        public bool aspectPof55;
        #endregion

        #region aspect Aspect
        [XmlElement("aspectConjunction11")]
        public bool aspectConjunction11;
        [XmlElement("aspectOpposition11")]
        public bool aspectOpposition11;
        [XmlElement("aspectTrine11")]
        public bool aspectTrine11;
        [XmlElement("aspectSquare11")]
        public bool aspectSquare11;
        [XmlElement("aspectSextile11")]
        public bool aspectSextile11;
        [XmlElement("aspectInconjunct11")]
        public bool aspectInconjunct11;
        [XmlElement("aspectSesquiquadrate11")]
        public bool aspectSesquiquadrate11;
        [XmlElement("aspectConjunction22")]
        public bool aspectConjunction22;
        [XmlElement("aspectOpposition22")]
        public bool aspectOpposition22;
        [XmlElement("aspectTrine22")]
        public bool aspectTrine22;
        [XmlElement("aspectSquare22")]
        public bool aspectSquare22;
        [XmlElement("aspectSextile22")]
        public bool aspectSextile22;
        [XmlElement("aspectInconjunct22")]
        public bool aspectInconjunct22;
        [XmlElement("aspectSesquiquadrate22")]
        public bool aspectSesquiquadrate22;
        [XmlElement("aspectConjunction33")]
        public bool aspectConjunction33;
        [XmlElement("aspectOpposition33")]
        public bool aspectOpposition33;
        [XmlElement("aspectTrine33")]
        public bool aspectTrine33;
        [XmlElement("aspectSquare33")]
        public bool aspectSquare33;
        [XmlElement("aspectSextile33")]
        public bool aspectSextile33;
        [XmlElement("aspectInconjunct33")]
        public bool aspectInconjunct33;
        [XmlElement("aspectSesquiquadrate33")]
        public bool aspectSesquiquadrate33;
        [XmlElement("aspectConjunction12")]
        public bool aspectConjunction12;
        [XmlElement("aspectOpposition12")]
        public bool aspectOpposition12;
        [XmlElement("aspectTrine12")]
        public bool aspectTrine12;
        [XmlElement("aspectSquare12")]
        public bool aspectSquare12;
        [XmlElement("aspectSextile12")]
        public bool aspectSextile12;
        [XmlElement("aspectInconjunct12")]
        public bool aspectInconjunct12;
        [XmlElement("aspectSesquiquadrate12")]
        public bool aspectSesquiquadrate12;
        [XmlElement("aspectConjunction13")]
        public bool aspectConjunction13;
        [XmlElement("aspectOpposition13")]
        public bool aspectOpposition13;
        [XmlElement("aspectTrine13")]
        public bool aspectTrine13;
        [XmlElement("aspectSquare13")]
        public bool aspectSquare13;
        [XmlElement("aspectSextile13")]
        public bool aspectSextile13;
        [XmlElement("aspectInconjunct13")]
        public bool aspectInconjunct13;
        [XmlElement("aspectSesquiquadrate13")]
        public bool aspectSesquiquadrate13;
        [XmlElement("aspectConjunction23")]
        public bool aspectConjunction23;
        [XmlElement("aspectOpposition23")]
        public bool aspectOpposition23;
        [XmlElement("aspectTrine23")]
        public bool aspectTrine23;
        [XmlElement("aspectSquare23")]
        public bool aspectSquare23;
        [XmlElement("aspectSextile23")]
        public bool aspectSextile23;
        [XmlElement("aspectInconjunct23")]
        public bool aspectInconjunct23;
        [XmlElement("aspectSesquiquadrate23")]
        public bool aspectSesquiquadrate23;
        #endregion

        public SettingXml()
        {
            dispCircle = new bool[6] { true, false, false, false, false, false };
            dispAspect = new bool[6] { true, true, true, true, true, true };
            orb_sun_soft_1st_0 = 8.0;
            orb_sun_soft_1st_1 = 8.0;
            orb_sun_soft_1st_2 = 8.0;
            orb_sun_soft_1st_3 = 8.0;
            orb_sun_soft_1st_4 = 8.0;
            orb_sun_soft_1st_5 = 8.0;
            orb_sun_hard_1st_0 = 4.0;
            orb_sun_hard_1st_1 = 4.0;
            orb_sun_hard_1st_2 = 4.0;
            orb_sun_hard_1st_3 = 4.0;
            orb_sun_hard_1st_4 = 4.0;
            orb_sun_hard_1st_5 = 4.0;
            orb_moon_soft_1st_0 = 8.0;
            orb_moon_soft_1st_1 = 8.0;
            orb_moon_soft_1st_2 = 8.0;
            orb_moon_soft_1st_3 = 8.0;
            orb_moon_soft_1st_4 = 8.0;
            orb_moon_soft_1st_5 = 8.0;
            orb_moon_hard_1st_0 = 4.0;
            orb_moon_hard_1st_1 = 4.0;
            orb_moon_hard_1st_2 = 4.0;
            orb_moon_hard_1st_3 = 4.0;
            orb_moon_hard_1st_4 = 4.0;
            orb_moon_hard_1st_5 = 4.0;
            orb_other_soft_1st_0 = 8.0;
            orb_other_soft_1st_1 = 8.0;
            orb_other_soft_1st_2 = 8.0;
            orb_other_soft_1st_3 = 8.0;
            orb_other_soft_1st_4 = 8.0;
            orb_other_soft_1st_5 = 8.0;
            orb_other_hard_1st_0 = 4.0;
            orb_other_hard_1st_1 = 4.0;
            orb_other_hard_1st_2 = 4.0;
            orb_other_hard_1st_3 = 4.0;
            orb_other_hard_1st_4 = 4.0;
            orb_other_hard_1st_5 = 4.0;
            orb_sun_soft_150_0 = 3.0;
            orb_sun_soft_150_1 = 3.0;
            orb_sun_soft_150_2 = 3.0;
            orb_sun_soft_150_3 = 3.0;
            orb_sun_soft_150_4 = 3.0;
            orb_sun_soft_150_5 = 3.0;
            orb_sun_hard_150_0 = 1.5;
            orb_sun_hard_150_1 = 1.5;
            orb_sun_hard_150_2 = 1.5;
            orb_sun_hard_150_3 = 1.5;
            orb_sun_hard_150_4 = 1.5;
            orb_sun_hard_150_5 = 1.5;
            orb_moon_soft_150_0 = 3.0;
            orb_moon_soft_150_1 = 3.0;
            orb_moon_soft_150_2 = 3.0;
            orb_moon_soft_150_3 = 3.0;
            orb_moon_soft_150_4 = 3.0;
            orb_moon_soft_150_5 = 3.0;
            orb_moon_hard_150_0 = 1.5;
            orb_moon_hard_150_1 = 1.5;
            orb_moon_hard_150_2 = 1.5;
            orb_moon_hard_150_3 = 1.5;
            orb_moon_hard_150_4 = 1.5;
            orb_moon_hard_150_5 = 1.5;
            orb_other_soft_150_0 = 3.0;
            orb_other_soft_150_1 = 3.0;
            orb_other_soft_150_2 = 3.0;
            orb_other_soft_150_3 = 3.0;
            orb_other_soft_150_4 = 3.0;
            orb_other_soft_150_5 = 3.0;
            orb_other_hard_150_0 = 1.5;
            orb_other_hard_150_1 = 1.5;
            orb_other_hard_150_2 = 1.5;
            orb_other_hard_150_3 = 1.5;
            orb_other_hard_150_4 = 1.5;
            orb_other_hard_150_5 = 1.5;
            orb_sun_soft_2nd_0 = 2.0;
            orb_sun_soft_2nd_1 = 2.0;
            orb_sun_soft_2nd_2 = 2.0;
            orb_sun_soft_2nd_3 = 2.0;
            orb_sun_soft_2nd_4 = 2.0;
            orb_sun_soft_2nd_5 = 2.0;
            orb_sun_hard_2nd_0 = 1.0;
            orb_sun_hard_2nd_1 = 1.0;
            orb_sun_hard_2nd_2 = 1.0;
            orb_sun_hard_2nd_3 = 1.0;
            orb_sun_hard_2nd_4 = 1.0;
            orb_sun_hard_2nd_5 = 1.0;
            orb_moon_soft_2nd_0 = 2.0;
            orb_moon_soft_2nd_1 = 2.0;
            orb_moon_soft_2nd_2 = 2.0;
            orb_moon_soft_2nd_3 = 2.0;
            orb_moon_soft_2nd_4 = 2.0;
            orb_moon_soft_2nd_5 = 2.0;
            orb_moon_hard_2nd_0 = 1.0;
            orb_moon_hard_2nd_1 = 1.0;
            orb_moon_hard_2nd_2 = 1.0;
            orb_moon_hard_2nd_3 = 1.0;
            orb_moon_hard_2nd_4 = 1.0;
            orb_moon_hard_2nd_5 = 1.0;
            orb_other_soft_2nd_0 = 2.0;
            orb_other_soft_2nd_1 = 2.0;
            orb_other_soft_2nd_2 = 2.0;
            orb_other_soft_2nd_3 = 2.0;
            orb_other_soft_2nd_4 = 2.0;
            orb_other_soft_2nd_5 = 2.0;
            orb_other_hard_2nd_0 = 1.0;
            orb_other_hard_2nd_1 = 1.0;
            orb_other_hard_2nd_2 = 1.0;
            orb_other_hard_2nd_3 = 1.0;
            orb_other_hard_2nd_4 = 1.0;
            orb_other_hard_2nd_5 = 1.0;
            dispPlanetSun11 = true;
            dispPlanetMoon11 = true;
            dispPlanetMercury11 = true;
            dispPlanetVenus11 = true;
            dispPlanetMars11 = true;
            dispPlanetJupiter11 = true;
            dispPlanetSaturn11 = true;
            dispPlanetUranus11 = true;
            dispPlanetNeptune11 = true;
            dispPlanetPluto11 = true;
            dispPlanetDh11 = true;
            dispPlanetChiron11 = true;
            dispPlanetAsc11 = true;
            dispPlanetMc11 = true;
            dispPlanetEarth11 = true;
            dispPlanetLilith11 = false;
            dispPlanetSun22 = true;
            dispPlanetMoon22 = true;
            dispPlanetMercury22 = true;
            dispPlanetVenus22 = true;
            dispPlanetMars22 = true;
            dispPlanetJupiter22 = true;
            dispPlanetSaturn22 = true;
            dispPlanetUranus22 = true;
            dispPlanetNeptune22 = true;
            dispPlanetPluto22 = true;
            dispPlanetDh22 = true;
            dispPlanetChiron22 = true;
            dispPlanetAsc22 = true;
            dispPlanetMc22 = true;
            dispPlanetEarth22 = true;
            dispPlanetLilith22 = false;
            dispPlanetSun33 = true;
            dispPlanetMoon33 = true;
            dispPlanetMercury33 = true;
            dispPlanetVenus33 = true;
            dispPlanetMars33 = true;
            dispPlanetJupiter33 = true;
            dispPlanetSaturn33 = true;
            dispPlanetUranus33 = true;
            dispPlanetNeptune33 = true;
            dispPlanetPluto33 = true;
            dispPlanetDh33 = true;
            dispPlanetChiron33 = true;
            dispPlanetAsc33 = true;
            dispPlanetMc33 = true;
            dispPlanetEarth33 = true;
            dispPlanetLilith33 = false;
            aspectSun11 = true;
            aspectMoon11 = true;
            aspectMercury11 = true;
            aspectVenus11 = true;
            aspectMars11 = true;
            aspectJupiter11 = true;
            aspectSaturn11 = true;
            aspectUranus11 = true;
            aspectNeptune11 = true;
            aspectPluto11 = true;
            aspectDh11 = true;
            aspectChiron11 = true;
            aspectAsc11 = true;
            aspectMc11 = true;
            aspectEarth11 = true;
            aspectLilith11 = false;
            aspectSun22 = true;
            aspectMoon22 = true;
            aspectMercury22 = true;
            aspectVenus22 = true;
            aspectMars22 = true;
            aspectJupiter22 = true;
            aspectSaturn22 = true;
            aspectUranus22 = true;
            aspectNeptune22 = true;
            aspectPluto22 = true;
            aspectDh22 = true;
            aspectChiron22 = true;
            aspectAsc22 = true;
            aspectMc22 = true;
            aspectEarth22 = true;
            aspectLilith22 = false;
            aspectSun33 = true;
            aspectMoon33 = true;
            aspectMercury33 = true;
            aspectVenus33 = true;
            aspectMars33 = true;
            aspectJupiter33 = true;
            aspectSaturn33 = true;
            aspectUranus33 = true;
            aspectNeptune33 = true;
            aspectPluto33 = true;
            aspectDh33 = true;
            aspectChiron33 = true;
            aspectAsc33 = true;
            aspectMc33 = true;
            aspectEarth33 = true;
            aspectLilith33 = false;
            aspectSun12 = true;
            aspectMoon12 = true;
            aspectMercury12 = true;
            aspectVenus12 = true;
            aspectMars12 = true;
            aspectJupiter12 = true;
            aspectSaturn12 = true;
            aspectUranus12 = true;
            aspectNeptune12 = true;
            aspectPluto12 = true;
            aspectDh12 = true;
            aspectChiron12 = true;
            aspectAsc12 = true;
            aspectMc12 = true;
            aspectEarth12 = true;
            aspectLilith12 = false;
            aspectSun13 = true;
            aspectMoon13 = true;
            aspectMercury13 = true;
            aspectVenus13 = true;
            aspectMars13 = true;
            aspectJupiter13 = true;
            aspectSaturn13 = true;
            aspectUranus13 = true;
            aspectNeptune13 = true;
            aspectPluto13 = true;
            aspectDh13 = true;
            aspectChiron13 = true;
            aspectAsc13 = true;
            aspectMc13 = true;
            aspectEarth13 = true;
            aspectLilith13 = false;
            aspectSun23 = true;
            aspectMoon23 = true;
            aspectMercury23 = true;
            aspectVenus23 = true;
            aspectMars23 = true;
            aspectJupiter23 = true;
            aspectSaturn23 = true;
            aspectUranus23 = true;
            aspectNeptune23 = true;
            aspectPluto23 = true;
            aspectDh23 = true;
            aspectChiron23 = true;
            aspectAsc23 = true;
            aspectMc23 = true;
            aspectEarth23 = true;
            aspectLilith23 = false;
            aspectConjunction11 = true;
            aspectOpposition11 = true;
            aspectTrine11 = true;
            aspectSquare11 = true;
            aspectSextile11 = true;
            aspectInconjunct11 = true;
            aspectSesquiquadrate11 = true;
            aspectConjunction22 = true;
            aspectOpposition22 = true;
            aspectTrine22 = true;
            aspectSquare22 = true;
            aspectSextile22 = true;
            aspectInconjunct22 = true;
            aspectSesquiquadrate22 = true;
            aspectConjunction33 = true;
            aspectOpposition33 = true;
            aspectTrine33 = true;
            aspectSquare33 = true;
            aspectSextile33 = true;
            aspectInconjunct33 = true;
            aspectSesquiquadrate33 = true;
            aspectConjunction12 = true;
            aspectOpposition12 = true;
            aspectTrine12 = true;
            aspectSquare12 = true;
            aspectSextile12 = true;
            aspectInconjunct12 = true;
            aspectSesquiquadrate12 = true;
            aspectConjunction13 = true;
            aspectOpposition13 = true;
            aspectTrine13 = true;
            aspectSquare13 = true;
            aspectSextile13 = true;
            aspectInconjunct13 = true;
            aspectSesquiquadrate13 = true;
            aspectConjunction23 = true;
            aspectOpposition23 = true;
            aspectTrine23 = true;
            aspectSquare23 = true;
            aspectSextile23 = true;
            aspectInconjunct23 = true;
            aspectSesquiquadrate23 = true;
            dispname = "名称未設定";
        }
    }
}
