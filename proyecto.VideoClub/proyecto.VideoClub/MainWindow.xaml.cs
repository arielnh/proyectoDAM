using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Frontend.ControlUsuario;
using proyecto.VideoClub.Frontend.Dialogos;
using System.Windows;
using System.Configuration;
using System.Collections.Generic;

namespace proyecto.VideoClub
{

    public partial class MainWindow : Window
    {
        private usuario usuLogin;
        private videoclubEntities vcEnt;

        public MainWindow()
        {
            InitializeComponent();
            vcEnt = new videoclubEntities();
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
            UCPeliculas uc = new UCPeliculas(vcEnt);
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


        void CerrarSeleccion (int sel)
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
    }
}
