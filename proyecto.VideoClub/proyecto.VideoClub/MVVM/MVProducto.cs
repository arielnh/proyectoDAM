using System;
using System.Collections.Generic;
using System.Linq;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Backend.Servicios;

namespace proyecto.VideoClub.MVVM
{
    class MVProducto: MVBaseCRUD<producto>
    {
        //Base de datos
        private videoclubEntities vcEnt;

        //Nuevo producto
        private producto prodNuevo;

        //Servicios
        private ProductoServicio prodServ;
        private PeliculaServicio peliServ;
        private JuegoServicio jueServ;

       
        public MVProducto(videoclubEntities vcEnt)
        {

            this.vcEnt = vcEnt;
            inicializa();
        }

        private void inicializa()
        {
            prodServ = new ProductoServicio(vcEnt);
            peliServ = new PeliculaServicio(vcEnt);
            jueServ = new JuegoServicio(vcEnt);
            servicio = prodServ;
            prodNuevo = new producto();
           
        }

    //Propiedades públicas para listar
    public List<producto> listaPeliculas => prodServ.getPeliculas();
    public List<producto> listaJuegos => prodServ.getJuegos();
    public List<producto> listaProductos { get { return prodServ.getAll().ToList(); } }

    public List<pelicula> listaPeliculasDB { get { return peliServ.getAll().ToList(); } }
    public List<juego> listaJuegossDB { get { return jueServ.getAll().ToList(); } }

    




        public producto productoNuevo
        {
            get { return prodNuevo; }
            set
            {
                prodNuevo = value;
                NotifyPropertyChanged(nameof(prodNuevo));
            }
        }
        public bool guarda { get { return add(prodNuevo); } }

    }
}

