using System;
using Microsoft.AspNetCore.Identity;

namespace Groc.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the GroceriesUser class
    public class GroceriesUser : IdentityUser<int>
    {
        [PersonalData]
        public string Name { get; set; }

        [PersonalData]
        public int VillaNumber { get; set; }
    }

    public class UserMap
    {
        public int Id { get; set; }
        public int VillaNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
