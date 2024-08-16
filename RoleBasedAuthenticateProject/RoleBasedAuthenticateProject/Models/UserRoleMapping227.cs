using System;
using System.Collections.Generic;

namespace RoleBasedAuthenticateProject.Models
{
    public partial class UserRoleMapping227
    {
        public int RoleMapId { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }

        public virtual RoleMaster227? Role { get; set; }
        public virtual MyLoginTable227? User { get; set; }
    }
}
