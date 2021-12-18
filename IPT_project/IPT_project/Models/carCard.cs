using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPT_project.Models
{
    public class carCard
    {
        public string ad_id { get; set; }
        public string brand_name { get; set; }
        public string item_condition { get; set; }
        public string model_year { get; set; }
        public string manufacturer { get; set; }
        public string fuel_type { get; set; }
        public string transmission { get; set; }
        public string engine_capacity { get; set; }
        public string description { get; set; }
        public string engine_milegage { get; set; }
        public string image_url { get; set; }
        public string price { get; set; }
    }
}