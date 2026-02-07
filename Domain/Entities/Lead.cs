using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudLeads.Domain.Entities
{
    public class Lead
    {
        public long Id { get; set; }

        [Required]
        public long BrokerId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        public string Remark { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }

        [Required]
        public long ActivityTypeId { get; set; }

        public int? AssignedBy { get; set; }

        [Required]
        public DateTime ScheduleDate { get; set; }

        [Range(0, 1440)]
        public int? ReminderMinutes { get; set; }

        public bool RemindMe { get; set; }

        public bool Completed { get; set; }

        public DateTime? CompletedOn { get; set; }

        public int? CompletedBy { get; set; }

        [StringLength(100)]
        public string Stage { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        [StringLength(200)]
        public string Action { get; set; }

        [ForeignKey("BrokerId")]
        public virtual Broker Broker { get; set; }

        [ForeignKey("ActivityTypeId")]
        public virtual ActivityType ActivityType { get; set; }
    }
}
