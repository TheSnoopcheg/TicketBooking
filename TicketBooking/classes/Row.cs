namespace TicketBooking.classes
{
    public class Row
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<Seat>? Seats { get; set; }
    }
}
