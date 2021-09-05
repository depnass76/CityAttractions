using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityAttractions.Data
{
    
    public class Sizes
    {
        [Key]
        public int rId { get; set; }
        public Original original { get; set; }
        public Medium medium { get; set; }
        public Thumbnail thumbnail { get; set; }
    }
}
