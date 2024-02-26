using System.Windows.Controls;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.MVVM;
using proyecto.VideoClub.Frontend.Dialogos;


namespace proyecto.VideoClub.Frontend.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UCJuegos.xaml
    /// </summary>
    public partial class UCJuegos : UserControl
    {
        private videoclubEntities vcEnt;
        private MVProducto mvProducto;
        private usuario _usu;
        public UCJuegos(videoclubEntities ent)
        {
            InitializeComponent();
            vcEnt = ent;
            mvProducto = new MVProducto(vcEnt);
            DataContext = mvProducto;
        }

        public UCJuegos(videoclubEntities ent, usuario usu)
        {
            InitializeComponent();
            vcEnt = ent;
            mvProducto = new MVProducto(vcEnt);
            DataContext = mvProducto;
            _usu = usu;
           
        }

        private void btnReserva_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            if (dgListaJuegos.SelectedItem != null && dgListaJuegos.SelectedItem is producto)
            {
                producto pr = (producto)dgListaJuegos.SelectedItem;

                Reserva nu = new Reserva(vcEnt, _usu, pr);
                nu.ShowDialog();

                dgListaJuegos.ItemsSource = mvProducto.RefrescaJue();

                // dgListaPeliculas.Items.Refresh();

            }
        }
    }
}
