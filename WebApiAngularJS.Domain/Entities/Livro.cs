using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiAngularJS.Domain.Enums;

namespace WebApiAngularJS.Domain.Entities
{
    [Table("Livro")]
    public class Livro: DbEntity
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        
        //Anotação de classe com uso de Data Anonotations
        [Required(ErrorMessage = "Campo obrigatório"), MinLength(3, ErrorMessage = "O nome não pode ter menos de 3 caracteres"), MaxLength(100)]
        public string Nome { get; set; }

        public string Autor { get; set; }
        //Utilizando enum para controle de domínios de propriedades

        public string Idioma { get; set; }

        public int Paginas { get; set; }

        //Utilizando enum para controle de domínios de propriedades
        public string Capa { get; set; }

        //Estabelece relcaionamento com a tabela de editoras
        public virtual Editora Editora { get; set; }

    }
}
