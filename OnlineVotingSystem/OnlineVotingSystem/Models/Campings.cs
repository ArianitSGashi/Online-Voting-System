using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace OnlineVotingSystem.Models
{
    public class Campaign
    {
        [Key]
        public int CampaignID { get; set; }

        [ForeignKey("Election")]
        public int ElectionID { get; set; }

        [ForeignKey("Candidate")]
        public int CandidateID { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public Elections Elections { get; set; }
        public Candidates Candidates { get; set; }
    }
}
