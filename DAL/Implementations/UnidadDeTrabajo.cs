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
        public ITemaDAL _temaDAL { get; }
        public IEventoDAL _eventoDAL { get; }
        public ICursoDAL _cursoDAL { get; }

        public IRatingDAL _ratingDAL { get; }

        public IHistorialCursoDAL _historialCursoDAL { get; }
        public IVideoDAL _videoDAL { get; }
        public ISolicitudInfoDAL _solicitudInfoDAL { get; }  

        private readonly CursosContext _context;

        public UnidadDeTrabajo(CursosContext context,
            IUsuarioDAL usuarioDAL, ITemaDAL temaDAL,
            IEventoDAL eventoDAL, ICursoDAL cursoDAL,
            IRatingDAL ratingDAL, IHistorialCursoDAL historialCursoDAL,
            IVideoDAL videoDAL, ISolicitudInfoDAL solicitudInfoDAL)
        {
            _context = context;
            _usuarioDAL = usuarioDAL;
            _temaDAL = temaDAL;
            _eventoDAL = eventoDAL;
            _cursoDAL = cursoDAL;
            _ratingDAL = ratingDAL;    
            _historialCursoDAL = historialCursoDAL; 
            _videoDAL = videoDAL;
            _solicitudInfoDAL = solicitudInfoDAL;


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
