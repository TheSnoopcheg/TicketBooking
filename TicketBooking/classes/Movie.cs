namespace TicketBooking.classes
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public double Rating { get; set; } 
        public string? Country { get; set; }
        public string? Genre { get; set; }
        public string? ReleaseYear { get; set; }
        public string? Description { get; set; }
        public string? Duration { get; set; }
        public string? AgeRestriction { get; set; }
        public string? ImageUrl { get; set; }
        public string? Director { get; set; }
        public string? Actors { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
