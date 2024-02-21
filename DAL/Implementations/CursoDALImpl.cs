using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CursoDALImpl : DALGenericoImpl<Curso>, ICursoDAL
    {
        public CursoDALImpl(CursosContext context) : base(context)
        {
        }
    }
}
