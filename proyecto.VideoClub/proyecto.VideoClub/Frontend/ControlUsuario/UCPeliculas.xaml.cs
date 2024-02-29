using System.Windows.Controls;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Frontend.Dialogos;
using proyecto.VideoClub.MVVM;

namespace proyecto.VideoClub.Frontend.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UCPeliculas.xaml
    /// </summary>
    public partial class UCPeliculas : UserControl
    {
        private videoclubEntities vcEnt;
        private MVProducto mvProducto;
        private producto prodReserva;
        private usuario _usu;
        private bool publico = false;
        public UCPeliculas(videoclubEntities ent)
        {
            InitializeComponent();
            vcEnt = ent;
            inicializa();
            publico = true;

    }
        public UCPeliculas(videoclubEntities ent, usuario usu)
        {
            InitializeComponent();
            vcEnt = ent;
            _usu = usu;
            inicializa();


        }


        private void inicializa()
        {
            mvProducto = new MVProducto(vcEnt);
            DataContext = mvProducto;

        }

        private void btnReserva_Click(object sender, System.Windows.RoutedEventArgs e)
        {
           if(publico)
            {
                ErrorRegistro er = new ErrorRegistro();
                er.Show();
               
            }

            if (!publico && dgListaPeliculas.SelectedItem != null && dgListaPeliculas.SelectedItem is producto)
            {
                producto pr = (producto)dgListaPeliculas.SelectedItem;
               
                Reserva nu = new Reserva (vcEnt, _usu, pr);
                nu.ShowDialog();

                dgListaPeliculas.ItemsSource = mvProducto.RefrescaPelis();
               
               // dgListaPeliculas.Items.Refresh();

            }

        }

        private void tbTitulo_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvProducto.Filtra();
        }

        private void tbDirector_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvProducto.Filtra();
        }
    }
}
