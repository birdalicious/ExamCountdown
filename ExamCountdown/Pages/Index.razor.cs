using ExamCountdown.Models.Exam;
using Microsoft.AspNetCore.Components;
using NavigationHelper;

namespace ExamCountdown.Pages
{
    public partial class Index
    {
        [Inject]
        public INavigationService NavigationService { get; set; } = null!;

        public List<Exam> Exams { get; set; } = new()
        {
            new Exam("Test", "lolo", new DateTime(2024,2,2, 9, 30, 0), TimeSpan.FromHours(1.5)),
            new Exam("aaah", "hehe", new DateTime(2024,2,16,11, 0, 0), TimeSpan.FromHours(1.5), Colour.Red),
            new Exam("aadve", "vd", new DateTime(2024,2,27,9, 0, 0), TimeSpan.FromHours(1), Colour.DeepPurple),
            new Exam("moore", "", new DateTime(2024,1,14,10, 30, 0), TimeSpan.FromHours(2.5)),
            new Exam("now", "fefe", new DateTime(2023,10,21,16,30,0), TimeSpan.FromHours(1), Colour.Green),
        };

        public void Test(Exam exam)
        {
            var p = new NavigationParameters();
            p.Add("Exam", exam);

            NavigationService.NavigateTo("/details", p);
        }
    }    
}
