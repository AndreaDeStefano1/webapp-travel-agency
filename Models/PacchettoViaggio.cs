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
        //errore lasciato al singolare per comodità
        public List<Destination>? Destination { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Image { get; set; }

        public PacchettoViaggio()
        {
        }

    }
}
