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

        public bool IsEditPage => NavigationService.RelativeUri != "add";
        public Exam? Exam { get; set; }

        private ColoursComponent _colourDialog = null!;

        private CalendarComponent _calendarDialog = null!;

        protected override void OnInitialized()
        {
            if (NavigationService.RelativeUri == "add")
            {
                var startDate = new DateTime(DateTime.Today.AddDays(1).AddHours(9).Ticks);
                Exam = new Exam("", "", startDate, TimeSpan.FromHours(1));
            }
            else
            {
                Exam = NavigationService.Parameters.GetValue<Exam>("Exam");
            }
        }

        private Task OpenColourDialog()
        {
            return _colourDialog.ShowDialog();
        }

        private Task OpenCalendarDialog()
        {
            return _calendarDialog.ShowDialog();
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
