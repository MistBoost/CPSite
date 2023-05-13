namespace DAL.Models
{
    public class TravelCommand
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Participant { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Transportation { get; set; }
        public string Status { get; set; }

        public TravelCommand(int id, DateTime dateCreated, string participant, string startLocation, string endLocation, DateTime startTime,
            DateTime endTime, string transportation, string status)
        {
            Id = id;
            DateCreated = dateCreated;
            Participant = participant;
            StartLocation = startLocation;
            EndLocation = endLocation;
            StartTime = startTime;
            EndTime = endTime;
            Transportation = transportation;
            Status = status;
        }

        public TravelCommand()
        {
            
        }
    }
}
