using System.Windows.Controls;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Frontend.Dialogos;
using proyecto.VideoClub.MVVM;

namespace proyecto.VideoClub.Frontend.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UCUsuarios.xaml
    /// </summary>
    public partial class UCUsuarios : UserControl
    {
        private videoclubEntities vcEnt;
        private MVUsuario mvUsuario;

        public UCUsuarios()
        {
            InitializeComponent();
        }
        public UCUsuarios(videoclubEntities ent)
        {
            InitializeComponent();
            vcEnt = ent;
            mvUsuario = new MVUsuario(vcEnt);
            DataContext = mvUsuario;
        }

        private void itemEditar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (dgListaUsuarios.SelectedItem != null && dgListaUsuarios.SelectedItem is usuario)
            {
               
                usuario usu = (usuario)dgListaUsuarios.SelectedItem;
                NuevoUsuario nu = new NuevoUsuario(vcEnt,usu);
                nu.ShowDialog();
                dgListaUsuarios.Items.Refresh();

            }
        }

        private void itemBorrar_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
