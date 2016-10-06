using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiAngularJS.Domain.Entities
{
    //Abstração de trilha de auditoria para gerenciamento de estados na base de dados, toda tabela com controle de auditoria herdará dessa classe
    public abstract class DbEntity
    {
        [Key]
        public int IdAudit { get; set; }

        [DataType(DataType.DateTime)]
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime DtInc { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DtAlt { get; set; }
    }
}
