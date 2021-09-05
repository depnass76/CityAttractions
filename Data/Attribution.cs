using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityAttractions.Data
{

    public class Attribution
    {
           [Key]
            public int rId { get; set; }
            public string format { get; set; }
            public string attribution_text { get; set; }
            public string attribution_link { get; set; }
            public string license_text { get; set; }
            public string license_link { get; set; }
            public string source_id { get; set; }
            public string url { get; set; }

    }
}
