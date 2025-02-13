using System.ComponentModel.DataAnnotations;

namespace MovieCollectionApp.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required]
        public string Category { get; set; } = null!; // or make it nullable/required property
        
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; } = null!;

        [Required]
        public string Rating { get; set; } = null!;

        // Optional fields
        public bool Edited { get; set; } // no longer nullable

        public string? LentTo { get; set; }

        [StringLength(25)]
        public string? Notes { get; set; }  // also consider making it nullable
    }
}