using System.Linq;
using proyecto.VideoClub.Backend.Servicios.Base;
using proyecto.VideoClub.Backend.Modelo;

namespace proyecto.VideoClub.Backend.Servicios
{
    class RolServicio: ServicioGenerico<rol>
    {
        private videoclubEntities contexto;


    /*
     * Constructor
     */
    public RolServicio(videoclubEntities context) : base(context)
    {
        contexto = context;
    }

    /*
     * Obtiene el último id de la tabla
     * La clave primaria es autoincrementable
     */
    public int getLastId()
    {
        rol rol = contexto.Set<rol>().OrderByDescending(r => r.id_rol).FirstOrDefault();
        return rol.id_rol;
    }


}
}
    
    

