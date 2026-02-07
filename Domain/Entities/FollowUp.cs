using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudLeads.Domain.Entities
{
    public class FollowUp
    {
        public long Id { get; set; }

        [Required]
        public long BrokerId { get; set; }

        public long? LeadId { get; set; }

        [Required]
        public DateTime FollowUpDate { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public long? StatusId { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        [ForeignKey("BrokerId")]
        public virtual Broker Broker { get; set; }

        [ForeignKey("LeadId")]
        public virtual Lead Lead { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
    }
}

