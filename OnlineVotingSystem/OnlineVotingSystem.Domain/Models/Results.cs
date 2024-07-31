using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace OnlineVotingSystem.Models
{
    public class Result
    {
        [Key]
        public int ResultID { get; set; }

        [ForeignKey("Election")]
        public int ElectionID { get; set; }

        [ForeignKey("Candidate")]
        public int CandidateID { get; set; }

        public int TotalVotes { get; set; }

        // Navigation Properties
        public Elections Elections { get; set; }
        public Candidates Candidates { get; set; }
    }
}
