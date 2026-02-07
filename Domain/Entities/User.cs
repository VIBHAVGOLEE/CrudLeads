using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudLeads.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string UserName { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(500)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(500)]
        public string PasswordSalt { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public long RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
