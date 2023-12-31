﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }
        public string? GenreName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
