using dal.ticket;
using modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using util.session;
using WebApi.Colas;

namespace WebApi.Controllers
{
    [RoutePrefix("api/cola")]
    public class ColaController : ApiController
    {
        [ThreadStatic]
        private contextoTicket db = new contextoTicket();
        bool procesando = false;

        /// <summary>
        /// Registra la informacion del cliente y verifica si esque se esta ejecutandose la cola
        /// </summary>
        /// <param name="tcliente"></param>
        /// <returns></returns>
        [Route("registrar")]
        public IHttpActionResult registrar([FromBody] tcliente tcliente)
        {
            Session.fijarContextoTicket(db);
            db.tcliente.Add(tcliente);
            tcoladetalle coladetalle = new tcoladetalle();
            coladetalle.id = tcliente.idCliente;
            coladetalle.idCola = validar();
            db.tcoladetalle.Add(coladetalle);
            try
            {
                db.SaveChanges();

                if (!procesando)
                {
                    string procesando = this.Get();
                }
            }
            catch (DbUpdateException)
            {
                if (TClienteDal.buscar(tcliente.idCliente)!=null)
                {
                    return Ok("Error: ya existe un cliente con ese id");
                }
                else
                {
                    throw;
                }
            }
            
            return Ok("Se ha registrado correctamente");
        }
       

        /// <summary>
        /// Trae el identificador de la cola que etsa disponible
        /// </summary>
        /// <returns></returns>
        public int validar()
        {
            int nCola = TColaDetalleDal.validar();
            return nCola;
        }
        /// <summary>
        /// Procesa las colas en paralelo
        /// </summary>
        /// <returns></returns>
        public string Get()
        {           

            
            Parallel.Invoke(
                () =>
            {
                Cola cola1 = new Cola(1);

                Console.WriteLine("Primera cola");
                cola1.procesar();
            },

            () =>
            {
                contextoTicket conCola2 = new contextoTicket();
                Cola cola2 = new Cola(2);
                Console.WriteLine("Segunda cola");
                cola2.procesar();
            });
            
            procesando = true;

            return "Procesando..";
        }
       

    }
}
