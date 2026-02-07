using System.ComponentModel.DataAnnotations;

namespace CrudLeads.Domain.Entities
{
    public class Status
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Category { get; set; }
    }
}

