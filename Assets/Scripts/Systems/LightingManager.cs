using Systems.EventSystem;
using Systems.TimeSystem;
using UnityEngine;

namespace Systems
{
    public class LightingManager : MonoBehaviour
    {
        [SerializeField] private Light _sun;
        [SerializeField] private GameTimeParams _timeParams;
        [SerializeField] private float _sunRotationAngle = 90f;

        private float _anglePerHour;

        private const float CIRCLE_DEGREES = 360f;
        
        private void RotateSun(int hour)
        {
            _sun.transform.rotation = Quaternion.Euler(hour * _anglePerHour - _sunRotationAngle, 0, 0);
        }

        private void CalculateAnglePerHour()
        {
            _anglePerHour = CIRCLE_DEGREES / _timeParams.HoursPerDay;
        }
        
        private void Start()
        {
            CalculateAnglePerHour();
            GameEventSystem.CalendarEvents.HoursUpdated.Subscribe(RotateSun);
        }
    }
}