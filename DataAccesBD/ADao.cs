using Microsoft.EntityFrameworkCore;
using ModelBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesBD
{
    public abstract class ADao
    {
        public ContextDB Context { get; }

        protected EntityState StateInsert = EntityState.Added;
        protected ADao(ContextDB _context)
        {
            Context = _context;

        }
        public bool InsertUpdateOrDelete<T>(T entity, string transaction) where T : class
        {
            try
            {

                var stateRegister = transaction == "I" ? EntityState.Added : transaction == "U" ? EntityState.Modified : EntityState.Deleted;

                if (stateRegister != EntityState.Deleted)
                {
                    Context.Set<T>().Add(entity);
                    Context.Entry(entity).State = stateRegister;
                }
                else
                {
                    Context.Set<T>().RemoveRange(entity);
                }



                Context.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Existe problema en base de datos", ex);


            }


        }
    }
}
