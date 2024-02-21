using CrystalDecisions.CrystalReports.Engine;
using proyecto.VideoClub.Backend.Servicios;
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

namespace proyecto.VideoClub.Informes
{
    /// <summary>
    /// Interaction logic for UCInforme.xaml
    /// </summary>
    public partial class UCInforme : UserControl
    {
        public UCInforme()
        {
            InitializeComponent();
            cargaInforme();
        }

        private void cargaInforme()
        {
            try
            {
                // Creamos un nuevo objeto Documento 
                ReportDocument rd = new ReportDocument();

                // Indicamos la ruta del informe 
                rd.Load("../../Informes/CRAlquiler.rpt");
                // Obtenemos el servicio asociado a las oficinas 
                ServicioSQL sqlServ = new ServicioSQL();
                // Obtenemos la liosta de oficinas 
                rd.SetDataSource(sqlServ.getDatos("select * from alquiler")); 
                // Rellenamos los datos del informe
                crViewerAlquiler.ViewerCore.ReportSource = rd;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
