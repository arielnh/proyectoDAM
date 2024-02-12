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
    class AlquilerServicio : ServicioGenerico<alquiler>
    {
        private DbContext contexto;


        /*
         * Constructor
         */
        public AlquilerServicio(videoclubEntities context) : base(context)
        {
            contexto = context;
        }

        /*
         * Obtiene el último id de la tabla
         * La clave primaria es autoincrementable
         */
        public int getLastId()
        {
            alquiler pe = contexto.Set<alquiler>().OrderByDescending(p => p.id_alquiler).FirstOrDefault();
            return pe.id_alquiler;
        }


    }
}
