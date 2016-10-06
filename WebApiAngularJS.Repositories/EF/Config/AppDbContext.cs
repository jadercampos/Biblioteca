using System.Data.Entity;
using WebApiAngularJS.Domain.Entities;
using WebApiAngularJS.Repositories.EF.Map;

namespace WebApiAngularJS.Repositories.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(): base("JaderCamposBiblioteca") 
        { 
        
        }

        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Livro> Livros { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EditoraMap());
            modelBuilder.Configurations.Add(new LivroMap());
        }
    }
}
