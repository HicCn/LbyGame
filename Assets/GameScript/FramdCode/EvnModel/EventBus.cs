
using System;
using System.Collections.Generic;

namespace FramdCode
{
    //事件委托
    public delegate void EventDelegate(EventObject evn);
    //事件传参
    public abstract class EventObject { }
    public class EventBus {
        //用字典存储事件
        readonly Dictionary<ushort, List<EventDelegate>> _dic;
        public EventBus()
        {
            _dic = new Dictionary<ushort, List<EventDelegate>>();
        }

        public void AddObserver(ushort EventID, EventDelegate evn)
        {
            try
            {
                _dic[EventID].Add(new EventDelegate(evn));
            }
            catch
            {
                List<EventDelegate> tL = new List<EventDelegate>();
                tL.Add(new EventDelegate(evn));
                _dic.Add(EventID, tL);

            }
        }
        public void RemoveObserver(ushort EventID)
        {
            try
            {
                _dic.Remove(EventID);
            }
            catch
            {
                
            }
        }
        public void Notify(ushort EventID)
        {
            try
            {
                foreach (var evn in _dic[EventID])
                {
                    evn.Invoke(null);
                }
            }
            catch{
               
            }
        }
    }

}

