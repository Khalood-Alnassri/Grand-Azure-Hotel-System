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

            while (true)
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

        // constructor to add new guest
        public Guest(string name, string ID)
        {
            SetName(name); // set name by using property
            nationalID = ID;
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

        // Property to get-only room number
        public int GetRoomNumber()
        {
            return roomNumber;
        }

        // Property to get-only room type
        public string GetRoomType()
        {
            return roomType;
        }

        // Property to get-only romm is booked
        public bool GetIsBooked()
        {
            return isBooked;
        }

        // constructor to add new room 
        public Room(int number, string type)
        {
            roomNumber = number;
            roomType = type;
            isBooked = false;
        }

        // method to booked room
        public bool Book()
        {
            if (isBooked == true) // is room booked? == true
            {
                Console.WriteLine("The already booked.");
                return false; // room book is fail
            }

            else // is room booked? == false / not booked
            {
                Console.WriteLine("The room booked successful."); // book the room
                isBooked = true; // make it true
                return true; // room book 
            }
        }

        // method to cancel booking
        public void CancelBooking()
        {
            if (isBooked == false) // is room booked? == false / not booked
            {
                Console.WriteLine("The room is not booked yet.");
            }
            else // is room booked? == true
            {
                Console.WriteLine("The booking canceled successful."); // cancel the booking
                isBooked = false; // make it false
            }
        }

        // method to display room information
        public void DisplayInfo()
        {
            string status = isBooked ? "Booked" : "Available"; // if isBooked == true => status = "Booked" / if isBooked == false => status = "Available"
            Console.WriteLine("Room number: " + roomNumber + " | " + "Room type: " + roomType + " | " + "Status: " + status);
        }
    }
    class Booking
    {
        int bookingID;
        int nextBookingID;
        Room room;
        Guest guest;

        // property to get-only booking ID
        public int GetBookingID()
        {
            return bookingID;
        }

        // property to get-only guest
        public Guest GetGuest()
        {
            return guest;
        }

        // property to get-only room
        public Room GetRoom()
        {
            return room;
        }

        // constructor to add new booking
        public Booking(Room room, Guest guest)
        {
            this.room = room;
            this.guest = guest;
            bookingID = ++nextBookingID; // generate unique booking ID
        }

        // method to display booking information
        public void DisplayInfo()
        {
            Console.WriteLine("Booking ID: " + bookingID);
            Console.WriteLine("Guest Name: " + guest.GetName());
            Console.WriteLine("Room Number: " + room.GetRoomNumber());
        }

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

        //-------------Guest Methods--------------//

        // add new guest
        public void AddGuest(string name, string id)
        {
            foreach (Guest guest in guests)
            {
                if (guest.GetNationalID() == id)
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


        //--------------Room Methods-------------//

        // add new room
        public void AddRoom(int number, string type)
        {
            foreach (Room room in rooms)
            {
                if (room.GetRoomNumber() == number)
                {
                    Console.WriteLine("The room is already exist.");
                    return;
                }
            }
            rooms.Add(new Room(number, type));
        }

        //Display available rooms
        public void DisplayAvailableRooms()
        {
            Console.WriteLine("Available Rooms:");
            foreach (Room room in rooms)
            {
                if (!room.GetIsBooked())
                {
                    room.DisplayInfo();
                }
            }

        }

        //Display booked rooms
        public void DisplayBookedRooms()
        {
            Console.WriteLine("Booked Rooms:");
            foreach (Room room in rooms)
            {
                if (room.GetIsBooked())
                {
                    room.DisplayInfo();
                }
            }
        }

        //-------------Booking Methods------------//

        // book a room
        public void BookRoom(int roomNumber, string guestID)
        {
            Room room = rooms.Find(r => r.GetRoomNumber() == roomNumber); // find the room by room number
            Guest guest = guests.Find(g => g.GetNationalID() == guestID); // find the guest by national ID

            if (room == null)
            {
                Console.WriteLine("The room does not exist.");
                return;
            }
            if (guest == null)
            {
                Console.WriteLine("The guest does not exist.");
                return;
            }
            if (room.Book())
            {
                bookings.Add(new Booking(room, guest)); // add new booking to the list of bookings
            }
        }

        // cancel a booking
        public void CancelBooking(int bookingID)
        {
            Booking booking = bookings.Find(b => b.GetBookingID() == bookingID); // find the booking by booking ID

            if (booking == null)
            {
                Console.WriteLine("The booking does not exist.");
                return;
            }

            booking.GetRoom().CancelBooking(); // cancel the booking of the room
            bookings.Remove(booking); // remove the booking from the list
        }

        // search guest booking by national ID
        public void SearchGuestBooking(string guestID)
        {
            Guest guest = guests.Find(g => g.GetNationalID() == guestID); // find the guest by national ID

            if (guest == null)
            {
                Console.WriteLine("The guest does not exist.");
                return;
            }

            Console.WriteLine("Bookings for Guest: " + guest.GetName());

            foreach (Booking booking in bookings)
            {
                if (booking.GetGuest().GetNationalID() == guestID)
                {
                    booking.DisplayInfo();
                }
            }
        }

        // Display hotel statistics
        public void DisplayStatistics()
        {
            Console.WriteLine("Hotel Name: " + HotelName);
            Console.WriteLine("Total Guests: " + guests.Count);
            Console.WriteLine("Total Rooms: " + rooms.Count);
            Console.WriteLine("Total Bookings: " + bookings.Count);
        }

    }
}
