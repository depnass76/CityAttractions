using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityAttractions.Data
{


    public class Result
    {
        [Key]
        public int rId { get; set; }
        public string id { get; set; }
        public string parent_id { get; set; }
        public Coordinates coordinates { get; set; }
        public double score { get; set; }
        public string country_id { get; set; }
        public string type { get; set; }
        public List<Image> images { get; set; }
        public List<Attribution> attribution { get; set; }
        public string name { get; set; }
        public string snippet { get; set; }
    }



}
