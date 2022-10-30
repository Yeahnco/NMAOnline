using ControlzEx.Standard;
using MahApps.Metro.Controls;
using PersistenciaBD;
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
using static Vistas.Administrador;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para TarjetaPagos.xaml
    /// </summary>
    public partial class TarjetaPagos : UserControl
    {
        public TarjetaPagos()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string nombreEmp { get; set; }
        public string rutEmp { get; set; }
        public string Estado { get; set; }
        public string Mes { get; set; }
        public string Plan { get; set; }
        public int ValorPlan { get; set; }
        public int ValorExtra { get; set; }
        public int Total { get; set; }
        public int idPago { get; set; }
        public int idCliente { get; set; }

        public void actualizarBD(string nuevoDato, int idP)
        {
            using (BD_NMAEntities db = new BD_NMAEntities())
            {
                db.crudUpdate("Pago", "Estado_pago", nuevoDato, idP);
                db.SaveChanges();
            }
        }

        private void lvPagos_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            btnCambiarEsPag.Visibility = Visibility.Visible;

        }

        private void btnCambiarEsPag_Click(object sender, RoutedEventArgs e)
        {
            Pagos pagos = (Pagos)lvPagos.SelectedItem;
            if(pagos.Estado == "PENDIENTE")
            {
                actualizarBD("PAGADO", pagos.idPago);
            }
            
            if(pagos.Estado == "PAGADO")
            {
                actualizarBD("PENDIENTE", pagos.idPago);
            }

            Administrador admi = new Administrador();
            Window.GetWindow(this).Close();
            admi.Show();

            
        }

        private void btnComprobante_Click(object sender, RoutedEventArgs e)
        {
            
        }

       
    }
}
