using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection_v2.Models
{
    public class Film
    {
        [Key] //primary key
        public int FilmID { get; set; }

        //model properties
        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }
        
        public bool Edited { get; set; } //optional (nullable)

        public string LentTo { get; set; } //optional (nullable)

        [MaxLength(25)]
        public string Notes { get; set; } //optional (nullable)
    }
}