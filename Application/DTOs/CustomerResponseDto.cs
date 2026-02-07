using System;

namespace CrudLeads.Application.DTOs
{
    public class CustomerResponseDto
    {
        public long Id { get; set; }
        public long BrokerId { get; set; }
        public long LeadId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public long? LeadSourceId { get; set; }
        public string LeadSourceName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

