using ExamCountdown.Models.Exam;
using Microsoft.AspNetCore.Components;
using NavigationHelper;

namespace ExamCountdown.Pages
{
    public partial class Details : IDisposable
    {
        [Inject]
        INavigationService NavigationService { get; set; } = null!;

        public Exam? Exam { get; set; }

        private static Timer? _timer;

        protected override void OnInitialized()
        {
            Exam = NavigationService.Parameters.GetValue<Exam>("Exam");

            _timer = new Timer((_) =>
            {
                InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            }, null, 0, 1000);

            base.OnInitialized();
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
