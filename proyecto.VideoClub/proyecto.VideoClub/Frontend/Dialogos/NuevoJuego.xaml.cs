using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.MVVM;

namespace proyecto.VideoClub.Frontend.Dialogos
{
    /// <summary>
    /// Lógica de interacción para NuevoJuego.xaml
    /// </summary>
    public partial class NuevoJuego : Window
    {
        private videoclubEntities vcEnt;
        private MVJuego mvJue;
        public NuevoJuego(videoclubEntities ent)
        {
            InitializeComponent();
            vcEnt = ent;
            mvJue = new MVJuego(vcEnt);
            DataContext = mvJue;

            //Deshabilitar el boton guardar en caso de hay algun error de validacion
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvJue.OnErrorEvent));
            mvJue.btnGuardar = btnGuardarJuego;

        }

        private void btnGuardarJuego_Click(object sender, RoutedEventArgs e)
        {
            
            if (mvJue.guarda)
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
    }
}
