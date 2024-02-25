using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo
    {
        IUsuarioDAL _usuarioDAL {  get; }
        ITemaDAL _temaDAL { get; }
        ICursoDAL _cursoDAL { get; }
        IRatingDAL _ratingDAL { get; }
        IEventoDAL _eventoDAL { get; }
        IHistorialCursoDAL _historialCursoDAL { get; }
        IVideoDAL _videoDAL { get; }
        ISolicitudInfoDAL _solicitudInfoDAL { get; }




        bool Complete();
    }
}
