
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
        private usuario usu;
        bool admin= true;

        public UCUsuarios()
        {
            InitializeComponent();
        }
        public UCUsuarios(videoclubEntities ent, usuario u)
        {
            InitializeComponent();
            vcEnt = ent;
            usu = u;
            mvUsuario = new MVUsuario(vcEnt);
            DataContext = mvUsuario;
            if(usu.id_rol != 1)
            { admin = false; }
           
        }

        private void itemEditar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            if (admin && dgListaUsuarios.SelectedItem != null && dgListaUsuarios.SelectedItem is usuario)
            {
               
                usuario usu = (usuario)dgListaUsuarios.SelectedItem;
                NuevoUsuario nu = new NuevoUsuario(vcEnt,usu);
                nu.ShowDialog();
                dgListaUsuarios.Items.Refresh();

            }
            else
            {
                ErrorPermiso nu = new ErrorPermiso();
                nu.ShowDialog();
            }
        }

        private void itemBorrar_Click(object sender, System.Windows.RoutedEventArgs e)
        {


            if (admin)
            {
                usuario usu = (usuario)dgListaUsuarios.SelectedItem;
                mvUsuario.BorrarUsu(usu);
                dgListaUsuarios.ItemsSource = mvUsuario.Refresca();
            }
            else
            {
                ErrorPermiso nu = new ErrorPermiso();
                nu.ShowDialog();
            }
            
           

        }

        private void tbApellido_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvUsuario.Filtra();
        }
    }
}
