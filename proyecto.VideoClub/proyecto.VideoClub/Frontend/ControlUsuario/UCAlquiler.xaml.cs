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
            mvAlq.Devolver(aq);
            dgListaAlquiler.Items.Refresh();
            
            
        }

        private void itemEntregado_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
