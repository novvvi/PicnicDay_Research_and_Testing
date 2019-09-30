using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace ApiServer.Models
{
    public class User
    {
        [Key]
        public string name {get; set;}
        public string email {get; set;}
        public int age {get; set;}

        
    }
}