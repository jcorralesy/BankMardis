using Microsoft.AspNetCore.Mvc;
using ModelBD;

namespace ServicesMardisBank.ControladorGenerico
{
    public class ControladorGenerico<T> : Controller
    {
        ContextDB Context { get; }

        public ControladorGenerico(ContextDB _context)
        {
            Context = _context;
        }
    }
}
