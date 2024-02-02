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
       

        public NuevoProducto(videoclubEntities ent)
        {
            InitializeComponent();
            vcEnt = ent;
            mvProd = new MVProducto(vcEnt);
            mvJue = new MVJuego(vcEnt);
            DataContext = mvProd;
            peliculaSelect();

        }
 

        private void btnGuardarProd_Click(object sender, RoutedEventArgs e)
        {
            if (mvProd.guarda)
            {
                MessageBox.Show("Todo guardado correctamente.", "Guardar Pelicula", MessageBoxButton.OK);
                this.Close();

            }
            else
            {
                MessageBox.Show("Se ha producido un error.", "Guardar Pelicula", MessageBoxButton.OK, MessageBoxImage.Error);



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
