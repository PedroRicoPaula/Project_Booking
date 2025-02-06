using System.Dynamic;

namespace Classes
{
    public class Hotel
    {
        public string Name { get; set; }
        public int Rooms {  get; set; }
        public int CapacityRoom { get; set; }
        public float Price { get; set; }

        public Hotel(string name, int rooms, int capacityroom, float price) 
        { 
            Name = name;
            Rooms = rooms;
            CapacityRoom = capacityroom;
            Price = price;
        }
    }
}
