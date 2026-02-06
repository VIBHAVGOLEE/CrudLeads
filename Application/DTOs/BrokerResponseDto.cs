using System;

namespace CrudLeads.Application.DTOs
{
    public class BrokerResponseDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string SalesAgent { get; set; }
        public string CoOwner { get; set; }
        public string Project { get; set; }
        public string LeadSource { get; set; }
        public string ChannelPartner { get; set; }
        public string SourcingManager { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
