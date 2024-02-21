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


        public MainWindow()
        {
            InitializeComponent();
            vcEnt = new videoclubEntities();
            servUsu = new UsuarioServicio(vcEnt);
        }
        public MainWindow(videoclubEntities ent, usuario usu)
        {
            vcEnt = ent;
            usuLogin = usu;
            InitializeComponent();
        }

        private void CatalogoPeliculas(object sender, RoutedEventArgs e)
        {
            CerrarSeleccion(1);
            UCPeliculas uc = new UCPeliculas(vcEnt, usuLogin);
            // Lo colocaremos en el panel central de nuestra aplicación
            // Si hay algo en el grid central lo borramos
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            // Añadimos nuestro user control
            gridCentral.Children.Add(uc);

        }

        private void CatalogoJuegos(object sender, RoutedEventArgs e)
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



        private void NewUser_Selected(object sender, RoutedEventArgs e)
        {
            gridCentral.Children.Clear();
            CerrarSeleccion(4);
            NuevoUsuario ventana = new NuevoUsuario(vcEnt);
            ventana.ShowDialog();

        }

        private void NewPeli_Selected(object sender, RoutedEventArgs e)
        {
            CerrarSeleccion(4);
            NuevaPelicula ventana = new NuevaPelicula(vcEnt);
            ventana.ShowDialog();

        }

        private void NewJuego_Selected(object sender, RoutedEventArgs e)
        {
            CerrarSeleccion(4);
            NuevoJuego ventana = new NuevoJuego(vcEnt);
            ventana.ShowDialog();


        }


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
       

        private void NewProduct_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CerrarSeleccion(4);
            NuevoProducto ventana = new NuevoProducto(vcEnt);
            ventana.ShowDialog();
        }

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

        private void UsuAlq_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CerrarSeleccion(3);
            UCMisAlquileres uc = new UCMisAlquileres(vcEnt, usuLogin);
            // Lo colocaremos en el panel central de nuestra aplicación
            // Si hay algo en el grid central lo borramos
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            // Añadimos nuestro user control
            gridCentral.Children.Add(uc);
            Todas.IsSelected = false;
        }

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
    }
}
