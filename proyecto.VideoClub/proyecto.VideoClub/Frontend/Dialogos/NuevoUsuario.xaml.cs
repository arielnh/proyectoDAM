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

namespace proyecto.VideoClub.Frontend.Dialogos
{
    /// <summary>
    /// Lógica de interacción para NuevoUsuario.xaml
    /// </summary>
    public partial class NuevoUsuario : Window
    {
        public NuevoUsuario(object vCEnt)
        {
            InitializeComponent();
        }

        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            
        }
    }
}
