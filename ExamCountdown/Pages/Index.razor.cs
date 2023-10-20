using Blazored.LocalStorage;
using ExamCountdown.Models.Exam;
using Microsoft.AspNetCore.Components;
using NavigationHelper;

namespace ExamCountdown.Pages
{
    public partial class Index
    {
        [Inject]
        public ISyncLocalStorageService LocalStorage { get; set; }

        [Inject]
        public INavigationService NavigationService { get; set; } = null!;

        public List<Exam> Exams { get; set; } = new();

        public void Test(Exam exam)
        {
            var p = new NavigationParameters();
            p.Add("Exam", exam);

            NavigationService.NavigateTo("/details", p);
        }

        protected override void OnInitialized()
        {
            var exams = LocalStorage.GetItem<List<Exam>>("Exams") ?? new();

            Exams.AddRange(exams);
        }
    }    
}
