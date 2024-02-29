using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Frontend.ControlUsuario;
using proyecto.VideoClub.Frontend.Dialogos;
using System.Windows;
using System.Configuration;
using System.Collections.Generic;
using proyecto.VideoClub.Backend.Servicios;
using proyecto.VideoClub.Informes;

namespace proyecto.VideoClub
{

    public partial class MainWindow : Window
    {
        private usuario usuLogin;
        private videoclubEntities vcEnt;
        private UsuarioServicio servUsu;
        private bool publico = false;

        public MainWindow()
        {
            InitializeComponent();
            vcEnt = new videoclubEntities();
            servUsu = new UsuarioServicio(vcEnt);
        }

        public MainWindow(videoclubEntities ent)
        {
            vcEnt = ent;
            InitializeComponent();
            BD.Visibility = Visibility.Hidden;
            GestionAdm.Visibility = Visibility.Hidden;
            MiPerfil.Visibility = Visibility.Hidden;
            publico = true;
        }
        public MainWindow(videoclubEntities ent, usuario usu)
        {
            vcEnt = ent;
            usuLogin = usu;
            InitializeComponent();
        }

        // CATALOGO PELICULAS
        private void CatalogoPeliculas(object sender, RoutedEventArgs e)
        {
            if (publico)
            {
                CerrarSeleccion(1);
                UCPeliculas uc = new UCPeliculas(vcEnt);
                // Lo colocaremos en el panel central de nuestra aplicación
                // Si hay algo en el grid central lo borramos
                if (gridCentral.Children != null) gridCentral.Children.Clear();
                // Añadimos nuestro user control
                gridCentral.Children.Add(uc);
            }
            else
            {
                CerrarSeleccion(1);
                UCPeliculas uc = new UCPeliculas(vcEnt, usuLogin);
                // Lo colocaremos en el panel central de nuestra aplicación
                // Si hay algo en el grid central lo borramos
                if (gridCentral.Children != null) gridCentral.Children.Clear();
                // Añadimos nuestro user control
                gridCentral.Children.Add(uc);
            }
           

        }

        //CATALOGO JUEGOS

        private void CatalogoJuegos(object sender, RoutedEventArgs e)
        {
            if (publico)
            {
                CerrarSeleccion(2);
                UCJuegos uc = new UCJuegos(vcEnt);
                // Lo colocaremos en el panel central de nuestra aplicación
                // Si hay algo en el grid central lo borramos
                if (gridCentral.Children != null) gridCentral.Children.Clear();
                // Añadimos nuestro user control
                gridCentral.Children.Add(uc);
                Todas.IsSelected = false;
            }
            else
            {

            CerrarSeleccion(2);
            UCJuegos uc = new UCJuegos(vcEnt, usuLogin);
            // Lo colocaremos en el panel central de nuestra aplicación
            // Si hay algo en el grid central lo borramos
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            // Añadimos nuestro user control
            gridCentral.Children.Add(uc);
            Todas.IsSelected = false;
            }

        }


        // NUEVO USUARIO
        private void NewUser_Selected(object sender, RoutedEventArgs e)
        {
            gridCentral.Children.Clear();
            CerrarSeleccion(4);
            NuevoUsuario ventana = new NuevoUsuario(vcEnt);
            ventana.ShowDialog();

        }

        //NUEVA PELICULA
        private void NewPeli_Selected(object sender, RoutedEventArgs e)
        {
            CerrarSeleccion(4);
            NuevaPelicula ventana = new NuevaPelicula(vcEnt);
            ventana.ShowDialog();

        }

        //NUEVO JUEGO
        private void NewJuego_Selected(object sender, RoutedEventArgs e)
        {
            CerrarSeleccion(4);
            NuevoJuego ventana = new NuevoJuego(vcEnt);
            ventana.ShowDialog();


        }

        //MINIMIZAR ARBOL DE OPCIONES
        void CerrarSeleccion(int sel)
        {
            switch (sel)
            {
                case 1:
                    Juegos.IsExpanded = false;
                    Perfil.IsExpanded = false;
                    Gestion.IsExpanded = false;
                    break;

                case 2:
                    Peliculas.IsExpanded = false;
                    Perfil.IsExpanded = false;
                    Gestion.IsExpanded = false;
                    break;

                case 3:
                    Juegos.IsExpanded = false;
                    Peliculas.IsExpanded = false;
                    Gestion.IsExpanded = false;
                    break;

                case 4:
                    Juegos.IsExpanded = false;
                    Peliculas.IsExpanded = false;
                    Perfil.IsExpanded = false;
                    break;
            }
        }

        //LISTAR USUARIOS
        private void ListUser_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CerrarSeleccion(4);
            UCUsuarios uc = new UCUsuarios(vcEnt);
            // Lo colocaremos en el panel central de nuestra aplicación
            // Si hay algo en el grid central lo borramos
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            // Añadimos nuestro user control
            gridCentral.Children.Add(uc);
            Todas.IsSelected = false;
        }
       
        //NUEVO PRODUCTO
        private void NewProduct_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CerrarSeleccion(4);
            NuevoProducto ventana = new NuevoProducto(vcEnt);
            ventana.ShowDialog();
        }

        //VER DATOS DEL USUARIO LOGEADO
        private void DatosUsu_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CerrarSeleccion(3);
            UCDatosUsuario uc = new UCDatosUsuario(vcEnt, usuLogin);
            // Lo colocaremos en el panel central de nuestra aplicación
            // Si hay algo en el grid central lo borramos
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            // Añadimos nuestro user control
            gridCentral.Children.Add(uc);
            Todas.IsSelected = false;
        }

        //LISTAR PRODUCTOS
        private void ListarProducto_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CerrarSeleccion(4);
            UCProducto uc = new UCProducto(vcEnt);
            // Lo colocaremos en el panel central de nuestra aplicación
            // Si hay algo en el grid central lo borramos
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            // Añadimos nuestro user control
            gridCentral.Children.Add(uc);
            Todas.IsSelected = false;
        }

        //LISTAR ALQUILERES
        private void ListAlquileres_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CerrarSeleccion(4);
            UCAlquiler uc = new UCAlquiler(vcEnt);
            // Lo colocaremos en el panel central de nuestra aplicación
            // Si hay algo en el grid central lo borramos
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            // Añadimos nuestro user control
            gridCentral.Children.Add(uc);
            Todas.IsSelected = false;
        }
       

        //VER INFORMES
        private void ListarInforme_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            UCInforme uc = new UCInforme();
            // Lo colocaremos en el panel central de nuestra aplicación
            // Si hay algo en el grid central lo borramos
           if (gridCentral.Children != null) gridCentral.Children.Clear();
            // Añadimos nuestro user control
            gridCentral.Children.Add(uc);
            //Todas.IsSelected = false;
        }

        //VER PELICULAS SIN ITEMS DISPONIBLES
        private void ProxPelis(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CerrarSeleccion(1);

            UCProxPeli uc = new UCProxPeli(vcEnt);

            if (gridCentral.Children != null) gridCentral.Children.Clear();

            gridCentral.Children.Add(uc);
        }

        private void Charts_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            UCChart uc = new UCChart();

            if (gridCentral.Children != null) gridCentral.Children.Clear();

            gridCentral.Children.Add(uc);
        }
    }
}
