using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace ExamCountdown.Components
{
    public partial class DateComponent
    {
        [Parameter]
        public DateTime DateTime { get; set; }

        private string[] _abbrDays;

        private string[] _abbrMonths;

        public DateComponent()
        {
            CultureInfo cl = CultureInfo.InvariantCulture;
            _abbrDays = cl.DateTimeFormat.AbbreviatedDayNames;
            _abbrMonths = cl.DateTimeFormat.AbbreviatedMonthNames;
        }

        public bool IsToday => DateTime.Date == DateTime.Now.Date;
        public bool IsTomorrow => DateTime.Date == DateTime.Now.Date.AddDays(1);

        public string GetDayHeadline()
        {
            if(IsToday)
            {
                return "Today";
            }
            else if(IsTomorrow)
            {
                return "Tomorrow";
            }
            return _abbrDays[(int)DateTime.DayOfWeek];
        }

        public string GetMainFigure()
        {
            if(IsToday || IsTomorrow)
            {
                return DateTime.TimeOfDay.ToString("hh\\:mm");
            }
            return DateTime.Day.ToString();
        }

        public string GetFooter()
        {
            if(IsToday || IsTomorrow)
            {
                return string.Empty;
            }
            return _abbrMonths[(int)DateTime.Month];
        }
    }
}
