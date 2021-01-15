using modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using util.session;

namespace dal.ticket
{
    public static class TColaDal
    {
        /// <summary>
        /// Busca todas las colas que estan en la Base de Datos
        /// </summary>
        /// <returns></returns>
        public static List<tcola> buscar()
        {
            contextoTicket _contextoTicket = Session.getTicketContexto();
            List<tcola> lst = _contextoTicket.tcola.ToList();
            return lst;
        }
        /// <summary>
        /// Busca una cola por su id
        /// </summary>
        /// <param name="idCola"></param>
        /// <returns></returns>
        public static tcola buscar(int idCola)
        {
            contextoTicket _contextoTicket = Session.getTicketContexto();
            tcola cola = _contextoTicket.tcola.Where(x => x.idCola == idCola).FirstOrDefault();
            return cola;
        }
    }
}

