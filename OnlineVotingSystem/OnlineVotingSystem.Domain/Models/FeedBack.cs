using System.ComponentModel.DataAnnotations;

namespace OnlineVotingSystem.Models
{
    public class FeedBack
    {
        /// <summary>
        /// Unique identifier for the feedback.
        /// </summary>
        [Key]
        public int FeedbackID { get; set; }
        /// <summary>
        /// Unique identifier for the user providing the feedback.
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// Unique identifier for the election associated with the feedback.
        /// </summary>
        public int ElectionID { get; set; }
        /// <summary>
        /// Text content of the feedback provided by the user.
        /// </summary>
        public string FeedbackText { get; set; }
        /// <summary>
        /// Date and time when the feedback was provided.
        /// </summary>
        public DateTime FeedbackDate { get; set; }
        // Foreign Key
        /// <summary>
        /// Election object associated with the feedback, representing the election details.
        /// </summary>
        public Elections Elections { get; set; }
    }
}