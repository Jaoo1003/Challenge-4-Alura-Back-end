using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Challenge_4_Users.Data {
    public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>{

        public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt){
        }
    }
}
