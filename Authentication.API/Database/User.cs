using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Database
{
    /// <summary>
    ///  Question : 1 user can have multiple roles  ??
    /// </summary>
    public class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRoles>();
            CreatedDate = DateTime.Now; //default value
        }
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
