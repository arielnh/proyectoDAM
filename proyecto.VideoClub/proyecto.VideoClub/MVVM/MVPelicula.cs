using System.Collections.Generic;
using System.Linq;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Backend.Servicios;

namespace proyecto.VideoClub.MVVM
{
    class MVPelicula : MVBaseCRUD<pelicula>
    {
        //Base de datos
        private videoclubEntities vcEnt;

        //Nueva pelicula
        private pelicula peliNuevo;

        //Servicios
        private PeliculaServicio peliServ;
        public MVPelicula(videoclubEntities vcEnt)
        {
            
            this.vcEnt = vcEnt;
            inicializa();
        }

        private void inicializa()
        {
            peliServ = new PeliculaServicio(vcEnt);
            servicio = peliServ;
            peliNuevo = new pelicula();
        }

        //Propiedades públicas para listar
        public List<pelicula> listaPeliculas { get { return peliServ.getAll().ToList(); } }

        public pelicula peliculaNuevo
        {
            get { return peliNuevo; }
            set
            {
                peliNuevo = value;
                NotifyPropertyChanged(nameof(peliNuevo));
            }
        }
        public bool guarda { get { return add(peliNuevo); } }
    }
}
