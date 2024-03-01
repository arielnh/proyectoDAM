﻿using System;
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


        //Lista para la tabla
        private ListCollectionView listaAuxPeli;
        private ListCollectionView listaAuxPeliProx;
        private ListCollectionView listaAuxJue;
        private ListCollectionView listaAuxJueProx;

        //Criterio de filtro

        private string titulo;
        private string director;

        //Predicados
        //Comun para todos los filtros
        private List<Predicate<producto>> criterios;
        private Predicate<object> predicadoFiltro;

        //Criterios especificos
        private Predicate<producto> criterioTitulo;
        private Predicate<producto> criterioDirector;
        

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
            //lista de criterios de filtrar
            listaAuxPeli = new ListCollectionView(prodServ.GetPeliDisp());
            listaAuxPeliProx = new ListCollectionView(prodServ.GetPeliProx());

            listaAuxJue = new ListCollectionView(prodServ.GetJueDisp());
            listaAuxJueProx = new ListCollectionView(prodServ.GetJueProx());

            //Predicado que nos indica el método de filtrado
            criterios = new List<Predicate<producto>>();

            //Criterio puntos
            //TextBox
            criterioTitulo = new Predicate<producto>(a => !string.IsNullOrEmpty(a.titulo) && a.titulo.ToUpper().StartsWith(tituloPelicula.ToUpper()));
            //TextBox
            criterioDirector = new Predicate<producto>(a => !string.IsNullOrEmpty(a.pelicula.director) && a.pelicula.director.ToUpper().StartsWith(directorPelicula.ToUpper()));

            //PARA TODOS
            predicadoFiltro = new Predicate<object>(FiltroCriterios);
        }

        //Propiedades públicas para listar

        public ListCollectionView listaProductos { get { return listaAux; } }

        //PELICULAS
        public ListCollectionView listaPeliculas { get { return listaAuxPeli; } }
        public ListCollectionView listaPeliculasProx { get { return listaAuxPeliProx; } }

        public List<pelicula> listaPeliculasDB { get { return peliServ.getAll().ToList(); } }
        public List<producto> lPeliDispo => prodServ.GetPeliDisp();

        //JUEGOS
        public ListCollectionView listaJuegos { get { return listaAuxJue; } }
        public ListCollectionView listaJuegosProx { get { return listaAuxJueProx; } }
        public List<juego> listaJuegosDB { get { return jueServ.getAll().ToList(); } }

        public List<producto> lJueDispo => prodServ.GetJueDisp();


        public string directorPelicula
        {
            get { return director; }
            set { director = value; NotifyPropertyChanged(nameof(directorPelicula)); }
        }

        public string tituloPelicula
    {
        get { return titulo; }
        set { titulo = value; NotifyPropertyChanged(nameof(tituloPelicula)); }
    }
        public string tituloJuego
        {
            get { return titulo; }
            set { titulo = value; NotifyPropertyChanged(nameof(tituloJuego)); }
        }

        private bool FiltroCriterios(object item)
    {
        bool correcto = true;
        producto entity = (producto)item;
        if (criterios.Count() != 0)
        {
            correcto = criterios.TrueForAll(x => x(entity));
        }
        return correcto;
    }
        //AÑADIR CRITERIO
        private void addCriterios()
        {
            criterios.Clear();
            
            if (!string.IsNullOrEmpty(titulo)) { criterios.Add(criterioTitulo); }
            if (!string.IsNullOrEmpty(director)) { criterios.Add(criterioDirector); }
           

        }

        //FILTRAR
        public void Filtra()
        {
            addCriterios();
            listaPeliculas.Filter = predicadoFiltro;
            
            listaPeliculasProx.Filter = predicadoFiltro;
           
           

        }

        public void FiltraJuegos()
        {
            addCriterios();
           
            listaJuegos.Filter = predicadoFiltro;
         



        }
        //QUITAR FILTRO
        public void QuitaFiltros()
        {
            listaPeliculas.Filter = null;
            listaJuegos.Filter = null;
            listaPeliculasProx.Filter = null;
            tituloPelicula = "";
            tituloJuego = "";
            directorPelicula = "";

        }


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

    public ListCollectionView RefrescaPelis()
        {
            return new ListCollectionView(prodServ.GetPeliDisp());
        }
        public ListCollectionView RefrescaJue()
        {
            return new ListCollectionView(prodServ.GetJueDisp());
        }
    }
}

