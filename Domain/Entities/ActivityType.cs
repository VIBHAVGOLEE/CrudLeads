using System.ComponentModel.DataAnnotations;

namespace CrudLeads.Domain.Entities
{
    public class ActivityType
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
