using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using MahApps.Metro.Theming;
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

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para Profesional.xaml
    /// </summary>
    public partial class Profesional : MetroWindow
    {
        public Profesional()
        {
            InitializeComponent();
            this.WindowStyle = WindowStyle.None;
        }
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            if (flyout.IsOpen == false)
            {
                flyout.IsOpen = true;
            }
            else if (flyout.IsOpen == true)
            {
                flyout.IsOpen = false;
            }

        }

    }
}
