﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVotingSystem.Models
{
  
    public class Campaign
    {
        /// <summary>
        /// Unique identifier for the campaign.
        /// </summary>
        [Key]
        public int CampaignID { get; set; }
        /// <summary>
        /// Unique identifier for the election associated with the campaign.
        /// </summary>
        [ForeignKey("Election")]
        public int ElectionID { get; set; }
        /// <summary>
        /// Unique identifier for the candidate associated with the campaign.
        /// </summary>
        [ForeignKey("Candidate")]
        public int CandidateID { get; set; }
        /// <summary>
        /// Description of the campaign.
        /// </summary>
        [MaxLength(500)]
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the start date of the campaign.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Gets or sets the end date of the campaign.
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Gets or sets the date and time when the campaign was created.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// Gets or sets the date and time when the campaign was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// Navigation property to the associated Election entity.
        /// </summary>
        public Elections Elections { get; set; }
        /// <summary>
        /// Navigation property to the associated Candidate entity.
        /// </summary>
        public Candidates Candidates { get; set; }
    }
}
