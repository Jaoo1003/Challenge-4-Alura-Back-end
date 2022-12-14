using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Challenge_4_Users.Data {
    public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>{
        private IConfiguration _configuration;
        public UserDbContext(DbContextOptions<UserDbContext> opt, IConfiguration configuration) : base(opt) {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 1, Name = "authorized", NormalizedName = "AUTHORIZED"}
                );
        }
    }
}
