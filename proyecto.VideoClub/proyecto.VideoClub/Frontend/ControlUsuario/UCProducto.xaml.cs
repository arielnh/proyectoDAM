using System;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Frontend.Dialogos;
using proyecto.VideoClub.MVVM;

namespace proyecto.VideoClub.Frontend.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UCProducto.xaml
    /// </summary>
    public partial class UCProducto : UserControl
    {
        private videoclubEntities vcEnt;
        private MVProducto mvProducto;
        public UCProducto()
        {
            InitializeComponent();
        }
        public UCProducto(videoclubEntities ent)
        {
            InitializeComponent();
            vcEnt = ent;
            mvProducto = new MVProducto(vcEnt);
            DataContext = mvProducto;
        }

        private void itemEditar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (dgListaProductos.SelectedItem != null && dgListaProductos.SelectedItem is producto)
            {

                producto prod = (producto)dgListaProductos.SelectedItem;
                NuevoProducto nu = new NuevoProducto(vcEnt, prod);
                nu.ShowDialog();
                dgListaProductos.Items.Refresh();
            }
        }

        private void itemBorrar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            producto prod = (producto)dgListaProductos.SelectedItem;
            mvProducto.BorrarProd(prod);
            dgListaProductos.ItemsSource = mvProducto.Refresca();
           
        }
    }
}