using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
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
        private ListCollectionView listaAux;
       
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
            listaAux = new ListCollectionView(servicio.getAll().ToList());
        }

    //Propiedades públicas para listar
    public List<producto> listaPeliculas => prodServ.getPeliculas();
    public List<producto> listaJuegos => prodServ.getJuegos();
    public ListCollectionView listaProductos { get { return listaAux; } }

    public List<pelicula> listaPeliculasDB { get { return peliServ.getAll().ToList(); } }
    public List<juego> listaJuegosDB { get { return jueServ.getAll().ToList(); } }


        public producto productoNuevo
        {
            get { return prodNuevo; }
            set
            {
                prodNuevo = value;
                NotifyPropertyChanged(nameof(productoNuevo));
            }
        }
        public bool guarda { get { return add(productoNuevo); } }
        public bool update { get { return update(productoNuevo); } }
        public bool BorrarProd(producto prodDel)
        {
            return delete(prodDel);
        }

        public ListCollectionView Refresca()
        {
            return new ListCollectionView(servicio.getAll().ToList());
        }
    }
}

