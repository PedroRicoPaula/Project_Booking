namespace Classes
{
    public class Reservation
    {
        public string HotelName { get; set; }
        public int RoomNumber { get; set; }
        public int NumberOfGuests { get; set; }
        public bool BreakfastIncluded { get; set; }

        public Reservation(string hotelName, int roomNumber, int numberOfGuests, bool breakfastIncluded)
        {
            HotelName = hotelName;
            RoomNumber = roomNumber;    
            NumberOfGuests = numberOfGuests;
            BreakfastIncluded = breakfastIncluded;
        }

        public override string ToString()
        {
            return $"Hotel: {HotelName}, RoomNumber: {RoomNumber}, NumberOfGuests: {NumberOfGuests}, Breakfast: {(BreakfastIncluded ? "Yes" : "No")}";
        }
    }
}
