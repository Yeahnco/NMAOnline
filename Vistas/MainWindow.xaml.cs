﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ValidarLogin()
        {
            if (usuarioLogin.Text.Equals(username) && contrasenaLogin.Text.Equals(password))
            {
                Administrador admini = new Administrador();
                this.Close();
                admini.ShowDialog();
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
