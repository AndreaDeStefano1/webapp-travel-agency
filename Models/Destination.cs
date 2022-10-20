using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class Destination
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        public List<PacchettoViaggio>? PacchettiViaggio { get; set; }


        public Destination()
        {

        }
    }
}