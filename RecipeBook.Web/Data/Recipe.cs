using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Web.Data
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required, MaxLength(120)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(60)]
        public string? Category { get; set; }

        [Required]
        public string Ingredients { get; set; } = string.Empty;

        [Required]
        public string Steps { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? ImagePath { get; set; }

        public string? OwnerId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        }
    }
