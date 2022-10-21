
using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class PacchettoViaggio
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int Duration { get; set; }
        public string? Description { get; set; }
        //errore lasciato al singolare per comodità
        public List<Destination>? Destinations { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Image { get; set; }
        public List<Message> Messages { get; set; }

        public PacchettoViaggio()
        {
        }

    }
}
