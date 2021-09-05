using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityAttractions.Data
{

    public class Root
    {
        [Key]
        public int rId { get; set; }
        public List<Result> results { get; set; }
        public bool more { get; set; }
    }
}
