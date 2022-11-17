using Newtonsoft.Json;

namespace WpfApp_Exam
{

    public abstract class CanError
    {
        internal CanError() { }

       
        [JsonProperty("error")]
        public string ErrorMessage { get; set; } = "";

        
        public bool DidError => ErrorMessage != string.Empty;
    }
}
