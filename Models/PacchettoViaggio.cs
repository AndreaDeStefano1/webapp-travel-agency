namespace webapp_travel_agency.Models
{
    public class PacchettoViaggio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public Destination Destination 
    }
}
