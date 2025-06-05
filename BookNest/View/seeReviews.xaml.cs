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
    /// Lógica de interacción para seeReviews.xaml
    /// </summary>
    public partial class seeReviews : Window
    {
        Usuario userOriginal;
        Libro l;
        Review r = new Review();
        List<Review> reviews;
        public seeReviews(Usuario user, Libro libro)
        {
            userOriginal = user;
            l = libro;
            InitializeComponent();
            reviews = r.readAllFromBook(l);
            generarReviews(reviews, panelReviews);
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
            this.Close();
        }

        private void generarReviews(List<Review> lista, StackPanel panelPadre)
        {
            foreach (Review rev in lista)
            {
                StackPanel panelPrincipal=new StackPanel { Orientation=Orientation.Vertical, Margin=new Thickness(0,10,0,0) };
                Usuario u=new Usuario();
                u = u.read(rev.getIdU());
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
                    FontSize=20,
                    FontStyle = FontStyles.Italic,
                };
                ContextMenu contextMenu = new ContextMenu();
                MenuItem option1 = new MenuItem { Header = "Ver perfil" };
                option1.Click += (s, e) => verUsuario(u);
                contextMenu.Items.Add(option1);
                boton.ContextMenu = contextMenu;
                boton.Click += (s, e) =>
                {
                    boton.ContextMenu.IsOpen = true;
                };

                TextBlock texto=new TextBlock { TextWrapping = TextWrapping.Wrap, Text=rev.getTexto() , Width=350, HorizontalAlignment=HorizontalAlignment.Left};
                Label fecha = new Label { 
                    Content = rev.getFecha().Substring(0, Math.Min(10, rev.getFecha().Length)), 
                    Margin = new Thickness(0, 23, 0, 0), 
                    Background = Brushes.Transparent,
                    FontSize = 16
                };

                StackPanel panelEstrellas=new StackPanel { Orientation = Orientation.Horizontal, Height=25, Margin=new Thickness(10,15,0,0)};
                generarEstrellas(rev, panelEstrellas);

                panel2.Children.Add(elipse);
                panel2.Children.Add(boton);
                panel2.Children.Add(panelEstrellas);
                panel2.Children.Add(fecha);
                panelPrincipal.Children.Add(panel2);
                panelPrincipal.Children.Add(texto);
                panelPadre.Children.Add(panelPrincipal);
            }
        }
        private void verUsuario(Usuario us2)
        {
            Perfil perfil = new Perfil(userOriginal, us2, 3);
            perfil.Show();
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
                    Width=25, Height=25,
                };

                panel.Children.Add(imagen);
            }
        }
    }
}
