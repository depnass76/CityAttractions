using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityAttractions.Models
{
    public class Coordinates
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Attribution
    {
        public string format { get; set; }
        public string attribution_text { get; set; }
        public string attribution_link { get; set; }
        public string license_text { get; set; }
        public string license_link { get; set; }
        public string source_id { get; set; }
        public string url { get; set; }
    }

    public class Original
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int bytes { get; set; }
        public string format { get; set; }
    }

    public class Medium
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int bytes { get; set; }
        public string format { get; set; }
    }

    public class Thumbnail
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int bytes { get; set; }
        public string format { get; set; }
    }

    public class Sizes
    {
        public Original original { get; set; }
        public Medium medium { get; set; }
        public Thumbnail thumbnail { get; set; }
    }

    public class Image
    {
        public string source_id { get; set; }
        public string source_url { get; set; }
        public string owner { get; set; }
        public string owner_url { get; set; }
        public string license { get; set; }
        public string caption { get; set; }
        public Attribution attribution { get; set; }
        public Sizes sizes { get; set; }
    }

    public class Result
    {
        public string id { get; set; }
        public string parent_id { get; set; }
        public Coordinates coordinates { get; set; }
        public double score { get; set; }
        public string country_id { get; set; }
        public string type { get; set; }
        public List<Image> images { get; set; }
        public List<Attribution> attribution { get; set; }
        public string name { get; set; }
        public object snippet_language_info { get; set; }
        public string snippet { get; set; }
    }

    public class Root
    {
        public List<Result> results { get; set; }
        public bool more { get; set; }
    }


}
