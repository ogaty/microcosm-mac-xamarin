﻿using System;
using microcosm.Common;
using microcosm.Config;
using microcosm.Models;

namespace microcosm.Calc
{
    public class TrineAspect : AbstractAspect
    {
        public TrineAspect(SettingData setting,
                                int ringIndex, 
                                int fromPlanetNumber,
                                int toPlanetNumber,
                                PlanetData from, PlanetData to) : base(setting, ringIndex,
                                                                       fromPlanetNumber, toPlanetNumber, from, to)
        {
            aspectDegree = (double)AspectDegrees.TRINE;
        }

        public override AspectInfo CreateAspectInfo(int i, int j, bool isDisp)
        {
            return new AspectInfo()
            {
                aspectKind = AspectKind.TRINE,
                softHard = softHard,
                absoluteDegree = from.absolute_position,
                targetDegree = to.absolute_position,
                srcPlanetNo = i,
                targetPlanetNo = j,
                isDisp = isDisp
            };
        }
    }
}
