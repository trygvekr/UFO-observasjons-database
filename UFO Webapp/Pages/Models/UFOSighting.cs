namespace UFO_Webapp.Pages.Models
{
    public class UFO_Sighting
    {
        public int UFO_ID { get; set; }
        public int LocationID { get; set; }
        public int CategoryID { get; set; }
        public int ImageID { get; set; }
        public DateTime SightingDate { get; set; }
        public string? SightingDesc { get; set; }
    }
}
