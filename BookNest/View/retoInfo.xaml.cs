using MyReads.Domain;
using Org.BouncyCastle.Ocsp;
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
    /// Lógica de interacción para modReto.xaml
    /// </summary>
    public partial class modReto : Window
    {
        Reto r;
        Usuario us;
        public modReto(Usuario user, Reto reto)
        {
            r = reto;
            us = user;
            InitializeComponent();
            labelTotal.Content=r.leido.ToString();
            DateTime fechaFin = DateTime.Parse(r.fechaFin);
            fechaPicker.SelectedDate = fechaFin;
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
            Perfil ventana = new Perfil(us, us, 1);
            ventana.Show();
            this.Close();
        }

        private void botonModReto_Click(object sender, RoutedEventArgs e)
        {
            if (fechaPicker.SelectedDate == null)
            {
                MessageBox.Show("Hay que rellenar todos los campos");
            }
            else
            {
                DateTime? fecha = fechaPicker.SelectedDate;
                int year = fecha.Value.Year;
                int mes = fecha.Value.Month;
                int dia = fecha.Value.Day;
                r.fechaFin= year + "-" + mes + "-" + dia;
                if (r.leido >= r.total)
                {
                    r.completado = true;
                }
                r.actualizar();
                MessageBox.Show("Reto actualizado con éxito");
                Perfil ventana = new Perfil(us, us, 1);
                ventana.Show();
                this.Close();
            }
        }
        private void sliderNumero_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labelTotal.Content = sliderNumero.Value;
            r.leido = Int32.Parse(sliderNumero.Value.ToString());
        }
    }
}
