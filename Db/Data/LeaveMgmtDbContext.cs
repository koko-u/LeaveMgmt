using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveMgmt.Db.Data;

public class LeaveMgmtDbContext(DbContextOptions<LeaveMgmtDbContext> opts) : IdentityDbContext(opts)
{

}
