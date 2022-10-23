
namespace FramdCode
{
    public static class EventModel 
    {
        //事件总线
        private static  EventBus _bus;

        public static void init()
        {
            _bus ??= new EventBus();
        }
        public static void AddObserver(ushort EventID, EventDelegate evn)
        {
            EventModel.init();
            _bus.AddObserver(EventID, evn);
        }
        public static void RemoveObserver(ushort EventID)
        {
            EventModel.init();
            _bus.RemoveObserver(EventID);
        }
        public static void Notify(ushort EventID)
        {
            EventModel.init();
            _bus.Notify(EventID);
        }
    }
}
