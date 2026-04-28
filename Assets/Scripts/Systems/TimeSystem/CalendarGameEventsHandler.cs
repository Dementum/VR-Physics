using System;

namespace Systems.TimeSystem
{
    public class CalendarGameEventsHandler : ICalendarEventsHandler
    {
        public void SubscribeOnMinuteUpdate(Action<int> subscriber)
        {
            GameEventSystem.CalendarEvents.MinutesUpdated.Subscribe(subscriber);
        }

        public void UnSubscribeOnMinuteUpdate(Action<int> subscriber)
        {
            GameEventSystem.CalendarEvents.MinutesUpdated.Unsubscribe(subscriber);
        }

        public void InvokeOnMinuteUpdate(int value)
        {
            GameEventSystem.CalendarEvents.MinutesUpdated.Invoke(value);
        }

        public void SubscribeOnHourUpdate(Action<int> subscriber)
        {
            GameEventSystem.CalendarEvents.HoursUpdated.Subscribe(subscriber);
        }

        public void UnSubscribeOnHourUpdate(Action<int> subscriber)
        {
            GameEventSystem.CalendarEvents.HoursUpdated.Unsubscribe(subscriber);
        }

        public void InvokeOnHourUpdate(int value)
        {
            GameEventSystem.CalendarEvents.HoursUpdated.Invoke(value);
        }

        public void SubscribeOnDayUpdate(Action<int> subscriber)
        {
            GameEventSystem.CalendarEvents.DaysUpdated.Subscribe(subscriber);
        }

        public void UnSubscribeOnDayUpdate(Action<int> subscriber)
        {
            GameEventSystem.CalendarEvents.DaysUpdated.Unsubscribe(subscriber);
        }

        public void InvokeOnDayUpdate(int value)
        {
            GameEventSystem.CalendarEvents.DaysUpdated.Invoke(value);
        }

        public void SubscribeOnWeekUpdate(Action<int> subscriber)
        {
            GameEventSystem.CalendarEvents.WeeksUpdated.Subscribe(subscriber);
        }

        public void UnSubscribeOnWeekUpdate(Action<int> subscriber)
        {
            GameEventSystem.CalendarEvents.WeeksUpdated.Unsubscribe(subscriber);
        }

        public void InvokeOnWeekUpdate(int value)
        {
            GameEventSystem.CalendarEvents.WeeksUpdated.Invoke(value);
        }

        public void SubscribeOnMonthUpdate(Action<int> subscriber)
        {
            GameEventSystem.CalendarEvents.MonthsUpdated.Subscribe(subscriber);
        }

        public void UnSubscribeOnMonthUpdate(Action<int> subscriber)
        {
            GameEventSystem.CalendarEvents.MonthsUpdated.Unsubscribe(subscriber);
        }

        public void InvokeOnMonthUpdate(int value)
        {
            GameEventSystem.CalendarEvents.MonthsUpdated.Invoke(value);
        }

        public void SubscribeOnSeasonUpdate(Action<int> subscriber)
        {
            GameEventSystem.CalendarEvents.SeasonsUpdated.Subscribe(subscriber);
        }

        public void UnSubscribeOnSeasonUpdate(Action<int> subscriber)
        {
            GameEventSystem.CalendarEvents.SeasonsUpdated.Unsubscribe(subscriber);
        }

        public void InvokeOnSeasonUpdate(int value)
        {
            GameEventSystem.CalendarEvents.SeasonsUpdated.Invoke(value);
        }

        public void SubscribeOnYearUpdate(Action<int> subscriber)
        {
            GameEventSystem.CalendarEvents.YearsUpdated.Subscribe(subscriber);
        }

        public void UnSubscribeOnYearUpdate(Action<int> subscriber)
        {
            GameEventSystem.CalendarEvents.YearsUpdated.Unsubscribe(subscriber);
        }

        public void InvokeOnYearUpdate(int value)
        {
            GameEventSystem.CalendarEvents.YearsUpdated.Invoke(value);
        }
    }
}