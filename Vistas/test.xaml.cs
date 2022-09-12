using MahApps.Metro.Controls;
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
using MahApps.Metro.Converters;
using System.Security.Cryptography.X509Certificates;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para test.xaml
    /// </summary>
    public partial class test : MetroWindow
    {
        public test()
        {
            InitializeComponent();
            tbItemOpciones1.Visibility = Visibility.Collapsed;
            tbItemOpciones2.Visibility = Visibility.Collapsed;
            tbItemOpciones3.Visibility = Visibility.Collapsed;
            scrlViewerOpcion1Cliente.Visibility = Visibility.Collapsed;
        }
        ////////////TESTEO DE DYNAMICTABITEM////////////////////////////////
        /*
        public List<TabItem> TabItems { get; set; } = new List<TabItem>();  
        
        private void AddTabItems()
        {
            TabItems.Add
                (
                    new TabItem()
                    {
                        Header = "Cliente"
                    }
                );
        }


        private void tabItemClientes_GotFocus(object sender, RoutedEventArgs e)
        {
            tbControlSecondOpcionesTabItem.Items.Clear();
            TabItem newTI = new TabItem
            {
                Header = "CLIENTE",
                Height = 60,
                Width = 110,
                Name = "CLIENTE"
            };
            TabItem newTI1 = new TabItem
            {
                Header = "ASESORÍA",
                Height = 60,
                Width = 110,
            };
            TabItem newTI2 = new TabItem
            {
                Header = "SOLICITUDES",
                Height = 60,
                Width = 110,
            };
            tbControlSecondOpcionesTabItem.Items.Add(newTI);
            tbControlSecondOpcionesTabItem.Items.Add(newTI1);
        }
        */
        ////////////TESTEO DE DYNAMICTABITEM////////////////////////////////
        private void tabItemClientes_GotFocus(object sender, RoutedEventArgs e)
        {
            tbItemOpciones1.Header = "CLIENTE";
            tbItemOpciones2.Header = "ASESORIAS";
            tbItemOpciones3.Header = "SOLICITUDES";
            tbItemOpciones1.Visibility = Visibility.Visible;
            tbItemOpciones2.Visibility = Visibility.Visible;
            tbItemOpciones3.Visibility = Visibility.Visible;
        }
        private void TabitemProfesionales_GotFocus(object sender, RoutedEventArgs e)
        {
            tbItemOpciones1.Header = "REVISIÓN";
            tbItemOpciones1.Visibility = Visibility.Visible;
            tbItemOpciones2.Visibility = Visibility.Collapsed;
            tbItemOpciones3.Visibility = Visibility.Collapsed;

        }
       
        private void tileSalir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            this.Close();
            login.ShowDialog();
        }

        private void tbItemOpciones1_GotFocus(object sender, RoutedEventArgs e)
        {
            if(tbItemOpciones1.Header.Equals("CLIENTE"))
            {
                scrlViewerOpcion1Cliente.Visibility = Visibility.Visible;   
            }
            else
            {
                scrlViewerOpcion1Cliente.Visibility = Visibility.Collapsed;
            }
        }
    }
}
