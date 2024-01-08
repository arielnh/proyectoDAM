using System.Windows.Controls;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.MVVM;

namespace proyecto.VideoClub.Frontend.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UCJuegos.xaml
    /// </summary>
    public partial class UCJuegos : UserControl
    {
        private videoclubEntities vcEnt;
        private MVProducto mvProducto;
        public UCJuegos(videoclubEntities ent)
        {
            InitializeComponent();
            vcEnt = ent;
            mvProducto = new MVProducto(vcEnt);
            DataContext = mvProducto;
        }
    }
}
