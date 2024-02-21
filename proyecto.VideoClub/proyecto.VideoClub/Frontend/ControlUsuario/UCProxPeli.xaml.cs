using System.Windows.Controls;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Frontend.Dialogos;
using proyecto.VideoClub.MVVM;

namespace proyecto.VideoClub.Frontend.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UCProxPeli.xaml
    /// </summary>
    public partial class UCProxPeli : UserControl
    {
        private videoclubEntities vcEnt;
        private MVProducto mvProducto;
        public UCProxPeli(videoclubEntities ent)
        {
            InitializeComponent();
            vcEnt = ent;
            inicializa();

        }
        private void inicializa()
        {
            mvProducto = new MVProducto(vcEnt);
            DataContext = mvProducto;
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
