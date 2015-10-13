using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTNUntappd.Models
{
    public class CheckInModels
    {
        public int Id { get; set; }
        public ApplicationUser UserId { get; set; }
        public BeerModels Beer { get; set; }
    }
}