using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Database
{
    public class Role
    {
        /// <summary>
        ///  1 Role can be associated with multiple users
        /// </summary>
        public Role()
        {
            UserRoles = new HashSet<UserRoles>();
        }
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
