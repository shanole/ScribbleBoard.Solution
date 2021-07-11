using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ScribbleBoard.Models
{
    public class ScribbleBoardContext : IdentityDbContext<ApplicationUser>
    {
      public ScribbleBoardContext(DbContextOptions options) : base(options) { }
    }
}