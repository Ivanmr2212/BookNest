using MyReads.Domain;
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

namespace MyReads.View
{
    /// <summary>
    /// Lógica de interacción para AddReto.xaml
    /// </summary>
    public partial class AddReto : Window
    {
        Usuario usOrig;
        Usuario usVer;
        int librosTotal;
        String fechaFin;
        public AddReto(Usuario userOriginal, Usuario userVer)
        {
            usOrig = userOriginal;
            usVer = userVer;
            InitializeComponent();
            
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void botonVolver_Click(object sender, RoutedEventArgs e)
        {
            Perfil ventana = new Perfil(usOrig,usVer,1);
            ventana.Show();
            this.Close();
        }

        private void sliderNumero_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labelTotal.Content = sliderNumero.Value;
            librosTotal = Int32.Parse(sliderNumero.Value.ToString());
        }

        private void botonAddReto_Click(object sender, RoutedEventArgs e)
        {
            if (fechaPicker.SelectedDate==null || librosTotal== 0)
            {
                MessageBox.Show("Hay que rellenar todos los campos");
            }
            else
            {
                Reto r = new Reto();
                r.setIdU(usOrig.id);
                r.setLeido(0);
                r.setTotal(librosTotal);
                int year = DateTime.Now.Year;
                int mes = DateTime.Now.Month;
                int dia = DateTime.Now.Day;
                string fechaInicio = year + "-" + mes + "-" + dia;
                DateTime? fecha = fechaPicker.SelectedDate;
                year = fecha.Value.Year;
                mes= fecha.Value.Month;
                dia= fecha.Value.Day;
                string fechaFin= year + "-" + mes + "-" + dia;
                r.setInicio(fechaInicio);
                r.setFin(fechaFin);
                r.setComp(false);

                r.insert();
                MessageBox.Show("Reto creado con éxito");
                Perfil ventana = new Perfil(usOrig, usVer, 1);
                ventana.Show();
                this.Close();
            }
        }
    }
}
