using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
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
using static Vistas.Administrador;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para Administrador.xaml
    /// </summary>
    public partial class Administrador : MetroWindow
    {
        

        

        //////////////////////// Variables Globales //////////////////////////
        int n = 0;
        ServiceCliente sc = new ServiceCliente();
        ServiceVisita sv = new ServiceVisita();
        ServiceActividad sa = new ServiceActividad();
        ServiceProfesional sp = new ServiceProfesional();
        ServiceGerente sg = new ServiceGerente();
        ServiceContrato sco = new ServiceContrato();
        ServicePlan spl = new ServicePlan();
        ServicePago spa = new ServicePago();

        public class Pagos
        {
            public string Estado { get; set; }
            public string Mes { get; set; }
            public string Plan { get; set; }
            public int ValorPlan { get; set; }
            public int ValorExtra { get; set; }
            public int Total { get; set; }
            public int idPago { get; set; }
            public int idCliente { get; set; }
        }


        //////////////////////// Variables Globales //////////////////////////
        public Administrador()
        {
            InitializeComponent();
        }

        private void actualizarBD(string nombreTab, string nombreCol, string nuevoDato, int id)
        {
            using (BD_NMAEntities db = new BD_NMAEntities())
            {
                db.crudUpdate(nombreTab,nombreCol,nuevoDato,id);
                db.SaveChanges();
            }
        }
        //////////////////////////////////////////////// METODOS CREADOS //////////////////////////////////////////////////////////////

        public TarjetaActividades CrearTarjetaActividades(int idAct, int idCli, int idProf)
        {
            TarjetaActividades tarjetaActividades = new TarjetaActividades();

            tarjetaActividades.nombreEmp = sc.GetEntity(idCli).Nombre_emp;
            tarjetaActividades.fechaAct = sa.GetEntity(idAct).Fecha_act.ToShortDateString();
            tarjetaActividades.nombreGer = sg.GetEntity(idCli).Nombre_gerente;
            tarjetaActividades.nombreProf = sp.GetEntity(idProf).Nombre_prof + ' ' + sp.GetEntity(idProf).Apellido_prof;
            tarjetaActividades.horaAct = sa.GetEntity(idAct).Hora_act.ToString();
            tarjetaActividades.lblAct = sa.GetEntity(idAct).Tipo_actividad.ToUpper();

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
                        string nP = sp.GetEntity(c.Prof_id_profe).Nombre_prof + ' ' + sp.GetEntity(c.Prof_id_profe).Apellido_prof;
                        string nG = sg.GetEntity(sc.GetEntity(c.Cliente_id_emp).id_emp).Nombre_gerente;
                        string nA = sa.GetEntity(c.id_act).Tipo_actividad;

                        if (nC.ToLower().Contains(filtro) | nP.ToLower().Contains(filtro) | nG.ToLower().Contains(filtro) | nA.ToLower().Contains(filtro))
                        {
                            stackActHoy.Children.Add(CrearTarjetaActividades(c.id_act, c.Cliente_id_emp, c.Prof_id_profe));
                        }

                    }

                }
            }

            catch (Exception ex)
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
                        string nP = sp.GetEntity(c.Prof_id_profe).Nombre_prof + ' ' + sp.GetEntity(c.Prof_id_profe).Apellido_prof;
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
                        string nP = sp.GetEntity(c.Prof_id_profe).Nombre_prof + ' ' + sp.GetEntity(c.Prof_id_profe).Apellido_prof;
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
        // ------------------------------------------------ ADM CLIENTE------------------------------------------------------ //
        public ClienteTarjetaCompleta CrearTarjeta(int idc, int idg, int idp)
        {
            ClienteTarjetaCompleta clienteTarjetaCompleta = new ClienteTarjetaCompleta();

            var rut = sc.GetEntity(idc).Rut_emp.ToString();

            clienteTarjetaCompleta.displayEmpresa = sc.GetEntity(idc).Nombre_emp;
            clienteTarjetaCompleta.displayRutEmpresa = rut;
            clienteTarjetaCompleta.displayGerente = sg.GetEntity(idg).Nombre_gerente;
            clienteTarjetaCompleta.displayProfNombre = sp.GetEntity(idp).Nombre_prof + ' ' + sp.GetEntity(idp).Apellido_prof;
            clienteTarjetaCompleta.displayMailGerente = sg.GetEntity(idg).Mail_cliente;
            clienteTarjetaCompleta.displayTelefonoEmpresa = sg.GetEntity(idg).Fono_cliente.ToString();
            clienteTarjetaCompleta.displayDireccion = sc.GetEntity(idc).Direccion_emp;
            clienteTarjetaCompleta.idClient = sc.GetEntity(idc).id_emp;

            clienteTarjetaCompleta.btnAgregarActividadMejora.Visibility = Visibility.Hidden;
            clienteTarjetaCompleta.btnAgregarAsesoria.Visibility = Visibility.Hidden;
            clienteTarjetaCompleta.btnAgregarCapacitacion.Visibility = Visibility.Hidden; 
            clienteTarjetaCompleta.btnAgregarVisita.Visibility = Visibility.Hidden;

            

            return clienteTarjetaCompleta;
        }

        public void TarjetasClientes()
        {

            List<Cliente> cliente = new List<Cliente>();
            foreach (Cliente c in sc.GetEntities())
            {
                if (c.id_emp == c.id_emp)
                {
                    stackCliAdm.Children.Add(CrearTarjeta(c.id_emp, sg.GetEntity(c.id_emp).id_gerente, c.Profesional_id_prof));
                }
            }
        }

        private async void FiltrarStackClientes()
        {
            try
            {
                string filtro = txbBuscAct.Text.ToLower();
                stackCliAdm.Children.Clear();

                foreach (Cliente c in sc.GetEntities())
                {
                    var rut = sc.GetEntity(c.id_emp).Rut_emp.ToString();
                    if (c.Nombre_emp.ToLower().Contains(filtro) | sp.GetEntity(c.Profesional_id_prof).Nombre_prof.ToLower().Contains(filtro) | sp.GetEntity(c.Profesional_id_prof).Apellido_prof.ToLower().Contains(filtro) | sg.GetEntity(c.id_emp).Nombre_gerente.ToLower().Contains(filtro) | c.Direccion_emp.ToLower().Contains(filtro) | sg.GetEntity(c.id_emp).Fono_cliente.ToString().ToLower().Contains(filtro) | sg.GetEntity(c.id_emp).Mail_cliente.ToLower().Contains(filtro) | rut.ToLower().Contains(filtro))
                    {

                        stackCliAdm.Children.Add(CrearTarjeta(c.id_emp, sg.GetEntity(c.id_emp).id_gerente, c.Profesional_id_prof));

                    }

                }

            }

            catch (Exception ex)
            {
                await this.ShowMessageAsync("ERROR: ", "Se ha producido un error al filtrar. \n" + ex.Message);
            }
        }
        // ------------------------------------------------ADM PAGOS------------------------------------------------------ //
        public TarjetaPagos CrearTarjetaPagos(int idc, int idg)
        {
            TarjetaPagos tarjetaPagos = new TarjetaPagos();
            var rut = sc.GetEntity(idc).Rut_emp.ToString();

            tarjetaPagos.nombreEmp = sc.GetEntity(idc).Nombre_emp;
            tarjetaPagos.rutEmp = rut;

            

            List<Pagos> items = new List<Pagos>();
            foreach (Pago p in spa.GetEntities())
            {
                if (sg.GetEntity(sco.GetEntity(spl.GetEntity(p.Plan_id_plan).Contrato_id_contrato).Gerente_id_gerente).Cliente_id_clien == idc)
                {

                    items.Add(new Pagos() { Estado = p.Estado_pago, Mes = p.Mes_pago, Plan = spl.GetEntity(p.Plan_id_plan).Tipo_plan, ValorPlan = Convert.ToInt32(spl.GetEntity(p.Plan_id_plan).Valor_plan), ValorExtra = Convert.ToInt32(p.Valor_extra), Total = Convert.ToInt32(spl.GetEntity(p.Plan_id_plan).Valor_plan + p.Valor_extra), idPago = p.id_pago, idCliente = idc });
                }

            }

            tarjetaPagos.lvPagos.ItemsSource = items;
      

            return tarjetaPagos;
        }

        public void TarjetaPagos()
        {

            foreach (Cliente c in sc.GetEntities())
            {
                stackPagos.Children.Add(CrearTarjetaPagos(c.id_emp, sg.GetEntity(c.id_emp).id_gerente));
            }
        }

        private async void FiltrarStackPagos()
        {
            try
            {
                string filtro = txbBuscAct.Text.ToLower();
                stackPagos.Children.Clear();

                foreach (Cliente c in sc.GetEntities())
                {

                    if (c.Nombre_emp.ToLower().Contains(filtro) | c.Rut_emp.ToLower().Contains(filtro))
                    {
                        stackPagos.Children.Add(CrearTarjetaPagos(c.id_emp, sg.GetEntity(c.id_emp).id_gerente));
                    }

                }

            }

            catch (Exception ex)
            {
                await this.ShowMessageAsync("ERROR: ", "Se ha producido un error al filtrar. \n" + ex.Message);
            }
        }  

        // ------------------------------------------------ADM PROF------------------------------------------------------ //
            
        public TarjetaProfesionales CrearTarjetaProfesional(int idp)
        {
            TarjetaProfesionales tarjetaProfesionales = new TarjetaProfesionales();

            var rut = sp.GetEntity(idp).Rut_prof.ToString();

            tarjetaProfesionales.rutProf = rut;
            tarjetaProfesionales.nombreProfesional = sp.GetEntity(idp).Nombre_prof;
            tarjetaProfesionales.apellidoProfesional = sp.GetEntity(idp).Apellido_prof;
            tarjetaProfesionales.telefonoProfesional = sp.GetEntity(idp).Telefono;
            tarjetaProfesionales.direccProf = sp.GetEntity(idp).Direccion;
            tarjetaProfesionales.mailProf = sp.GetEntity(idp).Mail_prof;

            tarjetaProfesionales.idProfe = sp.GetEntity(idp).id_prof;

            int contador = 0;
            foreach (Actividad a in sa.GetEntities())
            {
                if (a.Prof_id_profe == idp && a.Tipo_actividad == "Capacitación")
                {
                    contador++;
                }
            }
            tarjetaProfesionales.nCap = contador.ToString();

            contador = 0;
            foreach (Actividad a in sa.GetEntities())
            {
                if (a.Prof_id_profe == idp && a.Tipo_actividad == "Act Mejora")
                {
                    contador++;
                }
            }
            tarjetaProfesionales.nMejoras = contador.ToString();

            contador = 0;
            foreach (Actividad a in sa.GetEntities())
            {
                if (a.Prof_id_profe == idp && a.Tipo_actividad == "Visita")
                {
                    contador++;
                }
            }
            tarjetaProfesionales.nVisitas = contador.ToString();

            contador = 0;
            foreach (Actividad a in sa.GetEntities())
            {
                if (a.Prof_id_profe == idp && a.Tipo_actividad == "Asesoria")
                {
                    contador++;
                }
            }
            tarjetaProfesionales.nAsesorias = contador.ToString();

            contador = 0;
            foreach (Actividad a in sa.GetEntities())
            {
                if (a.Prof_id_profe == idp && a.Tipo_actividad == "Casos")
                {
                    contador++;
                }
            }
            tarjetaProfesionales.nCasos = contador.ToString();

            contador = 0;
            foreach (Cliente c in sc.GetEntities())
            {
                if (c.Profesional_id_prof == idp)
                {
                    contador++;
                }
            }
            tarjetaProfesionales.nClientes = contador.ToString();

            return tarjetaProfesionales;
        }

        public void TarjetaProfesional()
        {

            foreach (Profesional p in sp.GetEntities())
            {
                stackProf.Children.Add(CrearTarjetaProfesional(p.id_prof));
            }
        }

        private async void FiltrarStackProf()
        {
            try
            {
                string filtro = txbBuscAct.Text.ToLower();
                stackProf.Children.Clear();

                foreach (Profesional p in sp.GetEntities())
                {

                    if (p.Rut_prof.ToLower().Contains(filtro) | p.Nombre_prof.ToLower().Contains(filtro) | p.Mail_prof.ToLower().Contains(filtro) | p.Apellido_prof.ToLower().Contains(filtro))
                    {

                        stackProf.Children.Add(CrearTarjetaProfesional(p.id_prof));

                    }

                }

            }

            catch (Exception ex)
            {
                await this.ShowMessageAsync("ERROR: ", "Se ha producido un error al filtrar. \n" + ex.Message);
            }
        }
        //////////////////////////////////////////////// FIN METODOS CREADOS //////////////////////////////////////////////////////////////


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

            FiltrarStackClientes();
            FiltrarStackProf();
            FiltrarStackPagos();
        }

        private void stackPagos_Initialized(object sender, EventArgs e)
        {
            TarjetaPagos();
        }

        private void stackProf_Initialized(object sender, EventArgs e)
        {
            TarjetaProfesional();
        }

        private void stackCliAdm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Administrador adm = new Administrador();
                this.Close();
                adm.Show();
            }
            
        }

        private void TabControlAct2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Administrador adm = new Administrador();
                this.Close();
                adm.Show();
            }
        }

        private void stackPagos_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Vadmin_Closed(object sender, EventArgs e)
        {
           
        }
    }
}

