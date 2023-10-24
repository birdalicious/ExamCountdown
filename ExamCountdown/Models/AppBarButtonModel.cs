namespace ExamCountdown.Models
{
    public class AppBarButtonModel
    {
        public string Icon { get; set; }
        public string Link { get; set; }

        public AppBarButtonModel(string icon, string link)
        {
            Icon = icon;
            Link = link;
        }
    }
}
