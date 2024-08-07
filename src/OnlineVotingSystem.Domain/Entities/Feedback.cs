﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace OnlineVotingSystem.Domain.Entities
{
    public class Feedback
    {
        /// <summary>
        /// Unique identifier for the feedback.
        /// </summary>
        [Key]
        public int FeedbackID { get; set; }
        /// <summary>
        /// Unique identifier for the user providing the feedback.
        /// </summary>
        public string UserID { get; set; } = null!;
        /// <summary>
        /// Unique identifier for the election associated with the feedback.
        /// </summary>
        [ForeignKey("Election")]
        public int ElectionID { get; set; }
        /// <summary>
        /// Text content of the feedback provided by the user.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string FeedbackText { get; set; } = null!;
        /// <summary>
        /// Date and time when the feedback was provided.
        /// </summary>
        public DateTime FeedbackDate { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// Election object associated with the feedback, representing the election details.
        /// </summary>
        public Elections Elections { get; set; } = null!;
    }
}
