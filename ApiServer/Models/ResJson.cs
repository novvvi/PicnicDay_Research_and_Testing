using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace ApiServer.Models
{
    public class ResJson
    {
        public int postid {get; set;}
        public int id {get; set;}
        public string name {get; set;}
        public string email {get; set;}
        public string body {get; set;}

        
    }
}