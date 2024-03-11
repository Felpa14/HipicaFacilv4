
using Microsoft.EntityFrameworkCore;
namespace HipicaFacilv4.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet para a entidade Produto
        public DbSet<Produto> Produtos { get; set; }
        public class Produto
        {
            public int Id { get; set; }
            public string ?Nome { get; set; }
            public string ?Validade { get; set; }
            public int Quantidade { get; set; }
        }
    }
}