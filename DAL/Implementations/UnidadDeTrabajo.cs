using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IUsuarioDAL _usuarioDAL { get; }

        private readonly CursosContext _context;

        public UnidadDeTrabajo(CursosContext context,
            IUsuarioDAL usuarioDAL)
        {
            _context = context;
            _usuarioDAL = usuarioDAL;
        }

        public bool Complete()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
