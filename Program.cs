using System;
using System.Runtime.CompilerServices;

namespace Grand_Azure_Hotel_System
{

    internal class Program
    {
        public static Hotel hotil = new Hotel("Grand Azure Hotel");

        public static void DisplayMenu()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("===== Grand Azure Hotel System =====");
            Console.WriteLine("1. Add Guest.");
            Console.WriteLine("2. Add Room.");
            Console.WriteLine("3. Book a Room.");
            Console.WriteLine("4. Cancel Booking.");
            Console.WriteLine("5. Display Available Rooms.");
            Console.WriteLine("6. Display Booked Rooms.");
            Console.WriteLine("7. Search Guest by National ID.");
            Console.WriteLine("8. Show Hotel Statistics.");
            Console.WriteLine("9. Exit");
            Console.WriteLine("====================================");
        }

        public static int ChooseOption()
        {
            int option;

            while(true)
            {
                Console.Write("Choose option you need: ");
                string input = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(input, out option) && option >= 1 && option <= 9)
                {
                    return option;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                }
            }
        }

        // case 1: function to add new guest
        public static void AddGuest()
        {
            Console.WriteLine("Enter the name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter national ID: ");
            string id = Console.ReadLine();

            hotil.AddGuest(name, id);
        }

     
        static void Main(string[] args)
        { 
            bool exit = false;
            while (!exit)
            {
                DisplayMenu();

                int option = ChooseOption();
                 switch (option)
                 { 
                    case 1:

                        AddGuest();

                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    case 6:
                        break;

                    case 7:
                        break;

                    case 8:
                        break;

                    case 9:
                      
                        break;

                    default:

                        Console.WriteLine("Invalid option. Please choose from the list.!");

                        break;

                 }

                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }


    class Guest
    {
        private string fullName;
        private string nationalID;

        private static int totalGuestsCreated = 0;

        // Property to set name
        public void SetName(string guest)
        {
            if (guest.IsWhiteSpace())
            {
                Console.WriteLine("Please enter a valid name!");
            }

            else
            {
                fullName = guest;
            }
        }

        // Property to get name
        public string GetName()
        {
            return fullName;
        }

        // Property to get-only national ID
        public string GetNationalID()
        {
            return nationalID;
        }

        // method to count total guest created
        public static int getTotalGuestsCreated()
        {
            return totalGuestsCreated; 
        }

        // const to add new guest
        public Guest(string name, string ID)
        {
            this.fullName = name;
            this.nationalID = ID;
            totalGuestsCreated++;
        }

        // method to display guest information
        public void DisplayInfo()
        {
            Console.WriteLine("Guest name: " + fullName + " | " + "National ID: " + nationalID);
        }


    }

    class Room
    {
        int roomNumber;
        string roomType;
        bool isBooked;

    



    }

    class Booking
    {
        static int bookingID;
        static int nextBookingID;
        static Room room;
        static Guest guest;

    }


    class Hotel
    {
        private List<Guest> guests = new List<Guest>();
        private List<Room> rooms = new List<Room>();
        private List<Booking> bookings = new List<Booking>();

        public static string HotelName;

        public Hotel(string name)
        {
            HotelName = name;
            guests = new List<Guest>();
            rooms = new List<Room>();
            bookings = new List<Booking>();
        }

        //Guest Methods//
        // add new guest
        public void AddGuest(string name, string id)
        {
            foreach (Guest guest in guests)
            {
                if(guest.GetNationalID() == id)
                {
                    Console.WriteLine("The guest is already exist.");
                    return;
                }
            }

            guests.Add(new Guest(name, id));
        }

        // find guest by national id
        public Guest FindGuest(string id)
        {
            return guests.Find(g => g.GetNationalID() == id);
        }



    }
}
