using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityAttractions.Data
{

    public class Thumbnail
    {
        [Key]
        public int rId { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int bytes { get; set; }
        public string format { get; set; }
    }
}
