using MyReads.Domain;
using MyReads.View;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MyReads
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Frase> frases;
        int index1=-1, index2=-1, index3=-1; // Índices de frases para cada TextBlock
        Usuario user;
        public MainWindow()
        {
            Frase frase = new Frase();
            frases = frase.readAll();
            user = new Usuario();
            index1 = indexAleatorios(0,frases.Count);
            index2 = indexAleatorios(0, frases.Count);
            index3 = indexAleatorios(0, frases.Count);
            while (index2 == index1)
            {
                index2 = indexAleatorios(0, frases.Count);
            }
            while(index3==index1 || index3 == index2)
            {
                index3 = indexAleatorios(0, frases.Count);
            }
            InitializeComponent();

            // Asignar las primeras frases correctamente
            txtFrase1.Text = frases[index1].contenido;
            txtFrase2.Text = frases[index2].contenido;
            txtFrase3.Text = frases[index3].contenido;

            // Iniciar la animación del primer texto
            Storyboard sb1 = (Storyboard)FindResource("AnimacionTexto1");
            sb1.Begin();

            // Iniciar la animación del segundo texto después de un retraso
            DispatcherTimer timer1 = new DispatcherTimer();
            timer1.Interval = TimeSpan.FromSeconds(1); // Retraso de 1 segundo
            timer1.Tick += (s, e) =>
            {
                timer1.Stop();
                Storyboard sb2 = (Storyboard)FindResource("AnimacionTexto2");
                sb2.Begin();
            };
            timer1.Start();

            // Iniciar la animación del tercer texto después de otro retraso
            DispatcherTimer timer2 = new DispatcherTimer();
            timer2.Interval = TimeSpan.FromSeconds(2); // Retraso de 2 segundos
            timer2.Tick += (s, e) =>
            {
                timer2.Stop();
                Storyboard sb3 = (Storyboard)FindResource("AnimacionTexto3");
                sb3.Begin();
            };
            timer2.Start();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show(
                "¿Seguro que quieres salir?",
                "Confirmación",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (resultado == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void BotonMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private int indexAleatorios(int min, int max)
        {
            Random rnd = new Random();
            int num = rnd.Next(min, max);
            return num;
        }

        private void checkBoxMostrar_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                txtVerPass.Text = txtPass.Password;
                txtVerPass.Visibility = Visibility.Visible;
                txtPass.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtPass.Password = txtVerPass.Text;
                txtVerPass.Visibility = Visibility.Collapsed;
                txtPass.Visibility = Visibility.Visible;
            }
        }
        private void botonIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            if (comprobarUsuario())
            {
                user = user.readByNombreYCorreo(txtCorreo.Text);
                logIn();
            }
            else
            {
                badLogIn();
            }
        }
        private void logIn()
        {
            MessageBox.Show("Sesión iniciada correctamente");
            Home home = new Home(user);
            home.Show();
            this.Close();
        }
        private void badLogIn()
        {
            MessageBox.Show("Correo o contraseña incorrecta. Inténtelo de nuevo");
            txtCorreo.Text = null;
            txtPass.Password = null;
            txtVerPass.Text = null;
        }

        private void botonRegistrar_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Close();
        }

        private bool comprobarUsuario()
        {
            bool existe = false;
            bool passCorrecta = false;

            String correo = txtCorreo.Text.ToString();
            String pass=txtPass.Password.ToString();
            String passLetras = txtVerPass.Text.ToString();
            Usuario u = new Usuario(null, null, null);
            u = u.readByNombreYCorreo(correo);
            if (u == null || u.nombre == null || u.nombre == "" || u.correo == null || u.correo== "")
            {
                existe = false;
            }
            else
            {
                existe = true;
            }

            if (existe)
            {
                if(u.pass==pass || u.pass==passLetras)
                {
                    passCorrecta = true;
                }
            }
            return passCorrecta;
        }

        private void AnimacionTexto1_Completed(object sender, EventArgs e)
        {
            index1 = (index1 + 1) % frases.Count;
            txtFrase1.Text = frases[index1].contenido;
            txtFrase1.SetValue(Canvas.TopProperty, -50.0);

            Storyboard sb1 = (Storyboard)FindResource("AnimacionTexto1");
            sb1.Begin();
        }

        private void AnimacionTexto2_Completed(object sender, EventArgs e)
        {
            index2 = (index2 + 1) % frases.Count;
            txtFrase2.Text = frases[index2].contenido;
            txtFrase2.SetValue(Canvas.TopProperty, -50.0);

            Storyboard sb2 = (Storyboard)FindResource("AnimacionTexto2");
            sb2.Begin();
        }

        private void AnimacionTexto3_Completed(object sender, EventArgs e)
        {
            index3 = (index3 + 1) % frases.Count;
            txtFrase3.Text = frases[index3].contenido;
            txtFrase3.SetValue(Canvas.TopProperty, -50.0);

            Storyboard sb3 = (Storyboard)FindResource("AnimacionTexto3");
            sb3.Begin();
        }
    }
}
