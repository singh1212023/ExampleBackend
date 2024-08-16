using System;
using System.Collections.Generic;

namespace RoleBasedAuthenticateProject.Models
{
    public partial class RoleMaster227
    {
        public RoleMaster227()
        {
            UserRoleMapping227s = new HashSet<UserRoleMapping227>();
        }

        public int RoleId { get; set; }
        public string Role { get; set; } = null!;

        public virtual ICollection<UserRoleMapping227> UserRoleMapping227s { get; set; }
    }
}
