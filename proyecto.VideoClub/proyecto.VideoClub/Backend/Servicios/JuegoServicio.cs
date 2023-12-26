using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Backend.Servicios.Base;
using System.Linq;


namespace proyecto.VideoClub.Backend.Servicios
{
    class JuegoServicio: ServicioGenerico<juego>
    {
        private videoclubEntities contexto;


        /*
         * Constructor
         */
        public JuegoServicio(videoclubEntities context) : base(context)
        {
            contexto = context;
        }

        /*
         * Obtiene el último id de la tabla
         * La clave primaria es autoincrementable
         */
        public int getLastId()
        {
            juego ju = contexto.Set<juego>().OrderByDescending(j => j.id_juego).FirstOrDefault();
            return ju.id_juego;
        }


    }
}
