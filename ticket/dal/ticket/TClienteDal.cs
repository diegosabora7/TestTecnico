using modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using util.session;

namespace dal.ticket
{
   public static class TClienteDal
    {
        public static tcliente buscar(int idCliente)
        {
            contextoTicket _contextoTicket = Session.getTicketContexto();
            tcliente cliente = _contextoTicket.tcliente.Where(x => x.idCliente == idCliente).FirstOrDefault();
            return cliente;
        }
    }
}
