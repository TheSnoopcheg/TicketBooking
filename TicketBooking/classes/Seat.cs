﻿namespace TicketBooking.classes
{
    public class Seat
    {
        public int Id { get; set; }
        public SeatType Type { get; set; }
        public string? Number { get; set; }
        public int Row { get; set; }
        public string? Status { get; set; }
    }
}

namespace TicketBooking 
{
    public enum SeatType
    {
        Ordinary,
        Sofa,
        Loveseat,
        Reckliner,
        Balcony
    }
}