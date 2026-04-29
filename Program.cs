using System.Runtime.CompilerServices;

namespace Grand_Azure_Hotel_System
{
    internal class Program
    {
        public static void DisplayMenu()
        {
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
        private static string fullName;
        private static string nationalID;

        private static int totalGuestsCreated = 0;

    }

    class Room
    {
        static int roomNumber;
        static string roomType;
        static bool isBooked;


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
    }
}
