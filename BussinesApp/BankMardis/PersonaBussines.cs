using DataAccesBD.BankMardis;
using ModelBD;
using ModelBD.BankMardis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransversalUtilities;

namespace BussinesApp.BankMardis
{
    public class PersonaBussines : ABusiness
    {
        PersonaDao _personaDao;
        public PersonaBussines(ContextDB _Context) : base(_Context)
        {
            _personaDao = new PersonaDao(_Context);
        }

        public List<Persona> getPersonAll()
        {
            return _personaDao.GetPersona();
        }

        public void agregaPersona(ModeloCliente modelo)
        {

            try
            {

                Persona persona = new Persona();
                llenaPersona(modelo, persona);
                persona.DOCUMENTO = modelo.identificacion;
                _personaDao.InsertUpdateOrDelete(persona, "I");
                //FillSuccessReplyViewModel("El cliente se inserto correctamente", null);
                //return reply;

            }
            catch (Exception ex)
            {
                //FillErrorReplyViewModel(ex.Message);
                //return reply;

            }


        }

        private Persona llenaPersona(ModeloCliente _cliente, Persona persona)
        {

            persona.NOMBRE = _cliente.Nombres;
            persona.APELLIDO = _cliente.Apellido;
            persona.DOCUMENTO = _cliente.identificacion;
            persona.DIRECCION = _cliente.Dirección;
            persona.FECHANACIMIENTO = _cliente.fecha;
            persona.TIPOPERSONA = _cliente.Tipo;

            if (_cliente.genero.Equals("masculino") || _cliente.genero.Equals("femenino"))
                persona.GENERO = _cliente.genero.Equals("masculino") ? "M" : "F";
            else
                throw new Exception("El genero no es correcto debe ser masculino o femenino ", null);
            persona.TELEFONO = _cliente.Teléfono;
            Cliente cliente = new Cliente();
            cliente.ESTADO = "A";
            cliente.CONTRASENA = _cliente.Contraseña;
            persona.Clientes.Add(cliente);

            return persona;
        }


    }
}
