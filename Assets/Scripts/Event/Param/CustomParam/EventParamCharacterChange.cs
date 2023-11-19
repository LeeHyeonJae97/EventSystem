using System.Collections;
using System.Collections.Generic;

namespace Event
{
    public class EventParamCharacterChange : IEventParam
    {
        public uint Key { get { return EventKey.CharacterChanged; } }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public EventParamCharacterChange(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
