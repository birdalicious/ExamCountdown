using Microsoft.AspNetCore.Components;

namespace ExamCountdown.Components
{
    public partial class TimeTillComponent
    {
        [Parameter]
        public TimeSpan TimeTill { get; set; }

        public int HeaderNumber { get; private set; } = 0;
        public string Units { get; private set; } = "Days";

        private (int, string) CalculateTime()
        {
            if (TimeTill.TotalDays > 2)
            {
                return ((int)TimeTill.TotalDays, "Days");
            }
            else if (TimeTill.TotalHours > 1)
            {
                return ((int)TimeTill.TotalHours, "Hours");
            }
            else if (TimeTill.TotalMinutes > 1)
            {
                return ((int)TimeTill.TotalMinutes, "Minutes");
            }
            else
            {
                return ((int)TimeTill.TotalSeconds, "Seconds");
            }
        }
    }
}
