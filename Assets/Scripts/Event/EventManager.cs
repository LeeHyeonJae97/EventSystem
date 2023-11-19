using System.Collections.Generic;

namespace Event
{
    public class EventManager
    {
        static EventManager Instance
        {
            // TODO :
            // 멀티스레딩에 대비해 Lock 걸기
            //
            get
            {
                if (_instance == null)
                {
                    _instance = new EventManager();
                }
                return _instance;
            }
        }

        static EventManager _instance;

        Dictionary<uint, HashSet<IEventListener>> _dic;

        public EventManager()
        {
            _dic = new Dictionary<uint, HashSet<IEventListener>>();
        }

        public static void AddListener(uint key, IEventListener listener)
        {
            if (key == EventKey.None) return;

            var dic = Instance._dic;

            if (dic.TryGetValue(key, out var listeners))
            {
                listeners.Add(listener);
            }
            else
            {
                dic.Add(key, new HashSet<IEventListener>() { listener });
            }
        }

        public static void AddListener(uint[] keys, IEventListener listener)
        {
            foreach (var key in keys)
            {
                if (key != EventKey.None)
                {
                    AddListener(key, listener);
                }
            }
        }

        public static void RemoveListener(uint key, IEventListener listener)
        {
            if (key == EventKey.None) return;

            var dic = Instance._dic;

            if (dic.TryGetValue(key, out var listeners))
            {
                listeners.Remove(listener);
            }
        }

        public static void RemoveListener(uint[] keys, IEventListener listener)
        {
            foreach (var key in keys)
            {
                if (key != EventKey.None)
                {
                    RemoveListener(key, listener);
                }
            }
        }

        public static void RemoveListener(IEventListener listener)
        {
            var dic = Instance._dic;

            foreach (var listeners in dic.Values)
            {
                listeners.Remove(listener);
            }
        }

        public static void Invoke(IEventParam param)
        {
            Invoke(param.Key, param);
        }

        public static void Invoke(uint key, IEventParam param)
        {
            if (key == EventKey.None) return;

            var dic = Instance._dic;

            if (dic.TryGetValue(key, out var listeners))
            {
                foreach (var listener in listeners)
                {
                    listener.OnEvent(key, param);
                }
            }
        }
    }
}
