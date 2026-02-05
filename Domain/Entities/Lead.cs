using System;
using System.ComponentModel.DataAnnotations;

namespace CrudLeads.Domain.Entities
{
    public class Lead
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(12)]
        [RegularExpression(@"^91[6-9]\d{9}$", ErrorMessage = "Contact number must be Indian format: 91XXXXXXXXXX (10 digits after 91).")]
        public string ContactNumber { get; set; }

        [StringLength(200)]
        public string SalesAgent { get; set; }

        [StringLength(200)]
        public string CoOwner { get; set; }

        [StringLength(200)]
        public string Project { get; set; }

        [StringLength(200)]
        public string LeadSource { get; set; }

        [StringLength(200)]
        public string ChannelPartner { get; set; }

        [StringLength(200)]
        public string SourcingManager { get; set; }

        public string Remark { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
