using System.Collections.Generic;

namespace Event
{
    /// <summary>
    /// Common EventParam class with string value
    /// </summary>
    public class EventParamString : IEventParam
    {
        public uint Key { get { return 0; } }

        public string Value { get; private set; }

        public EventParamString(string value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// Common EventParam class with int value
    /// </summary>
    public class EventParamInt : IEventParam
    {
        public uint Key { get { return 0; } }

        public int Value { get; private set; }

        public EventParamInt(int value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// Common EventParam class with float value
    /// </summary>
    public class EventParamFloat : IEventParam
    {
        public uint Key { get { return 0; } }

        public float Value { get; private set; }

        public EventParamFloat(float value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// Common EventParam class with string collection value
    /// </summary>
    public class EventParamStringCollection : IEventParam
    {
        public uint Key { get { return 0; } }

        public IEnumerable<string> Values { get; private set; }

        public EventParamStringCollection(IEnumerable<string> values)
        {
            Values = values;
        }
    }

    /// <summary>
    /// Common EventParam class with integer collection value
    /// </summary>
    public class EventParamIntCollection : IEventParam
    {
        public uint Key { get { return 0; } }

        public IEnumerable<int> Values { get; private set; }

        public EventParamIntCollection(IEnumerable<int> values)
        {
            Values = values;
        }
    }

    /// <summary>
    /// Common EventParam class with float collection value
    /// </summary>
    public class EventParamFloatCollection : IEventParam
    {
        public uint Key { get { return 0; } }

        public IEnumerable<float> Values { get; private set; }

        public EventParamFloatCollection(IEnumerable<float> values)
        {
            Values = values;
        }
    }
}
