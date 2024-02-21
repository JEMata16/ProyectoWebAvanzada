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
        bool Complete();
    }
}
