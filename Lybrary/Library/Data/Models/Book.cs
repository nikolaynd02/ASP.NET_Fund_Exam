﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    public class Book
    {
        public Book()
        {
            this.UsersBooks = new HashSet<UserBook>();
        }

        [Key]
        public int Id { get; set; }

        [Required] 
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(5000)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; }

        public virtual ICollection<UserBook> UsersBooks { get; set; }
    }
}
