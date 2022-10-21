using NuGet.Protocol.Plugins;

namespace webapp_travel_agency.Models
{
    public class SupportModel
    {
        public Destination? Destination { get; set; }
        public List<Destination>? DestinationsList { get; set; }
        public List<int> DestinationsIds { get; set; }
        public PacchettoViaggio? PacchettoViaggio { get; set; }
        public List<PacchettoViaggio>? PacchettoViaggioList { get; set; }
        public Message? Message { get; set; }
    }
}
