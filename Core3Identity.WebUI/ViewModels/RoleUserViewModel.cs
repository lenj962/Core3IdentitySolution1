using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Core3ID.Domain;

namespace Core3Identity.WebUI.ViewModels
{
    public class RoleUserViewModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<Core3IDUser> Members { get; set; }
        public IEnumerable<Core3IDUser> NonMembers { get; set; }
    } // end public class RoleUserViewModel
} // end namespace Core3Identity.WebUI.ViewModels
