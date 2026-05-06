using System;
using System.Linq;
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
            Console.WriteLine("9. Exit.");
            Console.WriteLine("10. Display Available Rooms by types.");
            Console.WriteLine("====================================");
        }

        public static int ChooseOption()
        {
            int option;

            while (true)
            {
                Console.Write("Choose option you need: ");
                string input = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(input, out option) && option >= 1 && option <= 10)
                {
                    return option;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 10.");
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
            Console.WriteLine("Guest added successfully.");
        }

        // case 2: function to add new room
        public static void AddRoom()
        {
            Console.WriteLine("Enter room number: ");
            int number = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.WriteLine("Enter room type: ");
            string type = (Console.ReadLine() ?? string.Empty).Trim().ToLower();

            Console.WriteLine("Enter nightly rate: ");
            decimal num = decimal.Parse(Console.ReadLine() ?? string.Empty);

            hotil.AddRoom(number, type, num);
            Console.WriteLine("Room added successfully.");
        }

        // case 3: function to book a room
        public static void BookRoom()
        {
            Console.WriteLine("Enter room number: ");
            int roomNumber = int.Parse(Console.ReadLine() ?? string.Empty)
                ;
            Console.WriteLine("Enter guest national ID: ");
            string guestID = Console.ReadLine();

            Console.WriteLine("Enter number of nights: ");
            int num = int.Parse(Console.ReadLine() ?? string.Empty);

            hotil.BookRoom(roomNumber, guestID, num);
            Console.WriteLine("Room booked successfully.");
        }

        // case 4: function to cancel a booking
        public static void CancelBooking()
        {
            Console.WriteLine("Enter booking ID: ");
            int bookingID = int.Parse(Console.ReadLine() ?? string.Empty);

            hotil.CancelBooking(bookingID);
        }

        // case 5: function to display available rooms
        public static void DisplayAvailableRooms()
        {
            hotil.DisplayAvailableRooms();
        }

        // case 6: function to display booked rooms
        public static void DisplayBookedRooms()
        {
            hotil.DisplayBookedRooms();
        }

        // case 7: function to search guest booking by national ID
        public static void SearchGuestBooking()
        {
            Console.WriteLine("Enter guest national ID: ");
            string guestID = Console.ReadLine();

            hotil.SearchGuestBooking(guestID);
        }

        // case 8: function to display hotel statistics
        public static void DisplayStatistics()
        {
            hotil.DisplayStatistics();
        }

        // case 9: function to exit the program
        public static bool Exit()
        {
            Console.WriteLine("Are you sure you want to exit? (yes/no): ");
            string confirmExit = Console.ReadLine() ?? string.Empty;

            if (confirmExit == "yes")
            {
                Console.WriteLine("Exiting system...");
                Console.WriteLine("Thank you for using the Healthcare Management System!");
                return true;
            }

            else
            {
                Console.WriteLine("Returning to menu...");
                return false;
            }
        }

        public static void DisplayAvailableRoomsByTypes()
        {
            Console.WriteLine("Enter room type to filter (Standard, Deluxe, Suite): ");
            string type = (Console.ReadLine() ?? string.Empty).Trim().ToLower();

            hotil.DisplayAvailableRoomsByTypes(type);
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

                        AddRoom();

                        break;

                    case 3:

                        BookRoom();

                        break;

                    case 4:

                        CancelBooking();

                        break;

                    case 5:

                        DisplayAvailableRooms();

                        break;

                    case 6:

                        DisplayBookedRooms();

                        break;

                    case 7:

                        SearchGuestBooking();

                        break;

                    case 8:

                        DisplayStatistics();

                        break;

                    case 9:

                        exit = Exit();

                        break;

                    case 10:

                        DisplayAvailableRoomsByTypes();

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
            if (string.IsNullOrWhiteSpace(guest) || guest.Trim().Length < 3)
            {
                Console.WriteLine("Name must be at least 3 chars.!");
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
            Console.WriteLine("Guest added successfully.");
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
        decimal NightlyRate;

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
        public bool GetIsBooked { get; }

        // property to set room type
        public void SetRoomType(string type)
        {

            if (type == "standard")
            {
                roomType = "Standard";
            }

            else if (type == "deluxe")
            {
                roomType = "Deluxe";
            }

            else if (type == "suite")
            {
                roomType = "Suite";
            }
            else
            {
                Console.WriteLine("Invalid room type. Please enter 'Standard', 'Deluxe', or 'Suite'.");
            }
        }

        // property to get-only nightly rate
        public decimal GetNightlyRate { get; }

        // constructor to add new room 
        public Room(int number, string type, decimal nightRate)
        {
            roomNumber = number;
            SetRoomType(type);
            isBooked = false;
            NightlyRate = nightRate;
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
        int Nights;
        decimal TotalCost;

        // property to get-only booking ID
        public int GetBookingID { get; }

        // property to get-only guest
        public Guest GetGuest { get; }

        // property to get-only room
        public Room GetRoom { get; }

        // property to get-only number of nights
        public int GetNights { get; }

        // property to get-only total cost
        public decimal GetTotalCost()
        {
            return TotalCost;
        }

        // constructor to add new booking
        public Booking(Room room, Guest guest, int night)
        {
            this.room = room;
            this.guest = guest;
            this.Nights = night;

            TotalCost = room.GetNightlyRate * night; // calculate total cost by multiplying nightly rate by number of nights

            bookingID = ++nextBookingID; // generate unique booking ID
        }

        // method to display booking information
        public void DisplayInfo()
        {
            Console.WriteLine("Booking ID: " + bookingID);
            Console.WriteLine("Guest Name: " + guest.GetName());
            Console.WriteLine("Room Number: " + room.GetRoomNumber());
            Console.WriteLine("Nights: " + Nights);
            Console.WriteLine("Total Cost: " + TotalCost.ToString("F3") + "OMR");
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
        public void AddRoom(int number, string type, decimal num)
        {
            foreach (Room room in rooms)
            {
                if (room.GetRoomNumber() == number)
                {
                    Console.WriteLine("The room is already exist.");
                    return;
                }
            }
            rooms.Add(new Room(number, type, num));
        }

        //Display available rooms
        public void DisplayAvailableRooms()
        {
            Console.WriteLine("Available Rooms:");
            foreach (Room room in rooms)
            {
                if (!room.GetIsBooked)
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
                if (room.GetIsBooked)
                {
                    room.DisplayInfo();
                }
            }
        }

        //-------------Booking Methods------------//

        // book a room
        public void BookRoom(int roomNumber, string guestID, int num)
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
                bookings.Add(new Booking(room, guest, num)); // add new booking to the list of bookings
            }
        }

        // cancel a booking
        public void CancelBooking(int bookingID)
        {
            Booking booking = bookings.Find(b => b.GetBookingID == bookingID); // find the booking by booking ID

            if (booking == null)
            {
                Console.WriteLine("The booking does not exist.");
                return;
            }

            Console.WriteLine("Guest: " + booking.GetGuest.GetName);
            Console.WriteLine("Room Number: " + booking.GetRoom.GetRoomNumber + ", " + "Nights: " + booking.GetNights);
            Console.WriteLine("Cost: " + booking.GetTotalCost().ToString("F3") + "OMR");

            booking.GetRoom.CancelBooking(); // cancel the booking of the room
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
                if (booking.GetGuest.GetNationalID() == guestID)
                {
                    booking.DisplayInfo();
                }
            }
        }

        //-----------------Display hotel statistics-----------------//
        public void DisplayStatistics()
        {
            int totalRooms = rooms.Count;
            int bookedRooms = bookings.Count;
            int availableRooms = totalRooms - bookedRooms;

            if (bookings.Count == 0) // if there is no booking, display message and return
            {
                Console.WriteLine("No bookings found. Total cost is 0 OMR.");
                return;
            }

            // calculate total costs by summing the total cost of all bookings
            decimal totalCosts = 0;
            foreach (Booking booking in bookings)
            {
                totalCosts += booking.GetTotalCost();
            }

            // calculate average revenue per booking by dividing total costs by number of bookings
            decimal average = totalCosts / bookings.Count;


            Console.WriteLine("================Hotel Statistics====================");
            Console.WriteLine("Hotel Name: " + HotelName);
            Console.WriteLine("Total Guests: " + guests.Count);
            Console.WriteLine("Total Rooms: " + totalRooms);
            Console.WriteLine("Total Bookings: " + bookedRooms);
            Console.WriteLine("Available Rooms: " + availableRooms);
            Console.WriteLine("Total Revenue: " + totalCosts.ToString("F3") + "OMR");
            Console.WriteLine("Average Revenue per Booking: " + average.ToString("F3") + "OMR");
            Console.WriteLine("====================================================");
        }

        //------------------------display available rooms by types--------------------------
        public void DisplayAvailableRoomsByTypes(string type)
        {
            Console.WriteLine("Available " + type + " Rooms:");
            foreach (Room room in rooms)
            {
                if (!room.GetIsBooked && string.Equals(room.GetRoomType(), type, StringComparison.OrdinalIgnoreCase))
                {
                    room.DisplayInfo();
                }
            }

            Console.WriteLine("No available " + type + " rooms are found.");
        }
    }
}
