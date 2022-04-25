using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBD.BankMardis
{
    [Table("PERSONA", Schema = "BankMardis")]
    public class Persona
    {
        public Persona()
        {
            this.Clientes = new HashSet<Cliente>();
            this.Cuentas = new HashSet<Cuenta>();
        }
        [Key]
        public int id { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string DOCUMENTO { get; set; }
        public string FECHANACIMIENTO { get; set; }
        public string GENERO { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string TIPOPERSONA { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Cuenta> Cuentas { get; set; }
    }
}
