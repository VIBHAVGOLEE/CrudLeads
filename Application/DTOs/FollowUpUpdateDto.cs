using System;
using System.ComponentModel.DataAnnotations;

namespace CrudLeads.Application.DTOs
{
    public class FollowUpUpdateDto
    {
        public long? LeadId { get; set; }

        public DateTime? FollowUpDate { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public long? StatusId { get; set; }

        public bool? IsCompleted { get; set; }
    }
}

