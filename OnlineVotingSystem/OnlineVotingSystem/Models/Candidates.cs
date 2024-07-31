using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace OnlineVotingSystem.Models
{
    public class Candidates
    {
        [Key]
        public int CandidateID { get; set; }

        [ForeignKey("Election")]
        public int ElectionID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(50)]
        public string Party { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Income { get; set; }

        [MaxLength(500)]
        public string Works { get; set; }

        // Navigation Properties
        public Elections Elections { get; set; }
    }
}
