using System;

namespace Systems.EventSystem
{
    public class GameEvent
    {
        private event Action _eventInternal;
        
        public void Subscribe(Action subscriber)
        {
            _eventInternal += subscriber;
        }

        public void Unsubscribe(Action subscriber)
        {
            _eventInternal -= subscriber;
        }

        public void Invoke()
        {
            _eventInternal?.Invoke();
        }
    }

    public class GameEvent<T>
    {
        private event Action<T> _eventInternal;
        
        public void Subscribe(Action<T> subscriber)
        {
            _eventInternal += subscriber;
        }

        public void Unsubscribe(Action<T> subscriber)
        {
            _eventInternal -= subscriber;
        }

        public void Invoke(T value)
        {
            _eventInternal?.Invoke(value);
        }
    }
}