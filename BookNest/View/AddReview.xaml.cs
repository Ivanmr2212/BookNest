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
    /// Lógica de interacción para AddReview.xaml
    /// </summary>
    public partial class AddReview : Window
    {
        Usuario us;
        Libro l;
        int puntuacion=0;
        int info;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user">Usuario que ha hecho la review</param>
        /// <param name="libro">Libro del que se ha hecho la review</param>
        /// <param name="info">Numero para saber si se va a crear(1) o modificar(2) una review</param>
        public AddReview(Usuario user, Libro libro, int inf)
        {
            us = user;
            l = libro;
            info = inf;
            InitializeComponent();
            txtTitulo.Text=l.titulo;

            if (info == 2)
            {
                botonModReview.Visibility = Visibility.Visible;
                botonAddReview.Visibility = Visibility.Collapsed;
                //Para que al abrise la ventana salgan las estrellas en base a la puntuación de la review
                Review r = new Review();
                r = r.read(us.id, l.idLibro);

                txtContenido.Text = r.getTexto();

                //Esto de simulatedEvent se lo he pedido al ChatGpt
                MouseButtonEventArgs simulatedEvent = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left)
                {
                    RoutedEvent = Mouse.MouseDownEvent
                };
                switch (r.getPuntuacion())
                {
                    case 1:
                        puntuacionEstrellas(star1, simulatedEvent);
                        break;
                    case 2:
                        puntuacionEstrellas(star2, simulatedEvent);
                        break;
                    case 3:
                        puntuacionEstrellas(star3, simulatedEvent);
                        break;
                    case 4:
                        puntuacionEstrellas(star4, simulatedEvent);
                        break;
                    case 5:
                        puntuacionEstrellas(star5, simulatedEvent);
                        break;
                }
            }
            else
            {
                botonAddReview.Visibility = Visibility.Visible;
                botonModReview.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// METODO PARA MOVER LA VENTANA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void botonAddReview_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtContenido.Text) || puntuacion == 0)
            {
                MessageBox.Show("Hay que rellenar todos los campos, texto y puntuación");
            }
            else
            {
                Review r = new Review();
                r.setIdU(us.id);
                r.setIdL(l.idLibro);
                r.setTexto(txtContenido.Text);
                r.setPuntuacion(puntuacion);
                int year = DateTime.Now.Year;
                int mes = DateTime.Now.Month;
                int dia = DateTime.Now.Day;
                string fecha = year + "-" + mes + "-" + dia;
                r.setFecha(fecha);
                if (info == 1)
                {
                    r.insert();
                    MessageBox.Show("Review hecha correctamente");
                }
                else
                {
                    r.update();
                    MessageBox.Show("Review modificada correctamente");
                }
                this.Close();
            }
        }

        private void botonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void puntuacionEstrellas(object sender, RoutedEventArgs e)
        {
            // Cargar las imágenes solo una vez
            BitmapImage starEmpty = new BitmapImage(new Uri("pack://application:,,,/Images/starEmpty.png", UriKind.Absolute));
            BitmapImage starFull = new BitmapImage(new Uri("pack://application:,,,/Images/starFull.png", UriKind.Absolute));

            // Crear un array de botones para las estrellas
            Button[] estrellas = { star1, star2, star3, star4, star5 };

            // Identificar cuál estrella fue presionada
            Button boton = sender as Button;
            int indice = Array.IndexOf(estrellas, boton);

            // Actualizar todas las estrellas según la selección
            for (int i = 0; i < estrellas.Length; i++)
            {
                estrellas[i].Content = new Image
                {
                    Source = (i <= indice) ? starFull : starEmpty,
                    Width = 35,   // Ajusta el tamaño si es necesario
                    Height = 35
                };
            }
            puntuacion = int.Parse(boton.Tag.ToString());
        }
    }
}
