using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.MVVM;
using System;
using System.Windows.Controls;
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
    }
}
