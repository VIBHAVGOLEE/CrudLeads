using System.ComponentModel.DataAnnotations;

namespace CrudLeads.Application.DTOs
{
    public class BrokerCreateDto
    {
        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "ContactNumber is required")]
        [StringLength(12)]
        [RegularExpression(@"^91[6-9]\d{9}$", ErrorMessage = "Contact number must be Indian format: 91XXXXXXXXXX (10 digits after 91, starting with 6-9).")]
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
    }
}
