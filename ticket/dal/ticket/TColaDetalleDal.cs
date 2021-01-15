using modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using util.session;

namespace dal.ticket
{
    public static class TColaDetalleDal
    {
        public static List<tcoladetalle> buscar()
        {
            contextoTicket _contextoTicket = Session.getTicketContexto();
            List<tcoladetalle> lst = _contextoTicket.tcoladetalle.ToList();
            return lst;
        }
        public static tcoladetalle buscar(int idCola, int id)
        {
            contextoTicket _contextoTicket = Session.getTicketContexto();
            tcoladetalle cola = _contextoTicket.tcoladetalle.Where(x => x.idCola == idCola && x.id == id).FirstOrDefault();
            return cola;
        }
        class dato {
            public int idCola;
            public int suma;

        }
        public static int validar()
        {
            contextoTicket _contextoTicket = Session.getTicketContexto();


            var lst = (from cola in _contextoTicket.tcola
                       join coladetalle in _contextoTicket.tcoladetalle
                           on cola.idCola equals coladetalle.idCola into colaMovimientos // 1
                       from facMov in colaMovimientos.DefaultIfEmpty() // 2
                       group facMov by cola into grupo // 3
                       let sum = grupo.Sum(g => g == null ? 0 : 1 * g.tcola.tiempo)

                       select new
                       {
                           idCola = grupo.Key.idCola,
                           suma = sum
                       }).OrderBy(x=>x.suma).ToList();

            
            return (lst==null)?1:lst.FirstOrDefault().idCola;
        }
        public static List<tcoladetalle> buscar(int idCola)
        {
            contextoTicket _contextoTicket = Session.getTicketContexto();
            List<tcoladetalle> lst = _contextoTicket.tcoladetalle.Where(x => x.idCola == idCola).ToList();
            return lst;
        }
    }
}
