using dal.ticket;
using modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using util.session;

namespace WebApi.Colas
{
    public class Cola
    {
        int idCola;
        [ThreadStatic]
        public static contextoTicket db;
       public Cola(int id)
        {
            idCola = id;
            contextoTicket conCola = new contextoTicket();
            db = conCola;

            Session.fijarContextoTicket(conCola);
        }
        public void encolar(int idCola, int milisegundos)
        {
            //Atendiendo
            Thread.Sleep(milisegundos);
        }
        public void desencolar(int idCola, int id)
        {
            tcoladetalle coladetalle = TColaDetalleDal.buscar(idCola, id);
            db.tcoladetalle.Remove(coladetalle);
            db.SaveChanges();
        }
        public void procesar()
        {
          Session.fijarContextoTicket(Cola.db);
            tcola _cola1 = TColaDal.buscar(idCola);

            List<tcoladetalle> lstCola1 = TColaDetalleDal.buscar(idCola);

            while (lstCola1 != null && lstCola1.Count>0)
            {
                //Session.fijarContextoTicket(db);
                tcoladetalle procesando = lstCola1.FirstOrDefault();
                int milisegundos = _cola1.tiempo * 6000;
                
                encolar(idCola, milisegundos);
                desencolar(idCola, procesando.id);
                lstCola1 = TColaDetalleDal.buscar(idCola);
            }
        }
    }
}