using System.Data.Entity.ModelConfiguration;
using WebApiAngularJS.Domain.Entities;

namespace WebApiAngularJS.Repositories.EF.Map
{
    public class EditoraMap : EntityTypeConfiguration<Editora>
    {
        //Mapeamento de classe com uso de Fluent API
        public EditoraMap()
        {
            HasKey(e => e.Id);
            Property(e => e.Nome).IsRequired().HasMaxLength(100);
            //Property(e => e.Descricao).HasMaxLength(300);
        }
    }
}
