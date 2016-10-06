using System.Data.Entity.ModelConfiguration;
using WebApiAngularJS.Domain.Entities;

namespace WebApiAngularJS.Repositories.EF.Map
{
   public class LivroMap: EntityTypeConfiguration<Livro>
    {
        //Mapeamento de classe com uso de Fluent API
        public LivroMap()
        {
            HasKey(l => l.Id);
            Property(l => l.Nome).IsRequired().HasMaxLength(100);
            //Property(e => e.Descricao).HasMaxLength(300);
        }
    }
}
