using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ScribbleBoard.Models
{
    public class ScribbleBoardContext : IdentityDbContext<ApplicationUser>
    {
      public TestClientContext(DbContextOptions options) : base(options) { }
    }
}