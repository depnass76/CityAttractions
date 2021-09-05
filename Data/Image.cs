using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityAttractions.Data
{
    
    public class Image
    {
        [Key]
        public int rId { get; set; }
        public string source_id { get; set; }
        public string source_url { get; set; }
        public string owner { get; set; }
        public string owner_url { get; set; }
        public string license { get; set; }
        public string caption { get; set; }
        public Attribution attribution { get; set; }
        public Sizes sizes { get; set; }
    }
}
