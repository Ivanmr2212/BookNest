using MyReads.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Usuarios : Window
    {
        Usuario us;
        public Usuarios(Usuario user)
        {
            us = user;
            InitializeComponent();
            List<Usuario> usuarios = us.readAllMenosUno(us);
            generarUsuarios(usuarios,panelUsuarios,false);
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

        /// <summary>
        /// METODO QUE GENERA BOTONES SIMULANDO LIBROS EN UN STACK PANEL
        /// </summary>
        /// <param name="coleccion">COLECCION DE DONDE SE SACAN LOS LIBROS DE LA BBDD</param>
        /// <param name="panelPadre">STACK PANEL DONDE GENERAR LOS LIBROS</param>
        /// <param name="filtrar">TRUE O FALSE EN BASE A SI HAY UN FILTRADO POR TEXTO</param>
       private void generarUsuarios(List<Usuario> lista,StackPanel panelPadre, bool filtrar)
        {
            if (filtrar)
            {
                lista = filtrarBusqueda(lista, txtBusqueda.Text);
            }
            
            foreach(Usuario user in lista)
            {
                string ruta = null;
                if (user.img == "perfil_defecto.png") 
                { ruta = "pack://application:,,,/Images/" + us.img; }
                else 
                { ruta = @us.img; }

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

                StackPanel panel2= new StackPanel { Orientation = Orientation.Horizontal};
                StackPanel panel3 = new StackPanel { Orientation = Orientation.Vertical };
                Button boton = new Button
                {
                    Margin=new Thickness(0,0,0,0),
                    BorderThickness = new Thickness(0),
                    Content=panel2,
                    Background = Brushes.Transparent,
                };

                Label usuario = new Label
                {
                    Margin = new Thickness(0, 15, 0, 0),
                    FontStyle = FontStyles.Italic ,
                    FontWeight = FontWeights.Bold ,
                    FontSize = 16,
                    Content=user.nombre,
                };
                List<Usuario> listAmigos = generarListaAmigos(user);
                Label amigos = new Label
                {
                    FontStyle = FontStyles.Italic,
                    FontSize = 12,
                    Content="Amigos: "+listAmigos.Count,
                };
                panel3.Children.Add(usuario);
                panel3.Children.Add(amigos);
                boton.Click += (s, e) => verUsuario(user);
                panel2.Children.Add(elipse);
                panel2.Children.Add(panel3);
                panelPadre.Children.Add(boton);
            }
        }
        private List<Usuario> generarListaAmigos(Usuario user)
        {
            List<Usuario> listaAmigosUser = new List<Usuario>();
            List<Amigo> listaAmigos = user.readAmigos(user.nombre); //Sacas una lista de amigos, compuesta de dos id
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
                listaAmigosUser.Add(user.read(id));
            }
            return listaAmigosUser;
        }
        private void verUsuario(Usuario us2)
        {
            Perfil perfil = new Perfil(us, us2,3);
            perfil.Show();
        }
        private void seleccionarLibro(Coleccion coleccion, Libro libro)
        {
            AddClub aClub = new AddClub(us, libro);
            //aClub.txtNombre.Text = nombre;
            //aClub.txtContenido.Text = contenido;
            aClub.Show();
            this.Close();
        }

        /// <summary>
        /// METODO QUE TE LLEVA A UNA VENTANA PARA VER TODA LA INFORMACIÓN DEL LIBRO
        /// </summary>
        /// <param name="us">USUARIO QUE SE ESTÁ USANDO</param>
        /// <param name="l">LIBRO A VER</param>
        private void verLibro(Usuario us, Libro l)
        {
            LibroInfo ventana = new LibroInfo(l, us, 3);
            ventana.Show();
        }

        /// <summary>
        /// METODO QUE FILTRA LIBROS EN BASE A SI EL TITULO TIENE UN STRING
        /// </summary>
        /// <param name="lista">LISTA DE LA QUE SE FILTRA</param>
        /// <param name="busqueda">EN BASE A QUE SE FILTRA</param>
        /// <returns></returns>
        private List<Usuario> filtrarBusqueda(List<Usuario> lista, String busqueda)
        {
            List<Usuario> listaFinal = new List<Usuario>();
            foreach (Usuario u in lista)
            {
                String nombreMayus = u.nombre.ToUpper();
                String nombreMinus = u.nombre.ToLower();
                if (nombreMayus.Contains(busqueda.ToUpper()) || nombreMinus.Contains(busqueda.ToLower()))
                {
                    listaFinal.Add(u);
                }
            }
            return listaFinal;
        }

        private void botonVolver_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home(us);
            home.Show();
            this.Close();
        }
        private void botonBusqueda_Click(object sender, RoutedEventArgs e)
        {
            panelUsuarios.Children.Clear();
        }
    }
}
