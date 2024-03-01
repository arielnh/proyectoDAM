using System.Windows;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.MVVM;

namespace proyecto.VideoClub.Frontend.Dialogos
{
    
    public partial class EditarMisDatos : Window
    {
        private videoclubEntities vcEnt;
        private MVUsuario mvUsu;
        private bool editar;
        public EditarMisDatos(videoclubEntities ent, usuario usu)
        {
            InitializeComponent();
            vcEnt = ent;
            mvUsu = new MVUsuario(vcEnt);
            this.DataContext = mvUsu;
            mvUsu.usuarioNuevo = usu;
            editar = true;
        }
        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (!editar)
            {

                if (mvUsu.guarda)
                {
                    MessageBox.Show("Todo guardado correctamente.", "Guardar Usuario", MessageBoxButton.OK);
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Se ha producido un error.", "Guardar Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (mvUsu.update)
                {

                    DialogResult = true;
                }
                else
                {

                    DialogResult = false;
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}