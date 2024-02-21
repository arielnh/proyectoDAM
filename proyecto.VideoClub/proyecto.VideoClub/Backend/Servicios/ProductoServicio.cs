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
        public List<producto> GetPeliDisp()
        {
            // List<producto> lista = contexto.Database.SqlQuery<producto>("SELECT *FROM producto p JOIN item i ON p.id_producto = i.id_producto WHERE i.disponibilidad = 'Disponible';").ToList();

            //List<producto> lista = contexto.Database.SqlQuery<producto>("select * from producto p, item i where p.id_producto = i.id_producto and i.disponibilidad = 'disponible';").ToList();
            List<producto> lista = new List<producto>();
            foreach(producto p in getPeliculas())
            {
                int num = 0;
                foreach(item i in p.item)
                {
                    if (i.disponibilidad.Equals("Disponible")) num++;
                }
                if (num > 0) lista.Add(p);
            }
            return lista;
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
