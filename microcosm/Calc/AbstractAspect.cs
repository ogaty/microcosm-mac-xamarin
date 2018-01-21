﻿using System;
using microcosm.Common;
using microcosm.Config;
using microcosm.Models;

namespace microcosm.Calc
{
    public abstract class AbstractAspect
    {
        protected int ringIndex;
        protected int fromPlanetNumber;
        protected int toPlanetNumber;
        protected PlanetData from;
        protected PlanetData to;
        protected SettingData setting;
        protected SoftHard softHard;
        protected double aspectDegree;

        public AbstractAspect(
            SettingData setting, 
            int ringIndex,
            int fromPlanetNumber,
            int toPlanetNumber,
            PlanetData from, PlanetData to)
        {
            this.setting = setting;
            this.ringIndex = ringIndex;
            this.fromPlanetNumber = fromPlanetNumber;
            this.toPlanetNumber = toPlanetNumber;
            this.from = from;
            this.to = to;
        }

        public abstract AspectInfo CreateAspectInfo(int i, int j, bool isDisp);

        public bool Between(double targetDegree, double from, double to)
        {
            double absTargetDegree = Math.Abs(targetDegree);
            if (absTargetDegree > 180)
            {
                absTargetDegree = 360 - absTargetDegree;
            }
            Console.WriteLine("{0},{1},{2}", absTargetDegree, from, to);
            if (from <= absTargetDegree && absTargetDegree < to)
            {
                return true;
            }
            return false;
        }

        public bool Between(double targetDegree)
        {
            if (fromPlanetNumber == CommonData.ZODIAC_NUMBER_SUN || toPlanetNumber == CommonData.ZODIAC_NUMBER_SUN)
            {
                if (Between(targetDegree,
                                 aspectDegree - setting.orbs[ringIndex][OrbKind.SUN_SOFT_1ST],
                                 aspectDegree + setting.orbs[ringIndex][OrbKind.SUN_SOFT_1ST]))
                {
                    softHard = SoftHard.SOFT;
                    return true;
                }
                else if (Between(targetDegree,
                                      aspectDegree - setting.orbs[ringIndex][OrbKind.SUN_HARD_1ST],
                                      aspectDegree + setting.orbs[ringIndex][OrbKind.SUN_HARD_1ST]))
                {
                    softHard = SoftHard.HARD;
                    return true;
                }
            }
            else if (fromPlanetNumber == CommonData.ZODIAC_NUMBER_MOON || toPlanetNumber == CommonData.ZODIAC_NUMBER_MOON)
            {
                if (Between(targetDegree,
                                 aspectDegree - setting.orbs[ringIndex][OrbKind.MOON_SOFT_1ST],
                                 aspectDegree + setting.orbs[ringIndex][OrbKind.MOON_SOFT_1ST]))
                {
                    softHard = SoftHard.SOFT;
                    return true;
                }
                else if (Between(targetDegree,
                                      aspectDegree - setting.orbs[ringIndex][OrbKind.MOON_HARD_1ST],
                                      aspectDegree + setting.orbs[ringIndex][OrbKind.MOON_HARD_1ST]))
                {
                    softHard = SoftHard.HARD;
                    return true;
                }
            }
            else
            {
                if (Between(targetDegree,
                                 aspectDegree - setting.orbs[ringIndex][OrbKind.OTHER_SOFT_1ST],
                                 aspectDegree + setting.orbs[ringIndex][OrbKind.OTHER_SOFT_1ST]))
                {
                    softHard = SoftHard.SOFT;
                    return true;
                }
                else if (Between(targetDegree,
                                      aspectDegree - setting.orbs[ringIndex][OrbKind.OTHER_HARD_1ST],
                                      aspectDegree + setting.orbs[ringIndex][OrbKind.OTHER_HARD_1ST]))
                {
                    softHard = SoftHard.HARD;
                    return true;
                }
            }
            return false;
        }

    }
}
