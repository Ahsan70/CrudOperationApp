using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudOperationUsingEF.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(225)]
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Display(Name="Number in Stock")]
        public byte NumberInStock { get; set; }
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

    }
}