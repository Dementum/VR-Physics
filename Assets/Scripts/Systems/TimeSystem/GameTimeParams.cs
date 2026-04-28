using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Systems.TimeSystem
{
    [System.Serializable]
    public struct TimeContainer
    {
        public int Minutes;
        public int Hours;
        public int Day;
        public int Week;
        public int Month;
        public int Season;
        public int Year;
    }
    
    [CreateAssetMenu(fileName = "GameTimeParams", menuName = "Scriptables/GameTimeParams")]
    public class GameTimeParams : ScriptableObject
    {
        [FoldoutGroup("TimeValues")]
        public float SecondsPerMinute = 60f;
        [FoldoutGroup("TimeValues")]
        public int MinutesPerHour = 60;
        [FoldoutGroup("TimeValues")]
        public int HoursPerDay = 24;
        [FoldoutGroup("TimeValues")]
        public int DaysPerWeek = 7;
        [FoldoutGroup("TimeValues")]
        public int WeeksPerMonth = 4;
        [FoldoutGroup("TimeValues")]
        public int MonthsPerSeason = 3;
        [FoldoutGroup("TimeValues")]
        public int SeasonsPerYear = 4;
        [FoldoutGroup("TimeValues")] public int FirstSeasonStartMonth = 3;
        public TimeContainer StartTime;

        public int MonthsPerYear => MonthsPerSeason * SeasonsPerYear;
        
        public List<string> DayNames;
        public List<string> MonthNames;
        public List<string> SeasonNames;

        public string GetDayName(int index)
        {
            if (index < 0 || index >= DayNames.Count)
            {
                return string.Empty;
            }
            
            return DayNames[index];
        }

        public string GetMonthName(int index)
        {
            if (index < 0 || index >= MonthNames.Count)
            {
                return string.Empty;
            }

            return MonthNames[index];
        }

        public string GetSeasonName(int index)
        {
            if (index < 0 || index >= SeasonNames.Count)
            {
                return string.Empty;
            }
            
            return  SeasonNames[index];
        }
    }
}
