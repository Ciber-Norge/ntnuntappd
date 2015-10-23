using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiBeer.Models
{
    public class BeerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Brewery { get; set; }

    }
}