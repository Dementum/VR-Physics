using UnityEngine;

namespace Systems.TimeSystem
{
    public class TimeSystem : MonoBehaviour
    {
        [SerializeField] private GameTimeParams _timeParams;
        
        public ICalendar Calendar => _calendar;
        
        private ICalendar _calendar;

        public void Init()
        {
            _calendar = new Calendar(_timeParams);
        }

        private void UpdateCalendar()
        {
            _calendar.Increment(Time.deltaTime);
        }

        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            UpdateCalendar();
        }
    }
}