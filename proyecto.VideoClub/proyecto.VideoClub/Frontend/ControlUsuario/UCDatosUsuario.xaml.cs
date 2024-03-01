using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.MVVM;
using System.Windows.Controls;
using proyecto.VideoClub.Frontend.Dialogos;
namespace proyecto.VideoClub.Frontend.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UCDatosUsuario.xaml
    /// </summary>
    public partial class UCDatosUsuario : UserControl
    {
        private videoclubEntities vcEnt;
        private MVUsuario mvUsuario;
        private usuario usuLogin;
        public UCDatosUsuario(videoclubEntities ent, usuario usu)
        {
            
            vcEnt = ent;
            InitializeComponent();
            usuLogin = usu;
            mvUsuario = new MVUsuario(vcEnt, usuLogin);
            DataContext = mvUsuario;
        }

       

        private void Editar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (dgListaUsuarios.SelectedItem != null && dgListaUsuarios.SelectedItem is usuario)
            {

                usuario usu = (usuario)dgListaUsuarios.SelectedItem;
                EditarMisDatos ed = new EditarMisDatos (vcEnt, usu);
                ed.ShowDialog();
                dgListaUsuarios.Items.Refresh();

            }
           
        }
    }
}
