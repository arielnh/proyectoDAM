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
using proyecto.VideoClub.Backend.Servicios;


namespace proyecto.VideoClub.Frontend.Dialogos
{
    /// <summary>
    /// Lógica de interacción para NuevoUsuario.xaml
    /// </summary>
    public partial class NuevoUsuario : Window
    {
        private videoclubEntities vcEnt;
        private MVUsuario mvUsu;

        public NuevoUsuario()
        {
            InitializeComponent();
        }
        public NuevoUsuario(videoclubEntities ent)
        {
            
            InitializeComponent();
            vcEnt = ent;
            mvUsu = new MVUsuario(vcEnt);
            DataContext = mvUsu;
        }

        public NuevoUsuario(videoclubEntities ent, usuario usu)
        {
            InitializeComponent();
            vcEnt = ent;
            mvUsu = new MVUsuario(vcEnt);
            this.DataContext = mvUsu;
            mvUsu.usuarioEdit = usu;
            
        }

        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {

            if (mvUsu.guarda)
            {
                MessageBox.Show("Todo guardado correctamente.","Guardar Usuario", MessageBoxButton.OK);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Se ha producido un error.","Guardar Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
