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
        }

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

        private void TabitemProfesionales_GotFocus(object sender, RoutedEventArgs e)
        {
            tbControlSecondOpcionesTabItem.Items.Clear();
            TabItem newTI = new TabItem
            {
                Header = "REVISIÓN",
                Height = 60,
                Width = 110,
            };
            tbControlSecondOpcionesTabItem.Items.Add(newTI);
        }
    }
}
