using LiveCharts;
using LiveCharts.Wpf;
using proyecto.VideoClub.Backend.Servicios;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Controls;

namespace proyecto.VideoClub.Frontend.ControlUsuario
{
    /// <summary>
    /// Interaction logic for UCChart.xaml
    /// </summary>
    public partial class UCChart : UserControl
    {
        private ServicioCharts serChart;
        
        public UCChart()
        {
            serChart = new ServicioCharts();
            InitializeComponent();
            loadChart();
        }

        private void loadChart()
        {
            DataTable dt = serChart.getDatos("select count(id_alquiler) as alquileres, month(fecha_alquiler) as meses from videoclub.alquiler group by month(fecha_alquiler)"); 
            
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.SeriesView.Title, chartPoint.Participation);
            
            ChartValues<double> cht_y_values = new ChartValues<double>();
            SeriesCollection series = new LiveCharts.SeriesCollection();
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            foreach (DataRow dr in dt.Rows)
            {
                PieSeries ps = new PieSeries
                {
                    Title = "Mes: " + cultureInfo.DateTimeFormat.GetMonthName((int)dr[1]),
                    Values = new ChartValues<double> { double.Parse(dr[0].ToString()) },
                    DataLabels = true,
                    LabelPoint = labelPoint
                };
                series.Add(ps);
            }
            lvAlquiler.Series = series;
        }
    }
}
