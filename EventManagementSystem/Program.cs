using System;

namespace EventManagementSystem
{
    class Program
    {
        static void Main()
        {
            EventManager eventManager = new EventManager();
            EventManagementMethod eventManagerDef = new EventManagementMethod();
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
                        eventManagerDef.CreateEvent(eventManager);
                        break;

                    case "list":
                        eventManagerDef.ListEvents(eventManager);
                        break;

                    case "get":
                        eventManagerDef.GetEvent(eventManager);
                        break;

                    case "update":
                        eventManagerDef.UpdateEvent(eventManager);
                        break;

                    case "delete":
                        eventManagerDef.DeleteEvent(eventManager);
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


    }
}
