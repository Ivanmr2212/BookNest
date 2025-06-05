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
    /// Lógica de interacción para AddClub.xaml
    /// </summary>
    public partial class AddClub : Window
    {
        Usuario us;
        Libro l;
        List<Amigo> listaAmigos = new List<Amigo>();
        List<Usuario> listaUsuarios = new List<Usuario>();
        List<Usuario> listaAmigosAdd= new List<Usuario>();
        String nombreAmigo;
        Coleccion c=new Coleccion();
        public AddClub(Usuario user, Libro libro)
        {
            us = user;
            l = libro;

            listaUsuarios = generarListaAmigos(us);

            InitializeComponent();
            if (libro != null)
            {
                txtLectura.Text = l.titulo;
            }
            generarAmigos(listaUsuarios,panelAmigos, false);
            generarAmigos(listaAmigosAdd, panelAmigosAdd, true);
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
            Clubs ventana = new Clubs(us);
            ventana.Show();
            this.Close();
        }

        private void botonAddClub_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtContenido.Text))
            {
                MessageBox.Show("Uno o mas de los campos están vacios");
            }
            else
            {
                Club club = new Club(txtNombre.Text, txtContenido.Text, us.id,l.idLibro);
                club.insert();
                club = club.readClubFull();
                club.insertUser(us);
                
                /*Usuario usAdmin = us.read(11);
                c = c.readColeccionesUserYNombre(usAdmin, "Club de lectura");
                c.setIdCreador(us.id);
                c.insert();
                c.insertUsuarioColeccion(us);*/

                foreach (Usuario usuario in listaAmigosAdd)
                {
                    //Para añadir al amigo tanto en el club como en la coleccion compartida del club
                    club.insertUser(usuario);
                    //c.insertUsuarioColeccion(usuario);
                }

                MessageBox.Show("Club creado correctamente");
                this.Close();
            }
        }
        private void generarAmigos(List<Usuario> lista, StackPanel panel, bool tipo)
        {
            int cont = 2;
            panel.Children.Clear();
            foreach (Usuario user in lista)
            {
                StackPanel panel2 = new StackPanel { Orientation = Orientation.Horizontal };
                Color color = (cont % 2 == 0)
                    ? (Color)ColorConverter.ConvertFromString("#FFB8A36D")
                    : (Color)ColorConverter.ConvertFromString("#FFD6C37D");
                cont++;
                Button boton= new Button
                {
                    Content = user.nombre,
                    Margin = new Thickness(0, 0, 0, 10),
                    FontSize = 18,
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    Width = 220,
                    Height = 45,
                    FontWeight = FontWeights.Bold,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(color),
                    Foreground = Brushes.White
                };
                Image imagen = new Image
                {
                    Source = new BitmapImage(new Uri("pack://application:,,,/Images/info.png", UriKind.Absolute)) //Aquí se pondría el atributo del libro cuyo index en la lista sea contLibros 
                };
                Button boton2 = new Button
                {
                    Height = 30,
                    Width = 37,
                    Content = imagen,
                    BorderThickness = new Thickness(0),
                    Margin = new Thickness(0, 3, 0, 7),
                    Background = Brushes.Transparent
                };
                if (tipo)
                {
                    boton.Click += (sender, e) => quitarAmigo(sender, e);
                }
                else
                {
                    boton.Click += (sender, e) => seleccionarAmigo(sender, e);
                }
                boton2.Click += (sender, e) => verUsuario(user);
                panel2.Children.Add(boton);
                panel2.Children.Add(boton2);
                panel.Children.Add(panel2);
            }
        }
        private void verUsuario(Usuario user)
        {
            Perfil perfil = new Perfil(us, user, 3);
            perfil.Show();
        }

        private void seleccionarAmigo(object sender, RoutedEventArgs e)
        {
            nombreAmigo= (sender as Button).Content.ToString();
            Usuario usuario = null;
            foreach (Usuario user in listaUsuarios)
            {
                if (user.nombre.Equals(nombreAmigo))
                {
                    listaAmigosAdd.Add(user);
                    usuario = user;
                }
            }
            listaUsuarios.Remove(usuario);
            generarAmigos(listaUsuarios, panelAmigos, false);
            generarAmigos(listaAmigosAdd, panelAmigosAdd, true);
        }
        private void quitarAmigo(object sender, RoutedEventArgs e)
        {
            nombreAmigo = (sender as Button).Content.ToString();
            Usuario usuario = null;
            foreach (Usuario user in listaAmigosAdd)
            {
                if (user.nombre.Equals(nombreAmigo))
                {
                    listaUsuarios.Insert(0,user);
                    usuario = user;
                }
            }
            listaAmigosAdd.Remove(usuario);
            generarAmigos(listaUsuarios, panelAmigos, false);
            generarAmigos(listaAmigosAdd, panelAmigosAdd, true);
        }

        private void botonElegirLectura_Click(object sender, RoutedEventArgs e)
        {
            AddLectura addLectura = new AddLectura(us,null,1,"Todos",null);
            addLectura.Show();
        }

        private List<Usuario> generarListaAmigos(Usuario user)
        {
            List<Usuario> listaAmigosUser = new List<Usuario>(); 
            listaAmigos = us.readAmigos(user.nombre); //Sacas una lista de amigos, compuesta de dos id
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
