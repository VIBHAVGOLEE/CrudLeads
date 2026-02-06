using System;
using System.ComponentModel.DataAnnotations;

namespace CrudLeads.Application.DTOs
{
    public class LeadUpdateDto
    {
        [StringLength(200)]
        public string Title { get; set; }

        public string Remark { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }

        public long? ActivityTypeId { get; set; }

        public int? AssignedBy { get; set; }

        public DateTime? ScheduleDate { get; set; }

        [Range(0, 1440, ErrorMessage = "ReminderMinutes must be between 0 and 1440")]
        public int? ReminderMinutes { get; set; }

        public bool? RemindMe { get; set; }

        public bool? Completed { get; set; }

        public DateTime? CompletedOn { get; set; }

        public int? CompletedBy { get; set; }

        [StringLength(100)]
        public string Stage { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        [StringLength(200)]
        public string Action { get; set; }
    }
}
