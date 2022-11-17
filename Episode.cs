using Newtonsoft.Json;
using System;

namespace WpfApp_Exam
{
    
    public sealed class Episode : CanError
    {
        internal Episode() { }

        
        public int ID { get; set; }
       
        public string Name { get; set; }
        
        [JsonProperty("air_date")]
        public string AirDate { get; set; }
        
        public string EpisodeCode { get; set; }
        
        public string[] Characters { get; set; }
 
        public string URL { get; set; }
 
        public string Created { get; set; }

        public DateTime DateCreated => DateTime.Parse(Created);
 
        public DateTime AirDateTime => DateTime.Parse(AirDate);
    }
}
