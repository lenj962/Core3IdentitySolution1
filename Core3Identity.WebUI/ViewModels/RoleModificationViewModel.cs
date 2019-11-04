using System.ComponentModel.DataAnnotations;

namespace Core3Identity.WebUI.ViewModels
{
    public class RoleModificationViewModel
    {
        [Required]
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string[] IdsToAdd { get; set; }  // Non-membbers in role
        public string[] IdsToDelete { get; set; } // Membbers in role
    } // end public class RoleModificationViewModel
} // end namespace Core3Identity.WebUI.ViewModels
