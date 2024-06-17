namespace TicketBooking.classes
{
    public class TicketType
    {
        public int Id { get; set; }
        public int SeatType { get; set; }
        public string? Color { get; set; }
        public string? TicketName {  get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public List<Discount>? Discounts { get; set; }
    }
}