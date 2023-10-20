using Blazored.LocalStorage;
using ExamCountdown.Components;
using ExamCountdown.Models.Exam;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using NavigationHelper;
using Radzen;
using Radzen.Blazor;

namespace ExamCountdown.Pages
{
    public partial class Upsert
    {
        [Inject]
        public ISyncLocalStorageService LocalStorage { get; set; } = null!;

        [Inject]
        public INavigationService NavigationService { get; set; } = null!;
        public Exam? Exam { get; set; }

        private ColoursComponent _colourDialog { get; set; } = null!;

        protected override void OnInitialized()
        {
            if (NavigationService.RelativeUri == "add")
            {
                Exam = new Exam("", "", DateTime.Now, TimeSpan.FromHours(1));
            }
            else
            {
                Exam = NavigationService.Parameters.GetValue<Exam>("Exam");
            }
        }

        private Task OpenolourDialog()
        {
            return _colourDialog.ShowDialog();
        }

        public void HandleOnValidSubmit()
        {
            var exams = LocalStorage.GetItem<List<Exam>>("Exams") ?? new();
            exams.Add(Exam!);
            exams = exams.OrderBy(e => e.StartDateTime).ToList();
            LocalStorage.SetItem("Exams", exams);

            NavigationService.NavigateBack();
        }
    }
}
