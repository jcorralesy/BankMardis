using ModelBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesApp
{
    
    public class ABusiness
    {
        protected ContextDB context { get; }
        protected ABusiness(ContextDB _Context)
        {
            context = _Context;

        }
    }
}
