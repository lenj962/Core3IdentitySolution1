using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Core3ID.Domain
{
    /// <summary>
    /// Core 3.0 Identity User
    /// </summary>
    /// <remarks>
    /// This class inherits from IdentityUser and include customized data for all authenticated users.
    /// An instance of this class is created upon registration.
    /// </remarks>
    public class Core3IDUser : IdentityUser
    {
        /// <summary>
        /// User's Last Name
        /// </summary>
        [PersonalData]
        public string LastName { get; set; }

        /// <summary>
        /// User's First Name
        /// </summary>
        [PersonalData]
        public string FirstName { get; set; }

        /// <summary>
        /// Phone Number
        /// </summary>
        /// <remarks>
        /// This is override of IdentityUser.PhoneNumber.  Ideally, it should be
        /// used in any Two-Factor-Authentication, if used.
        /// </remarks>
        [PersonalData]
        [DataType(DataType.PhoneNumber)]
        public new string PhoneNumber { get; set; }
    } // end public class Core3IDUser : IdentityUser
} // end namespace Core3ID.Domain
