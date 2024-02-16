using proyecto.VideoClub.Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Windows;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.MVVM;
using System;
using System.Windows.Controls;

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
        
       // private ICollection<object> listItems;
        
        public Reserva(videoclubEntities ent, usuario usu, producto pr)
        {
           
            InitializeComponent();
            vcEnt = ent;
            usuLogin = usu;

           // listItems = (ICollection<object>)pr.item;
           
            mvAlq = new MVAlquiler(vcEnt, usuLogin, pr);
            DataContext = mvAlq;
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
    }
}
