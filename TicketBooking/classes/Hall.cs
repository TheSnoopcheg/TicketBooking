namespace TicketBooking.classes
{
    public class Hall
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Row>? Rows { get; set; } = new List<Row>();
        public int RowsNum { get; set; }
        public int MaxSeatsToPick { get; set; }
    }
}
