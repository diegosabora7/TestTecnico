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
        public static List<tcola> buscar()
        {
            contextoTicket _contextoTicket = Session.getTicketContexto();
            List<tcola> lst = _contextoTicket.tcola.ToList();
            return lst;
        }
        public static tcola buscar(int idCola)
        {
            contextoTicket _contextoTicket = Session.getTicketContexto();
            tcola cola = _contextoTicket.tcola.Where(x => x.idCola == idCola).FirstOrDefault();
            return cola;
        }
    }
}

