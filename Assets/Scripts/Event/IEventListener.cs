namespace Event
{
    public interface IEventListener
    {
        void AddEventListener();

        void RemoveEventListener();

        void OnEvent(uint key, IEventParam param);
    }
}
