
namespace WpfApp_Exam
{
 
    public sealed class Location : CanError
    {
        internal Location() { }
 
        public int ID { get; set; }
 
        public string Name { get; set; }
 
        public string Type { get; set; }
 
        public string Dimension { get; set; }
 
        public string[] Residents { get; set; }
 
        public string URL { get; set; }
    }
}
