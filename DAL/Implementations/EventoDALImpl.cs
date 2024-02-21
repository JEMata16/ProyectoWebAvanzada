using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class EventoDALImpl : DALGenericoImpl<Evento>, IEventoDAL
    {
        public EventoDALImpl(CursosContext context) : base(context)
        {
        }
    }
}
