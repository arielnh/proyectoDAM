using System.Linq;
using proyecto.VideoClub.Backend.Servicios.Base;
using proyecto.VideoClub.Backend.Modelo;

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
            producto art = contexto.Set<producto>().OrderByDescending(a => a.id_producto).FirstOrDefault();
            return art.id_producto;
        }


    }
}
