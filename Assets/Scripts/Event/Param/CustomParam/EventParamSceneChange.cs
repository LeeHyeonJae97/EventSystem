using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Event
{
    public class EventParamSceneChange : IEventParam
    {
        public uint Key { get { return EventKey.SceneChange; } }

        public string SceneName { get; private set; }

        public EventParamSceneChange(string sceneName)
        {
            SceneName = sceneName;
        }
    }
}
