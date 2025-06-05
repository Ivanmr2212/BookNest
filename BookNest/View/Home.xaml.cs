using MyReads.Domain;
using Org.BouncyCastle.Crypto.Engines;
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
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        Usuario us;
        List<Review> reviews1User;
        List<Review> reviewsAllUser = new List<Review>();
        List<Usuario> usuarios;
        Review r = new Review();
        public Home(Usuario user)
        {
            InitializeComponent();
            us = user;
            labelBienvenida.Content="Bienvenido "+us.nombre+"!";

            usuarios = generarListaAmigos(us);
            //Para añadir todas las reviews de amigos a una sola list<Reviews> para luego ordenarlas por fecha
            foreach(Usuario usuario in usuarios)
            {
                reviews1User = r.readAllFromUser(usuario);
                foreach(Review rev in reviews1User)
                {
                    reviewsAllUser.Add(rev);
                }
            }
            //Se ordena en base a la fecha
            reviewsAllUser = reviewsAllUser.OrderByDescending(x => DateTime.Parse(x.getFecha())).ToList();
            generarReviews(reviewsAllUser, panelNovedades);
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

        private void botonClubs_Click(object sender, RoutedEventArgs e)
        {
            Clubs clubs = new Clubs(us);
            clubs.Show();
            this.Close();
        }

        private void botonPerfil_Click(object sender, RoutedEventArgs e)
        {
            Perfil perfil = new Perfil(us,us,1);
            perfil.Show();
            this.Close();
        }
        private void generarReviews(List<Review> lista, StackPanel panelPadre)
        {
            foreach (Review rev in lista)
            {
                StackPanel panelPrincipal = new StackPanel { Orientation = Orientation.Vertical, Margin = new Thickness(0, 10, 0, 0) };
                Usuario u = new Usuario();
                u = u.read(rev.getIdU());
                Libro libro = new Libro();
                libro = libro.read(rev.getIdL());
                string ruta = null;
                if (u.img == "perfil_defecto.png")
                { ruta = "pack://application:,,,/Images/" + u.img; }
                else
                { ruta = @u.img; }

                ImageBrush brush = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(ruta, UriKind.Absolute)),
                };

                Ellipse elipse = new Ellipse
                {
                    Height = 36,
                    Width = 36,
                    Margin = new Thickness(0, 15, 0, 0),
                    Fill = brush
                };

                StackPanel panel2 = new StackPanel { Orientation = Orientation.Horizontal };
                Color color = (Color)ColorConverter.ConvertFromString("#FFB8A36D");
                Button boton = new Button
                {
                    Width = 110,
                    Height = 36,
                    Margin = new Thickness(0, 20, 0, 0),
                    BorderThickness = new Thickness(0),
                    Content = u.nombre,
                    Background = Brushes.Transparent,
                    FontSize = 20,
                    FontStyle = FontStyles.Italic,
                };
                ContextMenu contextMenu = new ContextMenu();
                MenuItem option1 = new MenuItem { Header = "Ver perfil" };
                MenuItem option2 = new MenuItem { Header = "Ver libro" };
                option1.Click += (s, e) => verUsuario(u);
                option2.Click += (s, e) => verLibro(libro);
                contextMenu.Items.Add(option1);
                contextMenu.Items.Add(option2);
                boton.ContextMenu = contextMenu;
                boton.Click += (s, e) =>
                {
                    boton.ContextMenu.IsOpen = true;
                };

                Label titulo = new Label {
                    FontSize = 20,
                    FontStyle = FontStyles.Italic,
                    Content=libro.titulo,
                };

                TextBlock texto = new TextBlock { TextWrapping = TextWrapping.Wrap, 
                    Text = rev.getTexto(), 
                    Width = 450, HorizontalAlignment = HorizontalAlignment.Left, FontSize=14,
                    Margin=new Thickness(20,0,0,0)};
                Label fecha = new Label
                {
                    Content = rev.getFecha().Substring(0, Math.Min(10, rev.getFecha().Length)),
                    Margin = new Thickness(0, 23, 0, 0),
                    Background = Brushes.Transparent,
                    FontSize = 16
                };

                StackPanel panelEstrellas = new StackPanel { Orientation = Orientation.Horizontal, Height = 25, Margin = new Thickness(10, 15, 0, 0) };
                generarEstrellas(rev, panelEstrellas);

                panel2.Children.Add(elipse);
                panel2.Children.Add(boton);
                panel2.Children.Add(panelEstrellas);
                panel2.Children.Add(fecha);
                panelPrincipal.Children.Add(panel2);
                panelPrincipal.Children.Add(titulo);
                panelPrincipal.Children.Add(texto);
                panelPadre.Children.Add(panelPrincipal);
            }
        }
        private void verUsuario(Usuario us2)
        {
            Perfil perfil = new Perfil(us, us2, 3);
            perfil.Show();
        }
        private void verLibro(Libro l)
        {
            LibroInfo lInfo = new LibroInfo(l,us,3);
            lInfo.Show();
        }
        private void generarEstrellas(Review rev, StackPanel panel)
        {
            int puntuacion = rev.getPuntuacion();
            string ruta = "pack://application:,,,/Images/starFull.png";

            for (int i = 0; i < puntuacion; i++)
            {
                Image imagen = new Image
                {
                    Source = new BitmapImage(new Uri(ruta, UriKind.Absolute)),
                    Width = 25,
                    Height = 25,
                };

                panel.Children.Add(imagen);
            }
        }

        private void botonUsuarios_Click(object sender, RoutedEventArgs e)
        {
            Usuarios ventana = new Usuarios(us);
            ventana.Show();
            this.Close();
        }

        private List<Usuario> generarListaAmigos(Usuario user)
        {
            List<Usuario> listaAmigosUser = new List<Usuario>();
            List<Amigo>listaAmigos = us.readAmigos(user.nombre); //Sacas una lista de amigos, compuesta de dos id
            List<Int32> idAmigos = new List<Int32>();
            foreach (Amigo am in listaAmigos)
            {
                //Compruebas cual es el id del amigo y cual el del propio usuario y lo mete a una lista
                if (am.idUser1 != user.id)
                {
                    idAmigos.Add(am.idUser1);
                }
                else
                {
                    idAmigos.Add(am.idUser2);
                }
            }
            foreach (Int32 id in idAmigos)
            {
                listaAmigosUser.Add(us.read(id));
            }
            return listaAmigosUser;
        }
    }
}
