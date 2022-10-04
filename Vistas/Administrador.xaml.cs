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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using Controladores;
using ControlzEx.Standard;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using PersistenciaBD;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para Administrador.xaml
    /// </summary>
    public partial class Administrador : MetroWindow
    {
        //////////////////////// Variables Globales //////////////////////////
        int n=0;
        ServiceCliente sc = new ServiceCliente();
        ServiceVisita sv = new ServiceVisita();
        ServiceActividad sa = new ServiceActividad();
        ServiceProfesional sp = new ServiceProfesional();
        ServiceGerente sg = new ServiceGerente();
        

        //////////////////////// Variables Globales //////////////////////////
        public Administrador()
        {
            InitializeComponent();
        }

        //////////////////////// METODOS CREADOS //////////////////////////

        public TarjetaActividades CrearTarjetaActividades(int idAct, int idCli, int idProf)
        {
            TarjetaActividades tarjetaActividades = new TarjetaActividades();
           
            tarjetaActividades.nombreEmp = sc.GetEntity(idCli).Nombre_emp;
            tarjetaActividades.fechaAct = sa.GetEntity(idAct).Fecha_act.ToShortDateString();
            tarjetaActividades.nombreGer = sg.GetEntity(idCli).Nombre_gerente;
            tarjetaActividades.nombreProf = sp.GetEntity(idProf).Nombre_prof;
            tarjetaActividades.horaAct = sa.GetEntity(idAct).Hora_act.ToString();
            tarjetaActividades.lblAct = sa.GetEntity(idAct).Tipo_actividad;

            return tarjetaActividades;
        }


        public void TarjetasHoy()
        {

            List<Actividad> actividad = new List<Actividad>();
            foreach (Actividad c in sa.GetEntities())
            {
                
                if (c.Fecha_act == DateTime.Today)
                {
                    stackActHoy.Children.Add(CrearTarjetaActividades(c.id_act, c.Cliente_id_emp, c.Prof_id_profe));
                }

            }
        }

        public void TarjetasSemana()
        {
            DateTime fechaHoy = DateTime.Today;
            DateTime fechaSemana = fechaHoy.AddDays(7);

            List<Actividad> actividad = new List<Actividad>();
            actividad.OrderBy(actividad => actividad.Hora_act);
            foreach (Actividad c in sa.GetEntities())
            {
                if ((c.Fecha_act >= fechaHoy) && (c.Fecha_act <= fechaSemana))
                {
                    stackSemana.Children.Add(CrearTarjetaActividades(c.id_act, c.Cliente_id_emp, c.Prof_id_profe));
                }
            }
        }

        public void TarjetasCerradas()
        {
            DateTime fechaHoy = DateTime.Today;
            DateTime fechaSemana = fechaHoy.AddDays(7);

            List<Actividad> actividad = new List<Actividad>();
            foreach (Actividad c in sa.GetEntities())
            {
                if (c.Fecha_act < fechaHoy)
                {
                    stackCerradas.Children.Add(CrearTarjetaActividades(c.id_act, c.Cliente_id_emp, c.Prof_id_profe));
                }
            }
        }

        private async void FiltrarStackActHoy()
        {
            try
            {
                string filtro = txbBuscAct.Text.ToLower();
                stackActHoy.Children.Clear();
                
                foreach (Actividad c in sa.GetEntities())
                {

                    if (c.Fecha_act == DateTime.Today)
                    {
                        string nC = sc.GetEntity(c.Cliente_id_emp).Nombre_emp;
                        string nP = sp.GetEntity(c.Prof_id_profe).Nombre_prof;
                        string nG = sg.GetEntity(sc.GetEntity(c.Cliente_id_emp).id_emp).Nombre_gerente;
                        string nA = sa.GetEntity(c.id_act).Tipo_actividad;

                        if (nC.ToLower().Contains(filtro) | nP.ToLower().Contains(filtro) | nG.ToLower().Contains(filtro) | nA.ToLower().Contains(filtro))
                        {
                            stackActHoy.Children.Add(CrearTarjetaActividades(c.id_act, c.Cliente_id_emp, c.Prof_id_profe));
                        }
                        
                    }

                }
            }

            catch(Exception ex)
            {
                await this.ShowMessageAsync("ERROR: ", "Se ha producido un error al filtrar. \n" + ex.Message);
            }
        }

        private async void FiltrarStackActSemana()
        {
            try
            {
                string filtro = txbBuscAct.Text.ToLower();
                stackSemana.Children.Clear();
                DateTime fechaHoy = DateTime.Today;
                DateTime fechaSemana = fechaHoy.AddDays(7);

                foreach (Actividad c in sa.GetEntities())
                {

                    if ((c.Fecha_act >= fechaHoy) && (c.Fecha_act <= fechaSemana))
                    {
                        string nC = sc.GetEntity(c.Cliente_id_emp).Nombre_emp;
                        string nP = sp.GetEntity(c.Prof_id_profe).Nombre_prof;
                        string nG = sg.GetEntity(sc.GetEntity(c.Cliente_id_emp).id_emp).Nombre_gerente;
                        string nA = sa.GetEntity(c.id_act).Tipo_actividad;
                        string fA = sa.GetEntity(c.id_act).Fecha_act.ToShortDateString();

                        if (nC.ToLower().Contains(filtro) | nP.ToLower().Contains(filtro) | nG.ToLower().Contains(filtro) | nA.ToLower().Contains(filtro) | fA.Contains(filtro))
                        {
                            stackSemana.Children.Add(CrearTarjetaActividades(c.id_act, c.Cliente_id_emp, c.Prof_id_profe));
                        }

                    }

                }
            }

            catch (Exception ex)
            {
                await this.ShowMessageAsync("ERROR: ", "Se ha producido un error al filtrar. \n" + ex.Message);
            }
        }

        private async void FiltrarStackActCerradas()
        {
            try
            {
                string filtro = txbBuscAct.Text.ToLower();
                stackCerradas.Children.Clear();
                DateTime fechaHoy = DateTime.Today;
                DateTime fechaSemana = fechaHoy.AddDays(7);

                foreach (Actividad c in sa.GetEntities())
                {

                    if (c.Fecha_act < fechaHoy)
                    {
                        string nC = sc.GetEntity(c.Cliente_id_emp).Nombre_emp;
                        string nP = sp.GetEntity(c.Prof_id_profe).Nombre_prof;
                        string nG = sg.GetEntity(sc.GetEntity(c.Cliente_id_emp).id_emp).Nombre_gerente;
                        string nA = sa.GetEntity(c.id_act).Tipo_actividad;
                        string fA = sa.GetEntity(c.id_act).Fecha_act.ToShortDateString();

                        if (nC.ToLower().Contains(filtro) | nP.ToLower().Contains(filtro) | nG.ToLower().Contains(filtro) | nA.ToLower().Contains(filtro) | fA.Contains(filtro))
                        {
                            stackCerradas.Children.Add(CrearTarjetaActividades(c.id_act, c.Cliente_id_emp, c.Prof_id_profe));
                        }

                    }

                }
            }

            catch (Exception ex)
            {
                await this.ShowMessageAsync("ERROR: ", "Se ha producido un error al filtrar. \n" + ex.Message);
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

        public void TarjetasClientes()
        {

            List<Cliente> cliente = new List<Cliente>();
            foreach (Cliente c in sc.GetEntities())
            {

                    stackCliAdm.Children.Add(CrearTarjeta(c.id_emp, sg.GetEntity(c.id_emp).id_gerente, c.Profesional_id_prof));

            }
        }
        //////////////////////// METODOS CREADOS //////////////////////////


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            this.Close();
            login.ShowDialog();
        }

        private void stackActHoy_Initialized(object sender, EventArgs e)
        {
            TarjetasHoy();
        }

        private void stackSemana_Initialized(object sender, EventArgs e)
        {
            TarjetasSemana();
        }

        private void stackCerradas_Initialized(object sender, EventArgs e)
        {
            TarjetasCerradas();
        }

        private void stackCliAdm_Initialized(object sender, EventArgs e)
        {
            TarjetasClientes();
        }

        private void txbBuscAct_TextChanged(object sender, TextChangedEventArgs e)
        {
            FiltrarStackActHoy();
            FiltrarStackActSemana();
            FiltrarStackActCerradas();
        }
    }
}

