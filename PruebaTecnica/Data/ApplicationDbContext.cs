using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;

namespace PruebaTecnica.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<PruebaTecnica.Models.ProductosModel> ProductosModel { get; set; } = default!;
		public DbSet<PruebaTecnica.Models.CiudadModel> CiudadModel { get; set; } = default!;
		public DbSet<PruebaTecnica.Models.ProductoCiudadModel> ProductoCiudadModel { get; set; } = default!;
	}
}