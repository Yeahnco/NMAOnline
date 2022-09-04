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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para Administrador.xaml
    /// </summary>
    public partial class Administrador : MetroWindow
    {
        //////////////////////// Variables Globales //////////////////////////
        int n=0;

        //////////////////////// Variables Globales //////////////////////////
        public Administrador()
        {
            InitializeComponent();
        }
        public void CambiarTamañoTexto(Label a, String b)
        {
            while(b.Length > a.Width)
            {
                a.FontSize = a.FontSize - 1;
            }
                
        } 
        private void Label_Initialized(object sender, EventArgs e)
        {
            Empresa1.Content = "CCU";
        }

<<<<<<< HEAD
        //////////////////////// METODOS CREADOS //////////////////////////
        public void CambiarTamañoTexto(Label a, String b)
        {
            while(b.Length > a.Width)
            {
                a.FontSize = a.FontSize - 1;
            }
                
        }

        public int CrearTarjeta(Grid a, StackPanel b, int n)
        {
            Grid tarjeta = new Grid();

            tarjeta = a;
            tarjeta.Name = a.Name + n;

            if (tarjeta.Children.Contains(tarjeta1))
            { 
                tarjeta.Children.Remove(tarjeta1);

                Rectangle cloneT1 = new Rectangle();
                cloneT1 = tarjeta1;
                cloneT1.Name = tarjeta1.Name + n;

                tarjeta.Children.Add(cloneT1);
            }

            if (tarjeta.Children.Contains(Empresa1))
            {
                tarjeta.Children.Remove(Empresa1);

                Label cloneEmp = new Label();
                cloneEmp = Empresa1;
                cloneEmp.Name = Empresa1.Name + n;

                tarjeta.Children.Add(cloneEmp);
            }

            if (tarjeta.Children.Contains(fechaAct))
            {
                tarjeta.Children.Remove(fechaAct);

                Label cloneFecAct = new Label();
                cloneFecAct = fechaAct;
                cloneFecAct.Name = fechaAct.Name + n;

                tarjeta.Children.Add(cloneFecAct);

            }

            if (tarjeta.Children.Contains(nombreGerente))
            {
                tarjeta.Children.Remove(nombreGerente);

                Label cloneNG = new Label();
                cloneNG = nombreGerente;
                cloneNG.Name = nombreGerente.Name + n;

                tarjeta.Children.Add(cloneNG);
            }

            if (tarjeta.Children.Contains(nombreProf))
            {
                tarjeta.Children.Remove(nombreProf);

                Label cloneNP = new Label();
                cloneNP = nombreProf;
                cloneNP.Name = nombreProf.Name + n;

                tarjeta.Children.Add(cloneNP);
            }

            if (tarjeta.Children.Contains(horaAct))
            {
                tarjeta.Children.Remove(horaAct);

                Label clonehoraAct = new Label();
                clonehoraAct = horaAct;
                clonehoraAct.Name = horaAct.Name + n;

                tarjeta.Children.Add(clonehoraAct);
            }

            if (tarjeta.Children.Contains(lblActividad))
            {
                tarjeta.Children.Remove(lblActividad);

                Label clonelblAct = new Label();
                clonelblAct = lblActividad;
                clonelblAct.Name = lblActividad.Name + n;

                tarjeta.Children.Add(clonelblAct);
            }

            if (tarjeta.Children.Contains(sombra))
            {   
                tarjeta.Children.Remove(sombra);

                Image cloneImg = new Image();
                cloneImg = sombra;
                cloneImg.Source = sombra.Source;
                cloneImg.Name = sombra.Name + n;

                tarjeta.Children.Add(cloneImg);
            }

            if (tarjeta.Children.Contains(header))
            {
                tarjeta.Children.Remove(header);

                Image cloneImgH = new Image();
                cloneImgH = header;
                cloneImgH.Source = header.Source;
                cloneImgH.Name = header.Name + n;

                tarjeta.Children.Add(cloneImgH);
            }

            if (tarjeta.Children.Contains(cuadro))
            {
                tarjeta.Children.Remove(cuadro);

                Rectangle cloneRec = new Rectangle();
                cloneRec= cuadro;
                cloneRec.Name = header.Name + n;

                tarjeta.Children.Add(cloneRec);
            }

            if (tarjeta.Children.Contains(cuadro))
            {
                tarjeta.Children.Remove(cuadro);

                Rectangle cloneRec = new Rectangle();
                cloneRec = cuadro;
                cloneRec.Name = header.Name + n;

                tarjeta.Children.Add(cloneRec);
            }

            if (tarjeta.Children.Contains(lblGerente))
            {
                tarjeta.Children.Remove(lblGerente);

                

                tarjeta.Children.Add(lblGerente);
            }

            b.Children.Add(tarjeta);

            return n;

        }



        //////////////////////////////////////////////////////////////////////

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            this.Close();
            login.ShowDialog();
        }

        private void Label_Initialized(object sender, EventArgs e)
        {
            Empresa1.Content = "CCU" + n;
        }

=======
>>>>>>> a5d65e2d3c6b74014f4ea2d31a69d9bc02b623f6
        private void fechaAct_Initialized(object sender, EventArgs e)
        {
            fechaAct.Content = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void nombreGerente_Initialized(object sender, EventArgs e)
        {
            nombreGerente.Content = "Willson Fisk";
        }

        private void nombreProf_Initialized(object sender, EventArgs e)
        {
            nombreProf.Content = "Gabriel Boric";
        }

<<<<<<< HEAD
=======
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            this.Close();
            login.ShowDialog();
        }
>>>>>>> a5d65e2d3c6b74014f4ea2d31a69d9bc02b623f6

        private void horaAct_Initialized(object sender, EventArgs e)
        {
            horaAct.Content = DateTime.Now.ToString("hh:mm tt");
        }

        private void lblActividad_Initialized(object sender, EventArgs e)
        {
            lblActividad.Content = "Visita";
        }
<<<<<<< HEAD

        private void gridTarjAct_Initialized(object sender, EventArgs e)
        {
            //CrearTarjeta(gridTarjAct, stackActHoy, n);
        }
=======
>>>>>>> a5d65e2d3c6b74014f4ea2d31a69d9bc02b623f6
    }
}

