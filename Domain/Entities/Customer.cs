using System;
using System.ComponentModel.DataAnnotations;

namespace CrudLeads.Domain.Entities
{
    public class Customer
    {
        public long Id { get; set; }

        public long BrokerId { get; set; }

        public long LeadId { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(12)]
        public string ContactNumber { get; set; }

        public long? LeadSourceId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

