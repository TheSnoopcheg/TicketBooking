namespace TicketBooking.classes
{
    public class Discount : Notifier
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double PriceMultiplier { get; set; }
        private int _count;
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged();
            }
        }
        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            var other = obj as Discount;
            if(other == null) return false;
            return Name == other.Name && PriceMultiplier == other.PriceMultiplier;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, PriceMultiplier);
        }
    }
}
