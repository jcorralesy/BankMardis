using BussinesApp.BankMardis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBD;
using ModelBD.BankMardis;
using ServicesMardisBank.ControladorGenerico;
using TransversalUtilities;

namespace ServicesMardisBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControladorGenerico<PersonaController>
    {
        PersonaBussines _personaBussines;
        public PersonaController(ContextDB _context) : base(_context)
        {
            _personaBussines = new PersonaBussines(_context);
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            var personas = _personaBussines.getPersonAll();
            return personas;
        }

        [HttpPost]
        public async Task<IActionResult> ingresaPersona(ModeloCliente modelo)
        {

            try
            {
                _personaBussines.agregaPersona(modelo);

                return Created($"modelo.Nombres", modelo);
            }

            catch (ApplicationException e)
            {
                return Problem($"Datos invalidos");
            }


            
        }

    }
}
