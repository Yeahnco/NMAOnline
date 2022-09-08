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

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para ClienteTarjetaCompleta.xaml
    /// </summary>
    public partial class ClienteTarjetaCompleta : UserControl
    {
        public ClienteTarjetaCompleta()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public string displayEmpresa { get; set; }
        public string displayRutEmpresa { get; set; }
        public string displayGerente { get; set; }
        public string displayProfNombre { get; set; }
        public string displayMailGerente { get; set; }
        public string displayTelefonoEmpresa { get; set; }
        public string displayDireccion { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(dockPanelMedio.Visibility == Visibility.Collapsed)
            {
                dockPanelMedio.Visibility = Visibility.Visible;
                ucVentana.Height.Equals(300);
            }
            else if (dockPanelMedio.Visibility == Visibility.Visible)
            {
                ucVentana.Height.Equals(72.4137931034483);
                dockPanelMedio.Visibility = Visibility.Collapsed;
            }
        }

        private void gridVentanaCompleta_Initialized(object sender, EventArgs e)
        {
            dockPanelMedio.Visibility=Visibility.Collapsed;
            ucVentana.Height.Equals(72.4137931034483);
        }
    }
}
