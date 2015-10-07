using System.ComponentModel.DataAnnotations;

namespace NTNUntappd.Models
{
    public class BeerModels
    {   
        [Key]
        public string Name { get; set; }
        public string Type { get; set; }
        public string Brewery { get; set; }
    }
}