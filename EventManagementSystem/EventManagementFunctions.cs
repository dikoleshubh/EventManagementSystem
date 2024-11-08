using System;
using System.Collections.Generic;

namespace EventManagementSystem
{

    public class EventManager
    {
        private Dictionary<int, EventEntity> events = new Dictionary<int, EventEntity>();

        private int nextId = 0;

        public EventEntity CreateEvent(string name, string description, DateTime date, string location)
        {
            var newEvent = new EventEntity(nextId++, name, description, date, location);
            events.Add(newEvent.Id, newEvent);
            return newEvent;
        }

        public bool DeleteEvent(int id)
        {
            return events.Remove(id);
        }

        public EventEntity GetEvent(int id)
        {
            events.TryGetValue(id, out EventEntity evnt);
            return evnt;
        }

        public List<EventEntity> ListEvents()
        {
            return new List<EventEntity>(events.Values);
        }

        public bool UpdateEvent(int id, string name, string description, DateTime? date, string location)
        {
            if (events.TryGetValue(id, out EventEntity evnt))
            {
                if (!string.IsNullOrEmpty(name)) evnt.Name = name;
                if (!string.IsNullOrEmpty(description)) evnt.Description = description;
                if (date.HasValue) evnt.Date = date.Value;
                if (!string.IsNullOrEmpty(location)) evnt.Location = location;
                return true;
            }
            return false;
        }
    }
}
