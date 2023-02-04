using Microsoft.AspNetCore.Identity;

namespace MVCLayers.Models
{
    public class User :IdentityUser
    {
        public string Address { get; set; }
        public int Age { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
