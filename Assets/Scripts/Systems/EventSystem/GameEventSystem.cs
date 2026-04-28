namespace Systems.EventSystem
{
    public class ExampleEventContainer
    {
        public static GameEvent ExampleEvent = new GameEvent();
        public static GameEvent<int> ExampleIntEvent = new GameEvent<int>();
    }
    
    public static partial class GameEventSystem
    {
        public static ExampleEventContainer ExampleEvents =  new ExampleEventContainer();
    }
}