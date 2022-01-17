using Microsoft.AspNetCore.Identity;

namespace Lib.Models
{
    public class User :IdentityUser
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public Roles Role { get;set;}

        /*public Shelf Shelfs { get; set; }*/
        /*public List<Shelf> Shelfs { get; set; }*/
    }
}
