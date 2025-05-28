using BlazorTodoApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BlazorTodoApp.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // configured keys here because of an error of primary key
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(login => new { login.LoginProvider, login.ProviderKey });
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(role => new { role.UserId, role.RoleId });
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(token => new { token.UserId, token.LoginProvider, token.Name });
            });


            // Creating the user roles

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var client = new IdentityRole("client");
            client.NormalizedName = "client";

            var seller = new IdentityRole("seller");
            seller.NormalizedName = "seller";

            builder.Entity<IdentityRole>().HasData(admin, client, seller);

        }
        public DbSet<Todo> Todos { get; set; }
    }
}
