using MyReads.Domain;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Tls;
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
    /// Lógica de interacción para Clubs.xaml
    /// </summary>
    public partial class Clubs : Window
    {
        Usuario us;
        Club club = new Club();
        List<Club> listaClubs = new List<Club>();
        public Clubs(Usuario user)
        {
            InitializeComponent();
            us = user;
            listaClubs = club.readClubsUsuario(us);
            generarClubs(listaClubs, panelClubs);
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
        private void botonBusqueda_Click(object sender, RoutedEventArgs e)
        {
            Busqueda busq = new Busqueda(us);
            busq.Show();
            this.Close();
        }
        private void botonLibreria_Click(object sender, RoutedEventArgs e)
        {
            Libreria lib = new Libreria(us);
            lib.Show();
            this.Close();
        }
        private void botonPerfil_Click(object sender, RoutedEventArgs e)
        {
            Perfil perfil = new Perfil(us,us,1);
            perfil.Show();
            this.Close();
        }

        private void botonAddClub_Click(object sender, RoutedEventArgs e)
        {
            AddClub aClub = new AddClub(us, null);
            aClub.Show();
            this.Close();
        }
        private void generarClubs(List<Club> lista, StackPanel panel)
        {
            int cont = 0;
            panel.Children.Clear();
            foreach (Club club in lista)
            {
                StackPanel panel2 = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(20, 0, 0, 0),
                };
                Color color = (cont % 2 == 0)
                    ? (Color)ColorConverter.ConvertFromString("#FFB8A36D")
                    : Colors.WhiteSmoke;
                Color color2 = (cont % 2 == 0)
                    ? Colors.White
                    : Colors.Black;
                cont++;
                string ruta = null;
                if (club.img == "grupo_perfil_defecto.png")
                { ruta = "pack://application:,,,/Images/"+club.img; }
                else
                { ruta = @club.img; }

                ImageBrush brush = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(ruta, UriKind.Absolute)),
                };

                Ellipse elipse = new Ellipse
                {
                    Height = 36,
                    Width = 36,
                    Fill = brush,
                };
                Button boton = new Button
                {
                    Content = club.nombre,
                    Margin = new Thickness(0, 0, 0, 10),
                    FontSize = 24,
                    FontStyle = FontStyles.Italic,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Height = 40,
                    FontWeight = FontWeights.Bold,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(color),
                    Foreground = new SolidColorBrush(color2),
                };
                ContextMenu contextMenu = new ContextMenu();

                MenuItem option1 = new MenuItem { Header = "Ver club " };
                MenuItem option2 = new MenuItem { Header = "Salir del club" };
                // Agregar eventos de clic a las opciones
                option1.Click += (s, e) => verClub();
                option2.Click += (s, e) => eliminarClub(club);

                // Agregar opciones al menú
                contextMenu.Items.Add(option1);
                contextMenu.Items.Add(option2);
                boton.Click += (s, e) =>
                {
                    boton.ContextMenu.IsOpen = true;
                };

                // Asignar el ContextMenu al botón
                boton.ContextMenu = contextMenu;
                panel2.Children.Add(elipse);
                panel2.Children.Add(boton);
                panel.Children.Add(panel2);
            }
        }
        private void verClub()
        {
            MessageBox.Show("No implementado");
        }
        private void eliminarClub(Club club)
        {
            List<Club> lstClubs = club.readClubsUsuario(us);
            foreach(Club c in lstClubs)
            {
                if (c.nombre == club.nombre)
                {
                    confirmarBorrarClub(c);
                }
            }
        }
        private void confirmarBorrarClub(Club c)
        {
            MessageBoxResult resultado = MessageBox.Show(
                "¿Seguro que quieres salir?",
                "Confirmación",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (resultado == MessageBoxResult.Yes)
            {
                c.deleteClubUser(us);
                MessageBox.Show("Has salido del club");
                int count = c.countUsuariosEnClub();
                if (count == 0)
                {
                    MessageBox.Show("El club del que acabas de salir está vacio. Se borrará permanentemente");
                    c.delete();
                }
                listaClubs = club.readClubsUsuario(us);
                generarClubs(listaClubs, panelClubs);
            }
        }

        private void botonHome_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home(us);
            home.Show();
            this.Close();
        }

        private void botonUsuarios_Click(object sender, RoutedEventArgs e)
        {
            Usuarios ventana = new Usuarios(us);
            ventana.Show();
            this.Close();
        }
    }
}
