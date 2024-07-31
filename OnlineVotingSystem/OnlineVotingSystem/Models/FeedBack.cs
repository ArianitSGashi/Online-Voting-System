using System.ComponentModel.DataAnnotations;

namespace OnlineVotingSystem.Models
{
    public class FeedBack
    {
        [Key]
        public int FeedbackID { get; set; }
        public int UserID { get; set; }
        public int ElectionID { get; set; }
        public string FeedbackText { get; set; }
        public DateTime FeedbackDate { get; set; }

        //Foreign Key
        public Elections Elections { get; set; }
    }
}
