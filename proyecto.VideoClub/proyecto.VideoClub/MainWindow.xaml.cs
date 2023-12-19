using proyecto.VideoClub.Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace proyecto.VideoClub
{
    
    public partial class MainWindow : Window
    {
        private usuario usuLogin;
        private videoclubEntities VCEnt;
        

        public MainWindow(videoclubEntities ent, usuario usu)
        {
            VCEnt = ent;
            usuLogin = usu;
            InitializeComponent();

        }

        

        private void Todas_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void TodosJ_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void TodosU_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
