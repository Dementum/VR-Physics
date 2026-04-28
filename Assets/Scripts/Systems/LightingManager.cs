using Tools.EventSystem;
using Tools.TimeSystem;
using UnityEngine;

namespace Systems
{
    public class LightingManager : MonoBehaviour
    {
        [SerializeField] private Light _sun;
        [SerializeField] private GameTimeParams _timeParams;

        private float _anglePerHour;
        
        private void RotateSun(int hour)
        {
            _sun.transform.rotation = Quaternion.Euler(hour * _anglePerHour - 90, 0, 0);
        }

        private void CalculateAnglePerHour()
        {
            _anglePerHour = 360f / _timeParams.HoursPerDay;
        }
        
        private void Start()
        {
            CalculateAnglePerHour();
            GameEventSystem.CalendarEvents.HoursUpdated.Subbscribe(RotateSun);
        }
    }
}