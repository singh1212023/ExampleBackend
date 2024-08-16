using System;
using System.Collections.Generic;

namespace RoleBasedAuthenticateProject.Models
{
    public partial class MyLoginTable227
    {
        public MyLoginTable227()
        {
            UserRoleMapping227s = new HashSet<UserRoleMapping227>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string? UserPhone { get; set; }

        public virtual ICollection<UserRoleMapping227> UserRoleMapping227s { get; set; }
    }
}
