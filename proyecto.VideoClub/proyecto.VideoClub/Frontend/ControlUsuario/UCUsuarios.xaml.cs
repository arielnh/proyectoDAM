using System.Windows.Controls;
using proyecto.VideoClub.Backend.Modelo;
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
        public UCUsuarios(videoclubEntities ent)
        {
            InitializeComponent();
            vcEnt = ent;
            mvUsuario = new MVUsuario(vcEnt);
            DataContext = mvUsuario;
        }
    }
}
