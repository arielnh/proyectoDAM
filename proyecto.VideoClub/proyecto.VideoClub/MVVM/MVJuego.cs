using System.Collections.Generic;
using System.Linq;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Backend.Servicios;

namespace proyecto.VideoClub.MVVM
{
    class MVJuego: MVBaseCRUD<juego>
    {
        //Base de datos
        private videoclubEntities vcEnt;

        //Servicios
        private JuegoServicio jueServ;
        public MVJuego(videoclubEntities vcEnt)
        {

            this.vcEnt = vcEnt;
            inicializa();
        }

        private void inicializa()
        {
            jueServ = new JuegoServicio(vcEnt);
            servicio = jueServ;
        }

        //Propiedades públicas para listar
        public List<juego> listaJuegos { get { return jueServ.getAll().ToList(); } }
    }
}


