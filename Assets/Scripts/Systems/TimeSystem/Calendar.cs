using System;

namespace Systems.TimeSystem
{
    public interface ICalendar
    {
        public int Minute { get; }
        public int Hour{ get; }
        public int Date { get; }
        public string Day{ get; }
        public int Week{ get; }
        public string Month{ get; }
        public string Season { get; }
        public int Year{ get; }
        
        public void Increment(float timeIncrement);
        
        public ICalendarEventsHandler Events { get; }
    }

    [System.Serializable]
    public class Calendar : ICalendar
    {
        public int Minute => _minute - 1;
        public int Hour  => _hour;
        public int Date => _week * _gameTimeParams.DaysPerWeek + _day + 1;
        public string Day  => _gameTimeParams.GetDayName(_day);
        public int Week => _week + 1;
        public string Month  => _gameTimeParams.GetMonthName(_month);
        public string Season => _gameTimeParams.GetSeasonName(GetSeasonIndex());
        public int Year  => _year;

        public ICalendarEventsHandler Events { get; } = new CalendarGameEventsHandler();

        private GameTimeParams _gameTimeParams;
        private float _timeStamp = 0;

        private int _minute;
        private int _hour;
        private int _day;
        private int _week;
        private int _month;
        private int _season;
        private int _year;

        public Calendar(GameTimeParams gameTimeParams)
        {
            _gameTimeParams = gameTimeParams;
            _minute = gameTimeParams.StartTime.Minutes;
            _hour = gameTimeParams.StartTime.Hours;
            _day = gameTimeParams.StartTime.Day;
            _week = gameTimeParams.StartTime.Week;
            _month = gameTimeParams.StartTime.Month;
            _year = gameTimeParams.StartTime.Year;
        }
        
        public void Increment(float timeIncrement)
        {
            _timeStamp += timeIncrement;

            if (!TryIncrementTimeValue(ref _timeStamp, _gameTimeParams.SecondsPerMinute, ref _minute))
            {
                return;
            }
            Events.InvokeOnMinuteUpdate(_minute);
            
            if (!TryIncrementTimeValue(ref _minute, _gameTimeParams.MinutesPerHour, ref _hour))
            {
                return;
            }
            Events.InvokeOnHourUpdate(_hour);
            
            if (!TryIncrementTimeValue(ref _hour, _gameTimeParams.HoursPerDay, ref _day))
            {
                return;
            }
            Events.InvokeOnDayUpdate(_day);
            
            if (!TryIncrementTimeValue(ref _day, _gameTimeParams.DaysPerWeek, ref _week))
            {
                return;
            }
            Events.InvokeOnWeekUpdate(_week);
            
            if (!TryIncrementTimeValue(ref _week, _gameTimeParams.WeeksPerMonth, ref _month))
            {
                return;
            }
            Events.InvokeOnMonthUpdate(_month);

            int season = GetSeasonIndex();
            if (_season != season)
            {
                _season = season;
                Events.InvokeOnSeasonUpdate(_season);
            }
            
            if (!TryIncrementTimeValue(ref _month, _gameTimeParams.MonthsPerYear, ref _year))
            {
                return;
            }
            Events.InvokeOnYearUpdate(_year);
        }

        private bool TryIncrementTimeValue(ref float inValue, float valueLimit, ref int incrementableValue)
        {
            if (inValue < valueLimit)
            {
                return false;
            }

            incrementableValue++;
            inValue -= valueLimit;
            return true;
        }
    
        private bool TryIncrementTimeValue(ref int inValue, int valueLimit, ref int incrementableValue)
        {
            if (inValue < valueLimit)
            {
                return false;
            }

            incrementableValue++;
            inValue -= valueLimit;
            return true;
        }
        
        private int GetSeasonIndex()
        {
            return GetMonthIndexFromDelta(_month, _gameTimeParams.FirstSeasonStartMonth) /  _gameTimeParams.MonthsPerSeason;
        }

        private int GetMonthIndexFromDelta(int currentIndex, int delta)
        {
            int diff = currentIndex - delta;
            return diff < 0 ? diff + _gameTimeParams.MonthsPerYear : diff;
        }
    }
}