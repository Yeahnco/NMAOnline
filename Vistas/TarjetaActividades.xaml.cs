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

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para TarjetaActividades.xaml
    /// </summary>
    public partial class TarjetaActividades : UserControl
    {
        public TarjetaActividades()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string nombreEmp { get; set; }
        public string fechaAct { get; set; }
        public string nombreGer { get; set; }
        public string nombreProf { get; set; }  
        public string horaAct {get; set; }
        public string lblAct { get; set; }


        
    }
}
