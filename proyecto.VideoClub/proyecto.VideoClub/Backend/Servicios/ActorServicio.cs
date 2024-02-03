using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto.VideoClub.Backend.Servicios.Base;
using proyecto.VideoClub.Backend.Modelo;
using System.Data.Entity;

namespace proyecto.VideoClub.Backend.Servicios
{
    class ActorServicio : ServicioGenerico<actor>
    {
        private DbContext contexto;


        /*
         * Constructor
         */
        public ActorServicio(videoclubEntities context) : base(context)
        {
            contexto = context;
        }

        /*
         * Obtiene el último id de la tabla
         * La clave primaria es autoincrementable
         */
        public int getLastId()
        {
            actor ac = contexto.Set<actor>().OrderByDescending(a=> a.id_actor).FirstOrDefault();
            return ac.id_actor;
        }

        public List<actor> getActor()
        {
            return contexto.Set<actor>().Where(p => p.id_actor > 0).ToList();

        }

    }
}
