using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApplication6.Models
{
    public class AppUser:IdentityUser
    {
        public string Name {  get; set; }
        public string Surname {  get; set; }
    }
}
