using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TesteTecnico.Models;

namespace TesteTecnico.Data;

public class AppContext : IdentityDbContext<IdentityUser> 
{
    public AppContext(DbContextOptions<AppContext> options): base(options) { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

}
