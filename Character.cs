using Newtonsoft.Json;
using System;
using WpfApp_Exam;

namespace WpfApp_Exam
{
    
    public sealed class Character : CanError
    {
        internal Character() { }
        
        public int ID { get; set; }
        
        public string Name { get; set; }
       
        public string Status { get; set; }
       
        public string Species { get; set; }
       
        public string Type { get; set; }
       
        public string Gender { get; set; }
        
        public string Image { get; set; }
        
        public string URL { get; set; }
        
        public string Created { get; set; }

       
        public Location Location { get; set; }

        
        public Location Origin { get; set; }

        
        [JsonProperty("Episode")]
        public string[] Episodes { get; set; }

        
        public DateTime DateCreated => DateTime.Parse(Created);
    }
}
