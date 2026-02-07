using System;
using System.ComponentModel.DataAnnotations;

namespace CrudLeads.Application.DTOs
{
    public class FollowUpCreateDto
    {
        [Required]
        public long BrokerId { get; set; }

        public long? LeadId { get; set; }

        [Required]
        public DateTime FollowUpDate { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public long? StatusId { get; set; }

        public bool IsCompleted { get; set; }

        public int? CreatedBy { get; set; }
    }
}

