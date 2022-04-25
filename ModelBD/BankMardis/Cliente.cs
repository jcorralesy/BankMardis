using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelBD.BankMardis
{
    [Table("CLIENTE", Schema = "BankMardis")]
    public class Cliente
    {
        [Key]
        public int id { get; set; }
        
        public string CONTRASENA { get; set; }
        public string ESTADO { get; set; }
        public int IDPERSONA { get; set; }
        [ForeignKey("IDPERSONA")]
        public virtual Persona _persona { get; set; }
    }
}
