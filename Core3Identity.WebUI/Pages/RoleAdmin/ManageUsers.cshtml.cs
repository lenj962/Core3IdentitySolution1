using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core3ID.Domain;
using Core3Identity.WebUI.ViewModels;

namespace Core3Identity.WebUI.Pages.RoleAdmin
{
    public class ManageUsersModel : PageModel
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<Core3IDUser> userManager;

        public RoleModificationViewModel RoleModificationViewModel;
        [BindProperty]
        public RoleUserViewModel RoleUserViewModel { get; set; }

        public ManageUsersModel(RoleManager<IdentityRole> roleMgr, UserManager<Core3IDUser> userMrg)
        {
            roleManager = roleMgr;
            userManager = userMrg;
        } // end public ManageUsersModel(RoleManager<IdentityRole> roleMgr, UserManager<VerityUser> userMrg)

        public async Task<IActionResult> OnGetAsync(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            List<Core3IDUser> members = new List<Core3IDUser>();
            List<Core3IDUser> nonMembers = new List<Core3IDUser>();
            foreach (Core3IDUser user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            } // end foreach (Core3IDUser user in userManager.Users)

            RoleUserViewModel = new RoleUserViewModel
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };

            return Page();
        } // end public async Task<IActionResult> OnGetAsync(string id)
        public async Task<IActionResult> OnPostAsync([FromForm]RoleModificationViewModel model)
        {
            IdentityResult result;

            if (ModelState.IsValid)
            {
                if (model.IdsToAdd != null)  // Avoid null exception
                {
                    foreach (string addId in model.IdsToAdd)
                    {
                        Core3IDUser user = await userManager.FindByIdAsync(addId);
                        if (user == null)
                        {
                            return BadRequest(String.Format("User with Id, {0}, was not found and cannot be added to role, {1}.", addId, model.RoleName));
                        }
                        else
                        {
                            result = await userManager.AddToRoleAsync(user, model.RoleName);
                            if (!result.Succeeded)
                            {
                                AddErrorsFromResult(result);
                            } // endif (!result.Succeeded)
                        } // endif (user == null)
                    } // end foreach (string addId in model.IdsToAdd)
                } // endif (model.IdsToAdd != null)

                if (model.IdsToDelete != null)  // Avoid null exception
                {
                    foreach (string deleteId in model.IdsToDelete)
                    {
                        Core3IDUser user = await userManager.FindByIdAsync(deleteId);
                        if (user == null)
                        {
                            return BadRequest(String.Format("User with Id, {0}, was not found and cannot be deleted from role, {1}.", deleteId, model.RoleName));
                        }
                        else
                        {
                            result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
                            if (!result.Succeeded)
                            {
                                AddErrorsFromResult(result);
                            } // endif (!result.Succeeded)
                        } // endif (user == null)
                    } // end foreach (string deleteId in model.IdsToDelete)
                } // endif (model.IdsToDelete != null)
            } // endif (ModelState.IsValid)

            return RedirectToPage("/RoleAdmin/ManageUsers", new { id = model.RoleId });
        } // end public async Task<IActionResult> Edit(RoleModificationViewModel model)

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            } // end foreach (IdentityError error in result.Errors)
        } // end private void AddErrorsFromResult(IdentityResult result)

    } // end public class ManageUsersModel : PageModel

} // end namespace Core3Identity.WebUI.Pages.RoleAdmin