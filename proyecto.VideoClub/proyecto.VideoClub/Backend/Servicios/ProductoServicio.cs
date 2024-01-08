using System.Linq;
using proyecto.VideoClub.Backend.Servicios.Base;
using proyecto.VideoClub.Backend.Modelo;
using System.Collections.Generic;

namespace proyecto.VideoClub.Backend.Servicios
{
    class ProductoServicio: ServicioGenerico<producto>
    {
        private videoclubEntities contexto;


        /*
         * Constructor
         */
        public ProductoServicio(videoclubEntities context) : base(context)
        {
            contexto = context;
        }

        /*
         * Obtiene el último id de la tabla
         * La clave primaria es autoincrementable
         */
        public int getLastId()
        {
            producto pr = contexto.Set<producto>().OrderByDescending(p => p.id_producto).FirstOrDefault();
            return pr.id_producto;
        }

        /*
         * Obtenemos la lista de Productos que son Peliculas
         */
        public List<producto> getPeliculas()
        {
            return contexto.Set<producto>().Where(p => p.id_pelicula > 0).ToList();

        }

        /*
         * Obtenemos la lista de Productos que son Juegos
         */
        public List<producto> getJuegos()
        {
            return contexto.Set<producto>().Where(p => p.id_juego > 0).ToList();

        }

    }
}
