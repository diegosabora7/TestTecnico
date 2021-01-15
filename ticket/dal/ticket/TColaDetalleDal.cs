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
        /// <summary>
        /// Busca  el detalle  de todas las colas que estan pendientes
        /// </summary>
        /// <returns></returns>
        public static List<tcoladetalle> buscar()
        {
            contextoTicket _contextoTicket = Session.getTicketContexto();
            List<tcoladetalle> lst = _contextoTicket.tcoladetalle.ToList();
            return lst;
        }
        /// <summary>
        /// Busca el detalle de una definición de colas por id de cola y el id del detalle de la cola
        /// </summary>
        /// <param name="idCola"></param>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Retorna la cola que esta disponible, el criterio para elegir la cola 
        /// es contar el numero de clientes o elementos de la cola por el tiempo de la cola 
        /// en la que se encuentra dicho elemento o cliente
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Busca y muesstra el detalle de colas que se encuentre en una de las dos.
        /// </summary>
        /// <param name="idCola"></param>
        /// <returns></returns>
        public static List<tcoladetalle> buscar(int idCola)
        {
            contextoTicket _contextoTicket = Session.getTicketContexto();
            List<tcoladetalle> lst = _contextoTicket.tcoladetalle.Where(x => x.idCola == idCola).ToList();
            return lst;
        }
    }
}
