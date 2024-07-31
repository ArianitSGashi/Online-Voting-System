using System.ComponentModel.DataAnnotations;

namespace OnlineVotingSystem.Models
{
    public class Complaints
    {
        [Key]
        public int ComplaintID { get; set; }
        public int UserID { get; set; }
        public int ElectionID { get; set; }
        public string ComplaintText { get; set; }
        public DateTime ComplaintDate { get; set; }

        //Foreign Key
        public Elections Elections { get; set; }    
    }
}
