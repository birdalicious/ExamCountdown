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
        public INavigationService NavigationService { get; set; } = null!;
        public Exam? Exam { get; set; }

        public RadzenDatePicker<DateTime> DateObj;

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
    }
}
