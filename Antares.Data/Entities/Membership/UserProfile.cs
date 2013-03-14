using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antares.Data
{
    [Table("UserProfile")]
    public class UserProfile
    {
        public UserProfile()
        {
            Roles = new HashSet<Role>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}