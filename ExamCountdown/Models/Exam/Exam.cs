﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExamCountdown.Models.Exam
{
    public class Exam
    {
        public Guid Id { get; set; } = new Guid();

        [Required]
        public string Subject { get; set; }
        public string Subheading { get; set; }
        public DateTime StartDateTime { get; set; }
        public TimeSpan Duration { get; set; }
        public Colour Colour { get; set; }

        [JsonIgnore]
        public TimeSpan TimeTillStart => StartDateTime - DateTime.Now;
        public ExamStatus Status
        {
            get
            {
                if (StartDateTime > DateTime.Now)
                {
                    return ExamStatus.Future;
                }
                else if (StartDateTime + Duration > DateTime.Now)
                {
                    return ExamStatus.InProgress;
                }
                return ExamStatus.Complete;
            }
        }

        public Exam() {
            Subject = string.Empty;
            Subheading = string.Empty; ;
        }

        public Exam(string subject, string module, DateTime startDateTime, TimeSpan duration, Colour colour = Colour.None)
        {
            Subject = subject;
            Subheading = module;
            StartDateTime = startDateTime;
            Duration = duration;
            Colour = colour;
        }
    }
}