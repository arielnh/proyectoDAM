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
        private juego jueNuevo;
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
            jueNuevo = new juego();
            servicio = jueServ;
        }

        public juego juegoNuevo
        {
            get { return jueNuevo; }
            set
            {
                jueNuevo = value;
                NotifyPropertyChanged(nameof(juegoNuevo));
            }
        }
        //Propiedades públicas para listar
        public List<juego> listaJuegos { get { return jueServ.getAll().ToList(); } }

        public bool guarda { get { return add(juegoNuevo); } }
    }
}


