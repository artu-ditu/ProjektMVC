using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProjektMVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Full name"), Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Display(Name = "Address"), Required]
        public string Address { get; set; }

        [Display(Name = "City"), Required]
        public string City { get; set; }

        [Display(Name = "Postal code"), Required]
        public string PostalCode { get; set; }

        public int Borrowed { get; set; }

        public bool IsBlocked { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MyCS", throwIfV1Schema: false)
        {
    }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<BookTag> BookTags { get; set; }

        public DbSet<BookFile> BookFiles { get; set; }

        public DbSet<Reader> Readers { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<CategoryParent> CategoryParents { get; set; }

        public DbSet<Borrow> Borrows { get; set; }

        public DbSet<Search> Searches { get; set; }

        public DbSet<Queue> Queues { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Penalty> Penalties { get; set; }

        public DbSet<RoleViewModel> RoleViewModels { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}