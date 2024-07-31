using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineVotingSystem.Models
{
    public class Complaints
    {
        /// <summary>
        /// Gets or sets the unique identifier for the complaint.
        /// </summary>
        [Key]
        public int ComplaintID { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier of the user who filed the complaint.
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier of the election related to the complaint.
        /// </summary>
        public int ElectionID { get; set; }
        /// <summary>
        /// Gets or sets the text of the complaint.
        /// </summary>
        public string ComplaintText { get; set; }
        /// <summary>
        /// Gets or sets the date the complaint was filed.
        /// </summary>
        public DateTime ComplaintDate { get; set; }
        /// <summary>
        /// Navigation property to the associated Election entity.
        /// </summary>
        public Elections Elections { get; set; }
    }
}
