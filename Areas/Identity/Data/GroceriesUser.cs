using Microsoft.AspNetCore.Identity;

namespace Groc.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the GroceriesUser class
    public class GroceriesUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }

        [PersonalData]
        public int VillaNumber { get; set; }
    }
}
