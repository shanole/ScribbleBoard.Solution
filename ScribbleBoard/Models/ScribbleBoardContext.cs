using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ScribbleBoard.Models
{
    public class ScribbleBoardContext : IdentityDbContext<ApplicationUser>
    {
      // Don't change code in here.
    }
}