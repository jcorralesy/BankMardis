using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelBD.BankMardis
{
    [Table("TRANSACCION", Schema = "BankMardis")]
    public class Transaccion
    {
        [Key]
        public int id { get; set; }
        public int IDCUENTA { get; set; }
        [ForeignKey("IDCUENTA")]
        public DateTime FECHA { get; set; }
        public string TIPOMOVIMIENTO { get; set; }
        public double VALOR { get; set; }
        public double SALDO { get; set; }
    }
}
