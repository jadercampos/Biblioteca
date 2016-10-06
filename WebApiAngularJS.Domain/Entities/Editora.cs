using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiAngularJS.Domain.Entities
{
    [Table("Editora")]
    public class Editora : DbEntity
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
