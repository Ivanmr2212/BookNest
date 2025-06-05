using Microsoft.Win32;
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
    /// Lógica de interacción para Perfil.xaml
    /// </summary>
    public partial class Perfil : Window
    {
        Usuario us;
        Usuario us2;
        int tipo;
        Libro l=new Libro();
        Coleccion c=new Coleccion();
        List<Amigo> listAmigos=new List<Amigo>();
        List<Reto> listRetos=new List<Reto>();
        Reto r = new Reto();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userOriginal">Usuario que ha iniciado sesión</param>
        /// <param name="userVer">Usuario del que se va a ver el perfil (puede ser el que ha iniciado sesión)</param>
        /// <param name="tip">Integer de info. 3=Cuando un user está en el perfil de otro user (añadir a amigo), 1 y 2=Cuando se está en tu propio perfil</param>
        public Perfil(Usuario userOriginal, Usuario userVer, int tip)
        {
            tipo = tip;
            us = userOriginal;
            us2 = userVer;
            listRetos = r.readAllUser(us);
            InitializeComponent();
            if (tipo == 3)
            {
                botonAddAmigo.Visibility = Visibility.Visible;
            }
            if (tipo == 1)
            {
                panelRetosPadre.Visibility = Visibility.Visible;
                generarRetos(listRetos,panelRetos);
            }
            labelNombre.Text = us2.nombre;

            generarColecciones(us2,panelColecciones);

            string ruta = null;
            if (us2.img == "perfil_defecto.png")
            { ruta = "pack://application:,,,/Images/" + us2.img; }
            else
            { ruta = @us2.img; }
            foto_perfil.Source = new BitmapImage(new Uri(ruta, UriKind.Absolute));

            c = c.readColeccionesUserYNombre(us2, "Leido");
            List<Libro> list = l.leerLibrosColeccion(c);
            labelLibrosLeidos.Content=list.Count;

            List<Usuario> amigos = generarListaAmigos(us2);
            generarAmigos(amigos,panelAmigos);
            labelAmigos.Content=amigos.Count;


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
            if (us == us2)
            {
                Home home = new Home(us);
                home.Show();
                this.Close();
            }
            else
            {
                if (tipo == 3)
                {
                    this.Close();
                }
                else if (tipo == 2)
                {
                    Perfil perfil = new Perfil(us, us,1);
                    perfil.Show();
                    this.Close();
                }
                else
                {
                    Usuarios users = new Usuarios(us);
                    users.Show();
                    this.Close();
                }
            }
        }

        private List<Usuario> generarListaAmigos(Usuario user)
        {
            List<Usuario> listaAmigosUser = new List<Usuario>();
            List<Amigo> listaAmigos = us2.readAmigos(user.nombre); //Sacas una lista de amigos, compuesta de dos id
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
                listaAmigosUser.Add(us2.read(id));
            }
            return listaAmigosUser;
        }

        private void botonFotoPerfil_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Cambiar foto de perfil:";
            openFileDialog.Filter = "Todos los archivos (*.*)|*.*"; // Puedes personalizar filtros

            if (openFileDialog.ShowDialog() == true)
            {
                string rutaArchivo = openFileDialog.FileName;
                // Aquí tienes la ruta completa del archivo seleccionado
                MessageBox.Show("Seleccionaste: " + rutaArchivo);
                us2.img = rutaArchivo;
                us2.updateImg();
                foto_perfil.Source = new BitmapImage(new Uri(rutaArchivo, UriKind.Absolute));
            }
        }

        private void generarColecciones(Usuario user, StackPanel panel)
        {            
            List<Coleccion> colecciones = c.readColeccionesUser(user);
            foreach(Coleccion colec in colecciones)
            {
                String nombreColec = colec.nombre;
                StackPanel panel2 = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Height = 60
                };
                StackPanel panel3 = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                };

                List<Libro> libros = l.leerLibrosColeccion(colec);
                libros.Reverse();
                if (libros.Count >= 3)
                {
                    Libro libro1 = libros[0];
                    Image img1= generarPortada(libro1);
                    panel2.Children.Add(img1);

                    Libro libro2 = libros[1];
                    Image img2 = generarPortada(libro2);
                    img2.Margin=new Thickness(0,0,10,0);
                    panel2.Children.Add(img2);

                    Libro libro3 = libros[2];
                    Image img3 = generarPortada(libro3);
                    panel2.Children.Add(img3);
                    img2.Margin = new Thickness(0, 0, 20, 0);
                }
                else if (libros.Count == 2)
                {
                    Libro libro1 = libros[0];
                    Image img1 = generarPortada(libro1);
                    panel2.Children.Add(img1);

                    Libro libro2 = libros[1];
                    Image img2 = generarPortada(libro2);
                    panel2.Children.Add(img2);
                    img2.Margin = new Thickness(0, 0, 10, 0);
                }
                else if (libros.Count == 1)
                {
                    Libro libro1 = libros[0];
                    Image img1 = generarPortada(libro1);
                    panel2.Children.Add(img1);
                }
                Label lbl = new Label
                {
                    Content = nombreColec
                };
                panel3.Children.Add(panel2);
                panel3.Children.Add(lbl);
                Button boton = new Button
                {
                    Content = panel3,
                    Margin = new Thickness(10, 0, 0, 0),
                    Height = 80,
                    Width = 80,
                    BorderThickness = new Thickness(0),
                    Background = Brushes.Transparent
                };
                boton.Click += (sender, e) => verColeccion(sender, e,nombreColec, us2);
                panel.Children.Add(boton);
            }
        }
        private Image generarPortada(Libro libro)
        {
            string ruta1 = "pack://application:,,,/Images/portadas/" + libro.img;
            Image img1 = new Image { 
                Source = new BitmapImage(new Uri(ruta1, UriKind.Absolute)), Width = 38, Height = 60 };
            return img1;
        }
        private void verColeccion(object sender, RoutedEventArgs e, String nombreColeccion, Usuario user)
        {
            AddLectura aLec = new AddLectura(us,null,3,nombreColeccion, user);
            aLec.Show();
        }

        private void generarAmigos(List<Usuario> usuarios, StackPanel panel)
        {
            panel.Children.Clear();
            foreach(Usuario u in usuarios)
            {
                StackPanel panel2 = new StackPanel
                {
                    Orientation = Orientation.Vertical, Height=60, Margin= new Thickness(10,0,0,0),
                };
                string ruta = null;
                if (u.img == "perfil_defecto.png")
                { ruta = "pack://application:,,,/Images/" + u.img; }
                else
                { ruta = @u.img; }
                Image brush = new Image
                {
                    Source = new BitmapImage(new Uri(ruta, UriKind.Absolute)), 
                };
                Button boton = new Button
                {
                    Content= brush,
                    Height = 40,
                    Width = 40,
                    BorderThickness=new Thickness(0),
                    Background=Brushes.Transparent
                };
                Label lbl = new Label
                {
                    Content = u.nombre
                };

                ContextMenu contextMenu = new ContextMenu();

                MenuItem option1 = new MenuItem { Header = "Ver Usuario " };
                // Agregar eventos de clic a las opciones
                option1.Click += (s, e) => verUsuario(u);

                // Agregar opciones al menú
                contextMenu.Items.Add(option1);
                if (tipo == 1)
                {
                    MenuItem option2 = new MenuItem { Header = "Eliminar Usuario de Amigos" };
                    option2.Click += (s, e) => eliminarAmigo(u);
                    contextMenu.Items.Add(option2);
                }

                // Asignar el ContextMenu al botón
                boton.ContextMenu = contextMenu;
                boton.Click += (s, e) =>
                {
                    boton.ContextMenu.IsOpen = true;
                };
                panel2.Children.Add(boton);
                panel2.Children.Add(lbl);
                panel.Children.Add(panel2);
            }
        }
        private void verUsuario(Usuario us2)
        {
            if (tipo == 3)
            {
                Perfil perfil = new Perfil(us, us2, 3);
                perfil.Show();
            }
            else
            {
                Perfil perfil = new Perfil(us, us2, 2);
                perfil.Show();
                this.Close();
            }
        }
        private void eliminarAmigo(Usuario usuario)
        {
            Amigo amigo = new Amigo(us.id, usuario.id);
            us.deleteAmigo(amigo);
            MessageBox.Show("Amigo eliminado correctamente");

            List<Usuario> amigos = generarListaAmigos(us2);
            generarAmigos(amigos, panelAmigos);
            labelAmigos.Content = amigos.Count;
        }

        private void botonAddAmigo_Click(object sender, RoutedEventArgs e)
        {
            bool insertable = true;
            Amigo am = new Amigo(us.id, us2.id);
            List<Amigo> amigos = us.readAllAmigos();
            foreach(Amigo amigo in amigos)
            {
                if((amigo.idUser1==us.id && amigo.idUser2 == us2.id) || (amigo.idUser1 == us2.id && amigo.idUser2 == us.id))
                {
                    MessageBox.Show("El usuario ya estaba agregado previamente");
                    insertable = false;
                }
                if (us.id == us2.id)
                {
                    MessageBox.Show("No te puedes agregar a tí mismo");
                    insertable = false;
                }
            }
            if (insertable)
            {
                us.insertAmigo(am);
                MessageBox.Show("Usuario agregado correctamente a amigos");
            }
            this.Close();
        }

        private void generarRetos(List<Reto> lista, StackPanel panelPadre)
        {
            panelPadre.Children.Clear();
            foreach (Reto reto in lista)
            {
                Brush brush;
                if (reto.completado)
                {
                    brush = Brushes.Green;
                }
                else {
                    brush = Brushes.Red;
                }
                StackPanel panel = new StackPanel { Orientation = Orientation.Vertical, Background=brush};
                Label labelLeidos = new Label
                {
                    FontSize = 12,
                    FontWeight = FontWeights.Bold,
                    BorderThickness = new Thickness(0),
                    Margin = new Thickness(0, 0, 0, 10),
                    Content = reto.leido + "/" + reto.total
                };
                Label fecha = new Label
                {
                    Content = reto.fechaFin.Substring(0, Math.Min(10, reto.fechaFin.Length)),
                    Margin = new Thickness(0,0, 0, 0),
                    Background = Brushes.Transparent,
                    FontSize = 12
                };
                Button boton = new Button
                {
                    Content = panel,
                    Background = Brushes.Transparent,
                    BorderThickness = new Thickness(0),
                };
                ContextMenu contextMenu = new ContextMenu();

                MenuItem option1 = new MenuItem { Header = "Ver Reto" };
                MenuItem option2 = new MenuItem { Header = "Eliminar Reto" };
                // Agregar eventos de clic a las opciones
                option1.Click += (s, e) => verReto(reto);
                option2.Click += (s, e) => eliminarReto(reto);

                // Agregar opciones al menú
                contextMenu.Items.Add(option1);
                contextMenu.Items.Add(option2);

                // Asignar el ContextMenu al botón
                boton.ContextMenu = contextMenu;
                boton.Click += (s, e) =>
                {
                    boton.ContextMenu.IsOpen = true;
                };
                panel.Children.Add(fecha);
                panel.Children.Add(labelLeidos);
                panelPadre.Children.Add(boton);
            }
        }
        private void verReto(Reto reto)
        {
            modReto ventana = new modReto(us,reto);
            ventana.Show();
            this.Close();
        }

        private void eliminarReto(Reto reto)
        {
            reto.delete();
            listRetos = r.readAllUser(us);
            generarRetos(listRetos, panelRetos);
        }
        private void botonAddReto_Click(object sender, RoutedEventArgs e)
        {
            bool crear = true;
            foreach(Reto reto in listRetos)
            {
                if (!reto.completado)
                {
                    crear = false;
                }
            }

            if (listRetos.Count == 0 || crear)
            {
                AddReto ventana = new AddReto(us, us2);
                ventana.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Solo un reto a la vez. Termina o borra el que ya está hecho para hacer otro.");
            }
        }
    }
}
