using ModelBD;
using ModelBD.BankMardis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesBD.BankMardis
{
    public class PersonaDao : ADao
    {
        public PersonaDao(ContextDB _context) : base(_context)
        {
        }

        public List<Persona> GetPersona()
        {
            try
            {
                List<Persona> itemsPersona = Context.Personas.ToList();

                return itemsPersona;
            }
            catch (Exception e)
            {

                throw;
            }

        }

    }
}
