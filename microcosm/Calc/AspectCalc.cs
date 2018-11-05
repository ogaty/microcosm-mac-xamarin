using System;
using System.Collections.Generic;
using microcosm.Common;
using microcosm.Config;
using microcosm.Models;

namespace microcosm.Calc
{
    public class AspectCalc
    {
        
        public AspectCalc()
        {
            
        }

        /// <summary>
        /// アスペクト計算
        /// </summary>
        /// <returns>The calculate same.</returns>
        /// <param name="planetList">Planet list.</param>
        /// <param name="ringIndex">ringIndex(0〜6)</param>
        public List<AspectInfo> AspectCalcSame(List<PlanetData> planetList, int ringIndex) 
        {
            List<AspectInfo> aspects = new List<AspectInfo>();
            int settingIndex = 0;
            SettingData setting = Common.CommonInstance.getInstance().settings[settingIndex];
            int j = 0;
            int aspectIndex = ringIndex;
            for (int i = 0; i < planetList.Count - 1; i++)
            {
                for (j = i + 1; j < planetList.Count; j++)
                {
                    bool isDisp = true;
                    if (!setting.dispAspectPlanet[aspectIndex][planetList[i].no] ||
                        !setting.dispAspectPlanet[aspectIndex][planetList[j].no])
                    {
                        Console.WriteLine(String.Format("{0} {1} planet nodisp", i.ToString(), j.ToString()));
                        isDisp = false;
                        continue;
                    }
                    if (!setting.dispPlanet[aspectIndex][planetList[i].no] ||
                        !setting.dispPlanet[aspectIndex][planetList[j].no])
                    {
                        Console.WriteLine(String.Format("{0} {1} aspect nodisp", i.ToString(), j.ToString()));
                        isDisp = false;
                        continue;
                    }

//                    Console.WriteLine(String.Format("{0},{1}", planetList[i].absolute_position, planetList[j].absolute_position));

                    OppositionAspect opposition = new OppositionAspect(setting, ringIndex, i, j, planetList[i], planetList[j]);
                    if (opposition.Between(planetList[j].absolute_position - planetList[i].absolute_position)) 
                    {
                        if (!setting.aspectOpposition[ringIndex, ringIndex])
                        {
                            isDisp = false;
                        }
                        else 
                        {
                            aspects.Add(opposition.CreateAspectInfo(i, j, isDisp));
                        }
                        continue;
                    }

                    TrineAspect trine = new TrineAspect(setting, ringIndex, i, j, planetList[i], planetList[j]);
                    if (trine.Between(planetList[j].absolute_position - planetList[i].absolute_position))
                    {
                        if (!setting.aspectTrine[ringIndex, ringIndex])
                        {
                            isDisp = false;
                        }
                        else 
                        {
                            aspects.Add(trine.CreateAspectInfo(i, j, isDisp));
                        }
                        continue;
                    }

                    SquareAspect square = new SquareAspect(setting, ringIndex, i, j, planetList[i], planetList[j]);
                    if (square.Between(planetList[j].absolute_position - planetList[i].absolute_position))
                    {
                        if (!setting.aspectSquare[ringIndex, ringIndex])
                        {
                            isDisp = false;
                        }
                        else {
                            aspects.Add(square.CreateAspectInfo(i, j, isDisp));
                        }
                        continue;
                    }

                    SextileAspect sextile = new SextileAspect(setting, ringIndex, i, j, planetList[i], planetList[j]);
                    if (sextile.Between(planetList[j].absolute_position - planetList[i].absolute_position))
                    {
                        if (!setting.aspectSextile[ringIndex, ringIndex])
                        {
                            isDisp = false;
                        }
                        else {
                            aspects.Add(sextile.CreateAspectInfo(i, j, isDisp));
                        }
                    }
                    // TODO
                }
            }
            

            return aspects;
        }

        public List<AspectInfo> AspectCalcOther(List<PlanetData> planetListA, List<PlanetData> planetListB, int ringIndex, int ringIndexTo)
        {
            List<AspectInfo> aspects = new List<AspectInfo>();
            int settingIndex = 0;
            SettingData setting = Common.CommonInstance.getInstance().settings[settingIndex];
            int j = 0;
            for (int i = 0; i < planetListA.Count; i++)
            {
                for (j = 0; j < planetListB.Count; j++)
                {
                    bool isDisp = true;
                    if (!setting.dispAspectPlanet[ringIndex][planetListA[i].no] ||
                        !setting.dispAspectPlanet[ringIndex][planetListB[j].no])
                    {
                        isDisp = false;
                        continue;
                    }

                    //                    Console.WriteLine(String.Format("{0},{1}", planetList[i].absolute_position, planetList[j].absolute_position));

                    OppositionAspect opposition = new OppositionAspect(setting, ringIndex, i, j, planetListA[i], planetListB[j]);
                    if (!setting.aspectOpposition[ringIndex, ringIndexTo])
                    {
                        isDisp = false;
                    }
                    if (opposition.Between(planetListB[j].absolute_position - planetListA[i].absolute_position))
                    {
                        aspects.Add(opposition.CreateAspectInfo(i, j, isDisp));
                    }

                    TrineAspect trine = new TrineAspect(setting, ringIndex, i, j, planetListA[i], planetListB[j]);
                    if (!setting.aspectTrine[ringIndex, ringIndexTo])
                    {
                        isDisp = false;
                    }
                    if (trine.Between(planetListB[j].absolute_position - planetListA[i].absolute_position))
                    {
                        aspects.Add(trine.CreateAspectInfo(i, j, isDisp));
                    }

                    SquareAspect square = new SquareAspect(setting, ringIndex, i, j, planetListA[i], planetListB[j]);
                    if (!setting.aspectSquare[ringIndex, ringIndexTo])
                    {
                        isDisp = false;
                    }
                    if (square.Between(planetListB[j].absolute_position - planetListA[i].absolute_position))
                    {
                        aspects.Add(square.CreateAspectInfo(i, j, isDisp));
                    }

                    SextileAspect sextile = new SextileAspect(setting, ringIndex, i, j, planetListA[i], planetListB[j]);
                    if (!setting.aspectSextile[ringIndex, ringIndexTo])
                    {
                        isDisp = false;
                    }
                    if (sextile.Between(planetListB[j].absolute_position - planetListA[i].absolute_position))
                    {
                        aspects.Add(sextile.CreateAspectInfo(i, j, isDisp));
                    }
                }
            }

            return aspects;
        }


        public bool Between(double target, double from, double to) {
            if (from <= target && target < to) {
                return true;
            }
            return false;
        }
    }
}
