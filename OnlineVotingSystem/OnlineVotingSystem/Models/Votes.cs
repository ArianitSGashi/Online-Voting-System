using Microsoft.AspNetCore.Routing.Matching;
using System.ComponentModel.DataAnnotations;

namespace OnlineVotingSystem.Models
{
    public class Votes
    {
        [Key]
        public int VoteID { get; set; }
        public int UserID { get; set; }
        public int ElectionID { get; set; }
        public int CandidateID { get; set; }
        public DateTime VoteDate { get; set; }

        //Foreign Key
        public Candidates Candidates {  get; set; }
        public Elections Elections { get; set; }


    }
}
