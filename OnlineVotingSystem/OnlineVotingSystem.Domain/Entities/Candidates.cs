using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVotingSystem.Models
{
    public class Candidates
    {
        /// <summary>
        /// Gets or sets the unique identifier for the candidate.
        /// </summary>
        [Key]
        public int CandidateID { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier for the election the candidate is participating in.
        /// </summary>
        [ForeignKey("Election")]
        public int ElectionID { get; set; }
        /// <summary>
        /// Gets or sets the full name of the candidate.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        /// <summary>
        /// Gets or sets the political party of the candidate.
        /// </summary>
        [MaxLength(50)]
        public string Party { get; set; }
        /// <summary>
        /// Gets or sets a description of the candidate.
        /// </summary>
        [MaxLength(500)]
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the declared income of the candidate.
        /// </summary>
        [Column(TypeName = "decimal(10,2)")]
        public decimal Income { get; set; }
        /// <summary>
        /// Gets or sets the works and achievements of the candidate.
        /// </summary>
        [MaxLength(500)]
        public string Works { get; set; }
        /// <summary>
        /// Navigation property to the associated Election entity.
        /// </summary>
        public Elections Elections { get; set; }
    }
}
