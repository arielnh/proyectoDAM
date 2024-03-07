using proyecto.VideoClub.Backend.Modelo;
using System;
using System.Windows;
using proyecto.VideoClub.MVVM;
using System.Windows.Media.Imaging;

namespace proyecto.VideoClub.Frontend.Dialogos
{
    /// <summary>
    /// Lógica de interacción para Reserva.xaml
    /// </summary>
    public partial class Reserva : Window
    {
        private videoclubEntities vcEnt;
        private MVAlquiler mvAlq;
        private usuario usuLogin;
        private string portada="";
        
      
        private DateTime hoy = DateTime.Now.Date;
       
        public Reserva(videoclubEntities ent, usuario usu, producto pr)
        {
           
            InitializeComponent();
            vcEnt = ent;
            usuLogin = usu;
            portada = pr.portada;
            ReservaPortada.Source = new BitmapImage(new Uri(portada));
           

            mvAlq = new MVAlquiler(vcEnt, usuLogin, pr);
            DataContext = mvAlq;

            btnReserva.IsEnabled = false;
        }


        private void comprobarBtn()
        {
            if (txtFechaAlq.SelectedDate >= hoy && cbItem.SelectedItem != null)
            {
                btnReserva.IsEnabled = true;
            }
            else
            {
                btnReserva.IsEnabled = false;
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnReserva_Click(object sender, RoutedEventArgs e)
        {
            item i = (item)cbItem.SelectedItem;
            mvAlq.alquilerNuevo.id_item = i.id_item;
            mvAlq.alquilerNuevo.item = i;
            mvAlq.alquilerNuevo.item.disponibilidad = "Reservado";
            



            if (mvAlq.guarda)
            {
                MessageBox.Show("Todo reservado correctamente.", "Reservar", MessageBoxButton.OK);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Se ha producido un error.", "Reservar", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cbItem_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            comprobarBtn();
        }

        private void txtFechaAlq_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            comprobarBtn();
        }
    }
}
