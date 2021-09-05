using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityAttractions.Data
{

    public class Coordinates
    {
        [Key]
        public int rId { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }


}
