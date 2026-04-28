using Systems.EventSystem;

namespace Systems
{
    public class CalendarEventContainer
    {
        public GameEvent<int> MinutesUpdated =  new GameEvent<int>();
        public GameEvent<int> HoursUpdated =  new GameEvent<int>();
        public GameEvent<int> DaysUpdated =  new GameEvent<int>();
        public GameEvent<int> WeeksUpdated =  new GameEvent<int>();
        public GameEvent<int> MonthsUpdated =  new GameEvent<int>();
        public GameEvent<int> SeasonsUpdated =  new GameEvent<int>();
        public GameEvent<int> YearsUpdated =  new GameEvent<int>();
    }

    public class GameLifeCycleEventContainer
    {
        public GameEvent GameStarted = new GameEvent();
        public GameEvent GamePaused = new GameEvent();
        public GameEvent GameFinished = new GameEvent();
    }
    
    public static partial class GameEventSystem
    {
        public static CalendarEventContainer CalendarEvents =  new CalendarEventContainer();
        public static GameLifeCycleEventContainer GameLifeCycleEvents = new GameLifeCycleEventContainer();
    }
}