using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.MVVM;
using System;
using System.Windows.Controls;

namespace proyecto.VideoClub.Frontend.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UCMisAlquileres.xaml
    /// </summary>
    public partial class UCMisAlquileres : UserControl
    {
        private videoclubEntities vcEnt;
        private MVAlquiler mvAlq;
        private usuario usuLogin;
        public UCMisAlquileres(videoclubEntities ent, usuario usu)
        {
            vcEnt = ent;
            InitializeComponent();
            usuLogin = usu;
            mvAlq = new MVAlquiler(vcEnt, usuLogin);
            DataContext = mvAlq;
        }
    }
}
