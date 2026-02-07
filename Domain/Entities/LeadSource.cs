using System.ComponentModel.DataAnnotations;

namespace CrudLeads.Domain.Entities
{
    public class LeadSource
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}

