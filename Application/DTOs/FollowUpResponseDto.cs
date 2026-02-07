using System;

namespace CrudLeads.Application.DTOs
{
    public class FollowUpResponseDto
    {
        public long Id { get; set; }
        public long BrokerId { get; set; }
        public long? LeadId { get; set; }
        public DateTime FollowUpDate { get; set; }
        public string Remark { get; set; }
        public long? StatusId { get; set; }
        public string StatusName { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
    }
}

