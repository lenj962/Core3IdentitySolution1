using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core3Identity.WebUI.Pages.RoleAdmin
{
    public class CreateModel : PageModel
    {
        private RoleManager<IdentityRole> roleManager;

        public IdentityRole IdentityRole;

        public CreateModel(RoleManager<IdentityRole> roleMgr)
        {
            roleManager = roleMgr;
        } // end public CreateModel(RoleManager<IdentityRole> roleMgr)

        public IActionResult OnGet()
        {
            return Page();
        } // end public IActionResult OnGet()

        public async Task<IActionResult> OnPostAsync(string name)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));

            return RedirectToPage("/RoleAdmin/Index");
        } // end public async Task<IActionResult> OnPostAsync()
    } // end public class CreateModel : PageModel
} // end namespace Core3Identity.WebUI.Pages.RoleAdmin