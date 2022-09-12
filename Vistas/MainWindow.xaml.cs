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
using System.Runtime.InteropServices;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        String username = "admin";
        String password = "123";
        String exampleUserProfesional = "prof";
        String examplePasswordProfesional = "123";
        String testname = "test";
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "NMA";
            
        }

        private async void ValidarLogin()
        {
            if (usuarioLogin.Text.Equals(username) && contrasenaLogin.Password.Equals(password))
            {
            }
            else if (usuarioLogin.Text.Equals(testname))
            {
                test prof = new test();
                this.Close();
                prof.ShowDialog();
            }
            else
            {
                await this.ShowMessageAsync("ERROR :", "Usuario no encontrado.");
            }
        }
        private void botonIngresar_Click(object sender, RoutedEventArgs e)
        {
            ValidarLogin();
        }
    }
}
