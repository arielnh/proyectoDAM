using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.MVVM;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace proyecto.VideoClub.Frontend.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UCAlquiler.xaml
    /// </summary>
    public partial class UCAlquiler : UserControl
    {
        private videoclubEntities vcEnt;
        private MVAlquiler mvAlq;
        private DateTime hoy = DateTime.Now;
        public UCAlquiler()
        {
            InitializeComponent();
        }
        public UCAlquiler(videoclubEntities ent)
        {
            InitializeComponent();
            vcEnt = ent;
            mvAlq = new MVAlquiler(vcEnt);
            DataContext = mvAlq;
        }

        

        private void itemDevuelto_Click(object sender, RoutedEventArgs e)
        {
            alquiler aq = (alquiler)dgListaAlquiler.SelectedItem;

            aq.devuelto = true;
            aq.fecha_devolucion = hoy;
            aq.item.disponibilidad = "Disponible";
            aq.recargo = mvAlq.CarcularRecargo(aq);


            mvAlq.ActualizarAlq(aq);
            dgListaAlquiler.Items.Refresh();

            
            
        }

        private void itemEntregado_Click(object sender, RoutedEventArgs e)
        {
            alquiler aq = (alquiler)dgListaAlquiler.SelectedItem;
            aq.fecha_prev_devolucion = hoy.AddDays(3);
            aq.item.disponibilidad = "Alquilado";

           
            mvAlq.ActualizarAlq(aq);
            dgListaAlquiler.Items.Refresh();
        }

        private void checkDevuelto_Checked(object sender, RoutedEventArgs e)
        {
            mvAlq.Filtra();
        }

        private void checkDevuelto_Unchecked(object sender, RoutedEventArgs e)
        {
            mvAlq.QuitaFiltros();
        }

        private void tbApellido_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvAlq.Filtra();
        }
    }
}
