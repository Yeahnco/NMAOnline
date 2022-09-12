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

        

        //////////////////////// Variables Globales //////////////////////////
        public Administrador()
        {
            InitializeComponent();
        }

        //////////////////////// METODOS CREADOS //////////////////////////
  
        public TarjetaActividades CrearTarjeta(int id)
        {
            TarjetaActividades tarjetaActividades = new TarjetaActividades();

            tarjetaActividades.nombreEmp = sc.GetEntity(1).Nombre_emp;
            tarjetaActividades.fechaAct = sa.GetEntity(id).Fecha_act.ToShortDateString();
            tarjetaActividades.nombreGer = "Willson Fisk";
            tarjetaActividades.nombreProf = sp.GetEntity(1).Nombre_prof;
            tarjetaActividades.horaAct = sa.GetEntity(id).Hora_act.ToString();
            tarjetaActividades.lblAct = sa.GetEntity(id).Tipo_actividad;

            return tarjetaActividades;
        }

        public void TarjetasHoy()
        {

            List<Actividad> actividad = new List<Actividad>();
            foreach (Actividad c in sa.GetEntities())
            {
                if (c.Fecha_act == DateTime.Today)
                {
                    stackActHoy.Children.Add(CrearTarjeta(c.id_act));
                }
            }
        }

        public void TarjetasSemana()
        {
            DateTime fechaHoy = DateTime.Today;
            DateTime fechaSemana = fechaHoy.AddDays(7);

            List<Actividad> actividad = new List<Actividad>();
            foreach (Actividad c in sa.GetEntities())
            {
                if ((c.Fecha_act >= fechaHoy) && (c.Fecha_act <= fechaSemana))
                {
                    stackSemana.Children.Add(CrearTarjeta(c.id_act));
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
                if ((c.Fecha_act < fechaHoy))
                {
                    stackCerradas.Children.Add(CrearTarjeta(c.id_act));
                }
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
    }
}

