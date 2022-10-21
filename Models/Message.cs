using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using webapp_travel_agency.Models;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace webapp_travel_agency.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        public int SmartBoxId { get; set; }
        [AllowNull]
        public PacchettoViaggio? SmartBox { get; set; }

        public Message()
        {
        }
    }
}
