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
using PersistenciaBD;
using Controladores;
using System.Data.Entity.Core.Mapping;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para test.xaml
    /// </summary>
    public partial class test : MetroWindow
    {
        ServiceCliente sc = new ServiceCliente();
        ServiceProfesional sp = new ServiceProfesional();
        ServiceGerente sg = new ServiceGerente();
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
        private void tbItemProfesionales_GotFocus(object sender, RoutedEventArgs e)
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
            if (tbItemOpciones1.Header.Equals("CLIENTE"))
            {
                scrlViewerOpcion1Cliente.Visibility = Visibility.Visible;
            }
            else
            {
                scrlViewerOpcion1Cliente.Visibility = Visibility.Collapsed;
            }
        }
        public ClienteTarjetaCompleta CrearTarjeta(int idc, int idg, int idp)
        {
            var rut = sc.GetEntity(idc).Rut_emp.ToString() + '-' + sc.GetEntity(idc).Dv_Rut_emp;
            ClienteTarjetaCompleta clienteTarjetaCompleta = new ClienteTarjetaCompleta();
            clienteTarjetaCompleta.displayEmpresa = sc.GetEntity(idc).Nombre_emp;
            clienteTarjetaCompleta.displayRutEmpresa = rut;
            clienteTarjetaCompleta.displayGerente = sg.GetEntity(idg).Nombre_gerente;
            clienteTarjetaCompleta.displayProfNombre = sp.GetEntity(idp).Nombre_prof;
            clienteTarjetaCompleta.displayMailGerente = sg.GetEntity(idg).Mail_cliente;
            clienteTarjetaCompleta.displayTelefonoEmpresa = sg.GetEntity(idg).Fono_cliente.ToString();
            clienteTarjetaCompleta.displayDireccion = sc.GetEntity(idc).Direccion_emp;

            return clienteTarjetaCompleta;
        }

        public void MostrarClientes()
        {
            List<Cliente> cliente = new List<Cliente>();
            List<Profesional> profesional = new List<Profesional>();
            List<Gerente> gerente = new List<Gerente>();
            foreach (Profesional p in sp.GetEntities())
                foreach (Gerente g in sg.GetEntities())
                    foreach (Cliente c in sc.GetEntities())
                    {
                        profesional.Add(sp.GetEntity(1));
                        gerente.Add(sg.GetEntity(1));
                        cliente.Add(sc.GetEntity(1));
                        stckPanelTarjetasCliente.Children.Add(CrearTarjeta(c.id_emp, g.id_gerente, p.id_prof));
                    }
        }
        /*
        public void ListaCliente()
        {
            ClienteTarjetaCompleta clienteTarjeta = new ClienteTarjetaCompleta();
            List<Cliente> cliente = new List<Cliente>();
            List<Gerente> gerente = new List<Gerente>();
            List<Profesional> profesional = new List<Profesional>();
            foreach (Cliente c in sc.GetEntities())
            {
                clienteTarjeta.displayEmpresa = c.Nombre_emp.ToString();
                clienteTarjeta.displayRutEmpresa = c.Rut_emp.ToString()+'-'+c.Dv_Rut_emp;
            }
        }
        */

        private void stckPanelTarjetasCliente_Initialized(object sender, EventArgs e)
        {
            MostrarClientes();
        }

        private void TabitemProfesionales_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}

