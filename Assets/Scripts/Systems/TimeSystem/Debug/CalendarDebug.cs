using GameSystems;
using TMPro;
using UnityEngine;

namespace Tools.TimeSystem.Debug
{
    public class CalendarDebug : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _debugOutput;
        [SerializeField] private GameSystems.TimeSystem _timeSystem;
        private ICalendar _calendar;
        
        private void Start()
        {
            if (!_timeSystem)
            {
                return;
            }
            _calendar = _timeSystem.Calendar;
            _calendar?.Events.SubscribeOnMinuteUpdate(UpdateOutput);
        }

        private void UpdateOutput(int _)
        {
            _debugOutput.text = $"{_calendar.Hour} : {_calendar.Minute}, {_calendar.Day}, {_calendar.Date} {_calendar.Month}, {_calendar.Year}, {_calendar.Season}";
        }
    }
}
