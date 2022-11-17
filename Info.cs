using Newtonsoft.Json;

namespace WpfApp_Exam
{
 
    public sealed class Info
    {
        internal Info() { }

         
        public int Count { get; set; }
    
        public int Pages { get; set; }
     
        public string Next { get; set; }
    
        [JsonProperty("prev")]
        public string Previous { get; set; }
    }
}
