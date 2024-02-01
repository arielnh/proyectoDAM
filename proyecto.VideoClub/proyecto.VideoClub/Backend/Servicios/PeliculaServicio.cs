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
    /*
     * Clase que contiene las reglas de negocio de la clase Pelicula
     */
   public class PeliculaServicio : ServicioGenerico<pelicula>
    {
        private DbContext contexto;


        /*
         * Constructor
         */
        public PeliculaServicio(videoclubEntities context) : base(context)
        {
            contexto = context;
        }

        /*
         * Obtiene el último id de la tabla
         * La clave primaria es autoincrementable
         */
        public int getLastId()
        {
            pelicula pe = contexto.Set<pelicula>().OrderByDescending(p => p.id_pelicula).FirstOrDefault();
            return pe.id_pelicula;
        }

        
    }
}
