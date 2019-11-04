using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core3ID.Domain;

namespace Core3Identity.WebUI.Pages.RoleAdmin
{
    public class IndexModel : PageModel
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<Core3IDUser> userManager;

        public IEnumerable<Core3IDUser> VerityUsers { get; set; }
        public IEnumerable<IdentityRole> IdentityRoles { get; set; }

        public IndexModel(RoleManager<IdentityRole> roleMgr, UserManager<Core3IDUser> usrMgr)
        {
            roleManager = roleMgr;
            userManager = usrMgr;
        } // end public IndexModel(UserManager<VerityUser> usrMgr, ...

        public void OnGet()
        {
            IdentityRoles = roleManager.Roles.OrderBy(r => r.Name);
        } // end public void OnGet()
    } // end public class IndexModel : PageModel
} // end namespace Core3Identity.WebUI.Pages.RoleAdmin