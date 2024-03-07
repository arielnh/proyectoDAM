
using System.Windows;
using System.Windows.Controls;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.MVVM;



namespace proyecto.VideoClub.Frontend.Dialogos
{
    /// <summary>
    /// Lógica de interacción para NuevoUsuario.xaml
    /// </summary>
    public partial class NuevoUsuario : Window
    {
        private videoclubEntities vcEnt;
        private MVUsuario mvUsu;
        private bool editar;

        public NuevoUsuario()
        {
            InitializeComponent();
            inicializa();
        }
        public NuevoUsuario(videoclubEntities ent)
        {
            
            InitializeComponent();
            vcEnt = ent;
            mvUsu = new MVUsuario(vcEnt);
            DataContext = mvUsu;
            editar = false;
            inicializa();
        }

        public NuevoUsuario(videoclubEntities ent, usuario usu)
        {
            InitializeComponent();
            vcEnt = ent;
            mvUsu = new MVUsuario(vcEnt);
            this.DataContext = mvUsu;
            mvUsu.usuarioNuevo = usu;
            editar = true;
            inicializa();
           

        }

        private void inicializa()
        {
            //Deshabilitar el boton guardar en caso de hay algun error de validacion
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvUsu.OnErrorEvent));
            mvUsu.btnGuardar = btnGuardarUsuario;

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
