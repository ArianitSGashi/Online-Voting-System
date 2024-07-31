using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineVotingSystem.Models
{
    public class Elections
    {
        /// <summary>
        /// Gets or sets the unique identifier for the election.
        /// </summary>
        [Key]
        public int ElectionID { get; set; }
        /// <summary>
        /// Gets or sets the title of the election.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description of the election.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the start date and time of the election.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Gets or sets the end date and time of the election.
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Gets or sets the date and time when the election was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the date and time when the election was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
