using System.ComponentModel.DataAnnotations;

namespace OnlineVotingSystem.Models
{
    public class Elections
    {
        [Key]
        public int ElectionID {get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
    }
}
