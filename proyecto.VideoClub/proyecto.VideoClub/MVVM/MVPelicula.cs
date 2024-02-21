using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Backend.Servicios;
using proyecto.VideoClub.Backend.Servicios.Base;

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
        private ActorServicio actServ;
     
        public MVPelicula(videoclubEntities vcEnt)
        {
            
            this.vcEnt = vcEnt;
            inicializa();
        }

        private void inicializa()
        {
            peliServ = new PeliculaServicio(vcEnt);
            actServ = new ActorServicio(vcEnt);
            servicio = peliServ;
            peliNuevo = new pelicula();

        }

        //Propiedades públicas para listar
        public List<pelicula> listaPeliculas { get { return peliServ.getAll().ToList(); } }

        //Probando diferentes listas de actor
        public List<actor> listaActores { get { return actServ.getAll().ToList(); } }

        public List<actor> listaActor => actServ.getActor();
        public List<actor> ListAct { get { return actServ.GetAll; } }

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
