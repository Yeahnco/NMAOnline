using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Controladores
{
    public class PropertyCh : INotifyPropertyChanged
    {
        private string estadoPago;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {


            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }


        }

        public string EstadoPago
        {
            get { return estadoPago; }
            set { estadoPago = value;

            OnPropertyChanged("EstadoPago");}
        }
    }
}
