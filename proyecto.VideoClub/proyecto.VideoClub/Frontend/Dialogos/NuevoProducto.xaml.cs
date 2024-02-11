using System;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Controls;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.MVVM;

namespace proyecto.VideoClub.Frontend.Dialogos
{
   
    public partial class NuevoProducto : Window
    {
        private videoclubEntities vcEnt;
        private MVProducto mvProd;
        private MVJuego mvJue;
        private bool editar;

        public NuevoProducto(videoclubEntities ent)
        {

            InitializeComponent();
            vcEnt = ent;
            editar = false;

            inicializa();
        }

        public NuevoProducto(videoclubEntities ent, producto prod)
        {
            InitializeComponent();
            vcEnt = ent;
            inicializa();
            editar = true;
            mvProd.productoNuevo = prod;
          

        }

        private void inicializa ()
        {
            
            mvProd = new MVProducto(vcEnt);
            mvJue = new MVJuego(vcEnt);
            DataContext = mvProd;
            peliculaSelect();
        }
 

        private void btnGuardarProd_Click(object sender, RoutedEventArgs e)
        {
            if (!editar)
            {

                if (mvProd.guarda)
                {
                    MessageBox.Show("Todo guardado correctamente.", "Guardar", MessageBoxButton.OK);
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Se ha producido un error.", "Guardar", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (mvProd.update)
                {

                    DialogResult = true;
                }
                else
                {

                    DialogResult = false;
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

       
        private void peliculaSelect()
        {

            cbPelicula.Visibility = Visibility.Visible;
            Pelicula.Visibility = Visibility.Visible;

            cbJuego.Visibility = Visibility.Hidden;
            Juego.Visibility = Visibility.Hidden;

            btnPeli.Opacity = 1;
            btnJue.Opacity = 0.4;
        }

        private void juegoSelect()
        {
            cbJuego.Visibility = Visibility.Visible;
            Juego.Visibility = Visibility.Visible;

            cbPelicula.Visibility = Visibility.Hidden;
            Pelicula.Visibility = Visibility.Hidden;

            btnPeli.Opacity = 0.4;
            btnJue.Opacity = 1;
        }
      
        private void btnPeli_Click(object sender, RoutedEventArgs e)
        {
            peliculaSelect();
        }

        private void btnJue_Click(object sender, RoutedEventArgs e)
        {
            juegoSelect();
        }
    }
}
