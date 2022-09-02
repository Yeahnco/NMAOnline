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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para Administrador.xaml
    /// </summary>
    public partial class Administrador : MetroWindow
    {
        public Administrador()
        {
            InitializeComponent();
        }
        public void CambiarTamañoTexto(Label a, String b)
        {
            while(b.Length > a.Width)
            {
                a.FontSize = a.FontSize - 1;
            }
                
        } 
        private void Label_Initialized(object sender, EventArgs e)
        {
            Empresa1.Content = "CCU";
        }

        private void fechaAct_Initialized(object sender, EventArgs e)
        {
            fechaAct.Content = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void nombreGerente_Initialized(object sender, EventArgs e)
        {
            nombreGerente.Content = "Willson Fisk";
        }

        private void nombreProf_Initialized(object sender, EventArgs e)
        {
            nombreProf.Content = "Gabriel Boric";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            this.Close();
            login.ShowDialog();
        }

        private void horaAct_Initialized(object sender, EventArgs e)
        {
            horaAct.Content = DateTime.Now.ToString("hh:mm tt");
        }

        private void lblActividad_Initialized(object sender, EventArgs e)
        {
            lblActividad.Content = "Visita";
        }
    }
}
