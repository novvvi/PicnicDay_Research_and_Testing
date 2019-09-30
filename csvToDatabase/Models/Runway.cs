using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace csvToDatabase.Models
{
    public class Runway
    {
        [Key]
        public int runway_id {get; set;}

        [Required]
        public string ident {get; set;}
        [Required]
        public string name {get; set;}
        [Required]
        public string runway {get; set;}
        [Required]
        public string latitude {get; set;}
        [Required]
        public string longitude {get; set;}

        public DateTime updatedAt {get;set;} = DateTime.Now;

    }
}