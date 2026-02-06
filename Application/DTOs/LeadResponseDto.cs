using System;

namespace CrudLeads.Application.DTOs
{
    public class LeadResponseDto
    {
        public long Id { get; set; }
        public long BrokerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }
        public string Mobile { get; set; }
        public long ActivityTypeId { get; set; }
        public string ActivityTypeName { get; set; }
        public int? AssignedBy { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int? ReminderMinutes { get; set; }
        public bool RemindMe { get; set; }
        public bool Completed { get; set; }
        public DateTime? CompletedOn { get; set; }
        public int? CompletedBy { get; set; }
        public string Stage { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
    }
}
