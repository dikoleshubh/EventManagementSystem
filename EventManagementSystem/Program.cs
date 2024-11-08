using System;
using System.Collections.Generic;
using System.Globalization;

namespace EventManagementSystem
{
    // Event class to store individual event details
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }

        public Event(int id, string name, string description, DateTime date, string location)
        {
            Id = id;
            Name = name;
            Description = description;
            Date = date;
            Location = location;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Date: {Date:yyyy-MM-dd}, Location: {Location}";
        }

        public string DetailedInfo()
        {
            return $"Event Details:\nName: {Name}\nDescription: {Description}\nDate: {Date:yyyy-MM-dd}\nLocation: {Location}";
        }
    }



    class Program
    {
        static void Main()
        {
            EventManager eventManager = new EventManager();
            Console.WriteLine("Welcome to the Event Management System!");

            while (true)
            {
                Console.WriteLine("\nPlease enter a command from any of these option" +
                    "\ncreate" +
                    "\nlist" +
                    "\nget" +
                    "\nupdate" +
                    "\ndelete" +
                    "\nexit");
                Console.Write("> ");
                string command = Console.ReadLine()?.ToLower();

                switch (command)
                {
                    case "create":
                        CreateEvent(eventManager);
                        break;

                    case "list":
                        ListEvents(eventManager);
                        break;

                    case "get":
                        GetEvent(eventManager);
                        break;

                    case "update":
                        UpdateEvent(eventManager);
                        break;

                    case "delete":
                        DeleteEvent(eventManager);
                        break;

                    case "exit":
                        Console.WriteLine("Exiting the Event Management System. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
            }
        }

        static void CreateEvent(EventManager eventManager)
        {
            Console.Write("Enter Event Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Description (optional): ");
            string description = Console.ReadLine();

            Console.Write("Enter Date (yyyy-MM-dd): ");
            DateTime date;
            while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                Console.Write("Invalid date format. Please enter Date (yyyy-MM-dd): ");
            }

            Console.Write("Enter Location (optional): ");
            string location = Console.ReadLine();

            var newEvent = eventManager.CreateEvent(name, description, date, location);
            Console.WriteLine("Event created successfully!");
            Console.WriteLine(newEvent);
        }

        static void ListEvents(EventManager eventManager)
        {
            var events = eventManager.ListEvents();
            if (events.Count == 0)
            {
                Console.WriteLine("No events available.");
            }
            else
            {
                foreach (var evnt in events)
                {
                    Console.WriteLine(evnt);
                }
            }
        }

        static void GetEvent(EventManager eventManager)
        {
            Console.Write("Enter Event ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var evnt = eventManager.GetEvent(id);
                if (evnt != null)
                {
                    Console.WriteLine(evnt.DetailedInfo());
                }
                else
                {
                    Console.WriteLine("Event not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }

        static void UpdateEvent(EventManager eventManager)
        {
            Console.Write("Enter Event ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Enter new Event Name (leave empty to keep current): ");
                string name = Console.ReadLine();

                Console.Write("Enter new Description (leave empty to keep current): ");
                string description = Console.ReadLine();

                Console.Write("Enter new Date (leave empty to keep current): ");
                DateTime? date = null;
                string dateInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(dateInput))
                {
                    if (DateTime.TryParseExact(dateInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                    {
                        date = parsedDate;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Keeping the current date.");
                    }
                }

                Console.Write("Enter new Location (leave empty to keep current): ");
                string location = Console.ReadLine();

                if (eventManager.UpdateEvent(id, name, description, date, location))
                {
                    Console.WriteLine("Event updated successfully!");
                }
                else
                {
                    Console.WriteLine("Event not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }

        static void DeleteEvent(EventManager eventManager)
        {
            Console.Write("Enter Event ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (eventManager.DeleteEvent(id))
                {
                    Console.WriteLine("Event deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Event not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }
    }
}
