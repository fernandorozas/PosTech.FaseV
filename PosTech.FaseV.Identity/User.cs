using Microsoft.AspNetCore.Identity;

namespace PosTech.FaseV.Identity
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
