using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelBD.BankMardis
{
    [Table("CUENTA", Schema = "BankMardis")]
    public class Cuenta
    {
        [Key]
        public int id { get; set; }
        public int IDCLIENTE { get; set; }
        [ForeignKey("IDCLIENTE")]
        public string NUMEROCUENTA { get; set; }
        public string ESTADO { get; set; }
        public virtual ICollection<Transaccion> Transacciones { get; set; }
    }

}
