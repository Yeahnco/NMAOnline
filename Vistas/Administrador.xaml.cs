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
        //////////////////////// Variables Globales //////////////////////////
        int n=0;

        //////////////////////// Variables Globales //////////////////////////
        public Administrador()
        {
            InitializeComponent();
        }

        //////////////////////// METODOS CREADOS //////////////////////////
        public void CambiarTamañoTexto(Label a, String b)
        {
            while(b.Length > a.Width)
            {
                a.FontSize = a.FontSize - 1;
            }
                
        }

        public void CrearTarjeta()
        {
            TarjetaActividades tarjetaActividades = new TarjetaActividades();
            stackActHoy.Children.Add(tarjetaActividades);

            tarjetaActividades.nombreEmp = "ZARA";
        }



        //////////////////////////////////////////////////////////////////////

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            this.Close();
            login.ShowDialog();
        }

        private void stackActHoy_Initialized(object sender, EventArgs e)
        {
            CrearTarjeta();
        }
    }
}

