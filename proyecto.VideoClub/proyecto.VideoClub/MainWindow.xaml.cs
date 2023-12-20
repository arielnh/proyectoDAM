using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Frontend.ControlUsuario;
using System.Windows;

namespace proyecto.VideoClub
{
    
    public partial class MainWindow : Window
    {
        private usuario usuLogin;
        private videoclubEntities vcEnt;
        

        public MainWindow(videoclubEntities ent, usuario usu)
        {
            vcEnt = ent;
            usuLogin = usu;
            InitializeComponent();

        }

        

        private void Todas_Selected(object sender, RoutedEventArgs e)
        {
            UCPeliculas uc = new UCPeliculas(vcEnt);
            // Lo colocaremos en el panel central de nuestra aplicación
            // Si hay algo en el grid central lo borramos
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            // Añadimos nuestro user control
            gridCentral.Children.Add(uc);
        }

        private void TodosJ_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void TodosU_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
