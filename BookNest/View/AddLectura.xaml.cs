using MyReads.Domain;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyReads.View
{
    /// <summary>
    /// Lógica de interacción para AddLectura.xaml
    /// </summary>
    public partial class AddLectura : Window
    {
        Usuario us;
        Usuario us2;
        Libro libro = new Libro();
        Coleccion colec=new Coleccion();
        int tipo;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user">Usuario que ha iniciado sesión</param>
        /// <param name="l">Libro que posteriormente servirá como lectura incial de un club de lectura, puede ser null</param>
        /// <param name="tip">Perfil=3, AddClub=1, 2 no se cuando es</param>
        /// <param name="nombreColeccion">Nombre de la colección en la que se va a buscar</param>
        /// <param name="user2">Usuario del que se abre la coleccion(puede ser el usuario que ha iniciado sesión)</param>
        public AddLectura(Usuario user, Libro l, int tip, String nombreColeccion, Usuario user2)
        {
            tipo = tip;
            us = user;
            us2 = user2;


            InitializeComponent();
            if (tipo == 1)
            {
                colec = colec.readColeccionesUserYNombre(us, "Todos");
            }
            else if (tipo == 2 || tipo==3)
            {
                if (user2 != null)
                {
                    colec = colec.readColeccionesUserYNombre(us2, nombreColeccion);
                }
                else
                {
                    colec = colec.readColeccionesUserYNombre(us, nombreColeccion);
                }
                labelTitulo.Content = "COLECCIÓN "+nombreColeccion.ToUpper();
                labelTitulo.Margin = new Thickness(0,0,-5,5);
            }

            if (colec == null)
            {
                MessageBox.Show("Colección vacia");
                panelLibros.Children.Clear();
            }
            else
            {
                generarLibrosColeccion(colec, panelLibros, false);
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

        /// <summary>
        /// METODO QUE GENERA BOTONES SIMULANDO LIBROS EN UN STACK PANEL
        /// </summary>
        /// <param name="coleccion">COLECCION DE DONDE SE SACAN LOS LIBROS DE LA BBDD</param>
        /// <param name="panelPadre">STACK PANEL DONDE GENERAR LOS LIBROS</param>
        /// <param name="filtrar">TRUE O FALSE EN BASE A SI HAY UN FILTRADO POR TEXTO</param>
        private void generarLibrosColeccion(Coleccion coleccion, StackPanel panelPadre, bool filtrar)
        {
            List<Libro> libros = libro.leerLibrosColeccion(coleccion);
            if (filtrar)
            {
                libros = filtrarBusqueda(libros, txtBusqueda.Text);
            }
            double numFilas = (double)libros.Count / 4;
            numFilas = Math.Ceiling(numFilas);

            int filasFinales = (int)numFilas; //Numero de filas del stackPanel
            int librosFila = 3; //Numero de libros x fila
            int contLibros = 0;
            int contLibrosTotal = 0;
            int contFilas = 0; //Contador de las filas que se han creado
            while (contLibros < libros.Count)
            {
                StackPanel panelHijo = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                };
                for (int i = 0; i < librosFila; i++)
                {
                    if (contLibros >= libros.Count)
                    {
                        break;
                    }
                    Libro libro2 = libros[contLibrosTotal];
                    string ruta = "pack://application:,,,/Images/portadas/" + libro2.img;
                    Button boton = new Button
                    {
                        Width = 110,
                        Height = 156,
                        BorderThickness = new Thickness(0)
                    };

                    Image imagen = new Image
                    {
                        Source = new BitmapImage(new Uri(ruta, UriKind.Absolute)) //Aquí se pondría el atributo del libro cuyo index en la lista sea contLibros 
                    };

                    boton.Content = imagen;

                    ContextMenu contextMenu = new ContextMenu();

                    int num = contLibrosTotal;
                    Libro libroElegido = libros[num];
                    MenuItem option2 = new MenuItem { Header = "Ver libro " };
                    if (tipo == 1)
                    {
                        MenuItem option1 = new MenuItem { Header = "Seleccionar para lectura" };
                        option1.Click += (s, e) => seleccionarLibro(coleccion, libroElegido);
                        contextMenu.Items.Add(option1);
                    }
                    // Agregar eventos de clic a las opciones
                    option2.Click += (s, e) => verLibro(us, libroElegido);

                    // Agregar opciones al menú
                    contextMenu.Items.Add(option2);

                    // Asignar el ContextMenu al botón
                    boton.ContextMenu = contextMenu;
                    boton.Click += (s, e) =>
                    {
                        boton.ContextMenu.IsOpen = true;
                    };

                    TextBlock labelTitulo = new TextBlock
                    {
                        Width = 110,
                        Text = libros[contLibros].titulo,
                        TextWrapping = TextWrapping.Wrap,
                        TextAlignment = TextAlignment.Center
                    };
                    StackPanel panelHijo2 = new StackPanel
                    {
                        Orientation = Orientation.Vertical,
                        Margin = new Thickness(17, 10, 17, 10)
                    };
                    panelHijo2.Children.Add(boton);
                    panelHijo2.Children.Add(labelTitulo);
                    contLibros++;
                    contLibrosTotal++;
                    panelHijo.Children.Add(panelHijo2);
                }
                panelPadre.Children.Add(panelHijo);
                contFilas++;
            }
        }
        private void seleccionarLibro(Coleccion coleccion, Libro libro)
        {
            AddClub aClub = new AddClub(us, libro);
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
            seeReviews see = new seeReviews(us, l);
            ventana.Show();
            see.Show();
        }

        /// <summary>
        /// METODO QUE FILTRA LIBROS EN BASE A SI EL TITULO TIENE UN STRING
        /// </summary>
        /// <param name="lista">LISTA DE LA QUE SE FILTRA</param>
        /// <param name="busqueda">EN BASE A QUE SE FILTRA</param>
        /// <returns></returns>
        private List<Libro> filtrarBusqueda(List<Libro> lista, String busqueda)
        {
            List<Libro> listaFinal = new List<Libro>();
            foreach (Libro l in lista)
            {
                String tituloMayus = l.titulo.ToUpper();
                String tituloMinus = l.titulo.ToLower();
                if (tituloMayus.Contains(busqueda.ToUpper()) || tituloMinus.Contains(busqueda.ToLower()))
                {
                    listaFinal.Add(l);
                }
            }
            return listaFinal;
        }

        private void botonVolver_Click(object sender, RoutedEventArgs e)
        {
            if (tipo == 1 || tipo==3)
            {
                this.Close();
            }
            else if(tipo==2)
            {
                if (us2 != null)
                {
                    Perfil perfil = new Perfil(us, us2,1);
                    perfil.Show();
                }
                else
                {
                    Perfil perfil = new Perfil(us, us,1);
                    perfil.Show();
                }
                this.Close();
            }
        }
        private void botonBusqueda_Click(object sender, RoutedEventArgs e)
        {
            panelLibros.Children.Clear();
            generarLibrosColeccion(colec, panelLibros, true);
        }
    }
}
