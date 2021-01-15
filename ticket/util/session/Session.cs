using modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace util.session
{
    public  class Session
    {
        [ThreadStatic]
        public static contextoTicket thread_contextoTicket = null;
        /// <summary>
        /// Fija el contexto de la base de datos
        /// </summary>
        /// <param name="_contextoTicket"></param>
        public static void fijarContextoTicket(contextoTicket _contextoTicket)
        {            
            Session.thread_contextoTicket = _contextoTicket;
        }
        /// <summary>
        ///  Obtiene una instancia del contexto
        /// </summary>
        /// <returns></returns>
        public static contextoTicket getTicketContexto()
        {
            contextoTicket _contextoTicket = Session.thread_contextoTicket;
            return _contextoTicket;
        }
        /// <summary>
        /// Cierra el contexto
        /// </summary>
        /// <param name="_contextoTicket"></param>
        public static void cerrarTicketContexto(contextoTicket _contextoTicket)
        {
            _contextoTicket.Dispose();
        }
    }
}
