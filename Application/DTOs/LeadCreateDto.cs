using System;
using System.ComponentModel.DataAnnotations;

namespace CrudLeads.Application.DTOs
{
    public class LeadCreateDto
    {
        [Required(ErrorMessage = "BrokerId is required")]
        public long BrokerId { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        public string Remark { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "ActivityTypeId is required")]
        public long ActivityTypeId { get; set; }

        public int? AssignedBy { get; set; }

        [Required(ErrorMessage = "ScheduleDate is required")]
        public DateTime ScheduleDate { get; set; }

        [Range(0, 1440, ErrorMessage = "ReminderMinutes must be between 0 and 1440")]
        public int? ReminderMinutes { get; set; }

        public bool RemindMe { get; set; }

        public bool Completed { get; set; }

        [StringLength(100)]
        public string Stage { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        [StringLength(200)]
        public string Action { get; set; }
    }
}
