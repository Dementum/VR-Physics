using System;

namespace Tools.TimeSystem
{
    public interface ICalendarEventsHandler
    {
        public void SubscribeOnMinuteUpdate(Action<int> subscriber);
        public void UnSubscribeOnMinuteUpdate(Action<int> subscriber);
        public void InvokeOnMinuteUpdate(int value);
        
        public void SubscribeOnHourUpdate(Action<int> subscriber);
        public void UnSubscribeOnHourUpdate(Action<int> subscriber);
        public void InvokeOnHourUpdate(int value);
        
        
        public void SubscribeOnDayUpdate(Action<int> subscriber);
        public void UnSubscribeOnDayUpdate(Action<int> subscriber);
        public void InvokeOnDayUpdate(int value);
        
        
        public void SubscribeOnWeekUpdate(Action<int> subscriber);
        public void UnSubscribeOnWeekUpdate(Action<int> subscriber);
        public void InvokeOnWeekUpdate(int value);
        
        
        public void SubscribeOnMonthUpdate(Action<int> subscriber);
        public void UnSubscribeOnMonthUpdate(Action<int> subscriber);
        public void InvokeOnMonthUpdate(int value);
        
        
        public void SubscribeOnSeasonUpdate(Action<int> subscriber);
        public void UnSubscribeOnSeasonUpdate(Action<int> subscriber);
        public void InvokeOnSeasonUpdate(int value);
        
        
        public void SubscribeOnYearUpdate(Action<int> subscriber);
        public void UnSubscribeOnYearUpdate(Action<int> subscriber);
        public void InvokeOnYearUpdate(int value);
        
    }
}