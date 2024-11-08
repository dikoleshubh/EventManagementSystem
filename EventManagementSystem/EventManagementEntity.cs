using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem
{

    public class EventManager
    {
        private Dictionary<int, Event> events = new Dictionary<int, Event>();

        private int nextId = 0;

        public Event CreateEvent(string name, string description, DateTime date, string location)
        {
            var newEvent = new Event(nextId++, name, description, date, location);
            events.Add(newEvent.Id, newEvent);
            return newEvent;
        }

        public bool DeleteEvent(int id)
        {
            return events.Remove(id);
        }

        public Event GetEvent(int id)
        {
            events.TryGetValue(id, out Event evnt);
            return evnt;
        }

        public List<Event> ListEvents()
        {
            return new List<Event>(events.Values);
        }

        public bool UpdateEvent(int id, string name, string description, DateTime? date, string location)
        {
            if (events.TryGetValue(id, out Event evnt))
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
