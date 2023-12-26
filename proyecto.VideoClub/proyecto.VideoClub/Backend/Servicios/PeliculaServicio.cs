using System.Linq;
using proyecto.VideoClub.Backend.Servicios.Base;
using proyecto.VideoClub.Backend.Modelo;


namespace proyecto.VideoClub.Backend.Servicios
{
    /*
     * Clase que contiene las reglas de negocio de la clase Pelicula
     */
    class PeliculaServicio : ServicioGenerico<pelicula>
    {
        private videoclubEntities contexto;


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
