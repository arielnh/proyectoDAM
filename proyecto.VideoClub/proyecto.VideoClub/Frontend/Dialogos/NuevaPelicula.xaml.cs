using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.MVVM;

namespace proyecto.VideoClub.Frontend.Dialogos
{
    /// <summary>
    /// Lógica de interacción para NuevaPelicula.xaml
    /// </summary>
    public partial class NuevaPelicula : Window
    {
        private videoclubEntities vcEnt;
        private MVPelicula mvPeli;
        public NuevaPelicula(videoclubEntities ent)
        {
            InitializeComponent();
            vcEnt = ent;
            mvPeli = new MVPelicula(vcEnt);
            DataContext = mvPeli;
            btnGuardarPeli.IsEnabled = false;
        }

        private void btnGuardarPeli_Click(object sender, RoutedEventArgs e)
        {
            


            if (mvPeli.guarda)
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

        private void comprobarBtn()
        {
            if (txtNombre.Text.Length > 0 && txtPais.Text.Length > 0 && txtDirector.Text.Length > 0 && txtDireccion.Text.Length > 0 &&
                txtAlquiler.Text.Length> 0 && txtSinopsis.Text.Length> 0)
            {
                btnGuardarPeli.IsEnabled = true;
            }
            else
            {
                btnGuardarPeli.IsEnabled = false;
            }
        }

        private void comprobarNumero()
        {
            int parsedValue;
            if (!int.TryParse(txtDuracion.Text, out parsedValue))
            {
                btnGuardarPeli.IsEnabled = false;
               // MessageBox.Show("El campo duración solo acepta minutos en numeros");
                return;
            }
            else
            {
                btnGuardarPeli.IsEnabled = true;
            }
        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            comprobarBtn();
            comprobarNumero();
        }

        private void txtPais_TextChanged(object sender, TextChangedEventArgs e)
        {
            comprobarBtn();
            comprobarNumero();
        }

        private void txtDuracion_TextChanged(object sender, TextChangedEventArgs e)
        {
            comprobarNumero();
        }

        private void txtDirector_TextChanged(object sender, TextChangedEventArgs e)
        {
            comprobarBtn();
            comprobarNumero();
        }

        private void txtDireccion_TextChanged(object sender, TextChangedEventArgs e)
        {
            comprobarBtn();
            comprobarNumero();
        }

        private void txtAlquiler_TextChanged(object sender, TextChangedEventArgs e)
        {
            comprobarBtn();
            comprobarNumero();
        }

        private void txtSinopsis_TextChanged(object sender, TextChangedEventArgs e)
        {
            comprobarBtn();
            comprobarNumero();
        }


    }
}
