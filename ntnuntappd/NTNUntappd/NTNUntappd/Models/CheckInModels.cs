using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace NTNUntappd.Models
{
    public class CheckInModels
    {
        public int Id { get; set; }
        public ApplicationUser UserId { get; set; }
        public BeerModels Beer { get; set; }
        public string UserEmail { get; set; } 
    }
}