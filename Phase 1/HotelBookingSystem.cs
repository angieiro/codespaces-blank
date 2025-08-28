
using System;
using System.Collections.Generic;
using System.Linq;

public class Room
{
    public int RoomNumber { get; set; }
    public decimal PricePerNight { get; set; }
    public bool IsOccupied { get; set; }

    public Room(int roomNumber, decimal pricePerNight)
    {
        this.RoomNumber = roomNumber;
        this.PricePerNight = pricePerNight;
        this.IsOccupied = false;
    }
    public Room(int roomNumber) : this(roomNumber, 0) { }
    public Room() : this(-99, 0) { }
    public void BookRoom()
    {
        this.IsOccupied = true;
    }

    public void VacateRoom()
    {
        this.IsOccupied = false;
    }

}

public class StandardRoom : Room
{
    public bool HasTV { get; set; }
    public StandardRoom(int roomNumber, decimal pricePerNight, bool hasTV) : base(roomNumber, pricePerNight)
    {
        HasTV = hasTV;
    }
    public StandardRoom(int roomNumber, decimal pricePerNight) : base(roomNumber, pricePerNight)
    {
        HasTV = true;
    }
}

public class DeluxeRoom : Room
{
    public bool HasMiniBar { get; set; }
    public DeluxeRoom(int roomNumber, decimal pricePerNight, bool hasMiniBar) : base(roomNumber, pricePerNight)
    {
        HasMiniBar = hasMiniBar;
    }
    public DeluxeRoom(int roomNumber, decimal pricePerNight) : base(roomNumber, pricePerNight)
    {
        HasMiniBar = true;
    }
}

public class Booking
{
    public string CustomerName { get; set; }
    public Room Room { get; set; }
    public int Nights { get; set; }

    public Booking(Room room, string customerName, int nights)
    {
        room.BookRoom();
        Room = room;
        CustomerName = customerName;
        Nights = nights;
    }
    public decimal CalculateTotalCost()
    {
        return Room.PricePerNight * Nights;
    }
}

public class Hotel
{
    public List<Room> Rooms { get; set; }
    public List<Booking> Bookings { get; set; }
    public Hotel()
    {
        Rooms = new List<Room>();
        Bookings = new List<Booking>();
    }
    public void AddRoom(Room room)
    {
        Rooms.Add(room);
    }

    public void ShowAvailableRooms()
    {
        string availableRoomsStr = Rooms.Where(x => !x.IsOccupied)
        .Select(x => x.RoomNumber.ToString())
        .Aggregate((r, next) => r + ", " + next);
        Console.WriteLine($"Available Rooms: {availableRoomsStr}");
    }

    public void BookRoom(int roomNumber, string customerName, int nights)
    {
        if (Rooms.Any(x => x.RoomNumber == roomNumber && !x.IsOccupied))
        {
            Room bookedRoom = Rooms.FirstOrDefault(x => x.RoomNumber == roomNumber);
            Booking booking = new Booking(bookedRoom, customerName, nights);
            Bookings.Add(booking);
        }
    }

    public void BookRoom(Booking booking)
    {
        BookRoom(booking.Room.RoomNumber, booking.CustomerName, booking.Nights);
    }

}

public static class HotelBookingSystem
{
    public static void Reception()
    {
        Hotel hotelOrfeas = new Hotel();
        hotelOrfeas.AddRoom(new StandardRoom(100, 80, false));
        hotelOrfeas.AddRoom(new StandardRoom(101, 95, true));
        hotelOrfeas.AddRoom(new StandardRoom(102, 85, true));
        hotelOrfeas.AddRoom(new DeluxeRoom(200, 150));

        hotelOrfeas.ShowAvailableRooms();

        Room roomToBook = hotelOrfeas.Rooms.FirstOrDefault(x => x.RoomNumber == 200);
        Booking newbooking = new Booking(roomToBook, "Lina Nikolakopoulou", 5);
        hotelOrfeas.BookRoom(newbooking);

        hotelOrfeas.ShowAvailableRooms();
    }
}